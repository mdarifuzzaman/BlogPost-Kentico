using BlogPost.Components;
using BlogPost.PageTemplates.PageTemplateFilters;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var kenticoServiceCollection = services.AddKentico(features =>
            {
                features.UsePageBuilder(new PageBuilderOptions
                {
                    DefaultSectionIdentifier = ComponentIdentifiers.SINGLE_COLUMN_SECTION,
                    RegisterDefaultSection = false,

                });

                //features.UsePageRouting(new PageRoutingOptions { EnableAlternativeUrls = true, CultureCodeRouteValuesKey = "culture" });
            })
            .SetAdminCookiesSameSiteNone();

            if (Environment.IsDevelopment())
            {
                kenticoServiceCollection.DisableVirtualContextSecurityForLocalhost();
            }

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddLocalization()
                    .AddControllersWithViews()
                    .AddViewLocalization()
                    .AddDataAnnotationsLocalization(options =>
                    {
                        options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResources));
                    });

            services.Configure<KenticoRequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Add(new RouteDataRequestCultureProvider
                {
                    RouteDataStringKey = "culture",
                    UIRouteDataStringKey = "culture"
                });
            });

            services.Configure<FormBuilderBundlesOptions>(options =>
            {
                options.JQueryCustomBundleWebRootPath = "Scripts/jquery-3.5.1.min.js";
                options.JQueryUnobtrusiveAjaxCustomBundleWebRootPath = "Scripts/jquery.unobtrusive-ajax.min.js";
            });

            services.AddCors(setupAction =>
            {
                setupAction.AddPolicy("allpermission", configure =>
                {
                    configure.AllowAnyOrigin();
                    configure.AllowAnyMethod();
                    configure.AllowAnyHeader();
                });
            });

            ConfigurePageBuilderFilters();
        }

        private static void ConfigurePageBuilderFilters()
        {
            PageBuilderFilters.PageTemplates.Add(new LandingPageTemplatesFilter());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseKentico();

            app.UseCookiePolicy();

            app.UseCors("allpermission");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Kentico().MapRoutes();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class SharedResources
    {
    }
}
