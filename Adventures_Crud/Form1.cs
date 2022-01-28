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
        }


        private void viewDataButton_Click(object sender, EventArgs e)
        {
            
            var selectedTable = databaseTablesDropDown.Text;
            selectedTable = selectedTable.Replace(" ", "");
            if(selectedTable != "")
            {
                SqlDataAdapter da = new SqlDataAdapter($"EXEC  GetReadOnly{selectedTable}", Properties.Settings.Default.Connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox1.Enabled = false;
                /*
                 Create multiple fields to match columns for editable tables. 
                When one table is selected update those fields and their labels.
                 */
            }

        }

    }
}

/*
 * databaseTablesDropDown
 * tableSelectLabel
 * viewDataButton
 */
