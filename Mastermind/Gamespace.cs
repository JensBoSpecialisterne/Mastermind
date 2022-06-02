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

            // To help debugging
            /*
            codeCorrect[0] = 2;
            codeCorrect[1] = 2;
            codeCorrect[2] = 3;
            codeCorrect[3] = 3;
            */
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

            List<int> tempCodeCorrect = new List<int>();

            tempCodeCorrect.Add(codeCorrect[0]);
            tempCodeCorrect.Add(codeCorrect[1]);
            tempCodeCorrect.Add(codeCorrect[2]);
            tempCodeCorrect.Add(codeCorrect[3]);

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
                } // For every element in the guess, checks if it hasn't been seen in the code yet, and adds a white pin to the answer if it hasn't
                  // Then checks whether the location is also the same, and "upgrades" the white pin to a black if it is
                for (int counter = 0; counter < 4; counter++)
                {
                    if (tempCodeCorrect.Contains(codeGuess[counter]))
                    {
                        correctColors++;
                        tempCodeCorrect.Remove(codeGuess[counter]);
                    }
                    if (codeGuess[counter] == codeCorrect[counter])
                    {
                        correctPins++;
                    }
                } // Draws an empty circle with a black border for every correct color. Then fills an empty circle for every correct location.
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
                tempCodeCorrect.Clear(); // JUST in case.

                // Ends the game if the sequence hasn't been guessed in twelve tries
                if (guesses == 12)
                {
                    gameOn = false;
                    labelInformation.Text = "You lost! Want to try again?";
                }
            }
        }

        // Sets the currently selected "guess pin" to the color Red, and continues to the next pin if the guess isn't done
        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (gameOn) 
            {
                int buttonColor = int.Parse((sender as Button).Tag as String);
                codeGuess[currentPin] = buttonColor;
                Color color = Color.Red;
                switch (buttonColor)
                {
                    case 1: color = Color.Red; break;
                    case 2: color = Color.Yellow; break;
                    case 3: color = Color.Green; break;
                    case 4: color = Color.Blue; break;
                    case 5: color = Color.White; break;
                    case 6: color = Color.Black; break;
                }
                switch (currentPin) {
                  case 0: buttonPinOne.BackColor = color; currentPin++; break;
                  case 1: buttonPinTwo.BackColor = color; currentPin++; break;
                  case 2: buttonPinThree.BackColor = color; currentPin++; break;
                  case 3: buttonPinFour.BackColor = color; break;
                }
            }
        }

        // Sets the first pin as the active one to have its color selected
        private void buttonPin_Click(object sender, EventArgs e)
        {
            if (gameOn)
            {
                int pinNumber = int.Parse((sender as Button).Tag as String);
                currentPin = pinNumber;
            }
        }
    }
}
