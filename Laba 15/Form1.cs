using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Laba_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            this.openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            this.saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            this.saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            this.averageToolStripMenuItem.Click += averageToolStripMenuItem_Click;
            this.negativeToolStripMenuItem.Click += negativeToolStripMenuItem_Click;
            this.recoverDeletedToolStripMenuItem.Click += recoverDeletedToolStripMenuItem_Click;
            LoadDataFromRecords();
        }

        private Logging logging = new Logging(Logging.Level.DEBUG, "lb15.log");

        private void averageToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("averageToolStripMenuItem_Click");
            Dictionary<int, List<int>> dictionary = new();
            if (SaveTest(out var deleted, out var duplicates, true))
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    if (dataGridViewRow.Index != dataGridView1.Rows.Count - 1 && dataGridViewRow.Visible)
                    {
                        int x = data.DateTimes[dataGridViewRow.Index].DayOfYear -
                                (int)data.DateTimes[dataGridViewRow.Index].DayOfWeek;
                        if (x < 0)
                            x = 0;
                        int key = data.DateTimes[dataGridViewRow.Index].Year * 1000 + x;
                        if (!dictionary.ContainsKey(key))
                            dictionary.Add(key, new());
                        dictionary[key].Add(int.Parse(dataGridViewRow.Cells["Temperature"].Value.ToString()));
                    }
                }

                string s = "";
                var list = dictionary.Keys.ToList();
                list.Sort();
                foreach (int key in list)
                {
                    double average = Math.Round((double)dictionary[key].Sum() / dictionary[key].Count, 2);
                    int year = key / 1000;
                    int week = (key - year * 1000) / 7 + 1;
                    s += $"The average temperature in the {week} week of {year} is {average} degrees, " +
                         $"based on data for {dictionary[key].Count} days\n";
                }

                if (s != "")
                {
                    s = s.Remove(s.Length - 1);
                    MessageBox.Show(s, "Average temperature by week",
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("negativeToolStripMenuItem_Click");
            if (SaveTest(out var deleted, out var duplicates, true))
            {
                Dictionary<DateTime, int> dictionary = new Dictionary<DateTime, int>();
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    if (dataGridViewRow.Index != dataGridView1.Rows.Count - 1 && dataGridViewRow.Visible)
                        dictionary.Add(data.DateTimes[dataGridViewRow.Index],
                            int.Parse(dataGridViewRow.Cells["Temperature"].Value.ToString()));
                }

                var list = dictionary.Keys.ToList();
                list.Sort();
                var negativesTemperatures = list.Where(x => dictionary[x] < 0).ToList();
                if (negativesTemperatures.Count < 2)
                {
                    MessageBox.Show("Less than 2 days with negative temperatures",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int t = 0;
                DateTime start = negativesTemperatures[0];
                DateTime bestStart = default;
                DateTime end = default;
                bool first = true;
                bool previousPositive = true;
                foreach (DateTime dateTime in list)
                {
                    if (dictionary[dateTime] < 0)
                    {
                        if ((dateTime.Date - start).Days > t && previousPositive)
                        {
                            t = (dateTime.Date - start).Days;
                            bestStart = start;
                            end = dateTime;
                        }

                        previousPositive = false;
                        first = true;
                    }
                    else
                    {
                        if (first)
                        {
                            start = dateTime.Date;
                            first = false;
                        }

                        previousPositive = true;
                    }
                }

                MessageBox.Show($"The longest period without negative temperatures is {t} days\n" +
                                $"From {bestStart.ToShortDateString()} to {end.ToShortDateString()}",
                    "The longest period without negative temperatures",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void recoverDeletedToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("recoverDeletedToolStripMenuItem_Click");
            var f = new Form3(dataGridView1);
            f.ShowDialog();
        }

        private Data data = new Data();

        private bool _changedWithoutSaving = false;

        private void LoadDataFromRecords()
        {
            logging.DEBUG("LoadDataFromRecords");
            dataGridView1.Rows.Clear();
            if (data.Records.Count > 0)
                dataGridView1.Rows.Add(data.Records.Count);
            int i = 0;
            int j = 1;
            foreach (Data.Record record in data.Records)
            {
                string[] s = record.Day.Split('|');
                dataGridView1.Rows[i].Cells["Day"].Value = data.DateTimes[i].ToShortDateString();
                dataGridView1.Rows[i].Cells["Temperature"].Value = record.Temperature.ToString();
                dataGridView1.Rows[i].Visible = !record.Deleted;
                if (!record.Deleted)
                {
                    dataGridView1.Rows[i].Cells["index"].Value = j;
                    j++;
                }
                i++;
            }
            if (dataGridView1.Rows.Count > i)
                dataGridView1.Rows[i].Cells["index"].Value = j;
        }

        private void DeleteRow(int index)
        {
            logging.INFO($"DeleteRow {index}");
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows.Count != 1)
                _changedWithoutSaving = true;
            ReloadIndex();
        }

        private void EditDayClick(int index)
        {
            logging.DEBUG("EditDayClick");
            if (index == dataGridView1.Rows.Count - 1)
                dataGridView1.Rows.Add();
            while (dataGridView1.Rows.Count > data.DateTimes.Count + 1)
                data.DateTimes.Add(default);
            var f = new EditDay(index, data.DateTimes);
            f.ShowDialog();
            for (int i = 0; i < data.DateTimes.Count; i++)
            {
                if (data.DateTimes[i] != default(DateTime))
                    dataGridView1.Rows[i].Cells["Day"].Value = data.DateTimes[i].ToShortDateString();
            }
        }

        private void ReloadIndex()
        {
            logging.DEBUG("ReloadIndex");
            int i = 1;
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if (dataGridViewRow.Visible)
                {
                    dataGridViewRow.Cells["index"].Value = i;
                    i++;
                }
            }
        }

        private void DataGridViewToRecords(List<int> deleted)
        {
            logging.DEBUG("DataGridViewToRecords");
            data.Records = new List<Data.Record>();
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if (dataGridViewRow.Index < dataGridView1.Rows.Count - 1 &&
                    !deleted.Contains(dataGridViewRow.Index))
                {
                    data.Records.Add(new Data.Record
                    {
                        Deleted = !dataGridViewRow.Visible,
                        Temperature = int.Parse(dataGridViewRow.Cells["Temperature"].Value.ToString()),
                        Day = $"{data.DateTimes[dataGridViewRow.Index].Year}|" +
                              $"{data.DateTimes[dataGridViewRow.Index].Month}|" +
                              $"{data.DateTimes[dataGridViewRow.Index].Day}"
                    });
                }
            }
        }

        private (List<int> Days, List<int> Temperatures, List<int> Deleted, List<int> Duplicates) TestDataGridView()
        {
            logging.DEBUG("TestDataGridView");
            List<int> days = new List<int>();
            List<int> temperatures = new List<int>();
            List<int> deleted = new List<int>();
            List<int> duplicates = new List<int>();
            List<DateTime> dateTimes = new();
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if (dataGridViewRow.Visible && dataGridViewRow.Index < dataGridView1.Rows.Count - 1)
                    dateTimes.Add(data.DateTimes[dataGridViewRow.Index]);
            }

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if (dataGridViewRow.Index < dataGridView1.Rows.Count - 1)
                {
                    if (dataGridViewRow.Cells["Day"].Value == null ||
                        dataGridViewRow.Cells["Day"].Value.ToString() == "")
                        if (dataGridViewRow.Visible)
                            days.Add(dataGridViewRow.Index);
                        else
                            deleted.Add(dataGridViewRow.Index);
                    else if (dateTimes.Count(x => x.Date == data.DateTimes[dataGridViewRow.Index].Date) > 1)
                        if (dataGridViewRow.Visible)
                            duplicates.Add(dataGridViewRow.Index);
                    if (dataGridViewRow.Cells["Temperature"].Value == null ||
                        dataGridViewRow.Cells["Temperature"].Value.ToString() == "")
                        if (dataGridViewRow.Visible)
                            temperatures.Add(dataGridViewRow.Index);
                        else
                            deleted.Add(dataGridViewRow.Index);
                    else if (!int.TryParse(dataGridViewRow.Cells["Temperature"].Value.ToString(), out var x))
                        temperatures.Add(dataGridViewRow.Index);
                }
            }

            return (days, temperatures, deleted, duplicates);
        }

        private bool SaveTest(out List<int> deleted, out List<int> duplicates, bool duplicatesIsError = false)
        {
            logging.DEBUG("SaveTest");
            var c = TestDataGridView();
            deleted = c.Deleted;
            duplicates = c.Duplicates;
            var s = "";
            var dup = "";
            if (c.Days.Count > 0)
            {
                s += "Check records of days in rows under numbers: ";
                foreach (int cDay in c.Days)
                {
                    s += dataGridView1.Rows[cDay].Cells["index"].Value.ToString() + ", ";
                }

                s = s.Remove(s.Length - 1);
                s = s.Remove(s.Length - 1);
            }

            if (c.Temperatures.Count > 0)
            {
                if (s != "")
                    s += "\n";
                s += "Check records of temperatures in rows under numbers: ";
                foreach (int cTemperatures in c.Temperatures)
                {
                    s += dataGridView1.Rows[cTemperatures].Cells["index"].Value.ToString() + ", ";
                }

                s = s.Remove(s.Length - 1);
                s = s.Remove(s.Length - 1);
            }

            if (c.Duplicates.Count > 0)
            {
                dup += "Check records of days in rows under numbers (duplicates): ";
                foreach (int cDuplicates in c.Duplicates)
                {
                    dup += dataGridView1.Rows[cDuplicates].Cells["index"].Value.ToString() + ", ";
                }

                dup = dup.Remove(dup.Length - 1);
                dup = dup.Remove(dup.Length - 1);
            }
            if (duplicatesIsError)
            {
                if (s != "")
                    s += "\n";
                s += dup;
            }
            if (s != "")
                MessageBox.Show(s, "Save error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!duplicatesIsError && dup != "")
                MessageBox.Show(dup, "Save error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return s == "";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("newToolStripMenuItem_Click");
            if (_changedWithoutSaving)
                if (MessageBox.Show("Are you sure you want to exit without saving?", "Save",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
            data = new Data();
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = true;
            Debug.Print(data.GetHashCode().ToString());
            LoadDataFromRecords();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("openToolStripMenuItem_Click");
            if (_changedWithoutSaving)
                if (MessageBox.Show("Are you sure you want to exit without saving?", "Save",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    logging.DEBUG("ChangedWithoutSaving");
                    return;
                }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Data vremdata;
                Debug.Print($"Open {openFileDialog1.FileName}");
                try
                {
                    vremdata = new Data(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("Failed to read file", "Failed to read file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (vremdata.Records.Count < 1)
                    MessageBox.Show("File is empty", "File is empty",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    data = vremdata;
                    saveToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                    LoadDataFromRecords();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("saveToolStripMenuItem_Click");
            if (SaveTest(out var deleted, out var duplicates))
            {
                DataGridViewToRecords(deleted);
                try
                {
                    data.SaveToCsv(data.PathCsvFile);
                    _changedWithoutSaving = false;
                }
                catch
                {
                    MessageBox.Show("Failed to save file", "Failed to save file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("saveAsToolStripMenuItem_Click");
            if (SaveTest(out var deleted, out var duplicates))
            {
                DataGridViewToRecords(deleted);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        data.SaveToCsv(saveFileDialog1.FileName);
                        saveToolStripMenuItem.Enabled = true;
                        _changedWithoutSaving = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to save file", "Failed to save file",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs args)
        {
            logging.INFO("exitToolStripMenuItem_Click");
            if (_changedWithoutSaving)
                if (MessageBox.Show("Are you sure you want to exit without saving?", "Save",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    logging.DEBUG("ChangedWithoutSaving");
                    this.Close();
                }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logging.INFO("Form1_FormClosing");
            if (_changedWithoutSaving)
                if (MessageBox.Show("Are you sure you want to exit without saving?", "Save",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    logging.DEBUG("ChangedWithoutSaving");
                    e.Cancel = true;
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            logging.INFO("dataGridView1_CellContentClick");
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex < dataGridView1.Rows.Count - 1)
                DeleteRow(e.RowIndex);
            else if (e.ColumnIndex == dataGridView1.Columns["EditDay"].Index)
                EditDayClick(e.RowIndex);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            logging.INFO("dataGridView1_UserDeletingRow");
            e.Cancel = true;
            DeleteRow(e.Row.Index);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            logging.INFO("dataGridView1_RowsAdded");
            if (dataGridView1.Rows.Count != 1)
                _changedWithoutSaving = true;
            ReloadIndex();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            logging.INFO("dataGridView1_CurrentCellChanged");
            if (dataGridView1.Rows.Count != 1)
                _changedWithoutSaving = true;
        }
    }
}