namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Planes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class PlanesController : Controller
    {
        private readonly IPlaneService planeService;

        public PlanesController(IPlaneService planeService)
        {
            this.planeService = planeService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(PlaneInputModel planeInputModel)
        {
            this.planeService.Create(planeInputModel);
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
