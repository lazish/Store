using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.DataBaseHelper;
using Store.Services;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public SoldProductsController(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }



        [HttpGet, Authorize(Roles = "admin")]
        public async Task<ActionResult<List<SoldProductDto>>> Get()
        {
            var soldProduct = await _context.SoldProducts.ToListAsync();

            List<SoldProductDto> SoldList = new List<SoldProductDto>();

            foreach (var item in soldProduct)
            {
                var user = _context.Users.Where(x => x.Id == item.AuthId).FirstOrDefault();

                var newSold = new SoldProductDto()
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    AuthName = user.Username,
                };

                SoldList.Add(newSold);

            }

            return Ok(SoldList);
        }


        [HttpPost, Authorize]
        public async Task<ActionResult<bool>> SoldProductPost([FromBody] string req)
        {
            var username = _userService.GetMyName();

            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user == null) return Ok(false);

            var orders = await _context.Orders.Where(x => x.AuthId == user.Id).ToListAsync();

            if (orders.Count <= 0) return Ok(false);


            foreach (var item in orders)
            {
                var sold = new SoldProduct()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductName = item.ProductName,
                    AuthId = user.Id
                };

                _context.SoldProducts.Add(sold);

                _context.Orders.Remove(item);

            }

            await _context.SaveChangesAsync();

            var soldList = await _context.SoldProducts.Where(x => x.AuthId == user.Id).ToListAsync();

            return Ok(true);
        }


        [HttpDelete, Authorize(Roles = "admin")]
        public async Task<ActionResult<SoldProduct>> DeleteSold([FromQuery] int id)
        {
            var soldPorduct = _context.SoldProducts.Where(x => x.Id == id).FirstOrDefault();

            if (soldPorduct == null) return Ok(false);

            _context.SoldProducts.Remove(soldPorduct);

            await _context.SaveChangesAsync();

            return Ok(soldPorduct);
        }
    }
}
