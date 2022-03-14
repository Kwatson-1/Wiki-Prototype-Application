using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace Wiki_Prototype_Application
{
    public partial class WikiPrototypeApplication : Form
    {
        public WikiPrototypeApplication()
        {
            InitializeComponent();
        }

        static int row = 12; //Maximum number of wiki entries
        static int column = 4; //Name, Category, Structure, Definition
        static String[,] wikiArray = new string[row, column];
        int counter = 0;
        

        private void WikiPrototypeApplication_Load(object sender, EventArgs e)
        {

        }

        // Add button method
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (counter < row)
            {
                try
                {
                    wikiArray[counter, 0] = textBoxName.Text;
                    wikiArray[counter, 1] = textBoxCategory.Text;
                    wikiArray[counter, 2] = textBoxStructure.Text;
                    wikiArray[counter, 3] = textBoxDefinition.Text;
                    counter++;
                }
                catch
                {
                    MessageBox.Show("Error: please try again.");
                }
            }
            else
            {
                statusStripOne.Text = "The array is full, delete a wiki entry and try again.";
            }
            displayArray();
        }

        // Delete button method
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deleteIndex = listBoxOne.SelectedIndex;
                String[,] copyArray = wikiArray;
                int deleteCounter = 0;
                counter--;

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if(i == deleteIndex)
                        {
                            deleteCounter++;
                            copyArray[i, j] = wikiArray[i + deleteCounter, j];
                        }
                        else if(deleteIndex == row-1)
                        {
                            copyArray[i, j] = "";
                        }
                        else
                        {
                            copyArray[i, j] = wikiArray[i + deleteCounter, j];
                        }
                    }
                }
                wikiArray = copyArray;
            }
            catch
            {

            }
            displayArray();
        }
        public void displayArray()
        {
            listBoxOne.Items.Clear();
            string idk = "";
            for(int x = 0; x<row; x++)
            {
                idk = wikiArray[x, 0] + "\t" + wikiArray[x, 1] + "\t" + wikiArray[x, 2];
                listBoxOne.Items.Add(idk);
            }

        }
    }
}

