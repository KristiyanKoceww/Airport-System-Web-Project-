namespace AirportSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Services.Data.HtmlToPdf;
    using AirportSystem.Services.Data.ViewRender;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class ExportController
    {
        private readonly IViewRenderService viewRenderService;
        private readonly IHtmlToPdfConverter htmlToPdfConverter;
        private readonly IHostingEnvironment environment;

        public ExportController(
            IViewRenderService viewRenderService,
            IHtmlToPdfConverter htmlToPdfConverter,
            IHostingEnvironment environment)
        {
            this.viewRenderService = viewRenderService;
            this.htmlToPdfConverter = htmlToPdfConverter;
            this.environment = environment;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPdf(SomeInputModel input)
        //{
        //    var model = this.GetViewModel(input);
        //    var htmlData = await this.viewRenderService.RenderToStringAsync("~/Views/Dashboard/GetPdf.cshtml", model);
        //    var fileContents = this.htmlToPdfConverter.Convert(this.environment.ContentRootPath, htmlData);
        //    return this.File(fileContents, "application/pdf");
        //}
    }
}
