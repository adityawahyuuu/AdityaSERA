using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AdityaSERA.Backend.Repositories.Cat;
using AdityaSERA.Backend.Repositories.Details;
using AdityaSERA.Backend.Repositories.Ord;
using AdityaSERA.Backend.Repositories.Prod;
using AdityaSERA.Backend.Services.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly AdityaSERADbContext _adityaSERADbContext;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ICategoryRepository categoryRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository, AdityaSERADbContext adityaSERADbContext)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._adityaSERADbContext = adityaSERADbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("order/{transactionID}")]
        public async Task<IActionResult> GetOrderDetailsSync([FromRoute] string transactionID)
        {
            var orderDetails = await _orderDetailRepository.getOrderDetails(transactionID);

            List<Product> productByTRX = new List<Product>();

            foreach (var orderDetail in orderDetails)
            {
                var prodById = await _productRepository.getOrderProductById(orderDetail.ProductID);

                productByTRX.Add(prodById);
            }

            return Ok(productByTRX);
        }

        [HttpDelete]
        [Route("order/{transactionID}/{productId}")]
        public async Task<IActionResult> DeleteOrderProductSync([FromRoute] string transactionID, [FromRoute] int productId)
        {
            var orderDetails = await _orderDetailRepository.getOrderDetails(transactionID);

            var deletedProduct = new Product();

            foreach (var orderDetail in orderDetails)
            {
                var prodById = await _productRepository.getOrderProductById(orderDetail.ProductID);

                if (productId == prodById.ProductID)
                {
                    deletedProduct = prodById;
                    _adityaSERADbContext.Remove(prodById);
                    await _adityaSERADbContext.SaveChangesAsync();

                }
            }

            return Ok(deletedProduct);
        }

        [HttpPatch]
        [Route("order/{transactionID}/{productId}")]
        public async Task<IActionResult> UpdateOrderProductSync([FromRoute] string transactionID, [FromRoute] int productId, [FromForm] AddProductRequest request)
        {
            var orderDetails = await _orderDetailRepository.getOrderDetails(transactionID);

            var categoryByName = await _categoryRepository.getCategoryByName(request.CategoryName);
            var categoryIdByName = _mapper.Map<GetCategoryIdByName>(categoryByName);

            var updatedProduct = new Product();

            foreach (var orderDetail in orderDetails)
            {
                var prodById = await _productRepository.getOrderProductById(orderDetail.ProductID);

                if (productId == prodById.ProductID)
                {
                    prodById.ProductName = request.ProductName;
                    prodById.Stock = request.Stock;
                    prodById.Price = request.Price* request.Stock;
                    prodById.CategoryID = categoryIdByName.CategoryID;
                    prodById.Category = categoryByName;

                    updatedProduct = prodById;

                }
                await _adityaSERADbContext.SaveChangesAsync();
            }

            return Ok(updatedProduct);
        }
    }
}
