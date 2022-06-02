namespace Mastermind
{
    partial class Gamespace
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
            this.newGameButton = new System.Windows.Forms.Button();
            this.makeGuessButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonWhite = new System.Windows.Forms.Button();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.buttonPinOne = new System.Windows.Forms.Button();
            this.buttonPinTwo = new System.Windows.Forms.Button();
            this.buttonPinThree = new System.Windows.Forms.Button();
            this.buttonPinFour = new System.Windows.Forms.Button();
            this.labelInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(445, 10);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 75);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // makeGuessButton
            // 
            this.makeGuessButton.Location = new System.Drawing.Point(445, 95);
            this.makeGuessButton.Name = "makeGuessButton";
            this.makeGuessButton.Size = new System.Drawing.Size(75, 75);
            this.makeGuessButton.TabIndex = 1;
            this.makeGuessButton.Text = "Make Guess";
            this.makeGuessButton.UseVisualStyleBackColor = true;
            this.makeGuessButton.Click += new System.EventHandler(this.makeGuessButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(220, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 656);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(0, 655);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(269, 1);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(268, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 656);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Red;
            this.buttonRed.Location = new System.Drawing.Point(287, 74);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(45, 45);
            this.buttonRed.TabIndex = 5;
            this.buttonRed.Tag = "1";
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.BackColor = System.Drawing.Color.Yellow;
            this.buttonYellow.Location = new System.Drawing.Point(339, 74);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(45, 45);
            this.buttonYellow.TabIndex = 6;
            this.buttonYellow.Tag = "2";
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(390, 74);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(45, 45);
            this.buttonGreen.TabIndex = 7;
            this.buttonGreen.Tag = "3";
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonBlue.Location = new System.Drawing.Point(287, 125);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(45, 45);
            this.buttonBlue.TabIndex = 8;
            this.buttonBlue.Tag = "4";
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonWhite
            // 
            this.buttonWhite.BackColor = System.Drawing.Color.White;
            this.buttonWhite.Location = new System.Drawing.Point(339, 125);
            this.buttonWhite.Name = "buttonWhite";
            this.buttonWhite.Size = new System.Drawing.Size(45, 45);
            this.buttonWhite.TabIndex = 9;
            this.buttonWhite.Tag = "5";
            this.buttonWhite.UseVisualStyleBackColor = false;
            this.buttonWhite.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(390, 125);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(45, 45);
            this.buttonBlack.TabIndex = 10;
            this.buttonBlack.Tag = "6";
            this.buttonBlack.UseVisualStyleBackColor = false;
            this.buttonBlack.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonPinOne
            // 
            this.buttonPinOne.Location = new System.Drawing.Point(287, 25);
            this.buttonPinOne.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPinOne.Name = "buttonPinOne";
            this.buttonPinOne.Size = new System.Drawing.Size(40, 40);
            this.buttonPinOne.TabIndex = 11;
            this.buttonPinOne.Tag = "0";
            this.buttonPinOne.UseVisualStyleBackColor = true;
            this.buttonPinOne.Click += new System.EventHandler(this.buttonPin_Click);
            // 
            // buttonPinTwo
            // 
            this.buttonPinTwo.Location = new System.Drawing.Point(326, 25);
            this.buttonPinTwo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPinTwo.Name = "buttonPinTwo";
            this.buttonPinTwo.Size = new System.Drawing.Size(40, 40);
            this.buttonPinTwo.TabIndex = 12;
            this.buttonPinTwo.Tag = "1";
            this.buttonPinTwo.UseVisualStyleBackColor = true;
            this.buttonPinTwo.Click += new System.EventHandler(this.buttonPin_Click);
            // 
            // buttonPinThree
            // 
            this.buttonPinThree.Location = new System.Drawing.Point(364, 25);
            this.buttonPinThree.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPinThree.Name = "buttonPinThree";
            this.buttonPinThree.Size = new System.Drawing.Size(40, 40);
            this.buttonPinThree.TabIndex = 13;
            this.buttonPinThree.Tag = "2";
            this.buttonPinThree.UseVisualStyleBackColor = true;
            this.buttonPinThree.Click += new System.EventHandler(this.buttonPin_Click);
            // 
            // buttonPinFour
            // 
            this.buttonPinFour.Location = new System.Drawing.Point(403, 25);
            this.buttonPinFour.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPinFour.Name = "buttonPinFour";
            this.buttonPinFour.Size = new System.Drawing.Size(40, 40);
            this.buttonPinFour.TabIndex = 14;
            this.buttonPinFour.Tag = "3";
            this.buttonPinFour.UseVisualStyleBackColor = true;
            this.buttonPinFour.Click += new System.EventHandler(this.buttonPin_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(275, 184);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(251, 20);
            this.labelInformation.TabIndex = 15;
            this.labelInformation.Text = "Press \"New Game\" to start playing";
            // 
            // Gamespace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(534, 736);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.buttonPinFour);
            this.Controls.Add(this.buttonPinThree);
            this.Controls.Add(this.buttonPinTwo);
            this.Controls.Add(this.buttonPinOne);
            this.Controls.Add(this.buttonBlack);
            this.Controls.Add(this.buttonWhite);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.makeGuessButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Gamespace";
            this.Text = "Mastermind";
            this.Load += new System.EventHandler(this.Gamespace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button makeGuessButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonWhite;
        private System.Windows.Forms.Button buttonBlack;
        private System.Windows.Forms.Button buttonPinOne;
        private System.Windows.Forms.Button buttonPinTwo;
        private System.Windows.Forms.Button buttonPinThree;
        private System.Windows.Forms.Button buttonPinFour;
        private System.Windows.Forms.Label labelInformation;
    }
}

