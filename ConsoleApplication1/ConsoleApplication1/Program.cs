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
            string server = "107.180.48.91",
                database = "Ezbarsdatabase",
                uid = "CapstoneUser2",
                password = "4nPy+@TXm_R)";
            
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database +
                ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            Console.WriteLine("Select what column you want to search. Liquid_Name, ABV, Genre, or Carbonation: ");
            string searchColumn;
            searchColumn = Console.ReadLine();
            Console.WriteLine("What do you want to search for: ");
            string inputText;
            inputText = Console.ReadLine();
            Console.WriteLine(inputText);

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
            string query = "Select * From Liquids where " + searchColumn + " like '" + inputText + "%' order by ABV;";
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
                    list[0].Add(dataReader["L_PK"] + "");
                    list[1].Add(dataReader["Liquid_Name"] + "");
                    list[2].Add(dataReader["ABV"] + "");
                    list[3].Add(dataReader["Genre"] + "");
                    list[4].Add(dataReader["Carbonation"] + "");
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

