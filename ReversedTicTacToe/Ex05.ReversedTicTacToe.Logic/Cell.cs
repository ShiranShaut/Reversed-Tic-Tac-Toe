using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.ReversedTicTacToe.Logic
{
    public class Cell<T>
    {
        private T m_Value;
        private bool m_Available;

        public Cell()
        {
            m_Value = default(T);
            m_Available = true;
        }

        public Cell(T i_Value)
        {
            m_Value = i_Value;
            m_Available = true;
        }

        public T Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        public bool Available
        {
            get { return m_Available; }
            set { m_Available = value; }
        }
    }
}