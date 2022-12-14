using Fresh.DataAccess.Interfaces;
using Fresh.Domain.Constants;
using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.DataAccess.Repositories
{
    public class RemovedUsers : IRemovedUsers
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public async Task<bool> AddRemovedUsers(int id)
        {
            try
            {
                await _con.OpenAsync();
                RemovedUsers removedUsers = new RemovedUsers();
                string all_rem_users = await removedUsers.GetAllRemovedUsers();
                string query = $"update RemovedUsers set " +
                    $"users_id = '{all_rem_users},{id}'";
                SQLiteCommand command = new SQLiteCommand(query, _con);
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
        

        public async Task<string> GetAllRemovedUsers()
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from RemovedUsers";
                SQLiteCommand command = new(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var result = reader.GetString(0);
                    reader.Close();
                    return result;
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
    }
}
