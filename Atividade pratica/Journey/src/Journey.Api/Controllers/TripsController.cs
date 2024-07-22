﻿using Journey.Application.UseCases.GetAll;
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
        public IActionResult GetAll()
        {
            var UseCase = new GetAllTripsUseCase();

            var result = UseCase.Execute();

            return Ok(result);
        }
    }
}
