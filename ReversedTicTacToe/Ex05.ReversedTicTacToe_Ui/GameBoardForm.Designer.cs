namespace Ex05.ReversedTicTacToe_Ui
{
    public partial class GameBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoardForm));
            this.m_Player1ScoreLabel = new System.Windows.Forms.Label();
            this.m_Player2ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Player1ScoreLabel
            // 
            this.m_Player1ScoreLabel.AutoSize = true;
            this.m_Player1ScoreLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Player1ScoreLabel.Location = new System.Drawing.Point(88, 236);
            this.m_Player1ScoreLabel.Name = "m_Player1ScoreLabel";
            this.m_Player1ScoreLabel.Size = new System.Drawing.Size(70, 23);
            this.m_Player1ScoreLabel.TabIndex = 1;
            this.m_Player1ScoreLabel.Text = "Score 1:";
            // 
            // m_Player2ScoreLabel
            // 
            this.m_Player2ScoreLabel.AutoSize = true;
            this.m_Player2ScoreLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.m_Player2ScoreLabel.Location = new System.Drawing.Point(153, 236);
            this.m_Player2ScoreLabel.Name = "m_Player2ScoreLabel";
            this.m_Player2ScoreLabel.Size = new System.Drawing.Size(73, 23);
            this.m_Player2ScoreLabel.TabIndex = 2;
            this.m_Player2ScoreLabel.Text = "Score 2:";
            this.m_Player2ScoreLabel.UseMnemonic = false;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 283);
            this.Controls.Add(this.m_Player2ScoreLabel);
            this.Controls.Add(this.m_Player1ScoreLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reversed Tic Tac Teo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameBoardForm_FormClosed);
            this.Load += new System.EventHandler(this.gameBoardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label m_Player1ScoreLabel;
        private System.Windows.Forms.Label m_Player2ScoreLabel;
    }
}