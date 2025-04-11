using Coditech.Admin.Agents;
using Coditech.API.Client;
using Coditech.Common.Helper.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace Coditech.Admin.Custom
{
    public static class DependencyRegistration
    {
        public static void RegisterCustomDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<CoditechTranslator>();
            #region Agent
            builder.Services.AddScoped<ICustomDashboardAgent, CustomDashboardAgent>();
            builder.Services.AddScoped<IBankInsurancePoliciesTypeAgent, BankInsurancePoliciesTypeAgent>();
            builder.Services.AddScoped<IBankSetupDivisionAgent, BankSetupDivisionAgent>();
            builder.Services.AddScoped<IBankSetupOfficesAgent, BankSetupOfficesAgent>();
            #endregion Agent

            #region Client
            builder.Services.AddScoped<ICustomDashboardClient, CustomDashboardClient>();
            builder.Services.AddScoped<IBankInsurancePoliciesTypeClient, BankInsurancePoliciesTypeClient>();
            builder.Services.AddScoped<IBankSetupDivisionClient, BankSetupDivisionClient>();
            builder.Services.AddScoped<IBankSetupOfficesClient, BankSetupOfficesClient>();
            #endregion 
        }
    }
}
