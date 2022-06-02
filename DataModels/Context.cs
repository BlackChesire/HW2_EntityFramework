using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_EntityFramework.DataModels
{
    public class Context : DbContext
    {
      

        public DbSet<Frame> Frames { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Point> Points { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");





    }

}

