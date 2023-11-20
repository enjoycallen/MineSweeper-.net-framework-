using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public partial class Grid
    {
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

        public Position position;
        public Type type;
        public State state;

        //图像资源
        public static Dictionary<Type, dynamic> Pattern;
        public static dynamic blank, concealed, concealed_mouseover, marked, marked_mouseover, question_mark, question_mark_mouseover, question_mark_mousedown, mine, mine_red, false_marked;
    }
}
