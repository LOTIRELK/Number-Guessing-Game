using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//a progam that creates a random number and allows the user 3 attemmpts to guess
//it correctly
namespace Lab3Question2
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //random number initialised here to stop it being changed each time
            //calculate button is clicked
            Random rand = new Random();
            number = rand.Next(1,11);
        }

        int attempt = 3;
        int number = 0;

        private void btnGuess_Click(object sender, EventArgs e)
        {
            //call function to compare the number entered by user and the random number
            compareNumber();      
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //close form when quit button clicked
            this.Close();
        }

        //declaration of the function to compare the number entered with the random number
        void compareNumber()
        {
            //convert tring to int
            int guess = Convert.ToInt32(txtNumber.Text);
            //check if number is not within the range
            if (guess > 10 || guess < 1)
            {
                MessageBox.Show(
                    "Please enter a whole number between one and ten",
                    "Error!");
                this.Close();//close form
            }
            if (guess > number)
            {
                txtPosition.Text = "Greater than.";
            }
            else if (guess < number)
            {
                txtPosition.Text = "Less than.";
            }
            else if (guess == number)
            {
                txtPosition.Text = "Equal to";
                txtAnswer.Text = number.ToString();
                
            }

            //minus attempt by one each time answer is incorrect
            attempt--;

            //output attempts left
            txtAttempt.Text = attempt.ToString();

            //when attempts are equal to 0
            if (attempt == 0&&guess!=number)
            {
                //reveal answer
                txtAnswer.Text = number.ToString();
                MessageBox.Show("The correct number is " + 
                    number.ToString()+". Please try again.");
                this.Close();
            }
        }
    }
}


