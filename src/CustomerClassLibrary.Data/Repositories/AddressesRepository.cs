using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CustomerClassLibrary.Data
{
    public class AddressesRepository : BaseRepository
    {
        public void Create(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO [Addresses] (CustomerId, AddressLine, AddressLine2, AddressType, City, PostalCode, State, Country) " +
                    "VALUES( @CustomerId, @AddressLine, @AddressLine2, @AddressType, @City, @PostalCode, @State, @Country)", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = address.CustomerId
                };

                var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine
                };

                var secondAddressLineParam = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = address.SecondAddressLine
                };

                var addressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 50)
                {
                    Value = address.AddressType.ToString()
                };

                var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = address.City
                };

                var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = address.PostalCode
                };

                var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20)
                {
                    Value = address.State
                };

                var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 50)
                {
                    Value = address.Country
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(secondAddressLineParam);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);

                command.ExecuteNonQuery();
            }
        }

        public Address Read(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Addresses]" +
                    "WHERE AddressId = @AddressId", connection);

                var addressIdParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(addressIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        AddressType type;
                        if (reader["AddressType"]?.ToString() == "Billing") type = AddressType.Billing;
                        else if (reader["AddressType"]?.ToString() == "Shipping") type = AddressType.Shipping;
                        else throw new TypeAccessException("Invalid Type");
                        return new Address()
                        {
                            AddressId = (int)reader["AddressId"],
                            CustomerId = (int)reader["CustomerId"],
                            AddressLine = reader["AddressLine"]?.ToString(),
                            SecondAddressLine = reader["AddressLine2"]?.ToString(),
                            AddressType = type,
                            City = reader["City"]?.ToString(),
                            PostalCode = reader["PostalCode"]?.ToString(),
                            State = reader["State"]?.ToString(),
                            Country = reader["Country"]?.ToString(),
                        };
                    }
                    return null;
                }
            }
        }

        public List<Address> ReadCustomerAddresses(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Addresses]" +
                    "WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    List<Address> addresses = new List<Address>();
                    while (reader.Read())
                    {
                        AddressType type;
                        if (reader["AddressType"]?.ToString() == "Billing") type = AddressType.Billing;
                        else if (reader["AddressType"]?.ToString() == "Shipping") type = AddressType.Shipping;
                        else throw new TypeAccessException("Invalid Type");
                        addresses.Add(new Address()
                        {
                            AddressId = (int)reader["AddressId"],
                            CustomerId = (int)reader["CustomerId"],
                            AddressLine = reader["AddressLine"]?.ToString(),
                            SecondAddressLine = reader["AddressLine2"]?.ToString(),
                            AddressType = type,
                            City = reader["City"]?.ToString(),
                            PostalCode = reader["PostalCode"]?.ToString(),
                            State = reader["State"]?.ToString(),
                            Country = reader["Country"]?.ToString(),
                        });
                    }
                    return addresses;
                }
            }
        }

        public void Update(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "UPDATE [Addresses] " +
                    "SET CustomerId = @CustomerId, AddressLine = @AddressLine, AddressLine2 = @AddressLine2, AddressType = @AddressType, City = @City, PostalCode = @PostalCode, State = @State, Country = @Country " +
                    "WHERE AddressId = @AddressId", connection);
                
                var addressIdParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = address.AddressId
                };

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = address.CustomerId
                };

                var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine
                };

                var secondAddressLineParam = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = address.SecondAddressLine
                };

                var addressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 50)
                {
                    Value = address.AddressType.ToString()
                };

                var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = address.City
                };

                var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = address.PostalCode
                };

                var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20)
                {
                    Value = address.State
                };

                var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 50)
                {
                    Value = address.Country
                };

                command.Parameters.Add(addressIdParam);
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(secondAddressLineParam);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Addresses]" +
                    "WHERE AddressId = @AddressId", connection);

                var addressIdParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(addressIdParam);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllByCustomerId(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Addresses]" +
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
