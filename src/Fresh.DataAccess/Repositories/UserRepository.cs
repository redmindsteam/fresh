using Fresh.DataAccess.Interfaces.Repositories;
using Fresh.Domain.Constants;
using System.Data;
using Fresh.Domain.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Fresh.DataAccess.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
       
        public async Task<bool> CreateAsync(User item)
        {
            try
            {
                await _con.OpenAsync();
                string query = @"INSERT INTO Users(FullName,Email,IsAdmin,PasswordHash,Salt,PhoneNumber,PassportSeria)" +
                     "VALUES($FullName,$Email,$IsAdmin,$PasswordHash,$Salt,$PhoneNumber,$PassportSeria);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("FullName", item.FullName),
                        new SQLiteParameter("Email", item.Email),
                        new SQLiteParameter("IsAdmin", item.IsAdmin),
                        new SQLiteParameter("PasswordHash", item.PasswordHash),
                        new SQLiteParameter("Salt", item.Salt),
                        new SQLiteParameter("PhoneNumber", item.PhoneNumber),
                        new SQLiteParameter("PassportSeria", item.PhoneNumber)
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
                string query = $"DELETE FROM Users where id = {id}";
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

        public async Task<IList<User?>> GetAllAsync(int skip, int take)
        {
            try
            {

                var users = new List<User>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM Users  lIMIT {take} OFFSET {skip};";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var user = new User()
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
                    users.Add(user);
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
