﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.TimeManager.Domain.Areas.Factories;
using Mmu.TimeManager.Domain.Areas.Models.Management;
using Mmu.TimeManager.Domain.Areas.Repositories;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class DayDetailsViewService : IDayDetailsViewService
    {
        private readonly IDailyReportFactory _dailyReportFactory;
        private readonly IDailyReportRepository _dailyReportRepository;

        public DayDetailsViewService(
            IDailyReportFactory dailyReportFactory,
            IDailyReportRepository dailyReportRepository)
        {
            _dailyReportFactory = dailyReportFactory;
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<DailyReport> LoadDailyReportAsync(params object[] initParams)
        {
            var reportDate = initParams?.Any() == true ? (DateTime)initParams[0] : DateTime.Now;
            var reportMaybe = await _dailyReportRepository.LoadByDateAsync(reportDate);
            var result = reportMaybe.Reduce(() => _dailyReportFactory.Create(reportDate));

            return result;
        }
    }
}