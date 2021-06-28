using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTurtle8.Data;
using RazorPagesTurtle8.Models;

namespace RazorPagesTurtle8.Pages.Turtles
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTurtle8.Data.RazorPagesTurtle8Context _context;

        public CreateModel(RazorPagesTurtle8.Data.RazorPagesTurtle8Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Turtle Turtle { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Turtle.Add(Turtle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
