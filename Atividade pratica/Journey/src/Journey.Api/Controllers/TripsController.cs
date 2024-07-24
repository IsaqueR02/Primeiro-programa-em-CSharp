using Journey.Application.UseCases.Trips2.GetAll;
using Journey.Application.UseCases.Trips2.GetById;
using Journey.Application.UseCases.Trips2.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
{ 
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            try
            {
                var useCase = new RegisterTripUserCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (JourneyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro desconhecido");
            }
        }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
        {
            var UseCase = new GetAllTripsUseCase();

            var result = UseCase.Execute();

            return Ok(result);
        }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetTripByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response);
    }
}
