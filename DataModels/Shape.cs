using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_EntityFramework.DataModels
{
    public class Shape
    {


        public int Id { get; set; }
        public string Title { get; set; }

        public Type type { get; set; }

        public List<Point> point { get; } = new();

        //TODO: Shape 5 & 6 & 7 & 16

      



        public Shape getShapeById(int id)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == id);
            return shape;
        }

        public void AddPointsToShape(int ShapeID, List<Point> points)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == ShapeID);
            foreach (Point p in points)
            {
                shape.point.Add(p);
            }
            myContext.SaveChanges();
        }

        public List<Point> getAllPointSortedByX(Shape shape_)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == shape_.Id);
            var points = shape.point.OrderBy(p => p.x).ToList();
            return points;
        }

        public List<Point> getAllPointSortedByY(Shape shape_)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == shape_.Id);
            var points = shape.point.OrderBy(p => p.y).ToList();
            return points;
        }
        public void CloneShapeToAnotherFrame(Shape s,Frame from,Frame to)
        {
            using Context myContext = new Context();
            var shape = myContext.Frames.Where(f => f.Id == from.Id).FirstOrDefault().shapes.Where(p => p.Id == s.Id).FirstOrDefault();
            myContext.Frames.Where(f => f.Id == to.Id).FirstOrDefault().shapes.Add(shape);
            myContext.SaveChanges();
        }
        public void DeleteShapeAndItsPoints(Shape s)
        {
            using Context myContext = new Context();
            myContext.Shapes.Where(f => f.Id == s.Id).FirstOrDefault().point.Clear();
            myContext.Remove(s);
            myContext.SaveChanges();
        }
        public List<Point> getAllPointsCuttingX()
        {
            using Context myContext = new Context();
            var points = myContext.Points.Where(p => p.y == 0).ToList();
            return points;
        }
        public List<Point> getAllPointsCuttingY()
        {
            using Context myContext = new Context();
            var points = myContext.Points.Where(p => p.x == 0).ToList();
            return points;
        }

        //TODO
        public List<Point> getAllCommonPoints(Frame f)
        {
            return null;

        }
        
        public void ChangeColor(Shape s,Color color)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.Where(f => f.Id == s.Id).FirstOrDefault();
            foreach (Point p in shape.point)
            {
                p.color = color;
            }
            myContext.SaveChanges();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
