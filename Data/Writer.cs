using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Writer : BinaryWriter
    {
        public Writer() : base(new FileStream(Properties.Resources.ArchiveFile, FileMode.Open)) { }

        public void WriteShape(Shape shape)
        {
            Write(shape.row);
            Write(shape.col);
        }

        public void WritePostion(Position position)
        {
            Write(position.row);
            Write(position.col);
        }

        public void WriteSetting(Setting setting)
        {
            Write((int)setting.level);
            WriteShape(setting.shape);
            Write(setting.mine_count);
        }

        public void WriteRecord(Record record)
        {
            Write(record.player_name);
            Write(record.time);
            Write(record.date.Ticks);
        }

        public void WriteRanking(Ranking ranking)
        {
            Write(ranking.records.Count);
            ranking.records.ForEach(x => WriteRecord(x));
        }

        public void WriteGrid(Grid grid)
        {
            WritePostion(grid.position);
            Write((int)grid.type);
            Write((int)grid.state);
        }

        public void WriteGame(Game game)
        {
            WriteSetting(game.setting);
            foreach(var grid in game.plane)
            {
                WriteGrid(grid);
            }
            Write(game.started);
            Write(game.time);
        }
    }
}
