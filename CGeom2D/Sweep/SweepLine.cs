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

            Console.WriteLine();
            Console.WriteLine("Handle event " + e);
            
            foreach (var ev in EventLine)
            {
                //var result = Intersect(e, ev);
                //HandleIntersection(result);
            }

            RemovePastEvents(e);
            RemoveEmptyEvents();

            Console.WriteLine("Add to event line " + e);

            EventLine.Add(e);

            Console.WriteLine("Event line");

            foreach (var ev in EventLine)
            {
                Console.WriteLine(ev);
            }
            
            return true;
        }

        private INTERSECTION Intersect(SweepEvent e1, SweepEvent e2)
        {
            Console.WriteLine("Check Intersection " + e1 + " with " + e2);

            return INTERSECTION.NONE;
        }

        private void HandleIntersection(INTERSECTION result)
        {
            Console.WriteLine("Handle intersect " + result);
        }

        private void RemovePastEvents(SweepEvent e)
        {
            Console.WriteLine("remove past end points");

            var A = e.Point;
            Console.WriteLine("A(" + e.StartPoint + ") = " + A);

            foreach (var ev in EventLine)
            {
                var remove = new List<int>();

                foreach (int b in ev.EndPoints)
                {
                    var B = ev.GetEndPoint(b);

                    Console.WriteLine("B(" + b + ")  = " + B);

                    int order = SweepEvent.Compare(B, A);

                    Console.WriteLine("Order " + order);

                    if (order < 1)
                        remove.Add(b);
                }

                foreach (int b in remove)
                {
                    Console.WriteLine("Remove " + b);
                    ev.RemoveEndPoint(b);
                }
            }
        }

        private void RemoveEmptyEvents()
        {
            Console.WriteLine("remove empty events");

            var remove = new List<SweepEvent>();

            foreach (var ev in EventLine)
            {
                if (ev.EndPoints.Count == 0)
                    remove.Add(ev);
            }

            foreach (var ev in remove)
            {
                EventLine.Remove(ev);
            }
        }

    }
}
