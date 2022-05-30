using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class Gamespace : Form
    {
        Boolean gameOn = false;

        Random rand = new Random();

        int currentPin = 0;
        int guesses = 0;
        int[] codeCorrect = new int[4];
        int[] codeGuess = { 0, 0, 0, 0 };
        int[] testCodeResult = new int[4];
        int[] testCodeGuess = new int[4];

        Pen penBlack = new Pen(Color.Black);
        Pen penWhite = new Pen(Color.Black);

        SolidBrush brushRed = new SolidBrush(Color.Red);
        SolidBrush brushYellow = new SolidBrush(Color.Yellow);
        SolidBrush brushGreen = new SolidBrush(Color.Green);
        SolidBrush brushBlue = new SolidBrush(Color.Blue);
        SolidBrush brushWhite = new SolidBrush(Color.White);
        SolidBrush brushBlack = new SolidBrush(Color.Black);

        Rectangle[,] guessesMatrix = new Rectangle[12, 4];
        Rectangle[,] resultMatrix = new Rectangle[12, 4];

        //Sets up the "gameboard"
        private void generateBoard()
        {
            Graphics g = this.CreateGraphics();

            for (int row = 0; row < 12; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    guessesMatrix[row, column] = new Rectangle((5+column*35),(5+row*35),30,30);
                    g.DrawEllipse(penBlack, guessesMatrix[row, column]);
                }
            }
            for (int row = 0; row < 12; row++)
            {
                resultMatrix[row, 0] = new Rectangle(155, 15 + row * 35, 5, 5);
                resultMatrix[row, 1] = new Rectangle(163, 15 + row * 35, 5, 5);
                resultMatrix[row, 2] = new Rectangle(155, 22 + row * 35, 5, 5);
                resultMatrix[row, 3] = new Rectangle(163, 22 + row * 35, 5, 5);
            }
        }

        //Randomises a new code to guess
        private void generateCode()
        {
            codeCorrect[0] = rand.Next(1, 6);
            codeCorrect[1] = rand.Next(1, 6);
            codeCorrect[2] = rand.Next(1, 6);
            codeCorrect[3] = rand.Next(1, 6);

            labelInformation.Text = "";

            // To help debugging
            // labelInformation.Text = codeCorrect[0] + " " + codeCorrect[1] + " " + codeCorrect[2] + " " + codeCorrect[3];
        }

        public Gamespace()
        {
            InitializeComponent();
        }

        private void Gamespace_Load(object sender, EventArgs e)
        {

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            g.Clear(Color.WhiteSmoke);
            generateCode();
            generateBoard();
            gameOn = true;
            guesses = 0;
        }

        private void makeGuessButton_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            currentPin = 0;

            testCodeResult[0] = codeCorrect[0];
            testCodeResult[1] = codeCorrect[1];
            testCodeResult[2] = codeCorrect[2];
            testCodeResult[3] = codeCorrect[3];

            testCodeGuess[0] = codeGuess[0];
            testCodeGuess[1] = codeGuess[1];
            testCodeGuess[2] = codeGuess[2];
            testCodeGuess[3] = codeGuess[3];

            int correctPins = 0;
            int correctColors = 0;

            if (!codeGuess.Contains(0))
            {
                for (int column = 0; column < 4; column++)
                {
                    guessesMatrix[guesses, column] = new Rectangle((5 + column * 35), (5 + guesses * 35), 30, 30);
                    switch (codeGuess[column])
                    {
                        case 1: g.FillEllipse(brushRed, guessesMatrix[guesses, column]); break;
                        case 2: g.FillEllipse(brushYellow, guessesMatrix[guesses, column]); break;
                        case 3: g.FillEllipse(brushGreen, guessesMatrix[guesses, column]); break;
                        case 4: g.FillEllipse(brushBlue, guessesMatrix[guesses, column]); break;
                        case 5: g.FillEllipse(brushWhite, guessesMatrix[guesses, column]); break;
                        case 6: g.FillEllipse(brushBlack, guessesMatrix[guesses, column]); break;
                    }
                }
                for (int currentResult = 0; currentResult < 4; currentResult++)
                {
                    if (testCodeResult[currentResult] == testCodeGuess[currentResult])
                    {
                        testCodeResult[currentResult] = 0;
                        testCodeGuess[currentResult] = 5;
                        g.DrawEllipse(penBlack, resultMatrix[guesses, correctPins]);
                        g.FillEllipse(brushBlack, resultMatrix[guesses, correctPins]);
                        correctPins++;
                        correctColors++;

                    }
                }
                for (int currentResult = 0; currentResult < 4; currentResult++)
                {
                    for (int temp = 0; temp < 4; temp++)
                    {
                        if (testCodeResult[temp] == testCodeGuess[currentResult])
                        {
                            testCodeResult[temp] = 0;
                            testCodeGuess[currentResult] = 5;
                            g.DrawEllipse(penBlack, resultMatrix[guesses, correctColors]);
                            correctColors++;
                        }
                    }
                }
                if (correctPins == 4)
                {
                    gameOn = false;
                    labelInformation.Text = "You won! Want to try again?";
                }

                Array.Clear(codeGuess, 0, codeGuess.Length);
                buttonPinOne.BackColor = default(Color);
                buttonPinOne.UseVisualStyleBackColor = true;
                buttonPinTwo.BackColor = default(Color);
                buttonPinTwo.UseVisualStyleBackColor = true;
                buttonPinThree.BackColor = default(Color);
                buttonPinThree.UseVisualStyleBackColor = true;
                buttonPinFour.BackColor = default(Color);
                buttonPinFour.UseVisualStyleBackColor = true;

                guesses++;

                if(guesses == 12)
                {
                    gameOn = false;
                    labelInformation.Text = "You lost! Want to try again?";
                }
            }
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            if (gameOn) 
            { 
                codeGuess[currentPin] = 1;
                Color color = Color.Red;
                switch (currentPin) {
                  case 0: buttonPinOne.BackColor = color; currentPin++; break;
                  case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                  case 2: buttonPinThree.BackColor = color; currentPin++; break;
                  case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                codeGuess[currentPin] = 2;
                Color color = Color.Yellow;
                switch (currentPin)
                {
                    case 0: buttonPinOne.BackColor = color; currentPin++; break;
                    case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                    case 2: buttonPinThree.BackColor = color; currentPin++; break;
                    case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                codeGuess[currentPin] = 3;
                Color color = Color.Green;
                switch (currentPin)
                {
                    case 0: buttonPinOne.BackColor = color; currentPin++; break;
                    case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                    case 2: buttonPinThree.BackColor = color; currentPin++; break;
                    case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                codeGuess[currentPin] = 4;
                Color color = Color.Blue;
                switch (currentPin)
                {
                    case 0: buttonPinOne.BackColor = color; currentPin++; break;
                    case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                    case 2: buttonPinThree.BackColor = color; currentPin++; break;
                    case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                codeGuess[currentPin] = 5;
                Color color = Color.White;
                switch (currentPin)
                {
                    case 0: buttonPinOne.BackColor = color; currentPin++; break;
                    case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                    case 2: buttonPinThree.BackColor = color; currentPin++; break;
                    case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                codeGuess[currentPin] = 6;
                Color color = Color.Black;
                switch (currentPin)
                {
                    case 0: buttonPinOne.BackColor = color; currentPin++; break;
                    case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                    case 2: buttonPinThree.BackColor = color; currentPin++; break;
                    case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }

        private void buttonPinOne_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 0;
            }
        }

        private void buttonPinTwo_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 1;
            }
        }

        private void buttonPinThree_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 2;
            }
        }

        private void buttonPinFour_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 3;
            }
        }
    }
}
