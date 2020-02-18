//Written by: AdamJD
//Date: 19/10/2019 
//Description: An app that calculates how much sleep the user needs to stay healthy based on the amount of sleep they had the night before.

using System;
using System.Windows.Forms;

namespace SleepApp
{
    public partial class SleepApp : Form
    {
        //variables
        private int idealAmount = 8; //the ideal hours of sleep
        private float idealAmountPlusOne; //for the recommended range
        private float idealAmountMinusOne; //for the recommended range
        private float outputAmount; //hours of sleep away from ideal amount
        private string finalOutput; //message that is displayed

        public SleepApp()
        {
            InitializeComponent(); //load up app
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            float inputAmount; //get the inputted sleep amount
            inputAmount = float.Parse(numAmount.Text); //parses the input as a float, the NumericUpDown counts minus numbers as 0, rounds up from .5, stops user entering text, leaving this blank and ignores whitespace

            //set up ranges for the recommended range
            idealAmountPlusOne = idealAmount + 1; //8 + 1
            idealAmountMinusOne = idealAmount - 1; //8 - 1

            if (inputAmount == idealAmount) //8 hours sleep
            {
                finalOutput = ("You have had " + idealAmount + " hour's of sleep! Congratulations, keep it up!"); //got 8 hours sleep message
                txtOutput.Text = finalOutput.ToString(); //show message to user
            }

            else if ((inputAmount < idealAmount && inputAmount >= idealAmountMinusOne) || (inputAmount > idealAmount && inputAmount <= idealAmountPlusOne)) //between 7-9 hours sleep
            {
                outputAmount = idealAmount - inputAmount; //calculate how far away the user is from 8 hours sleep
                finalOutput = ("You have had " + inputAmount + " hour/s of sleep which is " + outputAmount + " hour/'s of sleep away from the magic 8 hours. This is within the recommended range."); //got 7 hours sleep message
                txtOutput.Text = finalOutput.ToString(); //show message to user

                if (outputAmount < 0)
                {
                    outputAmount *= -1; //get rid of minus sign if output amount is below 0
                    finalOutput = ("You have had " + inputAmount + " hour/s of sleep which is " + outputAmount + " hour/'s of sleep over the magic 8 hours. This is within the recommended range."); //got 9 hours sleep message
                    txtOutput.Text = finalOutput.ToString(); //show message to user
                }
            }

            else if (inputAmount < idealAmountMinusOne && inputAmount >= 0) //0-6 hours of sleep 
            {
                outputAmount = idealAmount - inputAmount; //calculate how far away the user is from 8 hours sleep
                finalOutput = ("You have had " + inputAmount + " hour/s of sleep which is " + outputAmount + " hour/'s sleep under the recommended range. Get some more sleep to be in the healthy 7-9 hour range!"); //got under 7 hours sleep message
                txtOutput.Text = finalOutput.ToString(); //show message to user

                if (inputAmount >= 0 && inputAmount <= 3) //0-3 hours sleep
                {
                    outputAmount = idealAmount - inputAmount; //calculate how far away the user is from 8 hours sleep
                    finalOutput = ("You have had " + inputAmount + " hour/s of sleep which is " + outputAmount + " hour/'s sleep under the recommended range. What the fuck were you doing to get this amount of sleep? Go to bed!"); //tell the user to go to bed!
                    txtOutput.Text = finalOutput.ToString(); //show message to user
                }
            }

            else if (inputAmount > idealAmountPlusOne && inputAmount <= 24) //10-24 hours of sleep (must have been hell of a party if this is the amount...)
            {
                outputAmount = inputAmount - idealAmount; //calculate how far over the user is from 8 hours sleep
                finalOutput = ("You have had " + inputAmount + " hour/s of sleep which is " + outputAmount + " hour/'s of sleep over the recommended range. More than 7-9 hours sleep is bad for your health!"); //got over 9 hours sleep message
                txtOutput.Text = finalOutput.ToString(); //show message to user
            }

            else //validation
            {
                finalOutput = "Please enter a valid number between 0 and 24";  //enter correct value message
                txtOutput.Text = finalOutput.ToString(); //show message to user
            }
        }
    }
}
