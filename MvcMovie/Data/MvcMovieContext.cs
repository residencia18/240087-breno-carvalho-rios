using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MvcMovieContext).Assembly);
        }

        public DbSet<Movie> Movie { get; set; } = default!;

        public DbSet<User> User { get; set; } = default!;

        public DbSet<Artist> Artist { get; set; } = default!;

        public DbSet<Studio> Studio { get; set; } = default!;
    }
}
