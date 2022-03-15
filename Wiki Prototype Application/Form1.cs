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
                    if (!string.IsNullOrWhiteSpace(textBoxName.Text) &&
                !string.IsNullOrWhiteSpace(textBoxCategory.Text) &&
                !string.IsNullOrWhiteSpace(textBoxStructure.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDefinition.Text))

                    {
                        wikiArray[counter, 0] = textBoxName.Text;
                        wikiArray[counter, 1] = textBoxCategory.Text;
                        wikiArray[counter, 2] = textBoxStructure.Text;
                        wikiArray[counter, 3] = textBoxDefinition.Text;
                        counter++;
                    }
                    else
                    {
                        toolStripStatusLabel.Text = "Error: please fill out all fields.";
                    }
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
        // Deletes the item at the selected index and shuffles the array up to fill it
        // Method ensures blank elements are shuffled to the end of the array
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewOne.SelectedIndices[0];
                if (selectedRecord >= 0)
                {
                    DialogResult delName = MessageBox.Show("Do you wish to delete this wiki record?",
                     "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delName == DialogResult.Yes)
                    {
                        wikiArray[selectedRecord, 0] = "~";
                        wikiArray[selectedRecord, 1] = "~";
                        wikiArray[selectedRecord, 2] = "~";
                        wikiArray[selectedRecord, 3] = "~";
                    }
                }
                else
                {
                    toolStripStatusLabel.Text = "Error: please select a valid item from the list view box.";
                }
            }
            catch (Exception)
            {
                toolStripStatusLabel.Text = "Error: please select a valid item.";
            }


            displayArray();
        }
        public void displayArray()
        {
            listViewOne.Items.Clear();
            listViewOne.ForeColor = Color.Black;

            // Iterate through the array and display records which are not empty
            for (int x = 0; x < row; x++)
            {
                if (!string.IsNullOrEmpty(wikiArray[x, 0]))
                {
                    ListViewItem lvi = new ListViewItem(wikiArray[x, 0]);
                    lvi.SubItems.Add(wikiArray[x, 1]);
                    lvi.SubItems.Add(wikiArray[x, 2]);
                    listViewOne.Items.Add(lvi);
                }

            }
        }

        private void listViewOne_Click(object sender, EventArgs e)
        {
            int selectedRecord = listViewOne.SelectedIndices[0];
            textBoxName.Text = wikiArray[selectedRecord, 0];
            textBoxCategory.Text = wikiArray[selectedRecord, 1];
            textBoxStructure.Text = wikiArray[selectedRecord, 2];
            textBoxDefinition.Text = wikiArray[selectedRecord, 3];
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxCategory.Text = "";
            textBoxStructure.Text = "";
            textBoxDefinition.Text = "";
            textBoxOne.Text = "";
        }
    }
}

