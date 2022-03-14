
namespace Wiki_Prototype_Application
{
    partial class WikiPrototypeApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxOne = new System.Windows.Forms.TextBox();
            this.listBoxOne = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.textBoxStructure = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStripOne = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(24, 13);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(136, 51);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(168, 13);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(136, 51);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(24, 75);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(136, 51);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(508, 346);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(170, 59);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBoxOne
            // 
            this.textBoxOne.Location = new System.Drawing.Point(324, 15);
            this.textBoxOne.Name = "textBoxOne";
            this.textBoxOne.Size = new System.Drawing.Size(229, 20);
            this.textBoxOne.TabIndex = 4;
            // 
            // listBoxOne
            // 
            this.listBoxOne.FormattingEnabled = true;
            this.listBoxOne.Location = new System.Drawing.Point(324, 56);
            this.listBoxOne.Name = "listBoxOne";
            this.listBoxOne.Size = new System.Drawing.Size(354, 277);
            this.listBoxOne.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(559, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(119, 23);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(324, 346);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(170, 59);
            this.buttonLoad.TabIndex = 8;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(168, 75);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(136, 51);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(95, 160);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(209, 20);
            this.textBoxName.TabIndex = 10;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(95, 200);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(209, 20);
            this.textBoxCategory.TabIndex = 11;
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(95, 280);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(209, 126);
            this.textBoxDefinition.TabIndex = 13;
            // 
            // textBoxStructure
            // 
            this.textBoxStructure.Location = new System.Drawing.Point(95, 240);
            this.textBoxStructure.Name = "textBoxStructure";
            this.textBoxStructure.Size = new System.Drawing.Size(209, 20);
            this.textBoxStructure.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Structure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Definition";
            // 
            // statusStripOne
            // 
            this.statusStripOne.Location = new System.Drawing.Point(0, 422);
            this.statusStripOne.Name = "statusStripOne";
            this.statusStripOne.Size = new System.Drawing.Size(720, 22);
            this.statusStripOne.TabIndex = 19;
            this.statusStripOne.Text = "statusStrip1";
            // 
            // WikiPrototypeApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 444);
            this.Controls.Add(this.statusStripOne);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStructure);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxOne);
            this.Controls.Add(this.textBoxOne);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Name = "WikiPrototypeApplication";
            this.Text = "Wiki Prototype Application";
            this.Load += new System.EventHandler(this.WikiPrototypeApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxOne;
        private System.Windows.Forms.ListBox listBoxOne;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.TextBox textBoxStructure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStripOne;
    }
}

