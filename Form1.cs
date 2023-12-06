using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FLA7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void studentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dbDataDataSet);
            imgPic.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.dbDataDataSet.Students);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico|All Files|*.*";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                imgPic.Image = Image.FromFile(file.FileName);
                pictureTextBox.Text = file.FileName;
            }
        }

        private void studentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = studentsDataGridView.Rows[e.RowIndex];

                    studentIdTextBox.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                    firstNameTextBox.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    lastNameTextBox.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                    courseTextBox.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                    yearLevelTextBox.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                    pictureTextBox.Text = selectedRow.Cells[5].Value?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(pictureTextBox.Text))
                    {
                        imgPic.Image = Image.FromFile(pictureTextBox.Text);
                    }
                    else
                    {
                        imgPic.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
