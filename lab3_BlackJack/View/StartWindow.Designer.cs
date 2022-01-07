
namespace lab3_BlackJack.View
{
    partial class StartWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MoneyTextBox = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.errLabel = new System.Windows.Forms.Label();
            this.numOfDecks = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.numOfDecksLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numOfDecks)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(71, 91);
            this.NameTextBox.MaxLength = 25;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(151, 25);
            this.NameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Money";
            // 
            // MoneyTextBox
            // 
            this.MoneyTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneyTextBox.Location = new System.Drawing.Point(71, 152);
            this.MoneyTextBox.MaxLength = 6;
            this.MoneyTextBox.Name = "MoneyTextBox";
            this.MoneyTextBox.Size = new System.Drawing.Size(151, 25);
            this.MoneyTextBox.TabIndex = 3;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(133, 232);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(103, 43);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // errLabel
            // 
            this.errLabel.AutoSize = true;
            this.errLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errLabel.Location = new System.Drawing.Point(105, 190);
            this.errLabel.Name = "errLabel";
            this.errLabel.Size = new System.Drawing.Size(0, 17);
            this.errLabel.TabIndex = 5;
            this.errLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOfDecks
            // 
            this.numOfDecks.Location = new System.Drawing.Point(250, 91);
            this.numOfDecks.Maximum = 5;
            this.numOfDecks.Minimum = 1;
            this.numOfDecks.Name = "numOfDecks";
            this.numOfDecks.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.numOfDecks.Size = new System.Drawing.Size(45, 86);
            this.numOfDecks.TabIndex = 6;
            this.numOfDecks.Value = 1;
            this.numOfDecks.ValueChanged += new System.EventHandler(this.numOfDecks_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(231, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Decks";
            // 
            // numOfDecksLabel
            // 
            this.numOfDecksLabel.AutoSize = true;
            this.numOfDecksLabel.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfDecksLabel.Location = new System.Drawing.Point(292, 58);
            this.numOfDecksLabel.Name = "numOfDecksLabel";
            this.numOfDecksLabel.Size = new System.Drawing.Size(20, 30);
            this.numOfDecksLabel.TabIndex = 8;
            this.numOfDecksLabel.Text = "1";
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(133, 281);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(103, 43);
            this.ExitBtn.TabIndex = 9;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 334);
            this.ControlBox = false;
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.numOfDecksLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numOfDecks);
            this.Controls.Add(this.errLabel);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.MoneyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartWindow";
            ((System.ComponentModel.ISupportInitialize)(this.numOfDecks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MoneyTextBox;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label errLabel;
        private System.Windows.Forms.TrackBar numOfDecks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label numOfDecksLabel;
        private System.Windows.Forms.Button ExitBtn;
    }
}