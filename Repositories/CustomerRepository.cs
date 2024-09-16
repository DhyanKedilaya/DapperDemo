using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DapperDemo.Data;
using DapperDemo.Models;

namespace DapperDemo.Repositories

{
    public class CustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            var query = "SELECT * from Customers";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Customers>(query);
                 
            }
        }

        public async Task<Customers> GetCustomerbyid(int id)
        {
            var query = "SELECT * FROM Customers WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Customers>(query, new { Id = id });
            }
        }

        public async Task<int> CreateCustomer(Customers customer)
        {
            var query = "INSERT INTO Customers (FirstName, LastName, Email, DateOfBirth ) VALUES (@FirstName, @LastName, @Email, @DateOfBirth ) RETURNING Id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, customer);
            }
        }

        public async Task UpdateCustomer(int id, Customers customer)
        {
            var query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DateOfBirth = @DateOfBirth  WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { customer.FirstName, customer.LastName, customer.Email, customer.DateOfBirth, Id = id });
            }
        }

        public async Task DeleteCustomer(int id)
        {
            var query = "DELETE FROM Customers WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }


    }
}
