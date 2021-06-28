using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerClassLibrary.Data
{
    public class CustomerRepository : BaseRepository
    {
        public int Create(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO [Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) " +
                    "VALUES( @FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount); " +
                    "SELECT CAST(scope_identity() AS int)", connection);

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

                return (int)(command.ExecuteScalar());
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

        public List<Customer> ReadAll()
        {
            List<Customer> listCustomers = new List<Customer>();
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Customers]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listCustomers.Add(new Customer()
                        {
                            CustomerId = (int)reader["CustomerId"],
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString(),
                            PhoneNumber = reader["PhoneNumber"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Money = (decimal)reader["TotalPurchasesAmount"]
                        });
                    }
                    return listCustomers;
                }
            }
        }

        public List<Customer> ReadSelect(int numFrom, int numTo)
        {
            List<Customer> listCustomers = new List<Customer>();
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    $"SELECT  * " +
                    $"FROM(SELECT    ROW_NUMBER() OVER(ORDER BY CustomerId) AS RowNum, * " +
                    $"FROM[Customers] " +
                    $"WHERE     CustomerId >= 0 " +
                    $") AS RowConstrainedResult " +
                    $"WHERE   RowNum > {numFrom} " +
                    $"AND RowNum <= {numTo} " +
                    $"ORDER BY RowNum", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listCustomers.Add(new Customer()
                        {
                            CustomerId = (int)reader["CustomerId"],
                            FirstName = reader["FirstName"]?.ToString(),
                            LastName = reader["LastName"]?.ToString(),
                            PhoneNumber = reader["PhoneNumber"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Money = (decimal)reader["TotalPurchasesAmount"]
                        });
                    }
                    return listCustomers;
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

        public int Count()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT COUNT(*) FROM Customers", connection);


                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (int)reader[0];
                    }
                    return -1;
                }
            }
        }

    }
}
