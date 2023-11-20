using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Record
    {
        public string player_name;
        public int time;
        public DateTime date;

        public Record(string player_name, int time, DateTime date)
        {
            this.player_name = player_name;
            this.time = time;
            this.date = date;
        }

        public override string ToString()
        {
            return player_name + "\t" + time + "\t" + date.ToString();
        }
    }
}