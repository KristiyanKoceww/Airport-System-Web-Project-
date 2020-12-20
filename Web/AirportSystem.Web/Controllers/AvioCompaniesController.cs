namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.Airports;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AvioCompaniesController : Controller
    {
        private readonly IAvioCompanyService avioCompanyService;

        public AvioCompaniesController(IAvioCompanyService avioCompanyService)
        {
            this.avioCompanyService = avioCompanyService;
        }

        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AvioCompanyInputModel input)
        {
            this.avioCompanyService.Create(input);
            return this.View();
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }

        public async Task<IActionResult> AddPlane()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlane(AddPlaneToAvioCompanyInputModel addPlaneToAvioCompanyInputModel)
        {
            this.avioCompanyService.AddPlanes(addPlaneToAvioCompanyInputModel);
            return this.View();
        }
    }
}
