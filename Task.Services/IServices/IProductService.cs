using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Common.Dtos;

namespace Task.Services.IServices
{
    public interface IProductService
    {
        void InsertProduct(ProductDto productDto);
        List<ProductDto> GetProducts();
    }
}
