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
using System.IO;

namespace Wiki_Prototype_Application
{
    public partial class WikiPrototypeApplication : Form
    {
        public WikiPrototypeApplication()
        {
            InitializeComponent();
        }
        #region Program attributes
        static int row = 12; //Maximum number of wiki entries
        static int column = 4; //Name, Category, Structure, Definition
        static String[,] wikiArray = new string[row, column];
        int counter = 0;
        #endregion

        private void WikiPrototypeApplication_Load(object sender, EventArgs e)
        {
            //toolStripStatusLabel.Text = "test load";
        }
        #region Add Button
        // Add button method
        private void ButtonAdd_Click(object sender, EventArgs e)
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
                        counter += 1;
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
                toolStripStatusLabel.Text = "Error: The array is full, delete a wiki entry and try again.";
            }
            PostProcessFunction();
        }
        #endregion

        #region Delete Button
        // Delete button method
        // Deletes the item at the selected index and shuffles the array up to fill it
        // Method ensures blank elements are shuffled to the end of the array
        private void ButtonDelete_Click(object sender, EventArgs e)
        {

                try
                {
                    int currentRecord = listViewOne.SelectedIndices[0];
                    if (currentRecord >= 0)
                    {
                        DialogResult delName = MessageBox.Show("Do you wish to delete this definition?",
                        "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (delName == DialogResult.Yes)
                        {
                            ListViewItem lvi = new ListViewItem(wikiArray[currentRecord, 0]);
                            wikiArray[currentRecord, 0] = ("~");
                            wikiArray[currentRecord, 1] = ("~");
                            wikiArray[currentRecord, 2] = ("~");
                            wikiArray[currentRecord, 3] = ("~");
                            counter--;
                            ClearFields();
                            //Sort();
                            toolStripStatusLabel1.Text = "Data item deleted.";
                        }
                        else
                        {
                            MessageBox.Show("Item NOT Deleted", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Select an item to delete.");
                }
                BubbleSort();
                DisplayArray();
        }
        #endregion
        #region Display Array
        public void DisplayArray()
        {
            listViewOne.Items.Clear();
            // Iterate through the array and display records which are not empty
            for (int i = 0; i < row; i++)
            {
                if (!string.IsNullOrWhiteSpace(wikiArray[i, 0]))
               {
                    ListViewItem lvi = new ListViewItem(wikiArray[i, 0]);
                    lvi.SubItems.Add(wikiArray[i, 1]);
                    lvi.SubItems.Add(wikiArray[i, 2]);
                    lvi.SubItems.Add(wikiArray[i, 3]);
                    listViewOne.Items.Add(lvi);
                }

            }
        }
        #endregion
        #region List View Click
        private void listViewOne_Click(object sender, EventArgs e)
        {
            int selectedRecord = listViewOne.SelectedIndices[0];
            textBoxName.Text = wikiArray[selectedRecord, 0];
            textBoxCategory.Text = wikiArray[selectedRecord, 1];
            textBoxStructure.Text = wikiArray[selectedRecord, 2];
            textBoxDefinition.Text = wikiArray[selectedRecord, 3];
        }
        #endregion
        #region Clear Button
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion
        #region Clear Fields Method
        public void ClearFields()
        {
            textBoxName.Text = "";
            textBoxCategory.Text = "";
            textBoxStructure.Text = "";
            textBoxDefinition.Text = "";
            textBoxOne.Text = "";
            if (listViewOne.SelectedItems.Count != 0)
            {
                listViewOne.SelectedItems[0].Selected = false;
            }
        }
        #endregion
        #region Sort Method
        public void BubbleSort()
        {
            for (int x = 0; x < row-1; x++)
            {
                for (int i = 0; i < row-1; i++)
                {
                    if (!(string.IsNullOrEmpty(wikiArray[i + 1, 0])))
                    {
                        if (string.CompareOrdinal(wikiArray[i, 0], wikiArray[i + 1, 0]) > 0)
                        {
                            Swap(i);
                        }
                    }
                }
            }
        }
        public void Swap(int indx)
        {
            string temp;
            for (int i = 0; i < column; i++)
            {
                temp = wikiArray[indx, i];
                wikiArray[indx, i] = wikiArray[indx + 1, i];
                wikiArray[indx + 1, i] = temp;
            }
        }
        #endregion
        #region Post Process 
        public void PostProcessFunction()
        {
            BubbleSort();
            DisplayArray();
        }
        #endregion
        #region Edit Button
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewOne.SelectedIndices[0];
                if (selectedRecord >= 0)
                {
                    var result = MessageBox.Show("Proceed with update?", "Edit Record",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        wikiArray[selectedRecord, 0] = textBoxName.Text;
                        wikiArray[selectedRecord, 1] = textBoxCategory.Text;
                        wikiArray[selectedRecord, 2] = textBoxStructure.Text;
                        wikiArray[selectedRecord, 3] = textBoxDefinition.Text;
                        PostProcessFunction();
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "Error: please select a valid item.";
            }
            
        }
        #endregion
        #region Search Button
        private void buttonSearch_Click(object sender, EventArgs e)
        {

            int startIndex = -1;
            int finalIndex = counter; // set size of data in array
            bool flag = false;
            int foundIndex = -1;

            if (listViewOne.SelectedItems.Count != 0)
            {
                listViewOne.SelectedItems[0].Selected = false;
            }

            while (!flag && !((finalIndex - startIndex) <= 1))
            {
                int newIndex = (finalIndex + startIndex) / 2;
                // The string.Compare(a,b) method compares 2 strings a and b and returns an integer value
                // -1 if a is less than b, 0 if they are equal, 1 if b is less than a
                if (string.Compare(wikiArray[newIndex, 0], textBoxOne.Text) == 0) // they are equal
                {
                    foundIndex = newIndex;
                    flag = true;
                    break;
                }
                else
                {
                    if (string.Compare(wikiArray[newIndex, 0], textBoxOne.Text) == 1)
                        finalIndex = newIndex;
                    else
                        startIndex = newIndex;
                }
            }
            if (flag)
            {
                textBoxName.Text = wikiArray[foundIndex, 0];
                textBoxCategory.Text = wikiArray[foundIndex, 1];
                textBoxStructure.Text = wikiArray[foundIndex, 2];
                textBoxDefinition.Text = wikiArray[foundIndex, 3];
                listViewOne.Items[foundIndex].Selected = true;
                listViewOne.HideSelection = false;
            }
            else
                toolStripStatusLabel.Text = "Not found ";
        }
        #endregion
        #region Data partial preload
        private void ButtonLoadData_Click(object sender, EventArgs e)
        {
            wikiArray[0, 0] = "nameone";
            wikiArray[1, 0] = "nametwo";
            wikiArray[2, 0] = "namethree";
            wikiArray[3, 0] = "namefour";

            wikiArray[0, 1] = "categoryone";
            wikiArray[1, 1] = "categorytwo";
            wikiArray[2, 1] = "categorythree";
            wikiArray[3, 1] = "categoryfour";

            wikiArray[0, 2] = "structureone";
            wikiArray[1, 2] = "structureetwo";
            wikiArray[2, 2] = "structurethree";
            wikiArray[3, 2] = "structurefour";

            wikiArray[0, 3] = "definitionone";
            wikiArray[1, 3] = "definitiontwo";
            wikiArray[2, 3] = "definitionthree";
            wikiArray[3, 3] = "definitionfour";
            counter += 4;
            DisplayArray();
        }
        #endregion

        #region Button Save
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            BinaryWriter bw;
            try
            {
                bw = new BinaryWriter(new FileStream("definitions.dat", FileMode.Create));
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot append to file.");
                return;
            }
            try
            {
                for (int i = 0; i < counter; i++)
                {
                    bw.Write(wikiArray[i, 0]);
                    bw.Write(wikiArray[i, 1]);
                    bw.Write(wikiArray[i, 2]);
                    bw.Write(wikiArray[i, 3]);
                }
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot write data to file.");
                return;
            }
            bw.Close();
        }
        #endregion

        #region Button Load
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            BinaryReader br;
            int x = 0;
            listViewOne.Items.Clear();
            try
            {
                br = new BinaryReader(new FileStream("definitions.dat", FileMode.Open));
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot open file for reading");
                return;
            }
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                try
                {
                    wikiArray[x, 0] = br.ReadString();
                    wikiArray[x, 1] = br.ReadString();
                    wikiArray[x, 2] = br.ReadString();
                    wikiArray[x, 3] = br.ReadString();
                    x++;
                }
                catch (Exception fe)
                {
                    MessageBox.Show("Cannot read data from file or EOF" + fe);
                    break;
                }
                counter = x;
                DisplayArray();
            }
            br.Close();
        }
        #endregion


    }
}

