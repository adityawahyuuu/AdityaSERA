using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AdityaSERA.Backend.Repositories.Ord;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public HomeController(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        // controller login berisi satu form untuk masukan nama kasir kemudian generate semua properti yg ada di order
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromForm] AddOrderRequest request)
        {
            var addOrder = new Order
            {
                TransactionID = request.TransactionID,
                TransactionDate = DateTime.Now,
                TransactionNumber = request.TransactionNumber,
                CashierName = request.CashierName,
                TotalAmount = 0
            };

            addOrder = await _orderRepository.AddOrder(addOrder);

            return Ok(addOrder);
        }

        // controller logout merefresh kondisi login sehingga generate order baru, selama belum logout, id transaksi akan sama
        // dilakukan di FE, direct ke home dan hapus path, diarahkan oleh FE
    }
}
