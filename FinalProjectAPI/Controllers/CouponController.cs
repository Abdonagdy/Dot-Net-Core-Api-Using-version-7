using DbContextL;
using Domian;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly Context _dbContext;
        public CouponController(Context context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public IActionResult GetCoupons()
        {
            var coupons = _dbContext.cuponCodes.ToList();
            return Ok(coupons);
        }


        [HttpGet("GetCoupon")]
        public IActionResult GetCoupon([FromQuery] string code)
        {
            var coupon = _dbContext.cuponCodes.FirstOrDefault(c => c.Code == code && c.ExpirationDate >= DateTime.Now && c.Isavliable==true);

            if (coupon == null)
            {
                return Ok(null!);
            }
            else if(coupon.ExpirationDate < DateTime.Now) {

                return Ok(null!);
            }
            else if(coupon.Isavliable == false)
            {
                return Ok(null);
            }
            CuponCode couponCode = new CuponCode();
            couponCode.Code =coupon.Code;
            couponCode.Isavliable = coupon.Isavliable;
            couponCode.ExpirationDate = coupon.ExpirationDate;
            couponCode.DiscountAmount = coupon.DiscountAmount;

            coupon.Isavliable = false;
            _dbContext.SaveChanges();
            return Ok(couponCode);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCoupon(int id, [FromBody] CuponCode updatedCoupon)
        {
            var existingCoupon = _dbContext.cuponCodes.FirstOrDefault(c => c.Id == id);

            if (existingCoupon == null)
            {
                return NotFound();
            }
            existingCoupon.Isavliable = updatedCoupon.Isavliable;


            _dbContext.SaveChanges();

            return Ok(existingCoupon);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCoupon(int id)
        {
            var coupon = _dbContext.cuponCodes.FirstOrDefault(c => c.Id == id);

            if (coupon == null)
            {
                return NotFound();
            }

            _dbContext.cuponCodes.Remove(coupon);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
