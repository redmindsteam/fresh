﻿using Fresh.DataAccess.Interfaces.Repositories;
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
    public class ProductRepository : IProductRepository
    {
        private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
        public async Task<bool> CreateAsync(Product item)
        {
            try
            {
                await _con.OpenAsync();
                string query = @"INSERT INTO Products(Name,CategoryId,Price,Unit,BarcodeName,ProductionDate,ExpireDate,Value)" +
                     "VALUES($Name,$CategoryId,$Price,$Unit,$BarcodeName,$ProductionDate,$ExpireDate,$Value);";
                var command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {
                        new SQLiteParameter("Name", item.Name),
                        new SQLiteParameter("CategoryId", item.CategoryId),
                        new SQLiteParameter("Price", item.Price),
                        new SQLiteParameter("Unit", item.Unit),
                        new SQLiteParameter("BarcodeName", item.BarcodeName),
                        new SQLiteParameter("ProductionDate", item.ProductionDate),
                        new SQLiteParameter("ExpireDate", item.ExpireDate),
                        new SQLiteParameter("Value", item.Value)
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
                string query = $"DELETE FROM Products where id = {id}";
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

        public async Task<IList<Product>> GetAllLimit()
        {
            try
            {

                var products = new List<Product>();
                await _con.OpenAsync();
                string query = $"SELECT * FROM Products";
                var command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var product = new Product()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        CategoryId = reader.GetInt32("CategoryId"),
                        Price = reader.GetInt32("Price"),
                        Unit = reader.GetString("Unit"),
                        BarcodeName = reader.GetString("BarcodeName"),
                        ProductionDate = reader.GetString("ProductionDate"),
                        ExpireDate = reader.GetString("ExpireDate"),
                        Value = reader.GetFloat("Value")

                    };
                    products.Add(product);
                }

                return products;
            }
            catch
            {

                return new List<Product>();
            }
            finally { _con.Close(); }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"select * from Products where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con);
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new Product()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        CategoryId = reader.GetInt32("CategoryId"),
                        Price = reader.GetInt32("Price"),
                        Unit = reader.GetString("Unit"),
                        BarcodeName = reader.GetString("BarcodeName"),
                        ProductionDate = reader.GetString("ProductionDate"),
                        ExpireDate = reader.GetString("ExpireDate"),
                        Value = reader.GetFloat("Value")
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

        public async Task<bool> UpdateAsync(int id, Product entity)
        {
            try
            {
                await _con.OpenAsync();
                string query = $"update Users set " +
                    "Name = $Name, CategoryId = $CategoryId," +
                    "Price = $Price," +
                    " Unit = $Unit, BarcodeName = $BarcodeName, ProductionDate = $ProductionDate," +
                    "ExpireDate = $ExpireDate" +
                    "Value = $Value"+
                    $"Where Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, _con)
                {
                    Parameters =
                    {

                        new SQLiteParameter("Name", entity.Name),
                        new SQLiteParameter("CategoryId", entity.CategoryId),
                        new SQLiteParameter("Price", entity.Price),
                        new SQLiteParameter("Unit", entity.Unit),
                        new SQLiteParameter("BarcodeName", entity.BarcodeName),
                        new SQLiteParameter("ProductionDate", entity.ProductionDate),
                        new SQLiteParameter("ExpireDate", entity.ExpireDate),
                        new SQLiteParameter("Value", entity.Value)
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
