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
    public partial class Grid : Button
    {
        //静态构造函数
        static Grid()
        {
            //初始化图案资源
            Pattern = new Dictionary<Type, dynamic>
            {
                {Type.Zero,Properties.Resources.blank },
                {Type.One,Properties.Resources._1 },
                {Type.Two,Properties.Resources._2 },
                {Type.Three,Properties.Resources._3 },
                {Type.Four,Properties.Resources._4 },
                {Type.Five,Properties.Resources._5 },
                {Type.Six,Properties.Resources._6 },
                {Type.Seven,Properties.Resources._7 },
                {Type.Eight,Properties.Resources._8 }
            };

            blank = Properties.Resources.blank;
            concealed = Properties.Resources.concealed;
            concealed_mouseover = Properties.Resources.concealed_mouseover;
            marked = Properties.Resources.marked;
            marked_mouseover = Properties.Resources.marked_mouseover;
            question_mark = Properties.Resources.question_mark;
            question_mark_mouseover = Properties.Resources.question_mark_mouseover;
            question_mark_mousedown = Properties.Resources.question_mark_mousedown;
            mine = Properties.Resources.mine;
            mine_red = Properties.Resources.mine_red;
            false_marked = Properties.Resources.false_marked;
        }

        public void initialize()
        {
            FlatStyle = FlatStyle.Flat;
            Location = new Point(0, 0);
            Size = new Size(27, 27);
        }

        public Grid(Position position, Type type = Type.Zero, State state = State.Concealed)
        {
            initialize();
            this.position = position;
            this.type = type;
            this.state = state;
            if (state == State.Concealed)
            {
                Image = concealed;
            }
            else if (state == State.Revealed)
            {
                Image = Pattern[type];
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
                Image = blank;
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
                if (type == Type.Mine)
                {
                    Image = mine_red;
                    state = State.Revealed;
                    return true;
                }
                Image = Pattern[type];
                state = State.Revealed;
                return false;
            }
            if (state == State.Marked)
            {
                Image = marked;
            }
            return false;
        }

        public void expose()
        {
            if (type == Type.Mine && (state == State.Concealed || state == State.Undetermined))
            {
                Image = mine;
                state = State.Revealed;
            }
            else if (type != Type.Mine && state == State.Marked)
            {
                Image = false_marked;
                state = State.Revealed;
            }
        }

        public void transform()
        {
            if (state == State.Concealed)
            {
                Image = marked_mouseover;
                state = State.Marked;
                ((Game)Parent).mine_status_update(-1);
            }
            else if (state == State.Marked)
            {
                Image = question_mark_mouseover;
                state = State.Undetermined;
                ((Game)Parent).mine_status_update(1);
            }
            else if (state == State.Undetermined)
            {
                Image = concealed_mouseover;
                state = State.Concealed;
            }
        }
    }
}

