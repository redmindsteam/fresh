using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.Domain.Constants;
using Fresh.Domain.Entities;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Fresh.DataAccess.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);

        public async Task<bool> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

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

        public Task<IList<User>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

                return false;
            }
            finally 
            { 
                _con.Close(); 
            }
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

                return users;
            }
            catch
            {

                return new List<User>();
            }
            finally { _con.Close(); }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"SELECT * FROM Users where Email = $email";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter ("email",email)
                    }
                };
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt32("Id"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        IsAdmin = reader.GetBoolean("IsAdmin"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        PassportSeria = reader.GetString("PassportSeria")

                    };
                }
                else
                    return null!;
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

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from Users where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new User()
                    {
                        Id = reader.GetInt32("Id"),
                        FullName = reader.GetString("FullName"),
                        Email = reader.GetString("Email"),
                        IsAdmin = reader.GetBoolean("IsAdmin"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Salt = reader.GetString("Salt"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        PassportSeria = reader.GetString("PassportSeria")
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

        public async Task<bool> UpdateAsync(int id, User entity)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"update Users set " +
                    "FullName = $FullName, Email = $Email,"  +
                    "IsAdmin = $IsAdmin" +
                    " PasswordHash = $PasswordHash, Salt = $Salt, PhoneNumber = $PhoneNumber," +
                    "PassportSeria = $PassportSeria"+
                    $"Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {

                        new SQLiteParameter("FullName", entity.FullName),
                        new SQLiteParameter("Email",  entity.Email),
                        new SQLiteParameter("IsAdmin",  entity.IsAdmin),
                        new SQLiteParameter("PasswordHash",  entity.PasswordHash),
                        new SQLiteParameter("Salt", entity.Salt),
                        new SQLiteParameter("PhoneNumber", entity.PhoneNumber),
                        new SQLiteParameter("PassportSeria",  entity.PhoneNumber)
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
