using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data;
using Task.DataAccess.IRepository;
using Test.Models;

namespace Task.DataAccess.Repository
{
    internal class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShopContext  shopContext) : base(shopContext)
        {
        }
    }
}
