using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MineSweeper
{
    public class Plane : Control
    {
        public int row, col, mine;
        public Grid[,] plane;
        public Grid focus_grid;
        public MouseButtons mouse_state = MouseButtons.None;

        public void generate_mine(int m, int r, int c)
        {
            int[] a = new int[row * col];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i < m ? 1 : 0;
            }
            int[,] map = new int[row, col];
            while (true)
            {
                Algorithm.random_shuffle(a);
                map = Algorithm.ArrayToMatrix(a, col);
                if (map[r, c] == 0)
                {
                    break;
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

        public void initialize(int r, int c)
        {
            row = r;
            col = c;
            SuspendLayout();
            Size = new Size(col * 26 + 1, row * 26 + 1);
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
            ResumeLayout();
        }

        public Plane(int r, int c)
        {
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

        public void Plane_MouseUp(object sender, MouseEventArgs e)
        {
            if (click())
            {
                show_all_mine();
                MessageBox.Show("你输了!", "扫雷", MessageBoxButtons.OK);
                ((MainForm)Parent).新游戏NToolStripMenuItem_Click(sender, e);
                Dispose();
                return;
            }
            if (clear())
            {
                show_all_mine();
                MessageBox.Show("你赢了了!", "扫雷", MessageBoxButtons.OK);
                ((MainForm)Parent).新游戏NToolStripMenuItem_Click(sender, e);
                Dispose();
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
