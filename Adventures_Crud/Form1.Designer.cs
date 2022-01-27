
namespace Adventures_Crud
{
    partial class Form1
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
            this.viewDataButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.databaseTablesDropDown = new System.Windows.Forms.ComboBox();
            this.tableSelectLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // viewDataButton
            // 
            this.viewDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDataButton.Location = new System.Drawing.Point(221, 38);
            this.viewDataButton.Name = "viewDataButton";
            this.viewDataButton.Size = new System.Drawing.Size(75, 28);
            this.viewDataButton.TabIndex = 0;
            this.viewDataButton.Text = "View";
            this.viewDataButton.UseVisualStyleBackColor = true;
            this.viewDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1419, 521);
            this.dataGridView1.TabIndex = 1;
            // 
            // databaseTablesDropDown
            // 
            this.databaseTablesDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseTablesDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTablesDropDown.FormattingEnabled = true;
            this.databaseTablesDropDown.Items.AddRange(new object[] {
            "Product",
            "Product Model",
            "Product Category",
            "Product Description",
            "Product Model Product Description"});
            this.databaseTablesDropDown.Location = new System.Drawing.Point(12, 38);
            this.databaseTablesDropDown.Name = "databaseTablesDropDown";
            this.databaseTablesDropDown.Size = new System.Drawing.Size(203, 28);
            this.databaseTablesDropDown.TabIndex = 2;
            // 
            // tableSelectLabel
            // 
            this.tableSelectLabel.AutoSize = true;
            this.tableSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableSelectLabel.Location = new System.Drawing.Point(44, 15);
            this.tableSelectLabel.Name = "tableSelectLabel";
            this.tableSelectLabel.Size = new System.Drawing.Size(145, 20);
            this.tableSelectLabel.TabIndex = 3;
            this.tableSelectLabel.Text = "Database Tables";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 630);
            this.Controls.Add(this.tableSelectLabel);
            this.Controls.Add(this.databaseTablesDropDown);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.viewDataButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Adventures in CRUD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewDataButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox databaseTablesDropDown;
        private System.Windows.Forms.Label tableSelectLabel;
    }
}

