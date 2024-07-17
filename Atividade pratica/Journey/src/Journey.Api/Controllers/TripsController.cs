using Journey.Application.UseCases.Trips2.Register;
using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            try {
                var useCase = new RegisterTripUserCase();

                useCase.Execute(request);

                return Created();
            } 
            catch (JourneyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
