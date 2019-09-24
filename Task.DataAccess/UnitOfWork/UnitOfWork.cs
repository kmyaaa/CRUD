using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.DataAccess.IRepository;

namespace Task.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ShopContext DbEntity = new ShopContext();

        public IProductRepository ProductRepository { get; set; }

        public void SaveChanges()
        {
            DbEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    DbEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}