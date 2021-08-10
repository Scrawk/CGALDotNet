using System.Collections;
using System.Collections.Generic;
using System.Text;

using Common.Collections.Queues;
using CGeom2D.Geometry;

namespace CGeom2D.Sweep
{
    public class SweepLine : IEnumerable<SweepEvent>
    {
        public SweepLine()
        {
            EventQueue = new PriorityList<SweepEvent>();
            EventQueue.Comparer = SweepEvent.Comparer;
        }

        private PriorityList<SweepEvent> EventQueue;

        public void Add(SweepEvent e)
        {
            EventQueue.Add(e);
        }

        public SweepEvent Peek()
        {
            return EventQueue.Peek();
        }

        public SweepEvent Pop()
        {
            return EventQueue.Pop();
        }

        public Line2d CurrentLine(PointCollection collection, double len)
        {
            var e = Peek();
            var point = collection.ToPoint2d(e.Point);
            var x = point.x;

            var p1 = new Point2d(x, -len);
            var p2 = new Point2d(x, len);

            return new Line2d(p1, p2);

        }

        public IEnumerator<SweepEvent> GetEnumerator()
        {
            foreach (var e in EventQueue)
                yield return e;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
