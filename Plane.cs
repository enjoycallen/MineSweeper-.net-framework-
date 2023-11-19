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
        static private int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 }, dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

        private int row, col;
        private int[,] mine;
        private Grid[,] plane;
        private Grid focus_grid;
        private MouseButtons mouse_state = MouseButtons.None;

        private void swap<T>(ref T a,ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        private void generate_mine(int m)
        {
            int[] a = new int[row * col];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = i < m ? 1 : 0;
            }
            var algorithm = new Algorithm();
            algorithm.random_shuffle(a);
            mine = algorithm.transform1Dto2D(a, col);
        }

        private void generate_plane()
        {
            SuspendLayout();
            plane = new Grid[row, col];
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    int value;
                    if (mine[i, j] == 1)
                    {
                        value = 9;
                    }
                    else
                    {
                        value = 0;
                        for (int k = 0; k < 8; ++k)
                        {
                            int x = i + dx[k], y = j + dy[k];
                            if (x >= 0 && x < row && y >= 0 && y < col)
                            {
                                value += mine[x, y];
                            }
                        }
                    }
                    var g = plane[i, j] = new Grid(i, j, value, Grid.GridState.Concealed);
                    g.Name = "grid" + i.ToString() + "_" + j.ToString();
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

        public Plane(int r, int c, int m)
        {
            row = r;
            col = c;
            Size = new Size(col * 26 + 1, row * 26 + 1);
            generate_mine(m);
            generate_plane();
        }

        private bool valid_position(int x, int y)
        {
            return x >= 0 && x < row && y >= 0 && y < col;
        }

        private List<Grid> neighbour(Grid g)
        {
            var list = new List<Grid>();
            for (int i = 0; i < 8; ++i)
            {
                int x = g.row + dx[i], y = g.col + dy[i];
                if (valid_position(x, y))
                {
                    list.Add(plane[x, y]);
                }
            }
            return list;
        }

        private void focus()
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

        private void lostfocus()
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

        private bool click()
        {
            if (focus_grid == null)
            {
                return false;
            }
            lostfocus();
            if (mouse_state.HasFlag(MouseButtons.Left) && mouse_state.HasFlag(MouseButtons.Right))
            {
                if (focus_grid.state != Grid.GridState.Exposed)
                {
                    return false;
                }
                int marked = 0;
                foreach (var grid in neighbour(focus_grid))
                {
                    if (grid.state == Grid.GridState.Marked)
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

        private bool floodfill(Grid grid)
        {
            if (grid.state == Grid.GridState.Exposed || grid.state == Grid.GridState.Marked)
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
                if (g.state != Grid.GridState.Exposed && floodfill(g))
                {
                    return true;
                }
            }
            return false;
        }

        private bool clear()
        {
            foreach (var grid in plane)
            {
                if (grid.value <= 8 && grid.state != Grid.GridState.Exposed)
                {
                    return false;
                }
            }
            return true;
        }

        private void show_all_mine()
        {
            foreach (var grid in plane)
            {
                if (grid.value < 9 && grid.state == Grid.GridState.Marked)
                {
                    grid.value = 11;
                    grid.show();
                }
                if (grid.value == 9 && grid.state != Grid.GridState.Marked)
                {
                    grid.show();
                }
            }
        }

        private void Plane_MouseUp(object sender, MouseEventArgs e)
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

        private void Plane_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_state ^= e.Button;
            focus();
        }

        private void Plane_MouseEnter(object sender, EventArgs e)
        {
            focus();
        }

        private void Plane_MouseLeave(object sender, EventArgs e)
        {
            lostfocus();
        }

        private void Plane_MouseMove(object sender, MouseEventArgs e)
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
                if (!valid_position(x, y))
                {
                    focus_grid = null;
                }
                else
                {
                    focus_grid = plane[x, y];
                }
            }
            focus();
        }
    }
}
