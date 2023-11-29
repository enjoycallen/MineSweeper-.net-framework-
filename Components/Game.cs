using MineSweeper.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Game : Control
    {
        public Grid[,] plane { get; set; }
        public bool started { get; set; }
        public int timing { get; set; }

        private Grid focusGrid;
        private MouseButtons mouseState = MouseButtons.None;
        private PictureBox clockPictureBox, minePictureBox;
        private Label clockStatusLabel, mineStatusLabel;
        private Timer timer;
        private Setting setting;

        public void generate_plane()
        {
            plane = new Grid[setting.shape.row, setting.shape.col];
            for (int i = 0; i < setting.shape.row; ++i)
            {
                for (int j = 0; j < setting.shape.col; ++j)
                {
                    plane[i, j] = new Grid(new Position(i, j));
                }
            }
        }

        public void initialize()
        {
            SuspendLayout();

            Size = new Size(setting.shape.col * 26 + 1, setting.shape.row * 26 + 50);
            Location = new Point(40, 50);

            for (int i = 0; i < setting.shape.row; ++i)
            {
                for (int j = 0; j < setting.shape.col; ++j)
                {
                    var g = plane[i, j];
                    g.Location = new Point(26 * j, 26 * i);
                    g.MouseEnter += Plane_MouseEnter;
                    g.MouseLeave += Plane_MouseLeave;
                    g.MouseMove += Plane_MouseMove;
                    g.MouseDown += Plane_MouseDown;
                    g.MouseUp += Plane_MouseUp;
                    Controls.Add(g);
                }
            }

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += clock_status_update;

            clockPictureBox = new PictureBox();
            clockPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            clockPictureBox.Image = Properties.Resources.clock_status;
            clockPictureBox.Location = new Point(0, setting.shape.row * 26 + 10);
            Controls.Add(clockPictureBox);

            minePictureBox = new PictureBox();
            minePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            minePictureBox.Image = Properties.Resources.mine_status;
            minePictureBox.Location = new Point(26 * setting.shape.col - 37, setting.shape.row * 26 + 10);
            Controls.Add(minePictureBox);

            clockStatusLabel = new Label();
            clockStatusLabel.Size = new Size(60, 30);
            clockStatusLabel.Location = new Point(40, setting.shape.row * 26 + 13);
            clockStatusLabel.BackColor = Color.FromArgb(48, 85, 155);
            clockStatusLabel.ForeColor = Color.White;
            clockStatusLabel.Text = timing <= 999 ? timing.ToString() : "999";
            clockStatusLabel.Font = new Font("Arial", 18);
            clockStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(clockStatusLabel);

            mineStatusLabel = new Label();
            mineStatusLabel.Size = new Size(60, 30);
            mineStatusLabel.Location = new Point(26 * setting.shape.col - 100, setting.shape.row * 26 + 13);
            mineStatusLabel.BackColor = Color.FromArgb(48, 85, 155);
            mineStatusLabel.ForeColor = Color.White;
            int marked = 0;
            foreach (var grid in plane)
            {
                if (grid.state == Grid.State.Marked)
                {
                    ++marked;
                }
            }
            mineStatusLabel.Text = (setting.mineCount - marked).ToString();
            mineStatusLabel.Font = new Font("Arial", 18);
            mineStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(mineStatusLabel);

            ResumeLayout();
        }

        public void clock_status_update(object sender, EventArgs e)
        {
            if (++timing <= 999)
            {
                clockStatusLabel.Text = timing.ToString();
            }
            else
            {
                clockStatusLabel.Text = "999";
            }
        }

        public void mine_status_update(int delta)
        {
            mineStatusLabel.Text = (int.Parse(mineStatusLabel.Text) + delta).ToString();
        }

        public void generate_mine()
        {
            var blank = Algorithm.MatrixNeightbour(plane, focusGrid.position);
            blank.Add(focusGrid);
            int[] a = new int[setting.shape.row * setting.shape.col - blank.Count];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i < setting.mineCount ? 1 : 0;
            }
            Algorithm.RandomShuffle(a);
            int[,] map = new int[setting.shape.row, setting.shape.col];
            for (int i = 0, cur = 0; i < setting.shape.row; ++i)
            {
                for (int j = 0; j < setting.shape.col; ++j)
                {
                    map[i, j] = blank.Find(x => x == plane[i, j]) == null ? a[cur++] : 0;
                }
            }
            for (int i = 0; i < setting.shape.row; ++i)
            {
                for (int j = 0; j < setting.shape.col; ++j)
                {
                    if (map[i, j] == 0)
                    {
                        plane[i, j].type = (Grid.Type)Algorithm.MatrixNeightbour(map, new Position(i, j)).Sum();
                    }
                    else
                    {
                        plane[i, j].type = Grid.Type.Mine;
                    }
                }
            }
        }

        public void start()
        {
            generate_mine();
            started = true;
            timer.Start();
        }

        public void terminate()
        {
            Dispose();
        }

        public Game(Setting setting)
        {
            this.setting = setting;
            generate_plane();
            started = false;
            timing = 0;
            initialize();
        }

        public Game(Grid[,] plane, bool started, int time)
        {
            this.plane = plane;
            this.started = started;
            this.timing = time;
            initialize();
        }

        private List<Grid> neighbour(Grid grid)
        {
            return Algorithm.MatrixNeightbour(plane, grid.position);
        }

        public void focus()
        {
            if (focusGrid == null)
            {
                return;
            }
            if (mouseState.HasFlag(MouseButtons.Left) && mouseState.HasFlag(MouseButtons.Right))
            {
                focusGrid.Press();
                neighbour(focusGrid).ForEach(x => x.Press());
            }
            else if (mouseState.HasFlag(MouseButtons.Left))
            {
                focusGrid.Press();
            }
            else if (mouseState.HasFlag(MouseButtons.Right))
            {
                focusGrid.Focus();
            }
            else
            {
                focusGrid.Focus();
            }
        }

        public void lostfocus()
        {
            if (focusGrid == null)
            {
                return;
            }
            if (mouseState.HasFlag(MouseButtons.Left) && mouseState.HasFlag(MouseButtons.Right))
            {
                focusGrid.LostFocus();
                neighbour(focusGrid).ForEach(x => x.LostFocus());
            }
            else if (mouseState.HasFlag(MouseButtons.Left))
            {
                focusGrid.LostFocus();
            }
            else if (mouseState.HasFlag(MouseButtons.Right))
            {
                focusGrid.LostFocus();
            }
            else
            {
                focusGrid.LostFocus();
            }
        }

        public bool click()
        {
            if (focusGrid == null)
            {
                return false;
            }
            lostfocus();
            if (mouseState.HasFlag(MouseButtons.Left) && mouseState.HasFlag(MouseButtons.Right))
            {
                if (focusGrid.state != Grid.State.Revealed)
                {
                    return false;
                }
                var neighbour = this.neighbour(focusGrid);
                if (neighbour.Where(x => x.state == Grid.State.Marked).Count() != (int)focusGrid.type)
                {
                    return false;
                }
                foreach (var grid in neighbour)
                {
                    if (floodfill(grid))
                    {
                        return true;
                    }
                }
            }
            else if (mouseState.HasFlag(MouseButtons.Left))
            {
                if (!started)
                {
                    start();
                }
                return floodfill(focusGrid);
            }
            else if (mouseState.HasFlag(MouseButtons.Right))
            {
                focusGrid.Transform();
            }
            return false;
        }

        public bool floodfill(Grid grid)
        {
            if (grid.state == Grid.State.Revealed || grid.state == Grid.State.Marked)
            {
                return false;
            }
            if (grid.Reveal())
            {
                return true;
            }
            if (grid.type != Grid.Type.Zero)
            {
                return false;
            }
            foreach (var x in neighbour(grid))
            {
                if (x.state != Grid.State.Revealed && floodfill(x))
                {
                    return true;
                }
            }
            return false;
        }

        public bool clear()
        {
            foreach (var grid in plane)
            {
                if (grid.type != Grid.Type.Mine && grid.state != Grid.State.Revealed)
                {
                    return false;
                }
            }
            return true;
        }

        public void expose()
        {
            foreach (var grid in plane)
            {
                grid.Expose();
            }
        }

        public void lose()
        {
            timer.Stop();
            using (var bgm = new SoundPlayer(Properties.Resources.lose_bgm))
            {
                bgm.Play();
            }
            expose();
            using (var resultDialog = new ResultDialog())
            {
                resultDialog.ShowDialog(ResultDialog.Mode.Lose, timing);
            }
            ((MainForm)Parent).NewGame();
        }

        public void win()
        {
            timer.Stop();
            mineStatusLabel.Text = "0";
            using (var bgm = new SoundPlayer(Properties.Resources.win_bgm))
            {
                bgm.Play();
            }
            expose();
            using (var resultDialog = new ResultDialog())
            {
                var mode = setting.level == Setting.Level.PlayerDefined ? ResultDialog.Mode.Win : ResultDialog.Mode.Record;
                var record = resultDialog.ShowDialog(mode, timing);
            }
            ((MainForm)Parent).NewGame();
        }

        public void Plane_MouseUp(object sender, MouseEventArgs e)
        {
            if (click())
            {
                lose();
                return;
            }
            if (clear())
            {
                win();
                return;
            }
            mouseState ^= e.Button;
        }

        public void Plane_MouseDown(object sender, MouseEventArgs e)
        {
            mouseState ^= e.Button;
            focus();
        }

        public void Plane_MouseEnter(object sender, EventArgs e)
        {
            focus();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        public void Plane_MouseLeave(object sender, EventArgs e)
        {
            lostfocus();
        }

        public void Plane_MouseMove(object sender, MouseEventArgs e)
        {
            var grid = (Grid)sender;
            lostfocus();
            if (mouseState == MouseButtons.None)
            {
                focusGrid = grid;
            }
            else
            {
                var pos = new Position()
                {
                    row = (grid.position.row * 26 + e.Y) / 26,
                    col = (grid.position.col * 26 + e.X) / 26
                };
                if (Algorithm.InMatrix(plane, pos))
                {
                    focusGrid = plane[pos.row, pos.col];
                }
                else
                {
                    focusGrid = null;
                }
            }
            focus();
        }
    }
}
