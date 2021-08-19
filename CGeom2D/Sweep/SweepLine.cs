using System;
using System.Collections.Generic;
using System.Text;

using Common.Collections.Queues;
using CGeom2D.Geometry;

namespace CGeom2D.Sweep
{
    public class SweepLine
    {
        public SweepLine()
        {
            EventQueue = new PriorityList<SweepEvent>();
            EventLine = new PriorityList<SweepEvent>();
        }

        private PriorityList<SweepEvent> EventQueue { get; set; }

        private PriorityList<SweepEvent> EventLine { get; set; }


        public Line2d CurrentLine(PointCollection collection, double len)
        {
            var e = PeekEvent();
            var point = collection.ToPoint2d(e.Point);
            var x = point.x;

            var p1 = new Point2d(x, -len);
            var p2 = new Point2d(x, len);

            return new Line2d(p1, p2);
        }

        public void AddEvent(SweepEvent e)
        {
            EventQueue.Add(e);
        }

        public SweepEvent PeekEvent()
        {
            if (EventQueue.Count > 0)
                return EventQueue.Peek();
            else
                return null;
        }

        public SweepEvent PopEvent()
        {
            if (EventQueue.Count > 0)
                return EventQueue.Pop();
            else
                return null;
        }

        public void Run()
        {
            while(HandleEvent())
            {

            }
        }

        public bool HandleEvent()
        {
            var e = PopEvent();
            if (e == null) return false;

            Console.WriteLine("Handle event " + e);

            foreach (var ev in EventLine)
            {
                var result = Intersect(e, ev);
                HandleIntersection(result);
            }

            Console.WriteLine("Add to event line " + e);

            EventLine.Add(e);

            return true;
        }

        private INTERSECTION Intersect(SweepEvent e1, SweepEvent e2)
        {
            Console.WriteLine("Intersect " + e1 + " with " + e2);

            return INTERSECTION.NONE;
        }

        private void HandleIntersection(INTERSECTION result)
        {
            Console.WriteLine("Handle intersect " + result);
        }

    }
}
