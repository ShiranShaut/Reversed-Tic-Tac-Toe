namespace Ex05.ReversedTicTacToe_Ui
{
    internal partial class GameSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettingsForm));
            this.playersLable = new System.Windows.Forms.Label();
            this.player1Lable = new System.Windows.Forms.Label();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.player2Lable = new System.Windows.Forms.Label();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.player2CheckBox = new System.Windows.Forms.CheckBox();
            this.boardSizeLable = new System.Windows.Forms.Label();
            this.rowsLable = new System.Windows.Forms.Label();
            this.colsLable = new System.Windows.Forms.Label();
            this.rowsNumeric = new System.Windows.Forms.NumericUpDown();
            this.colsNumeric = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // playersLable
            // 
            this.playersLable.AutoSize = true;
            this.playersLable.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersLable.Location = new System.Drawing.Point(12, 9);
            this.playersLable.Name = "playersLable";
            this.playersLable.Size = new System.Drawing.Size(99, 37);
            this.playersLable.TabIndex = 7;
            this.playersLable.Text = "Players:";
            // 
            // player1Lable
            // 
            this.player1Lable.AutoSize = true;
            this.player1Lable.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Lable.Location = new System.Drawing.Point(30, 61);
            this.player1Lable.Name = "player1Lable";
            this.player1Lable.Size = new System.Drawing.Size(79, 28);
            this.player1Lable.TabIndex = 1;
            this.player1Lable.Text = "Player1:";
            // 
            // player1TextBox
            // 
            this.player1TextBox.Location = new System.Drawing.Point(115, 67);
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(166, 20);
            this.player1TextBox.TabIndex = 0;
            // 
            // player2Lable
            // 
            this.player2Lable.AutoSize = true;
            this.player2Lable.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Lable.Location = new System.Drawing.Point(30, 104);
            this.player2Lable.Name = "player2Lable";
            this.player2Lable.Size = new System.Drawing.Size(79, 28);
            this.player2Lable.TabIndex = 3;
            this.player2Lable.Text = "Player2:";
            // 
            // player2TextBox
            // 
            this.player2TextBox.Location = new System.Drawing.Point(115, 110);
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(166, 20);
            this.player2TextBox.TabIndex = 2;
            // 
            // player2CheckBox
            // 
            this.player2CheckBox.AutoSize = true;
            this.player2CheckBox.Location = new System.Drawing.Point(15, 112);
            this.player2CheckBox.Name = "player2CheckBox";
            this.player2CheckBox.Size = new System.Drawing.Size(15, 14);
            this.player2CheckBox.TabIndex = 1;
            this.player2CheckBox.UseVisualStyleBackColor = true;
            this.player2CheckBox.CheckedChanged += new System.EventHandler(this.player2CheckBox_CheckedChanged);
            // 
            // boardSizeLable
            // 
            this.boardSizeLable.AutoSize = true;
            this.boardSizeLable.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardSizeLable.Location = new System.Drawing.Point(12, 167);
            this.boardSizeLable.Name = "boardSizeLable";
            this.boardSizeLable.Size = new System.Drawing.Size(136, 37);
            this.boardSizeLable.TabIndex = 6;
            this.boardSizeLable.Text = "Board Size:";
            // 
            // rowsLable
            // 
            this.rowsLable.AutoSize = true;
            this.rowsLable.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowsLable.Location = new System.Drawing.Point(32, 221);
            this.rowsLable.Name = "rowsLable";
            this.rowsLable.Size = new System.Drawing.Size(59, 28);
            this.rowsLable.TabIndex = 7;
            this.rowsLable.Text = "Rows:";
            // 
            // colsLable
            // 
            this.colsLable.AutoSize = true;
            this.colsLable.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colsLable.Location = new System.Drawing.Point(170, 221);
            this.colsLable.Name = "colsLable";
            this.colsLable.Size = new System.Drawing.Size(49, 28);
            this.colsLable.TabIndex = 8;
            this.colsLable.Text = "Cols:";
            // 
            // rowsNumeric
            // 
            this.rowsNumeric.Location = new System.Drawing.Point(96, 226);
            this.rowsNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rowsNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.rowsNumeric.Name = "rowsNumeric";
            this.rowsNumeric.Size = new System.Drawing.Size(43, 20);
            this.rowsNumeric.TabIndex = 3;
            this.rowsNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.rowsNumeric.ValueChanged += new System.EventHandler(this.rowsNumeric_ValueChanged);
            // 
            // colsNumeric
            // 
            this.colsNumeric.Location = new System.Drawing.Point(225, 226);
            this.colsNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.colsNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.colsNumeric.Name = "colsNumeric";
            this.colsNumeric.Size = new System.Drawing.Size(43, 20);
            this.colsNumeric.TabIndex = 4;
            this.colsNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.colsNumeric.ValueChanged += new System.EventHandler(this.colsNumeric_ValueChanged);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.startButton.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(37, 275);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(231, 59);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(305, 352);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.colsNumeric);
            this.Controls.Add(this.rowsNumeric);
            this.Controls.Add(this.colsLable);
            this.Controls.Add(this.rowsLable);
            this.Controls.Add(this.boardSizeLable);
            this.Controls.Add(this.player2CheckBox);
            this.Controls.Add(this.player2TextBox);
            this.Controls.Add(this.player2Lable);
            this.Controls.Add(this.player1TextBox);
            this.Controls.Add(this.player1Lable);
            this.Controls.Add(this.playersLable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reversed Tic Tac Teo";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playersLable;
        private System.Windows.Forms.Label player1Lable;
        private System.Windows.Forms.TextBox player1TextBox;
        private System.Windows.Forms.Label player2Lable;
        private System.Windows.Forms.TextBox player2TextBox;
        private System.Windows.Forms.CheckBox player2CheckBox;
        private System.Windows.Forms.Label boardSizeLable;
        private System.Windows.Forms.Label rowsLable;
        private System.Windows.Forms.Label colsLable;
        private System.Windows.Forms.NumericUpDown rowsNumeric;
        private System.Windows.Forms.NumericUpDown colsNumeric;
        private System.Windows.Forms.Button startButton;
    }
}