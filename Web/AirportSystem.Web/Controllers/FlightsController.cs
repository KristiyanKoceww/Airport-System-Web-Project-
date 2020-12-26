namespace AirportSystem.Web.Controllers
{

    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Common;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Planes;
    using AirportSystem.Services.Data.TravelLines;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FlightsController : Controller
    {
        private readonly IFlightService flightService;
        private readonly ITravelLinesService travelLinesService;
        private readonly IPlaneService planeService;

        public FlightsController(IFlightService flightService, ITravelLinesService travelLinesService, IPlaneService planeService)
        {
            this.flightService = flightService;
            this.travelLinesService = travelLinesService;
            this.planeService = planeService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(FlightInputModel flightInputModel)
        {
            var travelLine = this.travelLinesService.FindTravelLineByCityId(flightInputModel.TravelLineCityId, flightInputModel.TravelLineCity2Id);
            var plane = this.planeService.GetPlaneById(flightInputModel.PlaneId);

            if (travelLine == null)
            {
                this.ViewBag.Massage = "Travel line not found";
                return this.View("TravelLineOrPlaneNotFound");
            }
            else if (plane == null)
            {

                this.ViewBag.Massage = "Plane not found";
                return this.View("TravelLineOrPlaneNotFound");
            }

            this.flightService.Create(flightInputModel);
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> All()
        {
            return this.View();
        }

        public async Task<IActionResult> All2()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> GetFlightById()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> GetFlightById(int Id)
        {
            var flight = this.flightService.GetFlightById(Id);

            if (flight == null)
            {
                return this.View("FlightByIdNotFound");
            }

            var viewModel = new GetFlightByIdViewModel
            {
                Id = flight.Id,
                PlaneId = flight.PlaneId,
                FlightStatus = flight.FlightStatus,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                FlightDuration = flight.FlightDuration,
                TravelLineCityName = flight.TravelLineCityName,
                TravelLineCity2Name = flight.TravelLineCity2Name,
                Price = flight.Price,
            };

            return this.View("GetFlightByIdResult", viewModel);
        }

        public async Task<IActionResult> Search(string origin, string destinaton)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchForFlightViewModel flight)
        {
            var flights = this.flightService.SearchForFlight(flight.Origin, flight.Destination);

            if (flights.Count() == 0)
            {
                return this.View("FlightNotFound");
            }

            return this.View("SearchResults", flights);
        }

        public async Task<IActionResult> SearchByDestination(string destination)
        {
            var flights = this.flightService.FlightsByDestination(destination);

            if (flights.Count() == 0)
            {
                return this.View("NotFound");
            }

            return this.View("SearchResults", flights);
        }
    }
}
