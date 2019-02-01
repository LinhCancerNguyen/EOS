using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using D2CMS.CORE.Models;
using D2CMS.SERVICE.Core;
using D2CMS.WEBUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2CMS.WEBUI.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IReportService reportService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReportController(IUserService userService, IRoleService roleService, IReportService reportService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.reportService = reportService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = userService.GetUser(User.Identity.Name);
            var currentDate = DateTime.Now;
            var reports = reportService.GetReports(user.Id, DateTime.Now).ToList();
            if (reports.Count() == 0)
            {
                //TODO: Create Monthly Report
                for (var i = 1; i <= DateTime.DaysInMonth(currentDate.Year, currentDate.Month); i++)
                {
                    var report = new Report
                    {
                        UserId = user.Id,
                        ReportDate = new DateTime(currentDate.Year, currentDate.Month, i),
                        Status = 1
                    };
                    reportService.CreateReport(report);
                    if (report.ReportDate <= currentDate)
                    {
                        reports.Add(report);
                    }
                }
            }
            ViewData["CurrentViewTargetMonth"] = currentDate.ToString("yyyy/MM");
            ViewData["CurrentLoginUser"] = user;
            reports = reports.OrderByDescending(r => r.ReportDate).ToList();
            return View(new ReportResponse
            {
                Reports = reports,
                User = user
            });
        }

        [HttpGet]
        public IActionResult History(int year, int month)
        {
            var user = userService.GetUser(User.Identity.Name);
            var targetDate = new DateTime(year, month, 1);
            var reports = reportService.GetReportsHistory(user.Id, targetDate);
            ViewData["CurrentViewTargetMonth"] = targetDate.ToString("yyyy/MM");
            ViewData["CurrentLoginUser"] = user;
            return View("Index", new ReportResponse
            {
                Reports = reports,
                User = user
            });
        }

        [HttpGet]
        public IActionResult UserReport(string account, int year, int month)
        {
            var user = userService.GetUser(User.Identity.Name);
            var viewUser = userService.GetUser(account);
            var targetDate = new DateTime(year, month, 1);
            var reports = reportService.GetReportsHistory(viewUser.Id, targetDate);
            ViewData["CurrentViewTargetMonth"] = targetDate.ToString("yyyy/MM");
            ViewData["CurrentLoginUser"] = user;
            return View("Index", new ReportResponse
            {
                Reports = reports,
                User = user
            });
        }

        [HttpGet]
        public IActionResult TeamReportHistory(int year, int month)
        {           
            var users = userService.GetUsers();
            var targetDate = new DateTime(year, month, 1);
            var reports = reportService.GetTeamReport(targetDate);            
            return View(new TeamReportResponse {
                    Users = users,
                    Reports = reports,
                    TargetDate = targetDate
            });
        }

        [HttpGet]
        public IActionResult TeamReport()
        {
            var users = userService.GetUsers();
            var targetDate = DateTime.Now;
            var reports = reportService.GetTeamReport(targetDate);
            return View(new TeamReportResponse
            {
                Users = users,
                Reports = reports,
                TargetDate = targetDate
            });
        }

        [HttpGet]
        public IActionResult TeamAnalytics()
        {
            var users = userService.GetUsers();
            var targetDate = DateTime.Now;
            var reports = reportService.GetTeamReport(targetDate);
            return View(new TeamReportResponse
            {
                Users = users,
                Reports = reports,
                TargetDate = targetDate
            });
        }

        [HttpPost]
        public JsonResult Save(List<Report> reports)
        {
            var user = userService.GetUser(User.Identity.Name);
            reports = reports.Select(r => { r.UserId = user.Id; return r; }).ToList();
            var message = reportService.SaveReports(reports);
            return Json(new
            {
                result = message == "OK" ? "success" : "error",
                message
            });
        }
    }
}