using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRMDotNetCore.PizzaApi.Db;
using STRMDotNetCore.PizzaApi.Models;

namespace STRMDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public PizzaController() 
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _appDbContext.pizzas.ToListAsync();
            return Ok(list);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var list = await _appDbContext.pizzaExtras.ToListAsync();
            return Ok(list);
        }

        [HttpPost("Orders")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest) 
        {
            var itemPizza =await _appDbContext.pizzas.FirstOrDefaultAsync(x => x.id == orderRequest.PizzaId);
            var total = itemPizza.price;

            if(orderRequest.Extras.Length> 0) 
            {
                //select * from PizzaExtra where PizzaExtraId in (1,2,3,4)
                var extrList= await _appDbContext.pizzaExtras.Where(x => orderRequest.Extras.Contains(x.id)).ToListAsync();
                total += extrList.Sum(x => x.pizzaExtraPrice);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrder = new PizzaOrderModel
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total,
            };
            List<PizzaOrderDetailModel> pizzaOrderDetails = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
            { 
                PizzaExtraId= extraId,
                PizzaOrderInvoiceNo= invoiceNo,

            }).ToList();
            await _appDbContext.pizzaOrders.AddAsync(pizzaOrder);
            await _appDbContext.pizzaOrderDetils.AddRangeAsync(pizzaOrderDetails);
            await _appDbContext.SaveChangesAsync();

            OrderResponse orderResponse = new OrderResponse
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your Order! Enjoy your Pizza!",
                TotalAmount = total,
            };
            return Ok(orderResponse);
        }

        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrders(String invoiceNo) 
        {
            var item = await _appDbContext.pizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            var list= await _appDbContext.pizzaOrders.Where(x=> x.PizzaOrderInvoiceNo== invoiceNo).ToListAsync();
            return Ok(new
            {
                Order = item,
                OrderDetail = list
            }) ;
        }
    }
}
