using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Application.UseCases.Trips2.Register;
public class RegisterTripUserCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request) 
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
                
            throw new JourneyException("Nome não pode ser vazio");
        } 
        
        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new JourneyException("A viagem não pode ser registrada para uma data passada.");
        }

        if (request.EndDate.Date < request.StartDate.Date)
        {
            throw new JourneyException("A viagem deve terminar apos a data de inicio.");
        }
    }
}
