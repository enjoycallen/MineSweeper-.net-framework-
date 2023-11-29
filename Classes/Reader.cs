using System;
using System.Collections.Generic;
using System.IO;

namespace MineSweeper
{
    public class Reader : BinaryReader
    {
        public Reader() : base(new FileStream(Properties.Resources.Archive, FileMode.Open)) { }

        public Shape ReadShape()
        {
            return new Shape(ReadInt32(), ReadInt32());
        }

        public Position ReadPostion()
        {
            return new Position(ReadInt32(), ReadInt32());
        }

        public Setting ReadSetting()
        {
            return new Setting((Setting.Level)ReadInt32(), ReadShape(), ReadInt32());
        }

        public Record ReadRecord()
        {
            return new Record(ReadString(), ReadInt32(), new DateTime(ReadInt64()));
        }

        public Ranking ReadRanking()
        {
            int count = ReadInt32();
            var records = new List<Record>();
            for (int i = 0; i < count; ++i)
            {
                records.Add(ReadRecord());
            }
            return new Ranking(records);
        }

        public Grid ReadGrid()
        {
            return new Grid(ReadPostion(), (Grid.Type)ReadInt32(), (Grid.State)ReadInt32());
        }

        public Game ReadGame()
        {
            Setting setting = ReadSetting();
            Grid[,] plane = new Grid[setting.shape.row, setting.shape.col];
            for (int i = 0; i < setting.shape.row; ++i)
            {
                for (int j = 0; j < setting.shape.col; ++j)
                {
                    plane[i, j] = ReadGrid();
                }
            }
            bool started = ReadBoolean();
            int timing = ReadInt32();
            return new Game(setting);
        }
    }
}