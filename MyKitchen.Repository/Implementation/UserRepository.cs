﻿using Microsoft.Data.SqlClient;
using MyKitchen.Model;
using MyKitchen.Repository.Interface;

namespace MyKitchen.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly string tableName = "users";
        public User Create(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"INSERT INTO {tableName} (username, password, name, email, is_admin, is_blocked) VALUES ('{user.Username}', CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2), '{user.Name}', '{user.Email}', '{isAdmin}', '{isBlocked}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public User DoLogin(string username, string password)
        {
            string sql = $"SELECT * FROM {tableName} WHERE username LIKE '{username}' AND password LIKE CONVERT(VARCHAR(32), HashBytes('MD5', '{password}'), 2) AND is_blocked = 0;";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            return null;
            //throw new Exception("Username or Password invalid.");
        }

        public User Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("User not found.");
        }

        public List<User> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(Parse(reader));
            }
            return users;
        }

        public User Update(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"UPDATE {tableName} SET" +
                $" name = '{user.Name}'," +
                $" email = '{user.Email}'," +
                $" is_admin = '{isAdmin}'," +
                $" is_blocked = '{isBlocked}'" +
                $" WHERE id = {user.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(user.Id);
        }

        private User Parse(SqlDataReader reader)
        {
            User user = new User()
            {
                Id = Convert.ToInt32(reader["id"]),
                Username = Convert.ToString(reader["username"]),
                Password = Convert.ToString(reader["password"]),
                Name = Convert.ToString(reader["name"]),
                Email = Convert.ToString(reader["email"]),
                IsAdmin = Convert.ToBoolean(reader["is_admin"]),
                IsBlocked = Convert.ToBoolean(reader["is_blocked"])
            };

            return user;
        }
    }
}
