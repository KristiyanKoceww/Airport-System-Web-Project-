namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Services.Data.Airports;
    using AirportSystem.Services.Data.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class AvioCompaniesController : Controller
    {
        private readonly IAvioCompanyService avioCompanyService;

        public AvioCompaniesController(IAvioCompanyService avioCompanyService)
        {
            this.avioCompanyService = avioCompanyService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AvioCompanyInputModel input)
        {
            this.avioCompanyService.Create(input);
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
