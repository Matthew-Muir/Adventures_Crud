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
        DbTable[] dbTables = new DbTable[] {new DbTable("Product",true), new DbTable("Product Model",true), new DbTable("Product Description",true), new DbTable("Product Model Product Description",true), new DbTable("Customer",false), new DbTable("Address",false,true), new DbTable("Customer Address",false,true)};

        public Form1()
        {
            InitializeComponent();
            databaseTablesDropDown.DataSource = dbTables;
            
        }


        private void viewDataButton_Click(object sender, EventArgs e)
        {
            //Grab table name from dropdown
            DbTable selectedTable = (DbTable)databaseTablesDropDown.SelectedItem;
            var formattedTableName = selectedTable.Name.Replace(" ", "");
            

            //Push data to data grid & update labels and text boxes
            if(formattedTableName != "")
            {
                
                SqlDataAdapter da = new SqlDataAdapter($"EXEC  GetTable{formattedTableName}", Properties.Settings.Default.Connection);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];

                var listOfColumns = dataGridView1.Columns;
                UpdateFieldsAndLabels(listOfColumns, selectedTable);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateFieldsAndLabels();
            
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

        private void UpdateFieldsAndLabels(DataGridViewColumnCollection cc = null, DbTable selectedTable = null)
        {
            //list of all labels and text areas on form1
            LabelInputPair[] array = new LabelInputPair[] { new LabelInputPair(input01,inputLabel01),new LabelInputPair(input02, inputLabel02), new LabelInputPair(input03, inputLabel03), new LabelInputPair(input04, inputLabel04), new LabelInputPair(input05, inputLabel05), new LabelInputPair(input06, inputLabel06), new LabelInputPair(input07, inputLabel07), new LabelInputPair(input08, inputLabel08), new LabelInputPair(input09, inputLabel09), new LabelInputPair(input10, inputLabel10), new LabelInputPair(input11, inputLabel11), new LabelInputPair(input12, inputLabel12), new LabelInputPair(input13, inputLabel13), new LabelInputPair(input14, inputLabel14), new LabelInputPair(input15, inputLabel15), new LabelInputPair(input16, inputLabel16), new LabelInputPair(input17, inputLabel17) };
            
            //set labels text. Turn ON/OFF fields.
            if(cc == null && selectedTable == null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].LabelField.Text = "...";
                    array[i].Textbox.Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if(i < cc.Count)
                    {
                        array[i].LabelField.Text = cc[i].HeaderText;
                        array[i].Textbox.Enabled = !selectedTable.ReadOnly;
                    }
                    else
                    {
                        array[i].LabelField.Text = "...";
                        array[i].Textbox.Enabled = false;
                    }
                    
                }
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tableSelectLabel_Click(object sender, EventArgs e)
        {

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
            //LEFT OFF HERE!!! Create EditAddress proc and deploy!
        }
    }
}

/*
 * databaseTablesDropDown
 * tableSelectLabel
 * viewDataButton
 */
