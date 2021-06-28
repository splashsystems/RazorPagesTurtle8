using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTurtle8.Data;
using RazorPagesTurtle8.Models;

namespace RazorPagesTurtle8.Pages.Turtles
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTurtle8.Data.RazorPagesTurtle8Context _context;

        public IndexModel(RazorPagesTurtle8.Data.RazorPagesTurtle8Context context)
        {
            _context = context;
        }

        public IList<Turtle> Turtle { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TurtleType { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from t in _context.Turtle
                                           orderby t.Type
                                           select t.Type;
            //LINQ query - defined, not run
            var turtles = from t in _context.Turtle
                          select t;
            if (!string.IsNullOrEmpty(SearchString))
            {
                turtles = turtles.Where(s => s.TurtleName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(TurtleType))
            {
                turtles = turtles.Where(x => x.Type == TurtleType);
            }
            Types = new SelectList(await typeQuery.Distinct().ToListAsync());

            Turtle = await turtles.ToListAsync();
        }
    }
}
