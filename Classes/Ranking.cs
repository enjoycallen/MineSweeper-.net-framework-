using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public class Ranking
    {
        public List<Record> records { get; set; }

        public Ranking()
        {
            records = new List<Record>();
        }

        public Ranking(List<Record> records)
        {
            this.records = records;
        }

        public void Add(Record record)
        {
            records.Add(record);
            records.Sort();
            if (records.Count > 5)
            {
                records.Remove(records.Last());
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < records.Count; ++i)
            {
                str += (i + 1) + "\t" + records[i].ToString() + "\n";
            }
            return str;
        }
    }
}
