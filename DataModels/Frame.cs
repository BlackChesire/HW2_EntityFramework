using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_EntityFramework.DataModels
{
    public class Frame
    {

        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public List<Shape> shapes { get; } = new();

        public void AddFrame(Frame frame)
        {
            using Context myContext = new Context();
            myContext.Frames.Add(frame);
            myContext.SaveChanges();
        }
        public void UpdateFrame(Frame frameToUpdate, int new_x, int new_y)
        {
            using Context myContext = new Context();
            var oldFrame = myContext.Frames.FirstOrDefault(f => f.Id == frameToUpdate.Id);
            oldFrame.x = new_x;
            oldFrame.y = new_y;
            myContext.SaveChanges();


        }
        public Frame GetFrameById(int id)
        {
            using Context myContext = new Context();
            var frame = myContext.Frames.FirstOrDefault(f => f.Id == id);
            return frame;

        }
        public void AllIdAndTitleByFrame(Frame frame_)
        {
            using Context myContext = new Context();
            var frame = myContext.Frames.FirstOrDefault(f => f.Id == frame_.Id);
            foreach (Shape s in frame.shapes)
            {
                Console.WriteLine(s.Id + " " + s.Title);
            }


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
