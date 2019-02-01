using D2CMS.CORE.Models;
using D2CMS.INFRA.Infrastructure;
using D2CMS.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.SERVICE.Core
{
    public interface IReportService
    {
        IEnumerable<Report> GetReports(int UserId, DateTime targetDate);
        IEnumerable<Report> GetReportsHistory(int UserId, DateTime targetDate);
        IEnumerable<Report> GetTeamReport(DateTime targetDate);
        Report GetReport(int seq);
        void CreateReport(Report report);
        void SaveReport();
        string SaveReports(List<Report> reports);
        void Update(Report report);
        void Delete(Report report);
    }

    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReportService(IReportRepository reportRepository, IUnitOfWork unitOfWork)
        {
            this.reportRepository = reportRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateReport(Report report)
        {
            reportRepository.Add(report);
            SaveReport();
        }

        public void Delete(Report report)
        {
            throw new NotImplementedException();
        }

        public Report GetReport(int seq)
        {
            var report = reportRepository.GetById(seq);
            return report;
        }

        public IEnumerable<Report> GetReports(int UserId, DateTime targetDate)
        {
            var reports = reportRepository.GetAllReport(UserId, targetDate);
            return reports;
        }

        public IEnumerable<Report> GetReportsHistory(int UserId, DateTime targetDate)
        {
            var reports = reportRepository.GetAllReportHistory(UserId, targetDate);
            return reports;
        }

        public void SaveReport()
        {
            unitOfWork.Commit();
        }

        public void Update(Report report)
        {
            reportRepository.Update(report);
            SaveReport();
        }

        public string SaveReports(List<Report> reports)
        {
            var result = reportRepository.Update(reports);
            if(result == "OK")
            {
                SaveReport();
            }
            return result;            
        }

        public IEnumerable<Report> GetTeamReport(DateTime targetDate)
        {
            var reports = reportRepository.GetTeamReports(targetDate);
            return reports;
        }
    }
}
