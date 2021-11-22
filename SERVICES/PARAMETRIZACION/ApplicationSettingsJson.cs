using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
	public class ApplicationSettingsJson
	{
		#region Singleton
		public static readonly ApplicationSettingsJson _instance = new ApplicationSettingsJson();


		public SqlConnection Master;
		public SqlConnection Seguridad;
		public SqlConnection Aplicacion;

		public string connMaster;
		public string connSeguridad;
		public string connAplicacion;

		public string file_enUS;
		public string file_esES;
		public string file_ptBR;
		public string RepositorioSQL;
		


		public ApplicationSettingsJson()
		{
			var configuation = GetConfiguration();


			Master = new SqlConnection(configuation.GetSection("connMaster").GetSection("ConnectionString").Value);
			connMaster = Master.ConnectionString.ToString();

			Seguridad = new SqlConnection(configuation.GetSection("connSeguridad").GetSection("ConnectionString").Value);
			connSeguridad = Seguridad.ConnectionString.ToString();

			Aplicacion = new SqlConnection(configuation.GetSection("connAplicacion").GetSection("ConnectionString").Value);
			connAplicacion = Aplicacion.ConnectionString.ToString();

			 file_enUS = configuation.GetSection("File_en-US").GetSection("Value").Value;
			 file_esES = configuation.GetSection("file_esES").GetSection("Value").Value;
			 file_ptBR = configuation.GetSection("file_ptBR").GetSection("Value").Value;
			 RepositorioSQL = configuation.GetSection("RepositorioSQL").GetSection("Value").Value;
		}

		public static ApplicationSettingsJson Current
		{
			get { return _instance; }
		}

		public IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			return builder.Build();
		}
		#endregion


	}
}
