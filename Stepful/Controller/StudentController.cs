using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StepfulLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stepful;

[Route("/api/v1/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private IStudentService Service { get; set; }

    public StudentController(IStudentService Service)
    {
        this.Service = Service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    {
       var result = await Service.GetAllAsync();
        return Ok(result);

    }


    [HttpGet("{email}")]
    public async Task<ActionResult<Student>> GetByEmail(string email)
    {
        return null;
    }

    [HttpPost("{email}")]
    public async Task<ActionResult<Student>> Create(string email)
    {
        return null;
    }

}

        //[HttpGet]
        //public IEnumerable<string> BookSlot(string Id)
        //{
        //    // Enable Phone Sharing, After Success

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






        //// GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    //}
