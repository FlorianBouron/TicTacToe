using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; //true = Player X turn; false = Player O turn
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Florian Bouron\n\nFollow me on GitHub:\nhttps://github.com/FlorianBouron/", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            if (turn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }

            turn = !turn;
            button.Enabled = false;
            turnCount++;

            checkWinner();

        }

        private void checkWinner()
        {
            bool winner = false;

            //Rows checking
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winner = true;
            }

            //Columns checking
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winner = true;
            }

            //Diagonal checking
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                winner = true;
            }

            if (winner)
            {
                disableAllButtons();

                String winnerName = "";
                if(turn)
                {
                    winnerName = "Player O";
                }
                else
                {
                    winnerName = "Player X";
                }

                MessageBox.Show(winnerName + " wins!", "End of the game");
            }
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("No winner!", "End of the game");
                }
            }

        }

        private void disableAllButtons()
        {
            try
            {
                foreach (Control control in Controls)
                {
                    Button button = (Button)control;
                    button.Enabled = false;
                }
            }
            catch { }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            try
            {
                foreach (Control control in Controls)
                {
                    Button button = (Button)control;
                    button.Enabled = true;
                    button.Text = "";
                }
            }
            catch { }
        }

    }
}
