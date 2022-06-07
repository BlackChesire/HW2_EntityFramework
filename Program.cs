using HW2_EntityFramework.DataModels;
using System;
using System.Collections.Generic;

namespace HW2_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create 2 Frames
            var frame1 = new Frame { height = 20, width = 20, x = 10, y = 10, shapes = new List<Shape>() };
            var frame2 = new Frame { height = 20, width = 20, x = 10, y = 10, shapes = new List<Shape>() };
            //add frames to the db
            using Context myContext = new Context();
            myContext.Frames.Add(frame1);
            myContext.Frames.Add(frame2);
            myContext.SaveChanges();
            //create 5 Points
            var point1 = new Point { x = 10, y = 10, color = Color.red, title = "point1", tav = "#" };
            var point2 = new Point { x = 5, y = 5, color = Color.blue, title = "point2", tav = "%" };
            var point3 = new Point { x = 1, y = 7, color = Color.yellow, title = "point3", tav = "&" };
            var point4 = new Point { x = 2, y = 0, color = Color.green, title = "point4", tav = "^" };
            var point5 = new Point { x = 2, y = 5, color = Color.white, title = "point5", tav = "!" };
            
            var pointsList = new List<Point>() { point1, point2, point3, point4, point5 };
            //add points list to frame 1 and frame 2
            frame1.shapes.Add(new Shape { Title="shape1-sp", type=Type.singlePoint,point = pointsList });
            frame1.shapes.Add(new Shape { Title="shape2-sp", type=Type.singlePoint,point = pointsList });
            myContext.SaveChanges();
            //create 4 horizontal lines
            var line1 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 10, y = 10, color = Color.red, title = "point1", tav = "#" }, new Point { x = 10, y = 10, color = Color.red, title = "point2", tav = "#" } } };
            var line2 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 5, y = 5, color = Color.red, title = "point3", tav = "#" }, new Point { x = 5, y = 5, color = Color.red, title = "point4", tav = "@" } } };
            var line3 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 3, y = 3, color = Color.red, title = "point5", tav = "#" }, new Point { x = 3, y = 3, color = Color.red, title = "point6", tav = "!" } } };
            var line4 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 4, y = 4, color = Color.red, title = "point7", tav = "#" }, new Point { x = 4, y = 4, color = Color.yellow, title = "point8", tav = "&" } } };
      
            //add lines to frame 1 and frame 2
            frame1.shapes.Add(line1);
            frame2.shapes.Add(line2);
            frame2.shapes.Add(line3);
            frame2.shapes.Add(line4);
            myContext.SaveChanges();
            //create 4 verticalLines 
            var verticalLine1 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 0, y = 10, color = Color.red, title = "point1", tav = "#" }, new Point { x = 0, y = 11, color = Color.red, title = "point2", tav = "#" } } };
            var verticalLine2 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 0, y = 5, color = Color.red, title = "point3", tav = "#" }, new Point { x = 0, y = 6, color = Color.red, title = "point4", tav = "@" } } };
            var verticalLine3 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 0, y = 3, color = Color.red, title = "point5", tav = "#" }, new Point { x = 0, y = 4, color = Color.red, title = "point6", tav = "!" } } };
            var verticalLine4 = new Shape { Title = "line1", type = Type.HorizontalLine, point = new List<Point>() { new Point { x = 0, y = 4, color = Color.red, title = "point7", tav = "#" }, new Point { x = 0, y = 5, color = Color.yellow, title = "point8", tav = "&" } } };

            //add lines to frame 1 and frame 2
            frame1.shapes.Add(verticalLine1);
            frame2.shapes.Add(verticalLine2);
            frame2.shapes.Add(verticalLine3);
            frame2.shapes.Add(verticalLine4);
            myContext.SaveChanges();
            //update verticalLine in frame 1
            var verticalLine = frame1.shapes;
            verticalLine[0].point[1].x = 30;
            verticalLine[0].point[1].y = 30;
            var verticalLine_2 = frame2.shapes;
            verticalLine[0].point[1].x = 2;
            verticalLine[0].point[1].y = 2;
            myContext.SaveChanges();


        }
    }
}
