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
        public async Task<Dictionary<string, StatsView>> GetByCurrentDate(string status,string dateTime)
        {
            var expanditures = await GetExpanditureByDate(ParseExact(dateTime));
            var incomes = await GetIncomesBydate(dateTime);
            Dictionary<string, StatsView> stats = new Dictionary<string, StatsView>();
            string key = string.Empty;
            if (status == "Yearly")
            {
                foreach (var exp in expanditures)
                {
                    key = exp.Item1.Year.ToString();
                    if (!stats.ContainsKey(key))
                    {
                        stats.Add(key, new StatsView());
                        stats[key].Date = key;
                    }
                    if(stats.ContainsKey(key))
                        stats[key].Expenditure += exp.Item2;
                }
                foreach (var inc in incomes)
                {
                    key = ParseExact(inc.Date).Year.ToString();
                    if (!stats.ContainsKey(key))
                    {
                        stats.Add(key, new StatsView());
                        stats[key].Date = key;
                    }
                        
                    if (stats.ContainsKey(key))
                        stats[key].Income += inc.Income;
                        
                }
            }
            else if (status == "Monthly")
            {
                foreach (var exp in expanditures)
                {
                    key = exp.Item1.ToString("MM/yyyy");
                    if (!stats.ContainsKey(key))
                    {
                        stats.Add(key, new StatsView());
                        stats[key].Date = exp.Item1.Year + " "
                            + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(exp.Item1.Month);
                    }
                    if (stats.ContainsKey(key))
                        stats[key].Expenditure += exp.Item2;
                }
                foreach (var inc in incomes)
                {
                    key = ParseExact(inc.Date).ToString("MM/yyyy");
                    if (!stats.ContainsKey(key))
                    {
                        stats.Add(key, new StatsView());
                        stats[key].Date = ParseExact(inc.Date).Year + " "
                            + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ParseExact(inc.Date).Month);
                    }
                    if (stats.ContainsKey(key))
                        stats[key].Income += inc.Income;
                }
            }
            else if (status == "Daily")
            {
                foreach (var exp in expanditures)
                {
                    key = exp.Item1.ToString("MM/dd/yyyy");
                    if (!stats.ContainsKey(key))
                    {
                        stats.Add(key, new StatsView());
                        stats[key].Date = exp.Item1.DayOfWeek + " "
                            + key;
                    }
                    if (stats.ContainsKey(key))
                        stats[key].Expenditure += exp.Item2;
                }
                foreach (var inc in incomes)
                {
                    key = ParseExact(inc.Date).ToString("MM/dd/yyyy");
                    if (!stats.ContainsKey(key))
                    {
                        stats.Add(key, new StatsView());
                        stats[key].Date = ParseExact(inc.Date).DayOfWeek + " "
                            + key;
                    }
                    if (stats.ContainsKey(key))
                        stats[key].Income += inc.Income;
                }
            }
            return stats;

        }
        private async Task<List<Tuple<DateTime, float>>> GetExpanditureByDate(DateTime dateTime)
        {
            var result = new List<Tuple<DateTime, float>>();
            ProductLetterRepository productLetter = new();
            IList<ProductLetter> PLInTime = (await productLetter.GetAllAsync())
            .Where(x => ParseExact(x.Date) >= dateTime).ToList();
            var groupedPL = PLInTime.GroupBy(x => ParseExact(x.Date).Date);
            foreach (var PL in groupedPL)
            {
                var thisday = PL.ToList();
                var totalsum = thisday.Sum(x => x.Price);
                result.Add(new Tuple<DateTime, float>(ParseExact(thisday[0].Date)
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
                    Date = thisDay[0].Date.ToString(),
                    Income
                    = thisDay.Sum(x => x.TotalSum)
                }) ;
            }
            return stats;
        }
        private DateTime ParseExact(string datetime)
        {
            return DateTime.Parse(datetime);
        }
    }
}
