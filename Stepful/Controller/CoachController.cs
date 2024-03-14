using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stepful
{
    [Authorize]
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetUpcomingSlots()
        {
            return new string[] { };
        }

        //[HttpGet]
        //public IEnumerable<string> AddSlot(string Id)
        //{
        //    return new string[] { };
        //}



        //[HttpGet]
        //public IEnumerable<string> CancelBooking(string Id)
        //{
        //    return new string[] { };
        //}

        //[HttpGet]
        //public IEnumerable<string> ShowBookings()
        //{
        //    return new string[] { };
        //}
    }
}
