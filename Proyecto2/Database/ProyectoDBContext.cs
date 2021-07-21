using MySql.Data.MySqlClient;

namespace Proyecto2.Database
{
    public class ProyectoDBContext
    {
        private string ConnectionString { get; set; }

        public ProyectoDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public ProyectoDBContext()
        {
        }



        protected MySqlConnection GetConnection()
        {

            return new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=root;database=cine2;");
        }

    }
}