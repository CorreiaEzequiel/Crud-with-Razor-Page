using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmesRP.Data;
using FilmesRP.Model;

namespace FilmesRP.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly FilmesRP.Data.FilmesRPContext _context;

        public IndexModel(FilmesRP.Data.FilmesRPContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;

        public string TermoBusca { get; set; }


        public async Task OnGetAsync()
        {
            Filme = await _context.Filme.ToListAsync();
        }
    }
}
