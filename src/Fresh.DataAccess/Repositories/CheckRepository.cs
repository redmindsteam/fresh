using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.Domain.Constants;
using Fresh.Domain.Entities;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Text;

namespace Fresh.DataAccess.Repositories
{
    public class CheckRepository : ICheckRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public async Task<bool> CreateAsync(Check item)
        {
            try
            {
                await _con.OpenAsync();
                string query = @"INSERT INTO Checks(CheckDescription,TotalSum,UserId,Date)" +
                     "VALUES($CheckDescription,$TotalSum,$UserId,$Date);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("CheckDescription", item.CheckDescription),
                        new SQLiteParameter("TotalSum", item.TotalSum),
                        new SQLiteParameter("UserId", item.UserId),
                        new SQLiteParameter("Date", item.Date)
                    }
                };

                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                _con.Close();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"DELETE FROM Checks where id = {id}";
                var command = new SQLiteCommand(query, _con);
                var result = await command.ExecuteNonQueryAsync();
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch
            {

                return false;
            }
            finally
            {
                _con.Close();
            }
        }

        public async Task<IList<Check>> GetAllAsync()
        {
            try
            {

                var checks = new List<Check>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM Checks";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var check = new Check()
                    {
                        Id = reader.GetInt32("Id"),
                        CheckDescription = reader.GetString("CheckDescription"),
                        TotalSum = reader.GetFloat("TotalSum"),
                        UserId = reader.GetInt32("UserId"),
                        Date = DateTime.ParseExact(reader.GetString("Date"), "MM/dd/yyyy", CultureInfo.InvariantCulture)
                    };
                    checks.Add(check);
                }
                reader.Close();
                return checks;
            }
            catch
            {

                return new List<Check>();
            }
            finally { _con.Close(); }
        }

        public async Task<IList<Check>> GetAllLimit(int skip, int take)
        {
            try
            {

                var checks = new List<Check>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM Checks lIMIT {take} OFFSET {skip}";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var check = new Check()
                    {
                        Id = reader.GetInt32("Id"),
                        CheckDescription = reader.GetString("CheckDescription"),
                        TotalSum = reader.GetFloat("TotalSum"),
                        UserId = reader.GetInt32("UserId"),
                        Date = DateTime.ParseExact(reader.GetString("Date"), "MM/dd/yyyy", CultureInfo.InvariantCulture)

                    };
                    checks.Add(check);
                }
                reader.Close();
                return checks;
            }
            catch
            {

                return new List<Check>();
            }
            finally { _con.Close(); }
        }

        public async Task<Check> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from Checks where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var resalt = new Check()
                    {
                        Id = reader.GetInt32(0),
                        CheckDescription = reader.GetString(1),
                        TotalSum = reader.GetFloat(2),
                        UserId = reader.GetInt32(3),
                        Date = DateTime.ParseExact(reader.GetString(4), "MM/dd/yyyy", CultureInfo.InvariantCulture)

                    };
                    reader.Close();
                    return resalt;
                }
                else
                {
                    reader.Close();
                    return null!;
                }
            }
            catch
            {

                return null!;
            }
            finally
            {
                _con.Close();
            }
        }

        public async Task<bool> UpdateAsync(int id, Check entity)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"update Users set " +
                    " CheckDescription = $CheckDescription, TotalSum = $TotalSum," +
                    " UserId = $UserId," +
                    " Date = $Date" +
                    $" Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {

                        new SQLiteParameter("CheckDescription", entity.CheckDescription),
                        new SQLiteParameter("TotalSum", entity.TotalSum),
                        new SQLiteParameter("UserId", entity.UserId),
                        new SQLiteParameter("Date", entity.Date)
                    }
                };
                int result = await command.ExecuteNonQueryAsync();
                if (result == 0)
                    return false;
                else
                    return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                _con.Close();
            }
        }
    }
}
