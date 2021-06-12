using System;
using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using CsvHelper.Configuration.Attributes;

namespace Laba_15
{
    public class Data
    {
        public class Record
        {
            [Index(0)] public string Day { get; set; }
            [Index(1)] public int Temperature { get; set; }
            [Index(2)] public bool Deleted { get; set; }
        }

        public Data(string pathCsvFile)
        {
            _pathCsvFile = pathCsvFile;
            using StreamReader streamReader = new StreamReader(pathCsvFile);
            using CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            _records = csvReader.GetRecords<Record>().ToList();
            foreach (Record record in Records)
            {
                string[] s = record.Day.Split('|');
                _dateTimes.Add(new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2])));
            }
        }

        public Data()
        {
        }

        private List<Record> _records = new List<Record>();

        public List<Record> Records
        {
            get => _records;
            set => _records = value;
        }

        private List<DateTime> _dateTimes = new List<DateTime>();

        public List<DateTime> DateTimes
        {
            get => _dateTimes;
            set => _dateTimes = value;
        }

        private string _pathCsvFile;
        public string PathCsvFile => _pathCsvFile;

        public void SaveToCsv(string pathCsvFile)
        {
            using var writer = new StreamWriter(pathCsvFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(Records);
            _pathCsvFile = pathCsvFile;
        }
    }
}