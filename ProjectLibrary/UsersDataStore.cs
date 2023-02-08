using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ProjectLibrary
{
    public class UsersDataStore
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public UsersDataStore(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool ValidateUser(string userName, string Password)
        {
            try
            {
                string validateUser = "select * from USERDATA where USERNAME = @UserName and [PASSWORD] = @Password";
                command = new SqlCommand(validateUser, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", Password);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    UserData userData = new UserData();
                    userData.UserName = reader["USERNAME"].ToString();
                    userData.Password = reader["PASSWORD"].ToString();

                    if(userData != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return false;

        }
    }
}
