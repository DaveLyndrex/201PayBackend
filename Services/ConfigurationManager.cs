using IniParser;
using IniParser.Model;
using MySqlConnector;


namespace BackEnd.Services
{
    public class ConfigurationManager
    {
        public static FileIniDataParser fileReader = null;
        public static IniData getIniData()
        {


            /* string _path = "C:\\Users\\cndev1\\.ssh\\201Pay-be\\config.ini";*/
            /*string _path = "C:\\201Pay_BE\\publish\\config.ini";*/
            /*string _path = "C:\\Users\\Dell\\.ssh\\201Pay-be\\config.ini";*/
            /*string _path = "C:\\Users\\cndev1\\.ssh\\201Pay-be\\config.ini";*/
           string _path = "C:\\201Pay_BE\\publish\\config.ini";
           /* string _path = "C:\\Users\\Work PC\\.ssh\\201Pay-be\\config.ini";*/



            FileIniDataParser fileReader = new FileIniDataParser();
            IniData data = fileReader.ReadFile(_path);

            return data;
        }

        public static MySqlConnection DatabaseConnection()
        {
            IniData data = getIniData();

            string server = data["DatabaseConfig"]["Server"];
            string database = data["DatabaseConfig"]["Database"];
            string username = data["DatabaseConfig"]["UID"];
            string password = data["DatabaseConfig"]["Password"];

            string connection_string = "server=" + server + ";port=3306;database=" + database + ";username=" + username + ";password=" + password + ";";

            MySqlConnection conn = new MySqlConnection(connection_string);
            return conn;
        }

        public static string getDatabaseParameters()
        {
            IniData data = getIniData();

            string server = data["DatabaseConfig"]["Server"];
            string database = data["DatabaseConfig"]["Database"];
            string username = data["DatabaseConfig"]["UID"];
            string password = data["DatabaseConfig"]["Password"];

            string databaseParams = "D PARAMETERS" + server + database + username + password;

            return databaseParams;
        }
    }
}