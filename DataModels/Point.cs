using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_EntityFramework.DataModels
{
    public class Point
    {

        public int id { get; set; }
        public int x { get; set; }
        
        public int y { get; set; }
        public Color color { get; set; }
        public string title { get; set; }
        public string tav { get; set; }

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
