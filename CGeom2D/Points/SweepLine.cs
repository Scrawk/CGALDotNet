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

            RemovePastEvents(e);
            RemoveEmptyEvents();
            HandleIntersections(e);
            AddToLine(e);

            return true;
        }

        private void RemovePastEvents(SweepEvent e)
        {
            var A = e.Point;

            foreach (var ev in EventLine)
            {
                var remove = new List<int>();

                foreach (int b in ev.EndPoints)
                {
                    var B = ev.GetEndPoint(b);

                    if (e.Comparison(B, A) < COMPARISON.LARGER)
                        remove.Add(b);
                }

                foreach (int b in remove)
                    ev.RemoveEndPoint(b);
            }
        }

        private void RemoveEmptyEvents()
        {
            var remove = new List<SweepEvent>();

            foreach (var ev in EventLine)
            {
                if (ev.EndPoints.Count == 0)
                    remove.Add(ev);
            }

            foreach (var ev in remove)
                EventLine.Remove(ev);
        }

        private void HandleIntersections(SweepEvent e)
        {

        }

        private INTERSECTION Intersect(SweepEvent e1, SweepEvent e2)
        {
            return INTERSECTION.NONE;
        }

        private void HandleIntersection(INTERSECTION result)
        {

        }

        private void AddToLine(SweepEvent e)
        {
            EventLine.Add(e);
        }

    }
}
