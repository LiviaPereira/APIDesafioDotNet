using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace APIEscola.Infra.Data.Repositories
{
    public abstract class APIEscolaRepositoryBase
    {
        private IConfigurationRoot _configurationRoot;

        internal IDbConnection ConnectionAPIEscola
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                _configurationRoot = builder.Build();
                return new SqlConnection(_configurationRoot.GetConnectionString("DefaultConnectionString"));
            }
        }
    }
}
