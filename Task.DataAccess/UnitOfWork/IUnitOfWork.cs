using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataAccess.IRepository;

namespace Task.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        void SaveChanges();
    }
}
