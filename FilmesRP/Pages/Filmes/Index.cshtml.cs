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
        [BindProperty(SupportsGet = true)]
        public string TermoBusca { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilmeGenero { get; set; }

        public SelectList Generos { get; set; }


        public async Task OnGetAsync()
        {
            var busca = from m in _context.Filme select m;

            if (!string.IsNullOrWhiteSpace(TermoBusca))
            {
                busca = busca.Where(f => f.Titulo.Contains(TermoBusca));
            }
            if (!string.IsNullOrWhiteSpace(FilmeGenero))
            {
                busca = busca.Where(f => f.Genero == FilmeGenero);
            }
            Generos = new SelectList(await _context.Filme.Select(g => g.Genero).Distinct().ToListAsync());
            Filme = await busca.ToListAsync();
        }
    }
}
