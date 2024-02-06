using System;
using System.Windows;
using System.Windows.Controls;

namespace KrestikiNoliki
{
    public partial class MainWindow : Window
    {
        private bool isGameOver;
        private Random random;
        private string playerSymbol;
        private string randomSymbol;

        private int round = 0;

        public MainWindow()
        {
            InitializeComponent();
            ResetGame();
        }

        private void ResetGame()
        {
            round++;

            isGameOver = false;
            random = new Random();

            but_1.Content = "";
            but_2.Content = "";
            but_3.Content = "";
            but_4.Content = "";
            but_5.Content = "";
            but_6.Content = "";
            but_7.Content = "";
            but_8.Content = "";
            but_9.Content = "";

            if (round % 2 == 1)
            {
                playerSymbol = "X";
                randomSymbol = "0";
            }
            else
            {
                playerSymbol = "0";
                randomSymbol = "X";
            }

            EnableButtons();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isGameOver)
                return;

            Button button = (Button)sender;
            if (button.Content.ToString() == "")
            {
                button.Content = playerSymbol;
                button.IsEnabled = false;
                CheckForWin();
                RandomMove();
                CheckForWin();
            }
        }

        private void RandomMove()
        {
            if (isGameOver)
                return;

            Button[] buttons = { but_1, but_2, but_3, but_4, but_5, but_6, but_7, but_8, but_9 };
            int[] availableMoves = ExistMoves();

            if (availableMoves.Length > 0)
            {
                int randomIndex = random.Next(availableMoves.Length);
                int move = availableMoves[randomIndex];

                buttons[move - 1].Content = randomSymbol;
                buttons[move - 1].IsEnabled = false;
            }
        }

        private int[] ExistMoves()
        {
            Button[] buttons = { but_1, but_2, but_3, but_4, but_5, but_6, but_7, but_8, but_9 };
            int[] ExMoves = new int[9];
            int index = 0;

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Content.ToString() == "")
                    ExMoves[index++] = i + 1;
            }

            Array.Resize(ref ExMoves, index);
            return ExMoves;
        }

        private void CheckForWin()
        {
            Button[] buttons = { but_1, but_2, but_3, but_4, but_5, but_6, but_7, but_8, but_9 };

            for (int i = 0; i < 9; i += 3)
            {
                if (buttons[i].Content.ToString() != "" && buttons[i].Content == buttons[i + 1].Content && buttons[i + 1].Content == buttons[i + 2].Content)
                {
                    DetermineWinner(buttons[i].Content.ToString());
                    return;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (buttons[i].Content.ToString() != "" && buttons[i].Content == buttons[i + 3].Content && buttons[i + 3].Content == buttons[i + 6].Content)
                {
                    DetermineWinner(buttons[i].Content.ToString());
                    return;
                }
            }

            if (buttons[0].Content.ToString() != "" && buttons[0].Content == buttons[4].Content && buttons[4].Content == buttons[8].Content)
            {
                DetermineWinner(buttons[0].Content.ToString());
                return;
            }

            if (buttons[2].Content.ToString() != "" && buttons[2].Content == buttons[4].Content && buttons[4].Content == buttons[6].Content)
            {
                DetermineWinner(buttons[2].Content.ToString());
            }

            if (ExistMoves().Length == 0)
            {
                Draw();
                return;
            }
        }

        private void DetermineWinner(string player)
        {
            MessageBox.Show("Победитель - " + player);
            isGameOver = true;
            DisableButtons();
            ResetGame();
        }

        private void Draw()
        {
            MessageBox.Show("Ничья");
            isGameOver = true;
            DisableButtons();
            ResetGame();
        }

        private void EnableButtons()
        {
            Button[] buttons = { but_1, but_2, but_3, but_4, but_5, but_6, but_7, but_8, but_9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
            }
        }

        private void DisableButtons()
        {
            Button[] buttons = { but_1, but_2, but_3, but_4, but_5, but_6, but_7, but_8, but_9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }

        private void btn_NewGame_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
    }
}
