﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace CustomerClassLibrary.Data
{
    public class CustomerRepository : BaseRepository
    {
        public void Create(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO [Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) " +
                    "VALUES( @FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)", connection);

                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.FirstName
                };

                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.LastName
                };

                var phoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = customer.PhoneNumber
                };

                var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
                {
                    Value = customer.Email
                };

                var totalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
                {
                    Value = customer.Money
                };

                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(phoneNumberParam);
                command.Parameters.Add(emailParam);
                command.Parameters.Add(totalPurchasesAmountParam);

                command.ExecuteNonQuery();
            }
        }

        public Customer Read(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Customers]" +
                    "WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer()
                        {
                            CustomerId = (int)reader["CustomerId"],
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString(),
                            PhoneNumber = reader["PhoneNumber"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Money = (decimal)reader["TotalPurchasesAmount"]
                        };
                    }
                    return null;
                }
            }
        }

        public void Update(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "UPDATE [Customers] " +
                    "SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email, TotalPurchasesAmount = @TotalPurchasesAmount " +
                    "WHERE CustomerId = @CustomerId", connection);

                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.FirstName
                };

                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = customer.LastName
                };

                var phoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = customer.PhoneNumber
                };

                var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
                {
                    Value = customer.Email
                };

                var totalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
                {
                    Value = customer.Money
                };

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Money)
                {
                    Value = customer.CustomerId
                };

                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(phoneNumberParam);
                command.Parameters.Add(emailParam);
                command.Parameters.Add(totalPurchasesAmountParam);
                command.Parameters.Add(customerIdParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Customers]" +
                    "WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(customerIdParam);

                command.ExecuteNonQuery();
            }
        }
    }
}