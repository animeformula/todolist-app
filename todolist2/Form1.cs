using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todolist2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable todolist = new DataTable();
        bool isEditing = false;

        private void NewBtn_Click(object sender, EventArgs e)
        {
            TitleText.Text = "";
            DiscriptionText.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            todolist.Columns.Add("Title");
            todolist.Columns.Add("Discription");

            todolistgrid.DataSource = todolist;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            isEditing = true;

            TitleText.Text = todolist.Rows[todolistgrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            DiscriptionText.Text = todolist.Rows[todolistgrid.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                todolist.Rows[todolistgrid.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todolist.Rows[todolistgrid.CurrentCell.RowIndex]["Title"] = TitleText.Text;
                todolist.Rows[todolistgrid.CurrentCell.RowIndex]["Discription"] = DiscriptionText.Text;
            }
            else
            {
                todolist.Rows.Add(TitleText.Text, DiscriptionText.Text);
            }
            TitleText.Text = "";
            DiscriptionText.Text = "";
            isEditing = false;
        }
    }
}
