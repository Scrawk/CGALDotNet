using System;
using System.Collections.Generic;
using System.Text;

using Common.Collections.Queues;

namespace CGeom2D.Points
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

        public bool HandleEvent(SweepEvent e)
        {
            if (e == null) return false;

            Console.WriteLine();
            Console.WriteLine("Handle event " + e);
        
            RemovePastEvents(e);
            RemoveEmptyEvents();
            HandleIntersections(e);
            AddToLine(e);

            return true;
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

        private void HandleIntersections(SweepEvent e)
        {
            Console.WriteLine("Handle intersects");

            foreach (var ev in EventLine)
            {
            
            }
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

        private void AddToLine(SweepEvent e)
        {
            Console.WriteLine("Add to event line " + e);

            EventLine.Add(e);

            Console.WriteLine("Event line");

            foreach (var ev in EventLine)
            {
                Console.WriteLine(ev);
            }
        }

    }
}
