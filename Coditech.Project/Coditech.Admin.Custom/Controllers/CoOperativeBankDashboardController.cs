﻿using Coditech.Admin.Agents;
using Coditech.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class CoOperativeBankDashboardController : BaseController
    {
        private readonly IDashboardAgent _dashboardAgent;
        private readonly ICustomDashboardAgent _customDashboardAgent;

        public CoOperativeBankDashboardController(IDashboardAgent dashboardAgent, ICustomDashboardAgent dBTMDashboardAgent)
        {
            _dashboardAgent = dashboardAgent;
            _customDashboardAgent = dBTMDashboardAgent;
        }

        [HttpGet]
        public IActionResult Index(short numberOfDaysRecord)
        {
            DashboardViewModel dashboardViewModel = _dashboardAgent.GetDashboardDetails();
            //if (IsNotNull(dashboardViewModel) && !string.IsNullOrEmpty(dashboardViewModel.DashboardFormEnumCode))
            //{
            //    if (dashboardViewModel.DashboardFormEnumCode.Equals(DashboardFormCustomEnum.CustomDashboard.ToString(), StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        CustomDashboardViewModel customDashboardViewModel = _customDashboardAgent.GetDBTMDashboardDetails();
            //        return View("~/Views/DBTM/DBTMDashboard/DBTMCentreDashboard.cshtml", customDashboardViewModel);
            //    }
            //    else if (dashboardViewModel.DashboardFormEnumCode.Equals(DashboardFormCustomEnum.CustomDashboard.ToString(), StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        CustomDashboardViewModel customDashboardViewModel = _customDashboardAgent.GetDBTMDashboardDetails();
            //        return View("~/Views/DBTM/DBTMDashboard/DBTMTrainerDashboard.cshtml", customDashboardViewModel);
            //    }
            //}
            return View("~/Views/Dashboard/GeneralDashboard.cshtml");
        }
    }
}
