using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laba_15
{
    public partial class EditDay : Form
    {
        public EditDay(int index, List<DateTime> dateTimes)
        {
            InitializeComponent();
            this.index = index;
            this.dateTimes = dateTimes;
        }

        private int index;
        private List<DateTime> dateTimes;

        private void OK_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != default(DateTime))
                dateTimes[index] = dateTimePicker1.Value;
            else
                dateTimes[index] = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day, 0, 58, 0);
            Close();
        }

        private void EditDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                OK_Click(sender, e);
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                OK_Click(sender, e);
        }
    }
}