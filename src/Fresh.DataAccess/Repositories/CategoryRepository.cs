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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public async Task<bool> CreateAsync(Category item)
        {
            try
            {
                await _con.OpenAsync();
                string query = @"INSERT INTO categories(Name,Description) " +
                     "VALUES($Name,$Description);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("Id",item.Id),
                        new SQLiteParameter("Name", item.Name),
                        new SQLiteParameter("Description", item.Description)
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
                string query = $"DELETE FROM categories where id = {id}";
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

        public async Task<IList<Category>> GetAllAsync(int skip, int take)
        {
            try
            {

                var categories = new List<Category>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM categories  lIMIT {take} OFFSET {skip};";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var category = new Category()
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description")

                    };
                    categories.Add(category);
                }

                return categories;
            }
            catch
            {

                return new List<Category>();
            }
            finally { _con.Close(); }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from categories where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new Category()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description")
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

        public async Task<bool> UpdateAsync(int id, Category entity)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"update categories set " +
                    "Name = $Name, Description = $Description " +
                    $"Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {

                        new SQLiteParameter("Name", entity.Name),
                        new SQLiteParameter("Description",  entity.Description)
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
