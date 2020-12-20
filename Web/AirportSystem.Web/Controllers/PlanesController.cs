namespace AirportSystem.Web.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Services.Data.InputModels;
    using AirportSystem.Services.Data.Planes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class PlanesController : Controller
    {
        private readonly IPlaneService planeService;

        public PlanesController(IPlaneService planeService)
        {
            this.planeService = planeService;
        }

        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlaneInputModel planeInputModel)
        {
            this.planeService.Create(planeInputModel);
            return this.View();
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
