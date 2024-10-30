using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new ArgumentNullException(nameof(configuration), "Connection string not found.");
        }


        public async Task<bool> RegisterMemberAsync(Member member)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Members (Username, Email, Password) VALUES (@Username, @Email, @Password)", connection);
                command.Parameters.AddWithValue("@Username", member.Username);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Password", member.Password);

                connection.Open();
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<Member> LoginMemberAsync(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = new SqlCommand(
                        "SELECT * FROM Members WHERE Email = @Email AND Password = @Password",
                        connection);

                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Member
                            {
                                MemberId = reader.GetInt32(reader.GetOrdinal("MemberID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                        }
                        return new Member();
                    }
                }
                catch (Exception )
                {
                    // Log exception here
                    throw; // Re-throw để caller có thể xử lý
                }
            }
        }
    }
}
