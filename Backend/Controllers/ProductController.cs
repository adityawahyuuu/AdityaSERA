using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AdityaSERA.Backend.Repositories.Cat;
using AdityaSERA.Backend.Repositories.Details;
using AdityaSERA.Backend.Repositories.Ord;
using AdityaSERA.Backend.Repositories.Prod;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("products/{transactionID}")]
        public async Task<IActionResult> AddProductAsync([FromForm] AddProductRequest request, [FromRoute] string transactionID)
        {
            var categoryByName = await _categoryRepository.getCategoryByName(request.CategoryName);
            var categoryIdByName = _mapper.Map<GetCategoryIdByName>(categoryByName);

            var whosOrder = await _orderRepository.getOrderInfo(transactionID);

            var addedProduct = new Product()
            {
                ProductName = request.ProductName,
                CategoryID = categoryIdByName.CategoryID,
                Price = request.Price*request.Stock,
                Stock = request.Stock,
                ProductImage = request.ProductImage
            };


            addedProduct = await _productRepository.addProduct(addedProduct);

            whosOrder.TotalAmount += addedProduct.Price;

            var addedOrderDetail = new OrderDetail()
            {
                TransactionDetail_ID = transactionID + addedProduct.ProductID.ToString(),
                TransactionID = transactionID,
                Order = whosOrder,
                ProductID = addedProduct.ProductID,
                Product = addedProduct,
                CategoryID = addedProduct.CategoryID,
                Categories = categoryByName,
                TotalPrice = addedProduct.Price
            };

            await _orderDetailRepository.addOrderDetail(addedOrderDetail);
            
            return Ok();
        }
    }
}
