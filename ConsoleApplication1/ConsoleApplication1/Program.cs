using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection;
            //Here


            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database +
                ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
            }
            //Here 2
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();

            // if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //Here 3
                }
               
                dataReader.Close();

               
                
                try
                {
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                
                StringBuilder builder = new StringBuilder();

                for (int x = 0; x < 5; x++)
                {
                    foreach (string cat in list[x]) // Loop through all strings
                    {
                        builder.Append(cat).Append("   "); // Append string to StringBuilder
                    }
                    string result = builder.ToString(); // Get string from StringBuilder
                    builder.Append("\n");
                    if (x == 4) { Console.WriteLine(result); }
                }
                
            }
        }
    }
}

