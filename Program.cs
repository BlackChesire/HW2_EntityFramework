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
            var point1 = new Point(10, 10, Color.red, "point1", "tav1");
            var point2 = new Point(10, 20, Color.red, "point2", "tav2");
            var point3 = new Point(10, 30, Color.red, "point3", "tav3");
            var point4 = new Point(10, 40, Color.red, "point4", "tav4");
            var point5 = new Point(10, 50, Color.red, "point5", "tav5");
            var pointsList = new List<Point>() { point1, point2, point3, point4, point5 };
            //add points list to frame 1 and frame 2
            frame1.shapes.Add(new Shape("frame1", Type.singlePoint, pointsList));
            frame2.shapes.Add(new Shape("frame2", Type.singlePoint, pointsList));
            myContext.SaveChanges();
            //create 4 horizontal lines
            var line1 = new Shape("line1", Type.HorizontalLine, new List<Point>() { point1, point2 });
            var line2 = new Shape("line2", Type.HorizontalLine, new List<Point>() { point2, point3 });
            var line3 = new Shape("line3", Type.HorizontalLine, new List<Point>() { point3, point4 });
            var line4 = new Shape("line4", Type.HorizontalLine, new List<Point>() { point4, point5 });
            //add lines to frame 1 and frame 2
            frame1.shapes.Add(line1);
            frame2.shapes.Add(line2);
            myContext.SaveChanges();
            //create 4 verticalLines 
            var verticalLine1 = new Shape("verticalLine1", Type.VerticalLine, new List<Point>() { point1, point2 });
            var verticalLine2 = new Shape("verticalLine2", Type.VerticalLine, new List<Point>() { point2, point3 });
            var verticalLine3 = new Shape("verticalLine3", Type.VerticalLine, new List<Point>() { point3, point4 });
            var verticalLine4 = new Shape("verticalLine4", Type.VerticalLine, new List<Point>() { point4, point5 });
            //add lines to frame 1 and frame 2
            frame1.shapes.Add(verticalLine1);
            frame2.shapes.Add(verticalLine2);
            myContext.SaveChanges();
            //update verticalLine in frame 1
            var verticalLine = frame1.shapes.Find(s => s.Id == 1 && s.Id == 2);
            verticalLine.point[0].x = 20;
            verticalLine.point[1].y = 30;
            var verticalLine_2 = frame2.shapes.Find(s => s.Id == 1 && s.Id == 2);
            verticalLine_2.point[0].x = 20;
            verticalLine_2.point[1].y = 30;
            myContext.SaveChanges();


        }
    }
}
