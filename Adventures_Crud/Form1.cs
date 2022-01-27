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

        private void button1_Click(object sender, EventArgs e)
        {
            var text = databaseTablesDropDown.Text;
            MessageBox.Show(text);
            //SqlDataAdapter da = new SqlDataAdapter("select * from SalesLT.Customer", Properties.Settings.Default.Connection);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

    }
}

/*
 * databaseTablesDropDown
 * tableSelectLabel
 * viewDataButton
 */
