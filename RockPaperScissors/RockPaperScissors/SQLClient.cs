using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace SQLClient
//{

//    public class User
//    {
//        public User
//        (long userid,
//        string userName,
//        string firstName,
//        string lastName,
//        string passwordHash,
//        string token,
//        DateTime? tokenIssued,

//        long wins,
//        long losses,
//        long ties,
//        long gamesPlayed) //end of parameter
//        {
//            UserID = userid;
//            UserName = userName;
//            FirstName = firstName;
//            LastName = lastName;
//            PasswordHash = passwordHash;
//            Token = token;
//            TokenIssued = tokenIssued;


//            Wins = wins;
//            Losses = losses;
//            Ties = ties;
//            GamesPlayed = gamesPlayed;
//        }

//        public long? UserID { get; set; }
//        public string UserName { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string PasswordHash { get; set; }
//        public string Token { get; set; }
//        public DateTime? DateTime { get; set; }


//        public long Wins { get; set; }
//        public long Losses { get; set; }
//        public long Ties { get; set; }

//        public long GamesPlayed { get; set; }

//        public static string baseSelectSQL => "select [UserID], [Username], [Firstname], [Lastname], [PasswordHash], [Token], [TokenIssued], [Wins], [Losses], [Ties], [GamesPlayed] from [User]";

//        public static string SqlAll()
//        {
//            return baseSelectSQL;
//        }

//        public static (string List<SqlParameter>) SqlLogin(string username, string passwordhash)
//        {
//            List<SqlParameter> parameterValues = new List<SqlParameter>();
//            parameterValues.Add(new SqlParameter("username", username));
//            parameterValues.Add(new SqlParameter("password", passwordhash));

//            string selectSql = baseSelectSQL + "where Username = @username and Passwordhash = @passwordhash";
//            return (selectSql, parameterValues);
//        }

//        public static (string, List<SqlParameter>) SqlAdd(User user)
//        {
//            List<SqlParameter> parameterValues = new List<SqlParameter>();
//            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Firstname", user.FirstName));
//            parameterValues.Add(MessageDatabaseConnection.GetParameter("@lastname", user.LastName));
//            parameterValues.Add(MessageDatabaseConnection.GetParameter("@PasswordHash", user.PasswordHash));
//            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Token", "NA"));
//            parameterValues.Add(MessageDatabaseConnection.GetParameter("@TokenIssued", "2000-01-01"));
//            parameterValues.Add(MessageDatabaseConnection.GetParameter("@Username", user.Username));


//            parameterValues.Add(Mess)


//            return (@"insert into [User]
//                ([FirstName],[LastName],[PasswordHash],[Token],[TokenIssued],[Username])
//                values (@Firstname, @Lastname, @PasswordHash,@Token, @TokenIssued, @Username)",
//                parameterValues);
//        }



//    }


//    public class MessageDatabaseConnection
//    {
//        public string ConnectionString { get; }

//            public MessageDatabaseConnection(string connectionString)
//            {
//               ConnectionString = connectionString;
//            }

//        public static SqlParameter GetParameter(string parameterName, object parameterValue)
//        {
//            SqlParameter parameterObject = new SqlParameter(parameterName, parameterValue == null ? DBNull.Value : parameterValue);

//            parameterObject.Direction = ParameterDirection.Input;
//            return parameterObject;
//        }
//    }


//    internal class Program
//    {
//        static void Main()
//        {

//            //Connect to Database
//            MessageDatabaseConnection msgDB = new MessageDatabaseConnection
//            ("Server=localhost;Database=MessageDB;Trusted_Connection=True");

//            //Retrieve Users
//            var users = msgDB.RunQuery<User>(User.SqlAll());

//            msgDB.RunQuery<User>(User.SqlAll());

//            //Print users
//            foreach (var user in users)
//            {
//                Console.WriteLine(user.FirstName);
//            }

//            //Create new User
//            var unique = DateTime.Now.Ticks;
//            var newUser = new User
//                (
//                1273 + unique, //needs value
//                "Username_" + unique,
//                "firstname_" + unique,
//                "lastname_" + unique,
//                "myhashedpassword",
//                null, //token
//                null, //tokenIssued
//                0 + unique, //wins
//                0 + unique, //loss
//                0 + unique, //ties
//                0 + unique //gamesplayed
//                );

//            msgDB.ExecuteNoneQuery(User.SqlAdd(newUser));

//            //Get User
//            (string, List<SqlParameter>) tupel = User.SqlUser("hamster_firelord", "badass");
//            var filteredUsers = msgDB.RunQuery<User>(tupel);

//        }
//    }
    
//}

