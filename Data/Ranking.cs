using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Ranking
    {
        public List<Record> records;

        public Ranking(List<Record> records)
        {
            this.records = records;
        }

        public override string ToString()
        {
            string str = "";
            for(int i=0; i < records.Count; ++i)
            {
                str += (i + 1) + "\t" + records[i].ToString() + "\n";
            }
            return str;
        }
    }
}
