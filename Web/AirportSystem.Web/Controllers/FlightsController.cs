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
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create(FlightInputModel flightInputModel)
        {
            var travelLine = this.travelLinesService.FindTravelLineByCityId(flightInputModel.TravelLineCityId, flightInputModel.TravelLineCity2Id);
            var plane = this.planeService.GetPlaneById(flightInputModel.PlaneId);

            if (plane.IsPlaneAvailable == false)
            {
                this.ViewBag.Massage = "This plane is already taken by another flight!";
                return this.View("TravelLineOrPlaneNotFound");
            }

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
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult All2()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult GetFlightById()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult GetFlightById(int id)
        {
            var flight = this.flightService.GetFlightById(id);

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

        public IActionResult Search(string origin, string destinaton)
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(SearchForFlightViewModel flight)
        {
            var flights = this.flightService.SearchForFlight(flight.Origin, flight.Destination);

            if (flights.Count() == 0)
            {
                return this.View("NotFoundDestination");
            }

            return this.View("SearchResults", flights);
        }

        [HttpGet]
        public IActionResult SearchByDestination(string destination)
        {
            var flights = this.flightService.FlightsByDestination(destination);

            if (flights.Count() == 0)
            {
                return this.View("NotFoundDestination");
            }

            return this.View("SearchResults", flights);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Remove()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var flight = this.flightService.GetFlightById(id);

            this.flightService.Remove(flight);

            return this.View();
        }
    }
}
