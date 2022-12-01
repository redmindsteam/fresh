using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.Domain.Constants;
using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.DataAccess.Repositories
{
    public class ProductLetterRepository : IProductLetterRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public async Task<bool> CreateAsync(ProductLetter item)
        {
            try
            {
                await _con.OpenAsync();
                string query = @"INSERT INTO ProductLetters(ProductDescription,Date,UserId)" +
                     "VALUES($ProductDescription,$Date,$UserId);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("ProductDescription", item.ProductDescription),
                        new SQLiteParameter("Date", item.Date),
                        new SQLiteParameter("UserId", item.UserId)
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
                string query = $"DELETE FROM ProductLetters where id = {id}";
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

        public async Task<IList<ProductLetter>> GetAllLimit()
        {
            try
            {

                var productLetters = new List<ProductLetter>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM ProductLetters";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var productLetter = new ProductLetter()
                    {
                        Id = reader.GetInt32("Id"),
                        ProductDescription = reader.GetString("ProductDescription"),
                        Date = reader.GetString("Date"),
                        UserId = reader.GetInt32("UserId")

                    };
                    productLetters.Add(productLetter);
                }

                return productLetters;
            }
            catch
            {

                return new List<ProductLetter>();
            }
            finally { _con.Close(); }
        }

        public async Task<ProductLetter> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from ProductLetters where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new ProductLetter()
                    {
                        Id = reader.GetInt32("Id"),
                        ProductDescription = reader.GetString("ProductDescription"),
                        Date = reader.GetString("Date"),
                        UserId = reader.GetInt32("UserId")

                    };
                }
                else return null!;
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

        public async Task<bool> UpdateAsync(int id, ProductLetter entity)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"update ProductLetters set " +
                    "ProductDescription = $ProductDescription, Date = $Date," +
                    "UserId = $UserId " +
                    $"Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {

                        new SQLiteParameter("ProductDescription", entity.ProductDescription),
                        new SQLiteParameter("Date", entity.Date),
                        new SQLiteParameter("UserId", entity.UserId)
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
