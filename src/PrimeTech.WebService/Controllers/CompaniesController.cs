using Microsoft.AspNetCore.Mvc;


namespace PrimeTech.Interview.Business.WebService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ILogger<CompaniesController> _logger;
    public CompaniesController(
        ILogger<CompaniesController> logger)
    {
        _logger = logger;
    }
    // GET: api/<CompaniesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CompaniesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CompaniesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CompaniesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CompaniesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

