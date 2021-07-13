using System;

using CGALDotNetConsole.Examples;

namespace CGALDotNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Polygon2Examples.CreateSimplePolygon();
            Polygon2Examples.CreateRelativelySimplePolygon();
            Polygon2Examples.CreateConcavePolygon();
            Polygon2Examples.CreateNonSimplePolygon();
            Polygon2Examples.PolygonContainsPoint();

            //Polygon2Examples.CreatePolygonWithHoles();
            //Polygon2BooleanExamples.DoIntersect();
            //Polygon2BooleanExamples.Join();

        }

    }
}
