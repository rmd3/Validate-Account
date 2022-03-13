using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Anjolell_7_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Code that closes the program
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Richard D'Anjolell
            //Try catch statement if there is an error accessing the file

            try
            {
                //Declare variables
                int validAccount = 0;
                const int ARRAY_SIZE = 18;
                string[] fileLines = new string[ARRAY_SIZE];
                string userInput = txtEntry.Text;
                StreamReader inputFile;

                //Open the file
                inputFile = File.OpenText("..\\..\\ChargeAccounts.txt");

                //Declare the index for the arrays
                int indexNum = 0;

                //Sends numbers from file into an array
                while (indexNum < fileLines.Length && !inputFile.EndOfStream) 
                {
                    //Set array number to number in the file
                    fileLines[indexNum] = inputFile.ReadLine();

                    //Increment index counter
                    indexNum++;
                }

                //Resets index for next while loop
                indexNum = 0;

                //Validates user's charge account number
                while (indexNum < fileLines.Length)
                {
                    if (fileLines[indexNum] == userInput)
                    {
                        lblResult.Text = "The number you have entered (" + userInput + ") is valid.";
                        validAccount++;
                    }

                    //Increment index counter
                    indexNum++;
                }

                //If statement in case number isn't valid
                if (validAccount == 0)
                {
                    lblResult.Text = "The number you have entered (" + userInput + ") is invalid!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
