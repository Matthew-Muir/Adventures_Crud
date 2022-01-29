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
        public Form1()
        {
            InitializeComponent();
            var test = "abc";
        }


        private void viewDataButton_Click(object sender, EventArgs e)
        {
            
            var selectedTable = databaseTablesDropDown.Text;
            selectedTable = selectedTable.Replace(" ", "");
            //add logic to prevent refetch if same table is selected
            if(selectedTable != "")
            {
                SqlDataAdapter da = new SqlDataAdapter($"EXEC  GetReadOnly{selectedTable}", Properties.Settings.Default.Connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                input01.Enabled = false;

                var foo = dataGridView1.Columns;
                UpdateFieldsAndLabels(foo);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateFieldsAndLabels();
        }

        private void UpdateFieldsAndLabels(DataGridViewColumnCollection cc = null)
        {
            
            LabelInputPair[] array = new LabelInputPair[] { new LabelInputPair(input01,inputLabel01),new LabelInputPair(input02, inputLabel02), new LabelInputPair(input03, inputLabel03), new LabelInputPair(input04, inputLabel04), new LabelInputPair(input05, inputLabel05), new LabelInputPair(input06, inputLabel06), new LabelInputPair(input07, inputLabel07), new LabelInputPair(input08, inputLabel08), new LabelInputPair(input09, inputLabel09), new LabelInputPair(input10, inputLabel10), new LabelInputPair(input11, inputLabel11), new LabelInputPair(input12, inputLabel12), new LabelInputPair(input13, inputLabel13), new LabelInputPair(input14, inputLabel14), new LabelInputPair(input15, inputLabel15), new LabelInputPair(input16, inputLabel16), new LabelInputPair(input17, inputLabel17) };
            
            if(cc == null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].LabelField.Text = "...";
                    array[i].Textbox.Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < cc.Count; i++)
                {
                    array[i].LabelField.Text = cc[i].HeaderText;
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
