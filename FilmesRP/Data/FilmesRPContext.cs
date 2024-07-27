using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmesRP.Model;

namespace FilmesRP.Data
{
    public class FilmesRPContext : DbContext
    {
        public FilmesRPContext (DbContextOptions<FilmesRPContext> options)
            : base(options)
        {
        }

        public DbSet<FilmesRP.Model.Filme> Filme { get; set; } = default!;
    }
}
