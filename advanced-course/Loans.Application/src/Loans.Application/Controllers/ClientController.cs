using Microsoft.AspNetCore.Mvc;
using Loans.Application.Base;
using Loans.Application.Requests;

namespace Loans.Application.Controllers
{
    [Route("client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("{clientId}/loans")]
        public IActionResult GetContracts(long clientId)
        {
            var contracts = Enumerable.Range(1, 5).Select(_ => Guid.NewGuid()).ToList();
            return Ok(contracts);
        }
        
        [HttpPost]
        public IActionResult SearchClients([FromQuery] ClientFilterModel filterModel)
        {
            var filteredClients = FilterClients(filterModel);
            var clientInfoModels = filteredClients.Select(client => new ClientInfoModel
            {
                ClientId = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                BirthDate = client.BirthDate
            }).ToList();
            return Ok(clientInfoModels);
        }
        
        private List<Client> FilterClients(ClientFilterModel filterModel)
        {
            return new List<Client>(); 
        }
    }
}
