using System.Data;
using System.Data.SqlClient; // <-- Nödvändig NuGet Package; för att kunna referera SQLparametrar

namespace RockPaperScissors
{

    //Än så länge hänvisar den till User; men kräver fortfarande SQL-koppling till övriga Tables
    //Koden är inte färdigtestad; 

    public class User
    {
        public User
        (long userid,
        string userName,
        string firstName,
        string lastName,
        string passwordHash,
        string token,
        DateTime? tokenIssued,

        long wins,
        long losses,
        long ties,
        long gamesPlayed) //end of parameter
        {
            UserID = userid;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            Token = token;
            TokenIssued = tokenIssued;


            Wins = wins;
            Losses = losses;
            Ties = ties;
            GamesPlayed = gamesPlayed;
        }

        public long? UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public DateTime? TokenIssued { get; set; }


        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Ties { get; set; }

        public long GamesPlayed { get; set; }

        public static string baseSelectSQL => "select [UserID], [UserName], [FirstName], [LastName], [PasswordHash], [Token], [TokenIssued], [Wins], [Losses], [Ties], [GamesPlayed] from [User]";

        public static string SqlAll()
        {
            return baseSelectSQL;
        }

        public static (string, List<SqlParameter>) SqlLogin(string username, string passwordhash)
        {
            List<SqlParameter> parameterValues = new List<SqlParameter>();
            parameterValues.Add(new SqlParameter("username", username));
            parameterValues.Add(new SqlParameter("password", passwordhash));

            string selectSql = baseSelectSQL + "where Username = @username and Passwordhash = @passwordhash";
            return (selectSql, parameterValues);
        }

        public static (string, List<SqlParameter>) SqlUser(string username, string passwordhash=null)
        {
            string sql = baseSelectSQL + "here Username = @UserName";
            List<SqlParameter> parameterValues = new List<SqlParameter>();
            parameterValues.Add(new SqlParameter("@UserName", username));
            if (string.IsNullOrEmpty(passwordhash) == false)
            {
                parameterValues.Add(new SqlParameter("password", passwordhash));
                sql = sql + " and passwordhash = @passwordhash";
            }
            return (sql, parameterValues);
        }

        public static (string, List<SqlParameter>) SqlAdd(User user)
        {
            List<SqlParameter> parameterValues = new List<SqlParameter>();
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@FirstName", user.FirstName));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@LastName", user.LastName));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@PasswordHash", user.PasswordHash));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Token", "NA"));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@TokenIssued", "2022-03-23"));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@UserName", user.UserName));

            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Wins", user.Wins));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Losses", user.Losses));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Ties", user.Ties));
            parameterValues.Add(MessageDatabaseConnection.GetParameter("@GamesPlayed", user.GamesPlayed));


            return (@"insert into [User]
                ([FirstName],[LastName],[PasswordHash],[Token],[TokenIssued],[UserName], [Wins], [Losses], [Ties], [GamesPlayed])
                values (@Firstname, @Lastname, @PasswordHash,@Token, @TokenIssued, @UserName, @Wins, @Losses, @Ties, @GamesPlayed)",
                parameterValues);
        }



    }


    public class MessageDatabaseConnection
    {
        public string ConnectionString { get; }

        public MessageDatabaseConnection(string connectionString)
        {
            ConnectionString = connectionString;
            

        }

        public static SqlParameter GetParameter(string parameterName, object parameterValue)
        {
            SqlParameter parameterObject = new SqlParameter
            (
            parameterName, parameterValue == null ? DBNull.Value : parameterValue
            );

            parameterObject.Direction = ParameterDirection.Input;
            return parameterObject;
        }

        #region Run Query

        public List<T> RunQuery<T>(string sql, List<SqlParameter> parameters = null)
        {
            Type itemtype = typeof(T);

            List<T> listarray = new List<T>();
            using (SqlConnection mySqlConnection = new SqlConnection(ConnectionString))
            {
                mySqlConnection.Open();

                using (SqlCommand cmd = mySqlConnection.CreateCommand())
                {
                    cmd.CommandText = sql;

                    if (parameters != null)
                        foreach (var pm in parameters)
                            cmd.Parameters.Add(pm);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int cols = reader.FieldCount;
                        while (reader.Read())
                        {
                            object[] item = new object[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var objectType = reader[i].GetType();
                                item[i] = Convert.ChangeType(reader[i], objectType);
                            }
                            listarray.Add((T)Activator.CreateInstance(itemtype, item));
                        }
                    }

                    mySqlConnection.Close();

                }
            }
            return listarray;
        }

        public List<T> RunQuery<T>((string, List<SqlParameter>) parameters)
        {
            return RunQuery<T>(parameters.Item1, parameters.Item2);
        }
        #endregion

        #region None Query

        public int ExecuteNoneQuery((string, List<SqlParameter>) parameters)
        {
            return ExecuteNoneQuery(parameters.Item1, parameters.Item2);
        }

        public int ExecuteNoneQuery(string sql, List<SqlParameter> sqlParameters)
        {
            int returnValue = -1;

            try
            {
                using (SqlConnection mySqlConnection = new SqlConnection(ConnectionString))
                {
                    mySqlConnection.Open();
                    using (SqlCommand cmd = mySqlConnection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                        returnValue = cmd.ExecuteNonQuery();
                    }
                    mySqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ExecuteNonQuery:");
                throw;
            }


            return returnValue;
        }

        #endregion


    }

    internal class TableDatabaseConnection //Osäker på detta namn, med "Program" kädnes för otydligt och kan lätt blandas ihop med det som sker i huvudapplikationen.
    {
        private void PrintSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void SqlToConsole()
        {

            #region Connect To Database

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Initiate connection to database...");

            ////////////////////////////////////////////////////////////////
            MessageDatabaseConnection msgDB = new MessageDatabaseConnection
            ("Server=localhost;Database=RockPaperScissor;Trusted_Connection=True");
            ////////////////////////////////////////////////////////////////

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");

            Console.ForegroundColor = ConsoleColor.Gray;

            #endregion

            #region Retrieve Users

            Console.WriteLine("Retrieving Users..");

            var users = msgDB.RunQuery<User>(User.SqlAll());

            msgDB.RunQuery<User>(User.SqlAll());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");

            Console.ForegroundColor = ConsoleColor.Gray;

            #endregion Retrieve Users

            Console.WriteLine("Printing Users..");

            //Print Users
            foreach (var user in users)
            {
                Console.WriteLine(user.FirstName);
            }
            Console.ReadLine();

            #region Create New User

            Console.WriteLine("Create New User: ... ");

            var unique = DateTime.Now.Ticks;
            var newUser = new User
                (
                1273 + unique, //needs value
                "UserName_" + unique,
                "FirstName_" + unique,
                "LastName_" + unique,
                "myhashedpassword",
                null, //token
                null, //tokenIssued
                0 + unique, //wins
                0 + unique, //loss
                0 + unique, //ties
                0 + unique //gamesplayed
                );

            msgDB.ExecuteNoneQuery(User.SqlAdd(newUser));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");

            Console.ForegroundColor = ConsoleColor.Gray;

            #endregion

            //Get User

            Console.WriteLine("Get User... ");

            (string, List<SqlParameter>) tupel = User.SqlUser("");
            var filteredUsers = msgDB.RunQuery<User>(tupel);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");

            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }

}

