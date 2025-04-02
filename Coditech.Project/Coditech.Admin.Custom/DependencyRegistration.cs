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
            #endregion Agent

            #region CoOperativeBank
            builder.Services.AddScoped<IBankSetupMortagePropertyTypeAgent, BankSetupMortagePropertyTypeAgent>();
            #endregion

            #region Client
            builder.Services.AddScoped<ICustomDashboardClient, CustomDashboardClient>();
            #endregion

            #region CoOperativeBank
            builder.Services.AddScoped<IBankSetupMortagePropertyTypeClient, BankSetupMortagePropertyTypeClient>();
            #endregion
        }
    }
}
