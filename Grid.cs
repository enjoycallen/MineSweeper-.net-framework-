using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace MineSweeper
{
    public class Grid : Button
    {
        //图案资源
        public static readonly dynamic[] Pattern;
        public static readonly dynamic empty, concealed, concealed_mouseover, marked, marked_mouseover, question_mark, question_mark_mouseover, question_mark_mousedown;

        //静态构造函数
        static Grid()
        {
            //初始化图案资源
            Pattern = new dynamic[12];
            Pattern[0] = empty = Properties.Resources.empty;
            Pattern[1] = Properties.Resources._1;
            Pattern[2] = Properties.Resources._2;
            Pattern[3] = Properties.Resources._3;
            Pattern[4] = Properties.Resources._4;
            Pattern[5] = Properties.Resources._5;
            Pattern[6] = Properties.Resources._6;
            Pattern[7] = Properties.Resources._7;
            Pattern[8] = Properties.Resources._8;
            Pattern[9] = Properties.Resources.mine;
            Pattern[10] = Properties.Resources.mine_red;
            Pattern[11] = Properties.Resources.false_marked;

            concealed = Properties.Resources.concealed;
            concealed_mouseover = Properties.Resources.concealed_mouseover;
            marked = Properties.Resources.marked;
            marked_mouseover = Properties.Resources.marked_mouseover;
            question_mark = Properties.Resources.question_mark;
            question_mark_mouseover = Properties.Resources.question_mark_mouseover;
            question_mark_mousedown = Properties.Resources.question_mark_mousedown;
        }

        //格子状态类型
        public enum State
        {
            Concealed = 1,          //隐藏
            Exposed = 2,            //揭开
            Marked = 4,             //地雷
            Undetermined = 8        //不确定
        };

        public int row, col;
        public int value;          //值
        public State state;            //状态

        public Grid(int r, int c)
        {
            row = r;
            col = c;
            initialize();
            value = 0;
            state = State.Concealed;
        }

        public Grid(int r, int c, int v, State init_state)
        {
            row = r;
            col = c;
            initialize();
            value = v;
            state = init_state;
            if (state == State.Concealed)
            {
                Image = concealed;
            }
            else if (state == State.Exposed)
            {
                Image = Pattern[value];
            }
            else if (state == State.Marked)
            {
                Image = marked;
            }
            else
            {
                Image = question_mark;
            }
        }

        public void initialize()
        {
            Name = "Grid" + row.ToString() + "_" + col.ToString();
            FlatStyle = FlatStyle.Flat;
            Location = new Point(0, 0);
            Size = new Size(27, 27);
        }

        public void focus()
        {
            if (state == State.Concealed)
            {
                Image = concealed_mouseover;
            }
            else if (state == State.Marked)
            {
                Image = marked_mouseover;
            }
            else if (state == State.Undetermined)
            {
                Image = question_mark_mouseover;
            }
        }

        public void lostfocus()
        {
            if (state == State.Concealed)
            {
                Image = concealed;
            }
            else if (state == State.Marked)
            {
                Image = marked;
            }
            else if (state == State.Undetermined)
            {
                Image = question_mark;
            }
        }

        public void press()
        {
            if (state == State.Concealed)
            {
                Image = empty;
            }
            else if (state == State.Marked)
            {
                Image = marked;
            }
            else if (state == State.Undetermined)
            {
                Image = question_mark_mousedown;
            }
        }

        public bool reveal()
        {
            if (state == State.Concealed || state == State.Undetermined)
            {
                if (value == 9)
                {
                    value = 10;
                }
                Image = Pattern[value];
                state = State.Exposed;
                return value > 8;
            }
            if (state == State.Marked)
            {
                Image = marked;
            }
            return false;
        }

        public void show()
        {
            Image = Pattern[value];
            state = State.Exposed;
        }

        public void transform()
        {
            if (state == State.Concealed)
            {
                Image = marked_mouseover;
                state = State.Marked;
            }
            else if (state == State.Marked)
            {
                Image = question_mark_mouseover;
                state = State.Undetermined;
            }
            else if (state == State.Undetermined)
            {
                Image = concealed_mouseover;
                state = State.Concealed;
            }
        }
    }
}

