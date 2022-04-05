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
        // 1) Create a global 2D string array, use static variables for the dimensions (row, column).
        #region Program attributes
        static int row = 12; //Maximum number of wiki entries
        static int column = 4; //Name, Category, Structure, Definition
        static String[,] wikiArray = new string[row, column];
        int counter = 0;
        #endregion
        // 2) Create an ADD button that will store the information from the 4 text boxes into the 2D array.
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
                        if (!CheckIsDuplicate())
                        {
                            wikiArray[counter, 0] = textBoxName.Text;
                            wikiArray[counter, 1] = textBoxCategory.Text;
                            wikiArray[counter, 2] = textBoxStructure.Text;
                            wikiArray[counter, 3] = textBoxDefinition.Text;
                            counter++;
                            toolStripStatusLabel.Text = "Item added successfully.";
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Error: item already exists.");
                            toolStripStatusLabel.Text = "Error: cannot add duplicate entries.";
                        }

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
        // 3) Create a CLEAR method to clear the four text boxes so a new definition can be added.
        #region Method Clear Fields
        // Method for clearing all text boxes and input text boxes
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
        // 4a) Write the code for a Bubble Sort method to sort the 2D array by Name ascending.
        #region Method Sort
        // Iterates through the array and utilises a comppare ordinal string method to sort it.
        public void BubbleSort()
        {
            for (int x = 0; x < row - 1; x++)
            {
                for (int i = 0; i < row - 1; i++)
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
        #endregion
        // 4b) Use a separate swap method that passes (by reference) the array element to be swapped (do not use any built-in array methods.
        #region Method Swap
        // Used for swapping the columns when called by the sort function
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
        /* 
         * 5) Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found.
         * Also, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods).
         */
        #region Button Search
        /* 
         * Each loop will utilise a string compare method to check the lexical value of the array's middle index name string versus the textbox input string
         * to determine whether to check the upper or lower bounds or if they are the same. This will repeat until the record is found or out of bounds.
         */
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
                // -1 if a precedes b, 0 if they are equal, 1 if a follows b
                if (string.Compare(wikiArray[newIndex, 0], textBoxOne.Text) == 0)
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
                MessageBox.Show("Item found.");
                toolStripStatusLabel.Text = "Item found at index " + foundIndex + ".";
            }
            else
            {
                MessageBox.Show("Item not found.");
                toolStripStatusLabel.Text = "Item not found.";
                ClearFields();
            }

        }
        #endregion
        // 6) Create a display method that will show the following information in a List box: Name and Category.
        #region Method Display Array
        // Creates a new list view item and adds Name, Category, Structure, Definition strings to it before displaying them in the array.
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
        // 7) Create a method so the user can select a definition (Name) from the Listbox and all the information is displayed in the appropriate Textboxes.
        #region Method List View Click
        private void listViewOne_Click(object sender, EventArgs e)
        {
            int selectedRecord = listViewOne.SelectedIndices[0];
            if (!string.Equals(wikiArray[selectedRecord, 0], "~")
                && (!string.Equals(wikiArray[selectedRecord, 1], "~")
                && !string.Equals(wikiArray[selectedRecord, 2], "~")
                && !string.Equals(wikiArray[selectedRecord, 3], "~")
                ))
            {
                textBoxName.Text = wikiArray[selectedRecord, 0];
                textBoxCategory.Text = wikiArray[selectedRecord, 1];
                textBoxStructure.Text = wikiArray[selectedRecord, 2];
                textBoxDefinition.Text = wikiArray[selectedRecord, 3];
            }
            else
            {
                textBoxName.Text = "";
                textBoxCategory.Text = "";
                textBoxStructure.Text = "";
                textBoxDefinition.Text = "";
            }

        }
        #endregion
        #region Button Clear
        // Calls the clear method on clear button click
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            toolStripStatusLabel.Text = "Fields cleared.";
        }
        #endregion
        // Sorts and then displays the array.
        #region Post Process Function 
        public void PostProcessFunction()
        {
            BubbleSort();
            DisplayArray();
        }
        #endregion
        // 8) Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is sorted by Name.
        #region Button Save
        //Creates a new binary writier object for writing items in the array to a stream to be saved to a file called defintions.dat.
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
                toolStripStatusLabel.Text = "File saved successfully.";
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message + "\n Cannot write data to file.");
                return;
            }
            bw.Close();
        }
        #endregion
        // 9) Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array.
        #region Button Load
        // Creates a new binary reader object to read the primitive data from a filestream calle definitions.dat and load them into the array.
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
                    toolStripStatusLabel.Text = "File loaded successfully.";
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
        // 11) Create an EDIT button that will read the information from the text boxes and write it over an existing record.
        #region Button Edit
        // 
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewOne.SelectedIndices[0];
                if (selectedRecord >= 0)
                {
                    if (!string.Equals(wikiArray[selectedRecord, 0], textBoxName.Text)
                        || !string.Equals(wikiArray[selectedRecord, 1], textBoxCategory.Text)
                        || !string.Equals(wikiArray[selectedRecord, 2], textBoxStructure.Text)
                        || !string.Equals(wikiArray[selectedRecord, 3], textBoxDefinition.Text)
                        )
                    {
                        var result = MessageBox.Show("Proceed with update?", "Edit Record",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            wikiArray[selectedRecord, 0] = textBoxName.Text;
                            wikiArray[selectedRecord, 1] = textBoxCategory.Text;
                            wikiArray[selectedRecord, 2] = textBoxStructure.Text;
                            wikiArray[selectedRecord, 3] = textBoxDefinition.Text;
                            toolStripStatusLabel.Text = "Item edited successfully.";
                            PostProcessFunction();
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("Error: no changes detected");
                        toolStripStatusLabel.Text = ("Item must have changes before editting.");
                    }

                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "Error: please select a valid item.";
                Console.WriteLine(ex);
            }

        }
        #endregion
        // 12) Create a DELETE button that will remove elements from the array.
        #region Method Delete
        // Checks there is a selected record and replaces object strings with a tilde key to faciliate sort function.
        private void DeleteMethod()
        {
            int currentRecord = listViewOne.SelectedIndices[0];
            if (currentRecord >= 0 && counter > 0 && !string.Equals(wikiArray[currentRecord, 0], "~"))
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
                    toolStripStatusLabel.Text = "Item deleted successfully.";
                }
                else
                {
                    MessageBox.Show("Item NOT Deleted", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Method Double-Click Delete
        // Deletes an object from the array when double clicked in the list box.
        private void ListViewOne_DoubleClick(object sender, EventArgs e)
        {
            DeleteMethod();
            PostProcessFunction();
        }
        #endregion
        #region Button Delete
        // Delete button method
        // Deletes the item at the selected index and shuffles the array up to fill it
        // Method ensures blank elements are shuffled to the end of the array
        private void ButtonDelete_Click(object sender, EventArgs e)
        {

            try
            {
                DeleteMethod();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select an item to delete.");
            }
            PostProcessFunction();
        }
        #endregion
        #region Data Partial Preload (Developmental)
        // Preloads data so for testing and demonstration purposes.
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
            PostProcessFunction();
        }
        #endregion
        #region Form Load Function
        // Fills empty array elements with tilde keys so when an object is deleted it is not the only record with tilde keys.
        private void WikiPrototypeApplication_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    wikiArray[i, j] = "~";
                }
            }
            PostProcessFunction();
        }
        #endregion
        #region Method Input Box Double Click Clear
        // Clears all fields when double clicking in the input textbox.
        private void textBoxOne_DoubleClick(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion
        #region Text Box Double Click Clear
        // Individual text box fields are cleared when double clicked inside of.
        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            textBoxName.Clear();
        }

        private void textBoxCategory_DoubleClick(object sender, EventArgs e)
        {
            textBoxCategory.Clear();
        }

        private void textBoxStructure_DoubleClick(object sender, EventArgs e)
        {
            textBoxStructure.Clear();
        }

        private void textBoxDefinition_DoubleClick(object sender, EventArgs e)
        {
            textBoxDefinition.Clear();
        }
        #endregion
        #region Check Duplicate
        // Method for checking if data entered already exists in the array. Returns true is duplicate and false if not.
        private bool CheckIsDuplicate()
        {
            bool duplicate = false;
            for (int i = 0; i < row; i++)
            {
                if (string.Equals(wikiArray[i, 0], textBoxName.Text)
                    && string.Equals(wikiArray[i, 1], textBoxCategory.Text)
                    && string.Equals(wikiArray[i, 2], textBoxStructure.Text)
                    && string.Equals(wikiArray[i, 3], textBoxDefinition.Text))
                {
                    duplicate = true;
                    break;
                }
                else
                {
                    duplicate = false;
                }
            }
            return duplicate;
        }
        #endregion
    }
}

