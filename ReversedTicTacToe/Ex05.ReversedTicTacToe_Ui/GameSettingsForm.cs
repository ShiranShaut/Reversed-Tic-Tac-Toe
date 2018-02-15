using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.ReversedTicTacToe_Ui
{
    partial class GameSettingsForm : Form
    {
        private bool m_Player2IsPlay = false;
        private string m_Player1Name = string.Empty;
        private string m_Player2Name = "Computer";
        private int m_numOfRows = 4;
        private int m_numOfCols = 4;

        public GameSettingsForm()
        {
            InitializeComponent();
            player2TextBox.Enabled = false;
            player2TextBox.Text = "[computer]";
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
        }

        public int NumOfRows
        {
            get { return m_numOfRows; }
        }

        public int NumOfCols
        {
            get { return m_numOfCols; }
        }

        public bool Player2IsPlay
        {
            get { return m_Player2IsPlay; }
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
        private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(player2CheckBox.Checked)
            {
                m_Player2IsPlay = true;
                player2TextBox.Text = string.Empty;
                player2TextBox.Enabled = true;
            }
            else
            {
                m_Player2IsPlay = false;
                player2TextBox.Text = "[computer]";
                player2TextBox.Enabled = false;
            }
        }

        private void rowsNumeric_ValueChanged(object sender, EventArgs e)
        {
            colsNumeric.Value = rowsNumeric.Value;
        }

        private void colsNumeric_ValueChanged(object sender, EventArgs e)
        {
            rowsNumeric.Value = colsNumeric.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (player1TextBox.Text != string.Empty && player2TextBox.Text != string.Empty)
            {
                m_numOfRows = (int)rowsNumeric.Value;
                m_numOfCols = m_numOfRows;
                m_Player2IsPlay = player2CheckBox.Checked;
                m_Player1Name = player1TextBox.Text;
                if (m_Player2IsPlay)
                {
                    m_Player2Name = player2TextBox.Text;
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (player1TextBox.Text == string.Empty)
                {
                    MessageBox.Show("Enter player 1 name.", "Error");
                }
                else
                {
                    MessageBox.Show("Enter player 2 name.", "Error");
                }
            }
        }
    }
}
