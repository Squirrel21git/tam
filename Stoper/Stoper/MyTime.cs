using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stoper
{
    public class MyTime
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LapTime { get; set; }

        public MyTime()
        { }

        public MyTime(string lapTime)
        {
            Date = DateTime.Today;
            LapTime = lapTime;
        }
    }
}
