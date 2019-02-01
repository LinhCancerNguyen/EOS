using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2CMS.INFRA.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<Report> GetAllReport(int UserId, DateTime targetDate)
        {
            var reports = this.DbContext.Reports.Where(r => r.UserId == UserId &&
                                                        r.ReportDate.Month == targetDate.Month &&
                                                        r.ReportDate.Year == targetDate.Year &&
                                                        r.ReportDate.Date <= targetDate.Date)
                                                        .OrderByDescending(r => r.ReportDate)
                                                        .ToArray();
            return reports;
        }

        public IEnumerable<Report> GetAllReportHistory(int UserId, DateTime targetDate)
        {
            var reports = this.DbContext.Reports.Where(r => r.UserId == UserId &&
                                                        r.ReportDate.Month == targetDate.Month &&
                                                        r.ReportDate.Year == targetDate.Year)
                                                        .OrderByDescending(r => r.ReportDate)
                                                        .ToArray();
            return reports;
        }

        public IEnumerable<Report> GetTeamReports(DateTime targetDate)
        {
            var reports = this.DbContext.Reports.Where(r => r.ReportDate.Month == targetDate.Month &&
                                                        r.ReportDate.Year == targetDate.Year)
                                                        .OrderByDescending(r => r.ReportDate)
                                                        .ToArray();
            return reports;
        }

        public string Update(List<Report> reports)
        {
            using (var dbContextTransaction = this.DbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in reports)
                    {
                        var report = GetById(item.Id);
                        if (report.UserId == item.UserId)
                        {
                            if(item.Status != 2)
                            {
                                report.Study = item.Study;
                                report.Docs = item.Docs;
                                report.Coding = item.Coding;
                                report.TestCode = item.TestCode;
                                report.FixBug = item.FixBug;
                                report.TestBug = item.TestBug;
                                report.Training = item.Training;
                                report.Communication = item.Communication;
                                report.Manage = item.Manage;
                                report.Meeting = item.Meeting;
                                report.Reviewing = item.Reviewing;
                                report.Others = item.Others;
                                report.Note = item.Note;
                            }                            
                        }
                        else
                        {
                            return "Permission Denined";
                        }
                    }
                    dbContextTransaction.Commit();
                    return "OK";
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return "Update Report Error";
                }
            }
        }
    }

    public interface IReportRepository : IRepository<Report>
    {
        IEnumerable<Report> GetAllReport(int UserId, DateTime targetDate);
        IEnumerable<Report> GetAllReportHistory(int UserId, DateTime targetDate);
        IEnumerable<Report> GetTeamReports(DateTime targetDate);
        string Update(List<Report> reports);
    }
}
