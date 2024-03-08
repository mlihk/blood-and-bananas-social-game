//Final version at week 12
using System;
using System.Data.SqlClient;

class dataStoring
{
    static void Main(String[] args) //The Main method starts by initializing the connection string to the database, and a boolean variable nextStep to false. Then, it enters a loop that will keep running until nextStep is set to true. Within this loop, it generates a random player ID, prompts the user to enter their email and password, and checks whether the email and player ID are unique. If both the email and player ID are unique, it opens a connection to the database and inserts the user data into the players table. Finally, it prints a success message and sets nextStep to true.
    {
        string connectionString = "Data Source=xx;Initial Catalog=myDataBase; User Id=admin;Password=admin";
        boolean nextStep = false;
        while (nextStep = false)
        {
        playerID = randomIDGem()

        Console.Write("Enter email address: ");
        string email = Console.ReadLine();

        Console.Write("Enter password: ");
        string userPassword = Console.ReadLine();

        if (checkEmailDupe(email) = true and checkIDDupe(playerID) = true)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql= "INSERT INTO players (playerID, email, password, wins) VALUES (@playerID, @email, @userPassword, 0)";
            using (SqlCommand command = new Sqlcommand(sql, connection))
            {
                command.Parameters.AddWithValue("@playerID", playerID);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@wins", 0);
                command.ExecuteNonQuery();

            }
            string sql= "INSERT INTO playerAssets (playerID, currency) VALUES (@playerID, 0)";
            using (SqlCommand command = new Sqlcommand(sql, connection))
            {
                command.Parameters.AddWithValue("@playerID", playerID);
                command.Parameters.AddWithValue("@currency", 0);
                command.ExecuteNonQuery();

            }
        }
            Console.WriteLine("Player account created!");
            Console.WriteLine("Your unique player ID is", playerID);
            Console.ReadKey();
            nextStep = true;
        }
        }

    
    static int randomIDGem()
        Random random = new Random();
        int playerID = random.Next(1,10000));

        return playerID;

    static bool checkEmailDupe(String email, string connectionString) // checks whether the given email address is already registered in the players table. It opens a connection to the database, executes a SELECT COUNT(*) query to count the number of rows that match the email address, and returns false if the count is greater than zero (i.e., the email is a duplicate), or true otherwise.
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql= "SELECT COUNT(*) FROM players WHERE email = @email";

            using (SqlCommand command = new Sqlcommand(sql, connection))
            {
                command.Parameters.AddWithValue("@email", email);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine("This email address has already been registered!");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    Console.ReadKey();
                    return true;
                }
            }
        }
    static bool checkIDDupe(int playerID, string connectionString)
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql= "SELECT COUNT(*) FROM players WHERE playerID = @playerID";

            using (SqlCommand command = new Sqlcommand(sql, connection))
            {
                command.Parameters.AddWithValue("@playerID", playerID);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine("This playerID has already been registered!");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    Console.ReadKey();
                    return true;
                }
            }
        }
    static (int, int) playerlogin(string[] args, string connectionString) //ompts the user to enter their email and password, and checks whether there is a row in the players table that matches both the email and password. If there is, it retrieves the player ID and wins for that row, and returns them as a tuple.

        while (true)
        {
            Console.Write("enter your login email: ");
            string email = Console.ReadLine();
            Console.Write("enter your login password: ");
            string password = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql= "SELECT COUNT(*) FROM players WHERE email = @email AND password = @password";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        Console.WriteLine("Login successful!");
                        string sql = "Select playerID, wins FROM players WHERE email=@email";
                        using (Sqlcommand command = new Sqlcommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@email", email);
                            
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows && reader.Read())
                                {
                                    int returnPlayerID = reader.GetInt32(0); //use to return player id for display?
                                    int wins = reader.GetInt32(1); // use to return wins, if you need to store any additional information lmk!
                                }
                            }
                        }
                        return (returnPlayerID, wins);
                        break;                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid login credentials! Please Try again!")
                    }
                }

            }
        }
        Console.ReadKey();

    static void winValueChange(int[] args) //simmply add 1 to the win in database for that user
        int returnPlayerID = int[0]
        {
        string connectionString = "Data Source=serverAddress; Initial Catalog=myDataBase;User Id=admin;Password=admin"
        
        Using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "UPDATE players SET wins = wins + 1 WHERE playerID = @returnPlayerID";
            using (Sqlcommand command = new Sqlcommand(sql, connection))
            {
                command.Parameters.AddwithValue("@returnPlayerID", playerID);
                Console.writeLine("Wins has been recorded to the player!")
            }
        }
        }

    static void deleteAccount(int playerID, int connectionString) // to use this function simply use Player player = new Player(); player.deleteAccount(xxxx, connectionString)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM players WHERE playerID = @playerID";
                using (Sqlcommand command= new Sqlcommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@playerID", playerID);

                    Console.writeLine("Account successfully deleted for ID {0}", playerID);
                }
                string sql = "DELETE FROM playerAssets WHERE playerID = {playerID}";//newly added to delete row at playerAssest as well
                using (Sqlcommand command= new Sqlcommand(sql, connection)) 
                {
                    command.Parameters.AddWithValue("@playerID", playerID);
                }
        }
    
    static void overrideWins(int playerID, int wins, int connectionString)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE players SET wins = @wins WHERE playerID = @playerID";
                using (Sqlcommand command = new Sqlcommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@playerID", playerID);
                    command.Parameters.AddWithValue("@wins", wins);

                    Console.writeLine("Manually Overrided win value for player {0}", playerID);
                }
            }

        }
    
    public void emailChange(int playerID, string newEmail, int connectionString) //BECAREFUL ONLY CALL THIS AFTER LOGIN! call by player.emailChange(xxxx, newemailaddress, connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)
            {
                connection.Open();

                string sql = "UPDATE players SET email = @newEmail WHERE playerID = @playerID";
                using (Sqlcommand command = new Sqlcommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@playerID", playerID);
                    command.Parameters.AddWithvalue("@newEmail", newEmail);
                    Console.WriteLine("Email address has been updated for player {0}", playerID);

                }
            }
        }
    public void passwordChange(int playerID, string newPassword, int connectionString) //BECAREFUL ONLY CALL THIS AFTER LOGIN! call this by player.passwordChange(xxxx, newpassword, connetionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)
            {
                connection.Open();

                string sql = "UPDATE players SET password = @newPassword WHERE playerID = @playerID";
                using (Sqlcommand command = new Sqlcommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@playerID", playerID);
                    command.Parameters.AddWithvalue("@newPassword", newPassword);
                    Console.WriteLine("Password has been updated for player {0}", playerID);

                }
            }
        }
    public void matchResult(int[] playerIDs, string winner, int matchDuration, connectionString) //Add a match result into the matches table after a game is finished.
    {
    // Generate a unique match ID example format: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx very suitable to store unique identities!
    string matchID = Guid.NewGuid().ToString(); 

    // Open a connection to the database
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        // Insert the match details into the 'matches' table
        using (SqlCommand command = new SqlCommand("INSERT INTO matches (matchID, playerID1, playerID2, playerID3, playerID4, playerID5, playerID6, @matchDuration, @winningSide)", connection))
        {
            command.Parameters.AddWithValue("@matchID", matchID);
            command.Parameters.AddWithValue("@playerID1", playerID[0]);
            command.Parameters.AddWithValue("@playerID2", playerID[1]);
            command.Parameters.AddWithValue("@playerID3", playerID[2]);
            command.Parameters.AddWithValue("@playerID4", playerID[3]);
            command.Parameters.AddWithValue("@playerID5", playerID[4]);
            command.Parameters.AddWithValue("@playerID6", playerID[5]);
            command.Parameters.AddWithValue("@matchDuration", matchDuration);
            command.Parameters.AddWithValue("@winningSide", winner);

            command.ExecuteNonQuery();
        }
    }
    }
    static int getPlayerCurrency(string connectionString, int playerID) //retreive the amount of currency the playerID has
    {
        int currency = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "SELECT currency FROM playerAssets WHERE playerID = {playerID}";

            using (SqlCommand command = new SqlCommand(query, connection))  
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currency = reader.GetInt32(0);
                    }
                }
            }
        }

        return currency; //returns the amount
    }
    static void storePlayerAssets(string connectionString, int playerID, int currency) //this method relies on the main program pulling initial currency from getPlayerCurrency method and store them locally in-instance then after operations, return it back to the database at the end.
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "UPDATE playerAssets SET currency = {currency} WHERE playerID = {playerID}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
    static List<int> top10RichestPlayers(string connectionString) //returns the top 10 players that has the most currency for the leaderboard purpose!
    {
        List<int> top10RichestPlayers = new List<int>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT TOP 10 playerID FROM playerAssets ORDER BY currency DESC";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int playerID = reader.GetInt32(0);
                        top10RichestPlayers.Add(playerID);
                    }
                }
            }
        }

        return top10RichestPlayers; //return it as a list
    }
    static List<int> getTop10Wins(string connectionString) //returns top 10 players with the most wins in players table
    {
    List<int> top10players = new List<int>();
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string query = "SELECT TOP 10 playerID, wins FROM players ORDER BY wins DESC";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int playerID = reader.GetInt32(0);
                top10players.Add(playerID);
            }
            reader.Close();
        }
    }
    return top10players; //use this method to retreive top 10 player as a list for leader board!
    }
}
