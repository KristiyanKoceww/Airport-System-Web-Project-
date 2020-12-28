namespace AirportSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using AirportSystem.Common;
    using AirportSystem.Services.Data.Airports;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Web.Areas.Administration.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AvioCompaniesController : AdminController
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
            var avioCompany = this.avioCompanyService.FindCompanyById(addPlaneToAvioCompanyInputModel.AvioCompanyId);

            if (avioCompany == null)
            {
                return this.View();
            }

            this.avioCompanyService.AddPlanes(addPlaneToAvioCompanyInputModel);
            return this.View();
        }
    }
}
