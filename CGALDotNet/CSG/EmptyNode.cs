using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.CSG
{
    public class EmptyNode<INPUT, OUTPUT> : Node<INPUT, OUTPUT>
    {

        public static readonly EmptyNode<INPUT, OUTPUT> Default = new EmptyNode<INPUT, OUTPUT>();

        public override string ToString()
        {
            return string.Format("[EmptyNode: Children={0}]", ChildrenCount);
        }

        public override OUTPUT Func(INPUT arg)
        {
            return default(OUTPUT);
        }
    }

    public class EmptyNode<INPUT1, INPUT2, OUTPUT> : Node<INPUT1, INPUT2, OUTPUT>
    {

        public static readonly EmptyNode<INPUT1, INPUT2, OUTPUT> Default = new EmptyNode<INPUT1, INPUT2, OUTPUT>();

        public override string ToString()
        {
            return string.Format("[EmptyNode: Children={0}]", ChildrenCount);
        }

        public override OUTPUT Func(INPUT1 arg1, INPUT2 arg2)
        {
            return default(OUTPUT);
        }
    }
}