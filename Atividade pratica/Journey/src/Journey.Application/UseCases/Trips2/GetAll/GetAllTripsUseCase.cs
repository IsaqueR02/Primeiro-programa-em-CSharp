using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips2.GetAll;
public class GetAllTripsUseCase
{
    public ResponseTripsJson Execute()
    {
        var dbContext = new JourneyDbContext();

        var trips = dbContext.Trips.ToList();

        return new ResponseTripsJson
        {
            Trips = trips.Select(trip => new ResponseShortTripJson
            {
                StartDate = trip.StartDate,
                Name = trip.Name,
                Id = trip.Id,
                EndDate = trip.EndDate
            }).ToList(),
        };
    }
}
