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
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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
                var command = new SqlCommand("SELECT * FROM Members WHERE Email = @Email AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return new Member
                        {
                            MemberId = (int)reader["MemberID"],
                            Username = reader["Username"].ToString(),
                            Email = reader["Email"].ToString(),
                        };
                    }
                }
            }
            return null;
        }
    }
}
