using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Magazine
{
    public class DeleteModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public DeleteModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Magazin Magazin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Magazin == null)
            {
                return NotFound();
            }

            var magazin = await _context.Magazin.FirstOrDefaultAsync(m => m.ID == id);

            if (magazin == null)
            {
                return NotFound();
            }
            else 
            {
                Magazin = magazin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Magazin == null)
            {
                return NotFound();
            }
            var magazin = await _context.Magazin.FindAsync(id);

            if (magazin != null)
            {
                Magazin = magazin;
                _context.Magazin.Remove(Magazin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
