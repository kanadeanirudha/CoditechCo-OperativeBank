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

            #region CoOperativeBank
            builder.Services.AddScoped<IBankSetupMortagePropertyTypeAgent, BankSetupMortagePropertyTypeAgent>();
            builder.Services.AddScoped<IBankVehicleModelAgent, BankVehicleModelAgent>();
            builder.Services.AddScoped<IBankSetupPropertyValuersAgent, BankSetupPropertyValuersAgent>();
            builder.Services.AddScoped<IBankSetupPropertyValuersAuthorityAgent, BankSetupPropertyValuersAuthorityAgent>();
            builder.Services.AddScoped<IBankMemberShareCapitalAgent, BankMemberShareCapitalAgent>();
            builder.Services.AddScoped<IBankMemberAgent, BankMemberAgent>();

            #endregion




            #region Client
            builder.Services.AddScoped<ICustomDashboardClient, CustomDashboardClient>();
            builder.Services.AddScoped<IBankInsurancePoliciesTypeClient, BankInsurancePoliciesTypeClient>();
            builder.Services.AddScoped<IBankSetupDivisionClient, BankSetupDivisionClient>();
            builder.Services.AddScoped<IBankSetupOfficesClient, BankSetupOfficesClient>();

            #region CoOperativeBank
            builder.Services.AddScoped<IBankSetupMortagePropertyTypeClient, BankSetupMortagePropertyTypeClient>();
            builder.Services.AddScoped<IBankVehicleModelClient, BankVehicleModelClient>();
            builder.Services.AddScoped<IBankSetupPropertyValuersClient, BankSetupPropertyValuersClient>();
            builder.Services.AddScoped<IBankSetupPropertyValuersAuthorityClient, BankSetupPropertyValuersAuthorityClient>();
            builder.Services.AddScoped<IBankMemberShareCapitalClient, BankMemberShareCapitalClient>();
            builder.Services.AddScoped<IBankMemberClient, BankMemberClient>();



            #endregion

            #endregion Client
        }
    }
}
