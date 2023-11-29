namespace MineSweeper
{
    public class Setting
    {
        public enum Level
        {
            Basic = 1,
            Intermidiate = 2,
            Advanced = 3,
            PlayerDefined = 4
        }

        public Level level { get; set; }
        public Shape shape { get; set; }
        public int mineCount { get; set; }

        public Setting(Level level, Shape shape, int mineCount)
        {
            this.level = level;
            this.shape = shape;
            this.mineCount = mineCount;
        }
    }
}