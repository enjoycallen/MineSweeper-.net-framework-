using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MineSweeper
{
    public partial class Game : Control
    {
        public void generate_plane()
        {
            plane = new Grid[setting.shape.row, setting.shape.col];
            for(int i=0;i< setting.shape.row; ++i)
            {
                for(int j=0;j< setting.shape.col; ++j)
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

            clock_pictureBox = new PictureBox();
            clock_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            clock_pictureBox.Image = Properties.Resources.clock_status;
            clock_pictureBox.Location = new Point(0, setting.shape.row * 26 + 10);
            Controls.Add(clock_pictureBox);

            mine_pictureBox = new PictureBox();
            mine_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            mine_pictureBox.Image = Properties.Resources.mine_status;
            mine_pictureBox.Location = new Point(26 * setting.shape.col - 37, setting.shape.row * 26 + 10);
            Controls.Add(mine_pictureBox);

            clock_status = new Label();
            clock_status.Size = new Size(60, 30);
            clock_status.Location = new Point(40, setting.shape.row * 26 + 13);
            clock_status.BackColor = Color.FromArgb(48, 85, 155);
            clock_status.ForeColor = Color.White;
            clock_status.Text = time <= 999 ? time.ToString() : "999";
            clock_status.Font = new Font("Arial", 18);
            clock_status.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(clock_status);

            mine_status = new Label();
            mine_status.Size = new Size(60, 30);
            mine_status.Location = new Point(26 * setting.shape.col - 100, setting.shape.row * 26 + 13);
            mine_status.BackColor = Color.FromArgb(48, 85, 155);
            mine_status.ForeColor = Color.White;
            int marked = 0;
            foreach (var grid in plane)
            {
                if (grid.state == Grid.State.Marked)
                {
                    ++marked;
                }
            }
            mine_status.Text = (setting.mine_count - marked).ToString();
            mine_status.Font = new Font("Arial", 18);
            mine_status.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(mine_status);

            ResumeLayout();
        }

        public void clock_status_update(object sender, EventArgs e)
        {
            if (++time <= 999)
            {
                clock_status.Text = time.ToString();
            }
            else
            {
                clock_status.Text = "999";
            }
        }

        public void mine_status_update(int delta)
        {
            mine_status.Text = (int.Parse(mine_status.Text) + delta).ToString();
        }
        
        public void generate_mine()
        {
            var blank = Algorithm.MatrixNeightbour(plane, focus_grid.position);
            blank.Add(focus_grid);
            int[] a = new int[setting.shape.row * setting.shape.col - blank.Count];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i < setting.mine_count ? 1 : 0;
            }
            Algorithm.RandomShuffle(a);
            int[,] map = new int[setting.shape.row, setting.shape.col];
            for (int i = 0, cur = 0; i < setting.shape.row; ++i)
            {
                for(int j = 0; j < setting.shape.col; ++j)
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
            time = 0;
            initialize();
        }

        public Game(Setting setting, Grid[,] plane, bool started, int time)
        {
            this.setting = setting;
            this.plane = plane;
            this.started = started;
            this.time = time;
            initialize();
        }

        public List<Grid> neighbour(Grid grid)
        {
            return Algorithm.MatrixNeightbour(plane, grid.position);
        }

        public void focus()
        {
            if (focus_grid == null)
            {
                return;
            }
            if (mouse_state.HasFlag(MouseButtons.Left) && mouse_state.HasFlag(MouseButtons.Right))
            {
                focus_grid.press();
                neighbour(focus_grid).ForEach(x => x.press());
            }
            else if (mouse_state.HasFlag(MouseButtons.Left))
            {
                focus_grid.press();
            }
            else if (mouse_state.HasFlag(MouseButtons.Right))
            {
                focus_grid.focus();
            }
            else
            {
                focus_grid.focus();
            }
        }

        public void lostfocus()
        {
            if (focus_grid == null)
            {
                return;
            }
            if (mouse_state.HasFlag(MouseButtons.Left) && mouse_state.HasFlag(MouseButtons.Right))
            {
                focus_grid.lostfocus();
                neighbour(focus_grid).ForEach(x => x.lostfocus());
            }
            else if (mouse_state.HasFlag(MouseButtons.Left))
            {
                focus_grid.lostfocus();
            }
            else if (mouse_state.HasFlag(MouseButtons.Right))
            {
                focus_grid.lostfocus();
            }
            else
            {
                focus_grid.lostfocus();
            }
        }

        public bool click()
        {
            if (focus_grid == null)
            {
                return false;
            }
            lostfocus();
            if (mouse_state.HasFlag(MouseButtons.Left) && mouse_state.HasFlag(MouseButtons.Right))
            {
                if (focus_grid.state != Grid.State.Revealed)
                {
                    return false;
                }
                var neighbour = this.neighbour(focus_grid);
                if (neighbour.Where(x => x.state == Grid.State.Marked).Count() != (int)focus_grid.type) 
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
            else if (mouse_state.HasFlag(MouseButtons.Left))
            {
                if (!started)
                {
                    start();
                }
                return floodfill(focus_grid);
            }
            else if (mouse_state.HasFlag(MouseButtons.Right))
            {
                focus_grid.transform();
            }
            return false;
        }

        public bool floodfill(Grid grid)
        {
            if (grid.state == Grid.State.Revealed || grid.state == Grid.State.Marked)
            {
                return false;
            }
            if (grid.reveal())
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
                grid.expose();
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
            ((MainForm)Parent).lose();
        }

        public void win()
        {
            timer.Stop();
            mine_status.Text = "0";
            using (var bgm = new SoundPlayer(Properties.Resources.win_bgm))
            {
                bgm.Play();
            }
            expose();
            ((MainForm)Parent).win();
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
            mouse_state ^= e.Button;
        }

        public void Plane_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_state ^= e.Button;
            focus();
        }

        public void Plane_MouseEnter(object sender, EventArgs e)
        {
            focus();
        }

        public void Plane_MouseLeave(object sender, EventArgs e)
        {
            lostfocus();
        }

        public void Plane_MouseMove(object sender, MouseEventArgs e)
        {
            var grid = (Grid)sender;
            lostfocus();
            if (mouse_state == MouseButtons.None)
            {
                focus_grid = grid;
            }
            else
            {
                int x = (grid.position.row * 26 + e.Y) / 26, y = (grid.position.col * 26 + e.X) / 26;
                if (x >= 0 && x < setting.shape.row && y >= 0 && y < setting.shape.col)
                {
                    focus_grid = plane[x, y];
                }
                else
                {
                    focus_grid = null;
                }
            }
            focus();
        }
    }
}
