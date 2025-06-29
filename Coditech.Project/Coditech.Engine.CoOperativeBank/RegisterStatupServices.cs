﻿
using Coditech.API.Data;
using Coditech.API.Service;
using Coditech.Common.API;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Coditech.API.Common
{
    /// <summary>
    /// Implemented common method which are using in the Program.cs.
    /// </summary>
    public static class RegisterStatupServices
    {
        #region static variables
        /// <summary>
        /// Cors policy name
        /// </summary>
        public static string corsOrigin = "CorsPolicy";

        #endregion

        /// <summary>
        /// Configure all services by using WebApplicationBuilder.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterCommonServices(this WebApplicationBuilder builder)
        {
            // Registred all media setting.
            builder.RegisterMedia();

            // Registred all entity classes with their connection string.
            builder.RegisterEntity();

            // Adds cross-origin resource sharing services to the specified <see cref="IServiceCollection" />.
            builder.RegisterCorsPolicy();

            // Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
            // register services used for views or pages.
            builder.RegisterControllerService();

            //RegisterDI
            builder.RegisterDI();

            // Configured conventional route settings.
            builder.ConfigureRouteSettings();

            // Configured AutoMapper Services.
            builder.ConfigureAutomapperAssemblies();

            // Registered custom filters.
            builder.RegisterFilters();

        }

        /// <summary>
        /// Register all application level services which we are using inside the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="builder"></param>
        public static void RegisterApplicationServices(this WebApplication app, WebApplicationBuilder builder)
        {
            //// Adds a middleware type to the application's request pipeline.
            //app.UseMiddleware<RequestMiddleware>();

            //Build service provider static instance.
            CoditechDependencyResolver._staticServiceProvider = builder.Services.BuildServiceProvider();

            // Assigned the values to the TanslatorExtension (Automapper).IProductHistoryServiceIProductHistoryService
            ConfigureAutomapperServices();

            // Register the Swagger middleware with optional setup action for DI-injected options with customisation.
            //app.ConfigureSwagger();

            // Adds a <see cref="EndpointRoutingMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>.
            app.UseRouting();

            // Adds middleware for redirecting HTTP Requests to HTTPS.
            app.UseHttpsRedirection();

            // Adds the static file configurations with custom path.
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                       Path.Combine(builder.Environment.ContentRootPath, "Data")),
                RequestPath = "/Data"
            });

            // Adds the <see cref="AuthorizationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>,
            // which enables authorization capabilities.
            app.UseAuthorization();

            // Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
            // without specifying any routes.
            app.MapControllers();

            // ToDo Can we use App.MapGet / MapPost methods instead on UseEndpoints.
            app.UseEndpoints(endpoints =>
            {
                // This is a temporary route, need to be removed.
                endpoints.MapFallbackToFile("index.html");
            });

            // Adds a CORS middleware to your web application pipeline to allow cross domain requests.
            app.UseCors(corsOrigin);
        }

        #region Common custom methods
        //ToDo manage cors policy at the runtime basis.
        /// <summary>
        /// Add cors policy for allow specific or all domains.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterCorsPolicy(this WebApplicationBuilder builder)
        {
            // Adds cross-origin resource sharing services to the specified <see cref="IServiceCollection" />.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsOrigin,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                  });
            });
        }

        /// <summary>
        /// Registering controllers and configures Newtonsoft.Json specific features
        /// such as input and output formatters.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterControllerService(this WebApplicationBuilder builder)
        {
            // Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
            // register services used for views or pages.
            builder.Services.AddControllers();

            //// Configures Newtonsoft.Json specific features such as input and output formatters.
            //builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Configures ApiExplorer using <see cref="Endpoint.Metadata"/>.
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
        }

        /// <summary>
        /// Registring all entity classes with their connection string.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterEntity(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("CoditechDatabase");
            // Coditech entity registration
            builder.Services.AddDbContext<Coditech_Entities>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            builder.Services.AddDbContext<CoditechCustom_Entities>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            // Repository classes registration
            builder.Services.AddTransient(typeof(ICoditechRepository<>), typeof(CoditechRepository<>));

            // Contextaccesssor registration (HttpContext)
            builder.Services.AddHttpContextAccessor();

        }

        /// <summary>
        /// Configure conventional route settings.
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureRouteSettings(this WebApplicationBuilder builder)
        {
            // Configure conventional route settings.
            builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddXmlSerializerFormatters();
        }

        /// <summary>
        /// Configure AutoMapper Services
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureAutomapperAssemblies(this WebApplicationBuilder builder)
        {
            // Configure AutoMapper Service Provider Instance
            builder.Services.AddScoped<CoditechTranslator>();

            // Register all assemblies in the Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// Register custom filters.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterFilters(this WebApplicationBuilder builder)
        {
            //Filter will be registered here.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<APIAuthorizeAttribute>();
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });
        }

        /// <summary>
        /// Assigning the values to the TanslatorExtension (Automapper)
        /// </summary>
        public static void ConfigureAutomapperServices()
        {
            // Assigned ZnoneTranslator to TranslatorExtension.
            TranslatorExtension.TranslatorInstance = CoditechDependencyResolver._staticServiceProvider?.GetService<CoditechTranslator>();
        }

        /// <summary>
        /// Registring all media setting
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterMedia(this WebApplicationBuilder builder)
        {
            // Coditech entity registration
            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = 104857600;
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = 104857600;
                options.MultipartBodyLengthLimit = 104857600;
                options.MultipartHeadersLengthLimit = 104857600;
            });

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxRequestBodySize = 104857600;
            });
        }
        #endregion

        #region Register Dependency
        /// <summary>
        /// Register DI with default microsoft container.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterDI(this WebApplicationBuilder builder)
        {
            // Add Dependency 
            builder.Services.AddSingleton<ICoditechLogging, CoditechLogging>();
            builder.Services.AddScoped<ICustomDashboardService, CustomDashboardService>();
           

            #region CoOperativeBank
            builder.Services.AddScoped<IBankSetupMortagePropertyTypeService, BankSetupMortagePropertyTypeService>();
            builder.Services.AddScoped<IBankVehicleModelService, BankVehicleModelService>();
            builder.Services.AddScoped<IBankSetupPropertyValuersService, BankSetupPropertyValuersService>();
            builder.Services.AddScoped<IBankSetupPropertyValuersAuthorityService, BankSetupPropertyValuersAuthorityService>();
            builder.Services.AddScoped<IBankMemberShareCapitalService, BankMemberShareCapitalService>();
            builder.Services.AddScoped<IBankMemberNomineeService, BankMemberNomineeService>();
            builder.Services.AddScoped<IBankInsurancePoliciesTypeService, BankInsurancePoliciesTypeService>();
            builder.Services.AddScoped<IBankSetupDivisionService, BankSetupDivisionService>();
            builder.Services.AddScoped<IBankSetupOfficesService, BankSetupOfficesService>();
            builder.Services.AddScoped<IBankSavingsAccountService, BankSavingsAccountService>();
            builder.Services.AddScoped<IBankMemberService, BankMemberService>();
            builder.Services.AddScoped<IBankSavingAccountIntrestPostingsService, BankSavingAccountIntrestPostingsService>();
            builder.Services.AddScoped<IBankFixedDepositAccountService, BankFixedDepositAccountService>();
            builder.Services.AddScoped<IBankProductService, BankProductService>();
            builder.Services.AddScoped<IBankPostingLoanAccountService, BankPostingLoanAccountService>();
            builder.Services.AddScoped<IBankRecurringDepositAccountService, BankRecurringDepositAccountService>();
            builder.Services.AddScoped<IBankSavingsAccountTransactionsService, BankSavingsAccountTransactionsService>();
            builder.Services.AddScoped<IBankLoanScheduleService, BankLoanScheduleService>();


            #endregion
        }
        #endregion
    }
}
