using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmesRP.Data;
using FilmesRP.Model;

namespace FilmesRP.Pages.Filmes
{
    public class DetailsModel : PageModel
    {
        private readonly FilmesRP.Data.FilmesRPContext _context;

        public DetailsModel(FilmesRP.Data.FilmesRPContext context)
        {
            _context = context;
        }

        public Filme Filme { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            else
            {
                Filme = filme;
            }
            return Page();
        }
    }
}
