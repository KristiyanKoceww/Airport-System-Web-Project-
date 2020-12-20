namespace AirportSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AirportSystem.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
