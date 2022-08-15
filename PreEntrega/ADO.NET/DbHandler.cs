using System.Data.SqlClient;

namespace PreEntrega
{
    public abstract class DbHandler
    {
        public const string ConnectionString =
            "Server=localhost;Initial Catalog=SistemaGestion;Trusted_Connection=true";
    }
}
