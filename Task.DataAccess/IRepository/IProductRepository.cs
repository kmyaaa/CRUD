using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data;

namespace Task.DataAccess.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();      //Get All
        Product Get(int id);                //Get By ID
        void Add(Product item);          //Insert Record
        void Update(Product item);          //Update Record
        void Delete(Product item);
    }

}
