using System;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Models;
using UnitOfWork.Repository;

namespace UnitOfWork.UWork
{
    public class UnitofWork : IDisposable
    {
        
        private DbContext context;
        private GenericRepository<Alquiler> alquilerRepository;
        private GenericRepository<Pelicula> peliculaRepository;

        public GenericRepository<Alquiler> AlquilerRepository
        {
            get
            {

                if (this.alquilerRepository == null)
                {
                    this.alquilerRepository = new GenericRepository<Alquiler>(context);
                }
                return alquilerRepository;
            }
        }

        public GenericRepository<Pelicula> PeliculaRepository
        {
            get
            {

                if (this.peliculaRepository == null)
                {
                    this.peliculaRepository = new GenericRepository<Pelicula>(context);
                }
                return peliculaRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}