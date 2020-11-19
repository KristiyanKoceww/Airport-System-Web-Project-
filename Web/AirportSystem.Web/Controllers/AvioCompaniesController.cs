namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.Airports;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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

        public IActionResult AddPlane()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddPlane(AddPlaneToAvioCompanyInputModel addPlaneToAvioCompanyInputModel)
        {
            this.avioCompanyService.AddPlanes(addPlaneToAvioCompanyInputModel);
            return this.View();
        }
    }
}
