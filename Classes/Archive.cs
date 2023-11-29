using System.IO;

namespace MineSweeper
{
    public static class Archive
    {
        public static void Load(MainForm mainForm)
        {
            if (!File.Exists(Properties.Resources.Archive))
            {
                mainForm.setting = new Setting(Setting.Level.Basic, new Shape(9, 9), 10);
                mainForm.game = new Game(mainForm.setting);
                mainForm.basicRanking = new Ranking();
                mainForm.intermidiateRanking = new Ranking();
                mainForm.advancedRanking = new Ranking();
            }
            else
            {
                using (var reader = new Reader())
                {
                    mainForm.setting = reader.ReadSetting();
                    bool saved = reader.ReadBoolean();
                    mainForm.game = saved ? reader.ReadGame() : new Game(mainForm.setting);
                    mainForm.basicRanking = reader.ReadRanking();
                    mainForm.intermidiateRanking = reader.ReadRanking();
                    mainForm.advancedRanking = reader.ReadRanking();
                }
            }
        }

        public static void Save(MainForm mainform, bool saved)
        {
            using (var writer = new Writer())
            {
                writer.Write(mainform.setting);
                writer.Write(saved);
                if (saved)
                {
                    writer.Write(mainform.game);
                }
                writer.Write(mainform.basicRanking);
                writer.Write(mainform.intermidiateRanking);
                writer.Write(mainform.advancedRanking);
            }
        }
    }
}