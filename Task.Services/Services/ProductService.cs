using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Common.Dtos;
using Task.Data;
using Task.DataAccess.UnitOfWork;
using Task.Services.IServices;

namespace Task.Services.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork UnitOfWork { get; }

        public ProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void InsertProduct(ProductDto productDto)
        {
            UnitOfWork.ProductRepository.Add(MapDtoToEntity(productDto));
            UnitOfWork.SaveChanges();

        }


        private Product MapDtoToEntity(ProductDto productDto)
        {
            return new Product
            {
                CategoryName = productDto.CategoryName,
                Name = productDto.Name,
                Price = productDto.Price
            };
        }

        
        private ProductDto MapEntityToDto(Product product)
        {
            return new ProductDto
            {
                CategoryName = product.CategoryName,
                Name = product.Name,
                Price = product.Price,
                Id = product.Id
            };
        }

        public List<ProductDto> GetProducts()
        {
            return UnitOfWork.ProductRepository.GetAll().Select(MapEntityToDto).ToList();
        }
    }
}
