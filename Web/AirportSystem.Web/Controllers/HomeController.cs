namespace AirportSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICityService cityService;

        public HomeController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult Index()
        {
            //var cities = this.cityService.GetRandomCities();
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
