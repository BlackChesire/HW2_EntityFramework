using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_EntityFramework.DataModels
{
    public class Shape
    {
      

        public int? Id { get; set; }
        public string Title { get; set; }

        public Type type { get; set; }

        public List<Point> point { get; set; } = new();




        
        public static void addSinglePointShape(int x, int y, Color color, string title, string tav, int FrameID)
        {
            var point = new Point { color = color, x = x, y = y, title = title, tav = tav };
            List<Point> singlePointList = new List<Point>() { point };
            var Shape = new Shape { Title = title, type = Type.singlePoint, point = singlePointList };
            using Context myContext = new Context();
            var frame = myContext.Frames.FirstOrDefault(f => f.Id == FrameID);
            frame.shapes.Add(Shape);
            myContext.SaveChanges();
        }

        public static void AddHorizontalline(List<Point> point, string Title,int FrameID)
        {
            var Shape = new Shape { Title = Title, type = Type.HorizontalLine, point = point };
            using Context myContext = new Context();
            var frame = myContext.Frames.FirstOrDefault(f => f.Id == FrameID);
            frame.shapes.Add(Shape);
            myContext.SaveChanges();
        }
        
        public static void AddVerticalLine(List<Point> point, string Title, int FrameID)
        {
            var Shape = new Shape { Title = Title, type = Type.VerticalLine, point = point };
            using Context myContext = new Context();
            var frame = myContext.Frames.FirstOrDefault(f => f.Id == FrameID);
            frame.shapes.Add(Shape);
            myContext.SaveChanges();
        }


        public static Shape getShapeById(int id)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == id);
            return shape;
        }

        public static void AddPointsToShape(int ShapeID, List<Point> points)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == ShapeID);
            foreach (Point p in points)
            {
                shape.point.Add(p);
            }
            myContext.SaveChanges();
        }

        public static List<Point> getAllPointSortedByX(Shape shape_)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == shape_.Id);
            var points = shape.point.OrderBy(p => p.x).ToList();
            return points;
        }

        public static List<Point> getAllPointSortedByY(Shape shape_)
        {
            using Context myContext = new Context();
            var shape = myContext.Shapes.FirstOrDefault(s => s.Id == shape_.Id);
            var points = shape.point.OrderBy(p => p.y).ToList();
            return points;
        }
        public static void CloneShapeToAnotherFrame(Shape s,Frame from,Frame to)
        {
            using Context myContext = new Context();
            var shape = myContext.Frames.Where(f => f.Id == from.Id).FirstOrDefault().shapes.Where(p => p.Id == s.Id).FirstOrDefault();
            myContext.Frames.Where(f => f.Id == to.Id).FirstOrDefault().shapes.Add(shape);
            myContext.SaveChanges();
        }
        public static void DeleteShapeAndItsPoints(Shape s)
        {
            using Context myContext = new Context();
            myContext.Shapes.Where(f => f.Id == s.Id).FirstOrDefault().point.Clear();
            myContext.Remove(s);
            myContext.SaveChanges();
        }
        public static List<Shape> getAllShapesCuttingX(Frame f)
        {
            using Context myContext = new Context();
            var shapes = myContext.Frames.Where(f => f.Id == f.Id).FirstOrDefault().shapes.ToList();
            var shapesCuttingX = new List<Shape>();
            foreach (Shape s in shapes)
            {
                //for each point in shape
                foreach (Point p in s.point)
                {
                    //if point is cutting x
                    if (p.y == 0)
                    {
                        shapesCuttingX.Add(s);
                    }
                }
            }
            return shapesCuttingX;
        }
        public static List<Shape> getAllShapesCuttingY(Frame f)
        {
            using Context myContext = new Context();
            var shapes = myContext.Frames.Where(f => f.Id == f.Id).FirstOrDefault().shapes.ToList();
            var shapesCuttingY = new List<Shape>();
            foreach (Shape s in shapes)
            {
                //for each point in shape
                foreach (Point p in s.point)
                {
                    //if point is cutting y
                    if (p.x == 0)
                    {
                        shapesCuttingY.Add(s);
                    }
                }
            }
            return shapesCuttingY;
        }

        //find all shapes in a frame with a commom points using groupby
        public static List<Shape> getAllShapesWithCommonPoints(Frame f)
        {
            using Context myContext = new Context();
            var shapes_ = myContext.Frames.Where(p => p.Id == f.Id).FirstOrDefault().shapes.GroupBy(p => p.point).ToList();
            //for each shape in shapes
            List<Shape> shapes = new List<Shape>();
            foreach (Shape s in shapes_) {
                shapes.Add(s);
            }
            return shapes;
        }

        public static void ChangeColor(Shape s,Color color)
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
