using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.DataAccess.Repositories;
using Fresh.Domain.Entities;
using Fresh.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Services.PageServices
{
    public class StatisticPage
    {
        public async Task<List<StatsView>> GetByCurrentDate(string status,string dateTime)
        {
            var expanditures = await GetExpanditureByDate(ParseExact(dateTime));
            var incomes = await GetIncomesBydate(dateTime);
            List<StatsView> statsViews = new List<StatsView>();
            if (status == "Yearly")
            {
                statsViews = expanditures.Join(incomes,
                x => x.Item1.Year,
                y => y.Date.Year,
                (x, y) => new StatsView
                {
                    Date = y.Date,
                    Income = y.Income,
                    Expenditure = x.Item2
                }).ToList();
            }
            else if (status == "Monthly")
            {
                statsViews = expanditures.Join(incomes,
                x => $"{x.Item1.Year}+{x.Item1.Month}",
                y => $"{y.Date.Year}+{y.Date.Month}",
                (x, y) => new StatsView
                {
                    Date = y.Date,
                    Income = y.Income,
                    Expenditure = x.Item2
                }).ToList();
            }
            else if(status == "Daily")
            {
                statsViews = expanditures.Join(incomes,
                x => x.Item1.Date,
                y => y.Date.Date,
                (x, y) => new StatsView
                {
                    Date = y.Date,
                    Income = y.Income,
                    Expenditure = x.Item2
                }).ToList();
            }

            return statsViews;

        }
        private async Task<List<Tuple<DateTime, string>>> GetExpanditureByDate(DateTime dateTime)
        {
            var result = new List<Tuple<DateTime, string>>();
            ProductLetterRepository productLetter = new();
            IList<ProductLetter> PLInTime = (await productLetter.GetAllAsync())
            .Where(x => ParseExact(x.Date) >= dateTime).ToList();
            var groupedPL = PLInTime.GroupBy(x => ParseExact(x.Date).Date);
            foreach (var PL in groupedPL)
            {
                var thisday = PL.ToList();
                var totalsum = thisday.Sum(x => x.Price).ToString();
                result.Add(new Tuple<DateTime, string>(ParseExact(thisday[0].Date)
                    , totalsum));
            }
            return result;
        }
        private async Task<List<StatsView>> GetIncomesBydate(string dateTime)
        {
            ///There are limitation for me and program performance as well because i haven't GetAllByDate DataAccess repository 
            CheckRepository checkRepository = new();

            var date = DateTime.Parse(dateTime);
            IList<Check> checksInTime = (await checkRepository.GetAllAsync())
             .Where(x => x.Date >= date).ToList();
            var groupedChecks = checksInTime.GroupBy(x => x.Date.Date);
            List<StatsView> stats = new List<StatsView>();
            foreach (var check in groupedChecks)
            {
                var thisDay = check.ToList();
                stats.Add(new StatsView
                {
                    Date = thisDay[0].Date,
                    Income
                    = thisDay.Sum(x => x.TotalSum).ToString()
                });
            }
            return stats;
        }
        private DateTime ParseExact(string datetime)
        {
            return DateTime.ParseExact(datetime, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
