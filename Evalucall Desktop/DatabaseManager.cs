using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public string RetrieveHashedPassword(string email)
    {
        string hashedPasswordFromDB = null;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string query = "SELECT password FROM agent_accounts WHERE email = @Email";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);

                hashedPasswordFromDB = cmd.ExecuteScalar() as string;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving hashed password from database: " + ex.Message);
            }
        }

        return hashedPasswordFromDB;
    }

    public List<(int id, string firstName, string lastName, string email)> RetrieveUserDetailsFromDatabase(string email)
    {
        List<(int id, string firstName, string lastName, string email)> userDetailsList = new List<(int id, string firstName, string lastName, string email)>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string query = "SELECT id, first_name, last_name, email FROM agent_accounts WHERE email = @Email";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string firstName = reader.GetString("first_name");
                        string lastName = reader.GetString("last_name");
                        string userEmail = reader.GetString("email");

                        userDetailsList.Add((id, firstName, lastName, userEmail));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user details from database: " + ex.Message);
            }
        }

        return userDetailsList;
    }

    public bool EmailExists(string email)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM agent_accounts WHERE Email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking if email exists in database: " + ex.Message);
            }
        }
    }

    public string GeneratePasswordResetToken(string email)
    {
        string token = Guid.NewGuid().ToString("N");

        DateTime tokenExpiry = DateTime.Now.AddMinutes(10);

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string query = "UPDATE agent_accounts SET resetPasswordToken = @ResetToken, resetPasswordExpires = @TokenExpiry WHERE Email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ResetToken", token);
                    cmd.Parameters.AddWithValue("@TokenExpiry", tokenExpiry);
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating password reset token: " + ex.Message);
            }
        }

        return token;
    }
}

