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
    public class Plane : Control
    {
        public bool started;
        public int row, col, mine;
        public Grid[,] plane;
        public Grid focus_grid;
        public MouseButtons mouse_state = MouseButtons.None;
        public PictureBox clock_pictureBox, mine_pictureBox;
        public Label clock_status, mine_status;
        public Timer timer;
        public int time;

        public void initialize(int r, int c)
        {
            row = r;
            col = c;
            SuspendLayout();
            Size = new Size(col * 26 + 1, row * 26 + 50);
            plane = new Grid[row, col];
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    var g = plane[i, j] = new Grid(i, j);
                    g.Location = new Point(26 * j, 26 * i);
                    g.MouseEnter += Plane_MouseEnter;
                    g.MouseLeave += Plane_MouseLeave;
                    g.MouseMove += Plane_MouseMove;
                    g.MouseDown += Plane_MouseDown;
                    g.MouseUp += Plane_MouseUp;
                    Controls.Add(g);
                }
            }

            time = 0;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += clock_status_update;

            clock_pictureBox = new PictureBox();
            clock_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            clock_pictureBox.Image = Properties.Resources.clock_status;
            clock_pictureBox.Location = new Point(0, row * 26 + 10);
            Controls.Add(clock_pictureBox);

            mine_pictureBox = new PictureBox();
            mine_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            mine_pictureBox.Image = Properties.Resources.mine_status;
            mine_pictureBox.Location = new Point(26 * col - 37, row * 26 + 10);
            Controls.Add(mine_pictureBox);

            clock_status = new Label();
            clock_status.Size = new Size(60, 30);
            clock_status.Location = new Point(40, row * 26 + 13);
            clock_status.BackColor = Color.FromArgb(48, 85, 155);
            clock_status.ForeColor = Color.White;
            clock_status.Text = "0";
            clock_status.Font = new Font("Arial", 18);
            clock_status.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(clock_status);

            mine_status = new Label();
            mine_status.Size = new Size(60, 30);
            mine_status.Location = new Point(26 * col - 100, row * 26 + 13);
            mine_status.BackColor = Color.FromArgb(48, 85, 155);
            mine_status.ForeColor = Color.White;
            mine_status.Text = mine.ToString();
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
            var blank = Algorithm.MatrixNeightbour(plane, focus_grid.row, focus_grid.col);
            blank.Add(focus_grid);
            int[] a = new int[row * col - blank.Count];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i < mine ? 1 : 0;
            }
            Algorithm.RandomShuffle(a);
            int[,] map = new int[row, col];
            for (int i = 0, cur = 0; i < row; ++i)
            {
                for(int j = 0; j < col; ++j)
                {
                    map[i, j] = blank.Find(x => x == plane[i, j]) == null ? a[cur++] : 0;
                }
            }
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    plane[i, j].value = map[i, j] == 1 ? 9 : Algorithm.MatrixNeightbour(map, i, j).Sum();
                }
            }
        }

        public void start()
        {
            generate_mine();
            started = true;
            timer.Start();
        }

        public Plane(int r, int c,int m)
        {
            started = false;
            mine = m;
            initialize(r, c);
        }

        public List<Grid> neighbour(Grid grid)
        {
            return Algorithm.MatrixNeightbour(plane, grid.row, grid.col);
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
                foreach (var grid in neighbour(focus_grid))
                {
                    grid.press();
                }
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
                foreach (var grid in neighbour(focus_grid))
                {
                    grid.lostfocus();
                }
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
                if (focus_grid.state != Grid.State.Exposed)
                {
                    return false;
                }
                int marked = 0;
                foreach (var grid in neighbour(focus_grid))
                {
                    if (grid.state == Grid.State.Marked)
                    {
                        ++marked;
                    }
                }
                if (marked != focus_grid.value)
                {
                    return false;
                }
                foreach (var grid in neighbour(focus_grid))
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
            if (grid.state == Grid.State.Exposed || grid.state == Grid.State.Marked)
            {
                return false;
            }
            if (grid.reveal())
            {
                return true;
            }
            if (grid.value > 0)
            {
                return false;
            }
            foreach (var g in neighbour(grid))
            {
                if (g.state != Grid.State.Exposed && floodfill(g))
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
                if (grid.value <= 8 && grid.state != Grid.State.Exposed)
                {
                    return false;
                }
            }
            return true;
        }

        public void show_all_mine()
        {
            foreach (var grid in plane)
            {
                if (grid.value < 9 && grid.state == Grid.State.Marked)
                {
                    grid.value = 11;
                    grid.show();
                }
                if (grid.value == 9 && grid.state != Grid.State.Marked)
                {
                    grid.show();
                }
            }
        }

        public void lose()
        {
            timer.Stop();
            using (var bgm = new SoundPlayer(Properties.Resources.lose_bgm))
            {
                bgm.Play();
            }
            show_all_mine();
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
            show_all_mine();
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
                int x = (grid.row * 26 + e.Y) / 26, y = (grid.col * 26 + e.X) / 26;
                if (x >= 0 && x < row && y >= 0 && y < col)
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
