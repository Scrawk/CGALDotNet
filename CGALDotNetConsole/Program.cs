using System;

using CGALDotNetConsole.Examples;

namespace CGALDotNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Polygon2Examples.Create();
            Polygon2BooleanExamples.DoIntersect();
            Polygon2BooleanExamples.Join();

        }

    }
}
