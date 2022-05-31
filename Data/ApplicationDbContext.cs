using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UnitOfWork.Models;

namespace UnitOfWork.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pelicula> peliculas { get; set; }
        public DbSet<Alquiler> alquileres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

      
    }
}
