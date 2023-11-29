using System;

namespace MineSweeper
{
    public class Record : IComparable<Record>
    {
        public string playerName { get; set; }
        public int time { get; set; }
        public DateTime date { get; set; }

        public Record(string playerName, int time, DateTime date)
        {
            this.playerName = playerName;
            this.time = time;
            this.date = date;
        }

        public int CompareTo(Record record)
        {
            return time < record.time || time == record.time && date > record.date ? -1 : 1;
        }

        public override string ToString()
        {
            return playerName + "\t" + time + "\t" + date.ToString();
        }
    }
}