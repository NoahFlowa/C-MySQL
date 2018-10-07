using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Required references for using MySql
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConnectMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection String to input server details and database settings
            string connStr = "server=noahosterhout.com;user=;database=noahnkes_CSharpTest;port=29018;password=";

            // Tells MySQL to create a new connection and use the connStr as the connection settings
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL. . . ");
                // Open method tells MySQL to open a connection using the conn settigns
                conn.Open();

                // Perform DB Commands here . . .

                // We use this line to tell MySQL that we are creating and using commands
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT PersonID, LastName, FirstName, Address, City FROM users";

                // IDataReader is apart of the System.Data reference and allows us to read from the above statement
                IDataReader reader = command.ExecuteReader();

                // This checks to see if there is any data to read from the database and then spits out its findings
                if (reader.Read())
                {
                    int PersonID = (int)reader["PersonID"];
                    string LastName = (string)reader["LastName"];
                    string FirstName = (string)reader["FirstName"];
                    string Address = (string)reader["Address"];
                    string City = (string)reader["City"];
                }

                // Closes the reader as we are not using it anymore, I could use a using() but I dont know how the MySQL reference would react to that
                reader.Close();
                // Clears the command to make way for other commands we might need to use
                command.Dispose();
            }
            // This will catch general exceptions and conver them to a string to see what went wrong
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Closes the connectiong
            conn.Close();
            Console.WriteLine("Done.");

            Console.ReadLine();
        }
    }
}
