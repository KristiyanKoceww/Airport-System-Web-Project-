﻿namespace AirportSystem.Web.Areas.Administration.Controllers
{
    using AirportSystem.Common;
    using AirportSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
    }
}
