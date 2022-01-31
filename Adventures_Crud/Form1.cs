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
        DbTable[] dbTables = new DbTable[] {new DbTable("Product",true), new DbTable("Product Model",true), new DbTable("Product Description",true), new DbTable("Product Model Product Description",true), new DbTable("Customer",false) };

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
                //LEFT OFF HERE!!! Need to create Proc at accepts any name and returns the table.
                SqlDataAdapter da = new SqlDataAdapter($"EXEC  GetReadOnly{formattedTableName}", Properties.Settings.Default.Connection);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];

                var listOfColumns = dataGridView1.Columns;
                UpdateFieldsAndLabels(listOfColumns, selectedTable);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateFieldsAndLabels();
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
    }
}

/*
 * databaseTablesDropDown
 * tableSelectLabel
 * viewDataButton
 */
