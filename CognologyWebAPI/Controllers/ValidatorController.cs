using Microsoft.AspNetCore.Mvc;
using CognologyApp;
using CognologyWebAPI.ViewModel;
using Newtonsoft.Json;

namespace CognologyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidatorController : ControllerBase
    {
        public ValidatorController(IValidator validator)
        {
            _validator = validator;
        }

        private IValidator _validator { get; }

        [HttpGet("{request}", Name = "Get")]
        public bool CheckAvailability(string request)
        {
            RequestData requestData = JsonConvert.DeserializeObject<RequestData>(request);

            return _validator.CheckAvailability(requestData.StartDate, requestData.EndDate, requestData.Pax);            
        }
    }
}