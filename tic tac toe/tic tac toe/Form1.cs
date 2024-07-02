using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[6, 6];
        private char currentPlayer = 'X';
        private const int size = 6;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Location = new Point(i * 50, j * 50),
                        Size = new Size(50, 50),
                        Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold),
                    };
                    buttons[i, j].Click += Button_Click;
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Text == "")
            {
                clickedButton.Text = currentPlayer.ToString();
                if (CheckWin())
                {
                    MessageBox.Show($"Player {currentPlayer} wins!");
                    ResetBoard();
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!");
                    ResetBoard();
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }
        private bool CheckWin()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 3; j++)
                {
                    if (buttons[i, j].Text == currentPlayer.ToString() &&
                        buttons[i, j + 1].Text == currentPlayer.ToString() &&
                        buttons[i, j + 2].Text == currentPlayer.ToString() &&
                        buttons[i, j + 3].Text == currentPlayer.ToString())
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < size - 3; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (buttons[i, j].Text == currentPlayer.ToString() &&
                        buttons[i + 1, j].Text == currentPlayer.ToString() &&
                        buttons[i + 2, j].Text == currentPlayer.ToString() &&
                        buttons[i + 3, j].Text == currentPlayer.ToString())
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < size - 3; i++)
            {
                for (int j = 0; j < size - 3; j++)
                {
                    if (buttons[i, j].Text == currentPlayer.ToString() &&
                        buttons[i + 1, j + 1].Text == currentPlayer.ToString() &&
                        buttons[i + 2, j + 2].Text == currentPlayer.ToString() &&
                        buttons[i + 3, j + 3].Text == currentPlayer.ToString())
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < size - 3; i++)
            {
                for (int j = 3; j < size; j++)
                {
                    if (buttons[i, j].Text == currentPlayer.ToString() &&
                        buttons[i + 1, j - 1].Text == currentPlayer.ToString() &&
                        buttons[i + 2, j - 2].Text == currentPlayer.ToString() &&
                        buttons[i + 3, j - 3].Text == currentPlayer.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsBoardFull()
        {
            foreach (var button in buttons)
            {
                if (button.Text == "")
                {
                    return false;
                }
            }
            return true;
        }
        private void ResetBoard()
        {
            foreach (var button in buttons)
            {
                button.Text = "";
            }
            currentPlayer = 'X';
        }
    }
}
