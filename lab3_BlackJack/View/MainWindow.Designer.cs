
namespace lab3_BlackJack
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Chip500PBox = new System.Windows.Forms.PictureBox();
            this.Chip200PBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerHandPBox = new System.Windows.Forms.PictureBox();
            this.Chip100PBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.StakePBox = new System.Windows.Forms.PictureBox();
            this.StakeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chip500PBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chip200PBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHandPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chip100PBox)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StakePBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.23188F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.53623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.23189F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Chip500PBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Chip200PBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Chip100PBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 289);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(780, 158);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Chip500PBox
            // 
            this.Chip500PBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chip500PBox.Image = global::lab3_BlackJack.Properties.Resources.Chip500;
            this.Chip500PBox.Location = new System.Drawing.Point(203, 3);
            this.Chip500PBox.Name = "Chip500PBox";
            this.Chip500PBox.Size = new System.Drawing.Size(94, 152);
            this.Chip500PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chip500PBox.TabIndex = 3;
            this.Chip500PBox.TabStop = false;
            this.Chip500PBox.Click += new System.EventHandler(this.Chip500PBox_Click);
            // 
            // Chip200PBox
            // 
            this.Chip200PBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chip200PBox.Image = global::lab3_BlackJack.Properties.Resources.Chip200;
            this.Chip200PBox.Location = new System.Drawing.Point(103, 3);
            this.Chip200PBox.Name = "Chip200PBox";
            this.Chip200PBox.Size = new System.Drawing.Size(94, 152);
            this.Chip200PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chip200PBox.TabIndex = 2;
            this.Chip200PBox.TabStop = false;
            this.Chip200PBox.Click += new System.EventHandler(this.Chip200PBox_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.PlayerHandPBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(303, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(314, 152);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // PlayerHandPBox
            // 
            this.PlayerHandPBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PlayerHandPBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerHandPBox.Location = new System.Drawing.Point(3, 3);
            this.PlayerHandPBox.Name = "PlayerHandPBox";
            this.PlayerHandPBox.Size = new System.Drawing.Size(308, 146);
            this.PlayerHandPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlayerHandPBox.TabIndex = 0;
            this.PlayerHandPBox.TabStop = false;
            // 
            // Chip100PBox
            // 
            this.Chip100PBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chip100PBox.ErrorImage = null;
            this.Chip100PBox.Image = global::lab3_BlackJack.Properties.Resources.Chip100;
            this.Chip100PBox.Location = new System.Drawing.Point(3, 3);
            this.Chip100PBox.Name = "Chip100PBox";
            this.Chip100PBox.Size = new System.Drawing.Size(94, 152);
            this.Chip100PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chip100PBox.TabIndex = 1;
            this.Chip100PBox.TabStop = false;
            this.Chip100PBox.Click += new System.EventHandler(this.Chip100PBox_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 166);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(794, 117);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.StakePBox, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.StakeLabel, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(267, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.67937F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.32062F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(258, 111);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // StakePBox
            // 
            this.StakePBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StakePBox.Location = new System.Drawing.Point(3, 3);
            this.StakePBox.Name = "StakePBox";
            this.StakePBox.Size = new System.Drawing.Size(252, 69);
            this.StakePBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StakePBox.TabIndex = 0;
            this.StakePBox.TabStop = false;
            // 
            // StakeLabel
            // 
            this.StakeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StakeLabel.AutoSize = true;
            this.StakeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StakeLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.StakeLabel.Location = new System.Drawing.Point(129, 81);
            this.StakeLabel.Name = "StakeLabel";
            this.StakeLabel.Size = new System.Drawing.Size(0, 30);
            this.StakeLabel.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lab3_BlackJack.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.Text = "BlackJack";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chip500PBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chip200PBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHandPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chip100PBox)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StakePBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox Chip500PBox;
        private System.Windows.Forms.PictureBox Chip200PBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox Chip100PBox;
        private System.Windows.Forms.PictureBox PlayerHandPBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox StakePBox;
        private System.Windows.Forms.Label StakeLabel;
    }
}

