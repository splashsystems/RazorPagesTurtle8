using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTurtle8.Data;
using RazorPagesTurtle8.Models;

namespace RazorPagesTurtle8.Pages.Turtles
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTurtle8.Data.RazorPagesTurtle8Context _context;

        public DeleteModel(RazorPagesTurtle8.Data.RazorPagesTurtle8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Turtle Turtle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Turtle = await _context.Turtle.FirstOrDefaultAsync(m => m.ID == id);

            if (Turtle == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Turtle = await _context.Turtle.FindAsync(id);

            if (Turtle != null)
            {
                _context.Turtle.Remove(Turtle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
