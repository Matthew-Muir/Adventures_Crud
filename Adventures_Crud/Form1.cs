using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Adventures_Crud
{
    public partial class Form1 : Form
    {
        //collection of accessible tables.
        DbTable[] dbTables = new DbTable[] {
            new DbTable("Product",true),
            new DbTable("Product Model",true),
            new DbTable("Product Description",true),
            new DbTable("Product Model Product Description",true),
            new DbTable("Customer",false,editIndexes: new int[]{1,2,3}),
            new DbTable("Address",false,true),
            new DbTable("Customer Address",false,true)
        };

        Modes currentMode = Modes.View;

        private DbTable GetCurrentTable()
        {
            DbTable selectedTable = (DbTable)databaseTablesDropDown.SelectedItem;
            return selectedTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateFieldsAndLabels();
        }

        public Form1()
        {
            InitializeComponent();
            //Set data for drop down
            databaseTablesDropDown.DataSource = dbTables;
            //Event for when dropwdown selection changes.
            databaseTablesDropDown.SelectedIndexChanged += new System.EventHandler(dataBaseTablesDropDown_SelectedIndexChanged);
            
        }


        private void viewDataButton_Click(object sender, EventArgs e)
        {
            //Grab table name from dropdown
            DbTable selectedTable = (DbTable)databaseTablesDropDown.SelectedItem;
            var formattedTableName = selectedTable.Name.Replace(" ", "");


            //Push data to data grid & update labels and text boxes
            if (formattedTableName != "")
            {

                SqlDataAdapter da = new SqlDataAdapter($"EXEC  GetTable{formattedTableName}", Properties.Settings.Default.Connection);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                currentMode = Modes.View;
                if (selectedTable.ReadOnly)
                {
                    deleteDataButton.Enabled = false;
                    addDataButton.Enabled = false;
                    editDataButton.Enabled = false;
                }
                else
                {
                    deleteDataButton.Enabled = true;
                    addDataButton.Enabled = true;
                    editDataButton.Enabled = true;
                }
            }

        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            //Grab table name from dropdown
            DbTable selectedTable = (DbTable)databaseTablesDropDown.SelectedItem;
            LabelInputPair[] array = new LabelInputPair[] { new LabelInputPair(input01, inputLabel01), new LabelInputPair(input02, inputLabel02), new LabelInputPair(input03, inputLabel03), new LabelInputPair(input04, inputLabel04), new LabelInputPair(input05, inputLabel05), new LabelInputPair(input06, inputLabel06), new LabelInputPair(input07, inputLabel07), new LabelInputPair(input08, inputLabel08), new LabelInputPair(input09, inputLabel09), new LabelInputPair(input10, inputLabel10), new LabelInputPair(input11, inputLabel11), new LabelInputPair(input12, inputLabel12), new LabelInputPair(input13, inputLabel13), new LabelInputPair(input14, inputLabel14), new LabelInputPair(input15, inputLabel15), new LabelInputPair(input16, inputLabel16), new LabelInputPair(input17, inputLabel17) };
            var addToTableProcString = selectedTable.AddtoTableProc(array);
            SqlDataAdapter da = new SqlDataAdapter(addToTableProcString, Properties.Settings.Default.Connection);
            DataSet dataSet = new DataSet();
            Console.WriteLine(addToTableProcString);

            da.Fill(dataSet);
            MessageBox.Show($"Add to {selectedTable.Name} Successful!");




        }

        private void UpdateFieldsAndLabels(DataGridViewColumnCollection cc = null, int[] indexArray = null)
        {
            //list of all labels and text areas on form1
            LabelInputPair[] array = new LabelInputPair[] { 
                new LabelInputPair(input01, inputLabel01), 
                new LabelInputPair(input02, inputLabel02), 
                new LabelInputPair(input03, inputLabel03), 
                new LabelInputPair(input04, inputLabel04), 
                new LabelInputPair(input05, inputLabel05), 
                new LabelInputPair(input06, inputLabel06), 
                new LabelInputPair(input07, inputLabel07), 
                new LabelInputPair(input08, inputLabel08), 
                new LabelInputPair(input09, inputLabel09), 
                new LabelInputPair(input10, inputLabel10), 
                new LabelInputPair(input11, inputLabel11), 
                new LabelInputPair(input12, inputLabel12), 
                new LabelInputPair(input13, inputLabel13), 
                new LabelInputPair(input14, inputLabel14), 
                new LabelInputPair(input15, inputLabel15), 
                new LabelInputPair(input16, inputLabel16), 
                new LabelInputPair(input17, inputLabel17)
            };


                //Turn off all fields and labels.
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].LabelField.Text = "...";
                    array[i].Textbox.Enabled = false;
                }
                if(indexArray!= null)
            {
                foreach (var index in indexArray)
                {
                    array[index].LabelField.Text = cc[index].HeaderText;
                    array[index].Textbox.Enabled = true;
                }
            }




                //for (int i = 0; i < array.Length; i++)
                //{
                //    if (i < cc.Count)
                //    {
                //        array[i].LabelField.Text = cc[i].HeaderText;
                //        array[i].Textbox.Enabled = !selectedTable.ReadOnly;
                //    }
                //    else
                //    {
                //        array[i].LabelField.Text = "...";
                //        array[i].Textbox.Enabled = false;
                //    }

                //}
            

        }

        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            //Grab table name from dropdown
            DbTable selectedTable = (DbTable)databaseTablesDropDown.SelectedItem;
            LabelInputPair[] array = new LabelInputPair[] { new LabelInputPair(input01, inputLabel01), new LabelInputPair(input02, inputLabel02), new LabelInputPair(input03, inputLabel03), new LabelInputPair(input04, inputLabel04), new LabelInputPair(input05, inputLabel05), new LabelInputPair(input06, inputLabel06), new LabelInputPair(input07, inputLabel07), new LabelInputPair(input08, inputLabel08), new LabelInputPair(input09, inputLabel09), new LabelInputPair(input10, inputLabel10), new LabelInputPair(input11, inputLabel11), new LabelInputPair(input12, inputLabel12), new LabelInputPair(input13, inputLabel13), new LabelInputPair(input14, inputLabel14), new LabelInputPair(input15, inputLabel15), new LabelInputPair(input16, inputLabel16), new LabelInputPair(input17, inputLabel17) };
            var addToTableProcString = selectedTable.DeleteFromTableProc(array);
            SqlDataAdapter da = new SqlDataAdapter(addToTableProcString, Properties.Settings.Default.Connection);
            DataSet dataSet = new DataSet();
            Console.WriteLine(addToTableProcString);

            da.Fill(dataSet);
            // MessageBox.Show($"Add to {selectedTable.Name} Successful!");
        }

        private void editDataButton_Click(object sender, EventArgs e)
        {
            var table = GetCurrentTable();

            if (currentMode != Modes.Edit)
            {
                var cc = dataGridView1.Columns;
                UpdateFieldsAndLabels(cc, table.EditIndexes);
            }
            else
            {
                //LEFT OFF HERE!!! Pass values from fields into PROC.
                SqlDataAdapter da = new SqlDataAdapter($"EXEC  GetTable{table.ToString(true)}", Properties.Settings.Default.Connection);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
            }
            currentMode = Modes.Edit;
        }

        private void UpdateButtons(Modes mode)
        {
            switch (mode)
            {
                case Modes.View:
                    deleteDataButton.Enabled = false;
                    addDataButton.Enabled = false;
                    editDataButton.Enabled = false;
                    break;
                case Modes.Edit:
                    editDataButton.Enabled = true;
                    deleteDataButton.Enabled = false;
                    addDataButton.Enabled = false;
                    break;
                case Modes.Add:
                    addDataButton.Enabled = true;
                    editDataButton.Enabled = false;
                    deleteDataButton.Enabled = false;
                    break;
                case Modes.Delete:
                    deleteDataButton.Enabled = true;
                    editDataButton.Enabled = false;
                    addDataButton.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        private void DisableButtons()
        {
            editDataButton.Enabled = false;
            deleteDataButton.Enabled = false;
            addDataButton.Enabled = false;
        }



        private void dataBaseTablesDropDown_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            DisableButtons();
            UpdateFieldsAndLabels();

        }



    }
}

