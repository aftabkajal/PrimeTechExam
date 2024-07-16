using Microsoft.AspNetCore.Mvc;
using PrimeTech.Interview.Business.Commands.Commands;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Domain.Dispatchers;
using PrimeTech.Interview.Business.Queries.Queries;

namespace PrimeTech.Interview.Business.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CompaniesController(
            ILogger<CompaniesController> logger,
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("all")]
        public async Task<object> GetAllCompanies([FromBody] GetAllCompaniesQuery query)
        {
            var result = await _queryDispatcher.DispatchAsync<GetAllCompaniesQuery, StringResult>(query);
            return result.GetResponse();
        }

        [HttpGet("customfields")]
        public async Task<object> GetCompanyCustomFieldsByCompanyId([FromBody] GetCompanyCustomFieldsByCompanyQuery query)
        {
            var result = await _queryDispatcher.DispatchAsync<GetCompanyCustomFieldsByCompanyQuery, StringResult>(query);
            return result.GetResponse();
        }

        [HttpGet("GetCompany")]
        public async Task<object> GetCompany([FromBody] GetCompanyQuery query)
        {
            var result = await _queryDispatcher.DispatchAsync<GetCompanyQuery, StringResult>(query);
            return result.GetResponse();
        }

        [HttpPost("Create")]
        public async Task<CommandResponse> Post([FromBody] CreateCompanyCommand command)
        {
            return await _commandDispatcher.DispatchAsync<CreateCompanyCommand, CommandResponse>(command);
        }

        [HttpPut("Update")]
        public async Task<CommandResponse> Put([FromBody] UpdateCompanyCommand command)
        {
            return await _commandDispatcher.DispatchAsync<UpdateCompanyCommand, CommandResponse>(command);
        }

        [HttpDelete("Delete")]
        public async Task<CommandResponse> Delete([FromBody] DeleteCompanyCommand command)
        {
            return await _commandDispatcher.DispatchAsync<DeleteCompanyCommand, CommandResponse>(command);
        }

        [HttpPost("CreareCustomField")]
        public async Task<CommandResponse> CreateCompanyCustomField([FromBody] CreateCompanyCustomFieldCommand command)
        {
            return await _commandDispatcher.DispatchAsync<CreateCompanyCustomFieldCommand, CommandResponse>(command);
        }
    }
}
