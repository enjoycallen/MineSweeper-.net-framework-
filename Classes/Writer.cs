using System.IO;

namespace MineSweeper
{
    public class Writer : BinaryWriter
    {
        public Writer() : base(new FileStream(Properties.Resources.Archive, FileMode.Open)) { }

        public void Write(Shape shape)
        {
            Write(shape.row);
            Write(shape.col);
        }

        public void Write(Position position)
        {
            Write(position.row);
            Write(position.col);
        }

        public void Write(Setting setting)
        {
            Write((int)setting.level);
            Write(setting.shape);
            Write(setting.mineCount);
        }

        public void Write(Record record)
        {
            Write(record.playerName);
            Write(record.time);
            Write(record.date.Ticks);
        }

        public void Write(Ranking ranking)
        {
            Write(ranking.records.Count);
            ranking.records.ForEach(x => Write(x));
        }

        public void Write(Grid grid)
        {
            Write(grid.position);
            Write((int)grid.type);
            Write((int)grid.state);
        }

        public void Write(Game game)
        {
            Write(game.started);
            if (game.started)
            {
                Write(game.timing);
            }
            foreach (var grid in game.plane)
            {
                Write(grid);
            }
        }
    }
}