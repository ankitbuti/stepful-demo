using Microsoft.AspNetCore.Mvc;
using StepfulLib;

namespace Stepful;

[Route("/api/v1/[controller]")]
[ApiController]
public class CalendarController : ControllerBase {
    [HttpGet]
    public IEnumerable<string> Get(){
        SLog.Write("...I am here...");
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string Get(int id){
        return "value";
    }

    [HttpPost]
    public void Post([FromBody] string value){

    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value){

    }

    [HttpDelete("{id}")]
    public void Delete(int id){

    }
}
