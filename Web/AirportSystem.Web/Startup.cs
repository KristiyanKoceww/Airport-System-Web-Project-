namespace AirportSystem.Web
{
    using System;
    using System.Reflection;

    using AirportSystem.Data;
    using AirportSystem.Data.Common;
    using AirportSystem.Data.Common.Repositories;
    using AirportSystem.Data.Models;
    using AirportSystem.Data.Repositories;
    using AirportSystem.Data.Seeding;
    using AirportSystem.Services.Data;
    using AirportSystem.Services.Data.Airport;
    using AirportSystem.Services.Data.Airports;
    using AirportSystem.Services.Data.CitiesAndCountries;
    using AirportSystem.Services.Data.Flights;
    using AirportSystem.Services.Data.Luggages;
    using AirportSystem.Services.Data.Passengers;
    using AirportSystem.Services.Data.Passports;
    using AirportSystem.Services.Data.Payments;
    using AirportSystem.Services.Data.Planes;
    using AirportSystem.Services.Data.Seats;
    using AirportSystem.Services.Data.Tickets;
    using AirportSystem.Services.Data.TravelLines;
    using AirportSystem.Services.Mapping;
    using AirportSystem.Services.Messaging;
    using AirportSystem.Web.StripeProps;
    using AirportSystem.Web.ViewModels;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Stripe;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));

            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ILuggageService, LuggageService>();
            services.AddTransient<IPassengersService, PassengersService>();
            services.AddTransient<IUserPassengersService, UserPassengersService>();
            services.AddTransient<IPassportService, PassportService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IAirportService, AirportService>();
            services.AddTransient<IAvioCompanyService, AvioCompanyService>();
            services.AddTransient<IPlaneService, PlaneService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<ITravelLinesService, TravelLinesService>();
            services.AddTransient<ISeatsService, SeatsService>();
            services.AddTransient<IPaymentService, PaymentService>();


            // Stripe service
            services.Configure<StripeSettings>(this.configuration.GetSection("Stripe"));

            // Sessions
            services.AddSession(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.SetApiKey(this.configuration.GetSection("Stripe")["SecretKey"]);

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
