using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Grid : Button
    {
        private static readonly Dictionary<Type, dynamic> Pattern;
        private static readonly dynamic blank, concealed, concealedMouseover, marked, markedMouseover, questionMark, questionMarkMouseover, questionMarkMousedown, mine, mineRed, mineFalse;
        
        static Grid()
        {
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
            concealedMouseover = Properties.Resources.concealed_mouseover;
            marked = Properties.Resources.marked;
            markedMouseover = Properties.Resources.marked_mouseover;
            questionMark = Properties.Resources.question_mark;
            questionMarkMouseover = Properties.Resources.question_mark_mouseover;
            questionMarkMousedown = Properties.Resources.question_mark_mousedown;
            mine = Properties.Resources.mine;
            mineRed = Properties.Resources.mine_red;
            mineFalse = Properties.Resources.false_marked;
        }

        public enum Type
        {
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Mine = 9
        }

        public enum State
        {
            Concealed = 1,
            Revealed = 2,
            Marked = 3,
            Undetermined = 4
        }

        public Position position { get; }
        public Type type { get; set; }
        public State state { get; set; }

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
                Image = questionMark;
            }
        }

        public new void Focus()
        {
            if (state == State.Concealed)
            {
                Image = concealedMouseover;
            }
            else if (state == State.Marked)
            {
                Image = markedMouseover;
            }
            else if (state == State.Undetermined)
            {
                Image = questionMarkMouseover;
            }
        }

        public new void LostFocus()
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
                Image = questionMark;
            }
        }

        public void Press()
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
                Image = questionMarkMousedown;
            }
        }

        public bool Reveal()
        {
            if (state == State.Concealed || state == State.Undetermined)
            {
                if (type == Type.Mine)
                {
                    Image = mineRed;
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

        public void Transform()
        {
            if (state == State.Concealed)
            {
                Image = markedMouseover;
                state = State.Marked;
                ((Game)Parent).mine_status_update(-1);
            }
            else if (state == State.Marked)
            {
                Image = questionMarkMouseover;
                state = State.Undetermined;
                ((Game)Parent).mine_status_update(1);
            }
            else if (state == State.Undetermined)
            {
                Image = concealedMouseover;
                state = State.Concealed;
            }
        }

        public void Expose()
        {
            if (type == Type.Mine && (state == State.Concealed || state == State.Undetermined))
            {
                Image = mine;
                state = State.Revealed;
            }
            else if (type != Type.Mine && state == State.Marked)
            {
                Image = mineFalse;
                state = State.Revealed;
            }
        }
    }
}

