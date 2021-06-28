using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTurtle8.Data
{
    public class RazorPagesTurtle8Context : DbContext
    {
        public RazorPagesTurtle8Context(
            DbContextOptions<RazorPagesTurtle8Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTurtle8.Models.Turtle> Turtle { get; set; }
    }
}
