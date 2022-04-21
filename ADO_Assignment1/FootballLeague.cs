using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment1
{
    internal class FootballLeague
    {
        static void Main(string[] args)
        {

            FootballLeague football = new FootballLeague();

            string connect = "data source=.; database=sports; integrated security=SSPI ";

            // Creating Connection
            SqlConnection conn = null;
            conn = new SqlConnection(connect);

            football.WinTeamDetails(conn);

            football.MatchDetails(conn);

            Console.ReadKey();
        }

        public void WinTeamDetails(SqlConnection conn)
        {
            try
            {
                Console.WriteLine("\n-------- Winning TeamNames ---------------\n");

                // Creating Command
                SqlCommand cmd = new SqlCommand("Select * from FootballLeague where MatchStatus = 'Win'", conn);

                // Opening Connection  
                conn.Open();

                // Executing the SQL query  
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["MatchID"] +" , " +
                                      dataReader["TeamName1"] + " , " + 
                                      dataReader["TeamName2"] + " , " +
                                      dataReader["MatchStatus"] +" , "+
                                      dataReader["WinningTeam"] + " , " +
                                      dataReader["Points"]);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }   
        }

        public void MatchDetails(SqlConnection conn)
        {
            try
            {
                Console.WriteLine("\n-------- Details of all matches in which Japan played ---------------\n");

                // Creating Command
                SqlCommand cmd = new SqlCommand("Select * from FootballLeague where TeamName1 = 'Japan' or TeamName2 = 'Japan'", conn);

                // Opening Connection  
                conn.Open();

                // Executing the SQL query  
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["MatchID"] + " , " +
                                      dataReader["TeamName1"] + " , " +
                                      dataReader["TeamName2"] + " , " +
                                      dataReader["MatchStatus"] + " , " +
                                      dataReader["WinningTeam"] + " , " +
                                      dataReader["Points"]);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
