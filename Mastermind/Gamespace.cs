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
        int[] testCodeCorrect = new int[4];
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

        //Sets up the "gameboard", drawing the empty holes to guess, and setting up the framework for the reply pins
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

        //Randomises a new code to guess and removes the "Press New Game" message
        private void generateCode()
        {
            codeCorrect[0] = rand.Next(1, 6);
            codeCorrect[1] = rand.Next(1, 6);
            codeCorrect[2] = rand.Next(1, 6);
            codeCorrect[3] = rand.Next(1, 6);

            /* // To help debugging
            codeCorrect[0] = 2;
            codeCorrect[1] = 2;
            codeCorrect[2] = 3;
            codeCorrect[3] = 2; */

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

        // Clears the filled circles from last time, then generates a new board, code to guess and resets guessers progress
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

            testCodeCorrect[0] = codeCorrect[0];
            testCodeCorrect[1] = codeCorrect[1];
            testCodeCorrect[2] = codeCorrect[2];
            testCodeCorrect[3] = codeCorrect[3];

            testCodeGuess[0] = codeGuess[0];
            testCodeGuess[1] = codeGuess[1];
            testCodeGuess[2] = codeGuess[2];
            testCodeGuess[3] = codeGuess[3];

            int correctPins = 0;
            int correctColors = 0;

            if (!codeGuess.Contains(0)) // Only allows a guess to be made if a color has been selected for all four holes
            {
                for (int column = 0; column < 4; column++)
                { // Fills out the next row with circles in the guessed colors
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
                if (codeCorrect[0] == testCodeGuess[0])
                {
                    testCodeGuess[0] = 5;
                    correctPins++;
                    correctColors++;
                }
                else if (codeCorrect[0] == testCodeGuess[1] & !(codeCorrect[1] == testCodeGuess[1]))
                {
                    testCodeGuess[1] = 5;
                    correctColors++;
                }
                else if (codeCorrect[0] == testCodeGuess[2] & !(codeCorrect[2] == testCodeGuess[2]))
                {
                    testCodeGuess[2] = 5;
                    correctColors++;
                }
                else if (codeCorrect[0] == testCodeGuess[3] & !(codeCorrect[3] == testCodeGuess[3]))
                {
                    testCodeGuess[3] = 5;
                    correctColors++;
                }
                if (codeCorrect[1] == testCodeGuess[1])
                {
                    testCodeGuess[1] = 5;
                    correctPins++;
                    correctColors++;
                }
                else if (codeCorrect[1] == testCodeGuess[0] & !(codeCorrect[0] == testCodeGuess[0]))
                {
                    testCodeGuess[0] = 5;
                    correctColors++;
                }
                else if (codeCorrect[1] == testCodeGuess[2] & !(codeCorrect[2] == testCodeGuess[2]))
                {
                    testCodeGuess[2] = 5;
                    correctColors++;
                }
                else if (codeCorrect[1] == testCodeGuess[3] & !(codeCorrect[3] == testCodeGuess[3]))
                {
                    testCodeGuess[3] = 5;
                    correctColors++;
                }
                if (codeCorrect[2] == testCodeGuess[2])
                {
                    testCodeGuess[2] = 5;
                    correctPins++;
                    correctColors++;
                }
                else if (codeCorrect[2] == testCodeGuess[0] & !(codeCorrect[0] == testCodeGuess[0]))
                {
                    testCodeGuess[0] = 5;
                    correctColors++;
                }
                else if (codeCorrect[2] == testCodeGuess[1] & !(codeCorrect[1] == testCodeGuess[1]))
                {
                    testCodeGuess[1] = 5;
                    correctColors++;
                }
                else if (codeCorrect[2] == testCodeGuess[3] & !(codeCorrect[3] == testCodeGuess[3]))
                {
                    testCodeGuess[3] = 5;
                    correctColors++;
                }
                if (codeCorrect[3] == testCodeGuess[3])
                {
                    testCodeGuess[2] = 5;
                    correctPins++;
                    correctColors++;
                }
                else if (codeCorrect[3] == testCodeGuess[0] & !(codeCorrect[0] == testCodeGuess[0]))
                {
                    testCodeGuess[0] = 5;
                    correctColors++;
                }
                else if (codeCorrect[3] == testCodeGuess[1] & !(codeCorrect[1] == testCodeGuess[1]))
                {
                    testCodeGuess[1] = 5;
                    correctColors++;
                }
                else if (codeCorrect[3] == testCodeGuess[2] & !(codeCorrect[2] == testCodeGuess[2]))
                {
                    testCodeGuess[2] = 5;
                    correctColors++;
                }
                for (int results = 0; results < correctColors; results++)
                {
                    g.DrawEllipse(penBlack, resultMatrix[guesses, results]);
                    if(results < correctPins)
                    {
                        g.FillEllipse(brushBlack, resultMatrix[guesses, results]);
                    }
                } 
                // Ends the game if the correct sequence has been guessed
                if (correctPins == 4)
                {
                    gameOn = false;
                    labelInformation.Text = "You won! Want to try again?";
                }

                // Resets the "guess area" after a guess has been made.
                Array.Clear(codeGuess, 0, codeGuess.Length);
                buttonPinOne.BackColor = default(Color);
                buttonPinOne.UseVisualStyleBackColor = true;
                buttonPinTwo.BackColor = default(Color);
                buttonPinTwo.UseVisualStyleBackColor = true;
                buttonPinThree.BackColor = default(Color);
                buttonPinThree.UseVisualStyleBackColor = true;
                buttonPinFour.BackColor = default(Color);
                buttonPinFour.UseVisualStyleBackColor = true;
                currentPin = 0;

                guesses++;

                // Ends the game if the sequence hasn't been guessed in twelve tries
                if(guesses == 12)
                {
                    gameOn = false;
                    labelInformation.Text = "You lost! Want to try again?";
                }
            }
        }

        // Sets the currently selected "guess pin" to the color Red, and continues to the next pin if the guess isn't done
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

        // Sets the currently selected "guess pin" to the color Yellow, and continues to the next pin if the guess isn't done
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

        // Sets the currently selected "guess pin" to the color Green, and continues to the next pin if the guess isn't done
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

        // Sets the currently selected "guess pin" to the color Blue, and continues to the next pin if the guess isn't done
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

        // Sets the currently selected "guess pin" to the color White, and continues to the next pin if the guess isn't done
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

        // Sets the currently selected "guess pin" to the color Black, and continues to the next pin if the guess isn't done
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

        // Sets the first pin as the active one to have its color selected
        private void buttonPinOne_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 0;
            }
        }

        // Sets the second pin as the active one to have its color selected
        private void buttonPinTwo_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 1;
            }
        }

        // Sets the third pin as the active one to have its color selected
        private void buttonPinThree_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 2;
            }
        }

        // Sets the fourth pin as the active one to have its color selected
        private void buttonPinFour_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                currentPin = 3;
            }
        }
    }
}
