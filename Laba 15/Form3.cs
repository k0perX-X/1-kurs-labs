using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laba_15
{
    public partial class Form3 : Form
    {
        public Form3(DataGridView dataGridViewOriginal)
        {
            InitializeComponent();
            this.dataGridViewOriginal = dataGridViewOriginal;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn dgvc in dataGridViewOriginal.Columns)
            {
                dataGridView1.Columns.Add(dgvc.Clone() as DataGridViewColumn);
            }
            for (int i = 0; i < dataGridViewOriginal.Rows.Count; i++)
            {
                var row = (DataGridViewRow)dataGridViewOriginal.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dataGridViewOriginal.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }

                row.Visible = !row.Visible;
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.Columns["EditDay"].Visible = false;
            dataGridView1.Columns["Delete"].Visible = false;
            dataGridView1.Columns["index"].Visible = false;
            dataGridView1.Refresh();

            this.undoDelete = new DataGridViewButtonColumn();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Undo Delete";
            this.undoDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.undoDelete.HeaderText = "Undo Delete";
            this.undoDelete.Name = "undoDelete";
            this.undoDelete.ReadOnly = true;
            this.undoDelete.Resizable = DataGridViewTriState.False;
            this.undoDelete.Text = "undoDelete";
            this.undoDelete.ToolTipText = "undoDelete row";
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Columns.Add(undoDelete);
        }

        private DataGridView dataGridViewOriginal;
        private DataGridViewButtonColumn undoDelete;
        private List<int> undoList = new List<int>();

        private void OKButton_Click(object sender, EventArgs e)
        {
            foreach (int i in undoList)
            {
                dataGridViewOriginal.Rows[i].Visible = true;
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["undoDelete"].Index)
            {
                undoList.Add(e.RowIndex);
                dataGridView1.Rows[e.RowIndex].Visible = false;
            }
        }
    }
}