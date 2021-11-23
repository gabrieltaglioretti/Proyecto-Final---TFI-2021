using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
	public class ApplicationSettings
	{
		#region Singleton
		private static readonly ApplicationSettings _instance = new ApplicationSettings();


		private ApplicationSettings()
		{

		}

		public static ApplicationSettings Current
		{
			get { return _instance; }
		}
        #endregion

        /// <summary>
        /// MOVER A APP.CONFIG
        /// </summary>

        ////BUSINESS CLOUD DATABASE
        public IFirebaseConfig connNoSql = new FirebaseConfig() { AuthSecret = "v3UOM2rhl2ka4ibg35XZD5Bzj66chGqxX9IvLCM4", BasePath = "https://productosvolando-default-rtdb.firebaseio.com/" };


        ////BUSINESS LOCAL DATABASE
        public readonly string connAplicacionDB = @"Server=tcp:volandoappdb.database.windows.net,1433;Initial Catalog=VolandoEshop;Persist Security Info=False;User ID=TAGLIG01;Password=Utopia012;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        ////SERVICES CLOUD DATABASE
        public readonly string connSeguridadDB = @"Server=tcp:volandoappdb.database.windows.net,1433;Initial Catalog=Seguridad;Persist Security Info=False;User ID=TAGLIG01;Password=Utopia012;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        //BUSINESS CLOUD DATABASE
        //public readonly string connAplicacionDB = "workstation id=VolandoEshop.mssql.somee.com;packet size = 4096; user id = Taglig01_SQLLogin_1; pwd=Utopia012;data source = VolandoEshop.mssql.somee.com; persist security info=False;initial catalog = VolandoEshop";

        //SERVICES CLOUD DATABASE
        //public readonly string connSeguridadDB = "workstation id=VolandoEshop.mssql.somee.com;packet size = 4096; user id = Taglig01_SQLLogin_1; pwd=Utopia012;data source = VolandoEshop.mssql.somee.com; persist security info=False;initial catalog = VolandoEshop";


        //LOCAL BUSINESS REPOSITORIES
        public readonly string RepositorioSQL = "DAL.Repositories.SQL";
		public readonly string RepositorioFirebase = "DAL.Repositories.Firebase";

        //public readonly string CurrentApi = "https://localhost:44303";
        public readonly string CurrentApi = "https://apivolando.azurewebsites.net/";

        ////////////////////////////ALREADY RUNNING IN THE PROJECT////////////////////////////////////////

        public static string Api = "https://localhost:44303";
        //public static string Api = "http://volandoapi.somee.com";

		public readonly string connApiCarrito = Api + "/api/Carrito";
		public readonly string connApiProducto = Api + "/api/Producto";
        public readonly string connApiPago = Api + "/api/Pago";
        public readonly string connApiPedido = Api + "/api/Pedido";
        public readonly string connApiBitacora = Api + "/api/Bitacora";

        //ACCESS TOKEN MP
        public readonly string AccessTokenMP = "TEST-2876215673747081-092103-b7349cff7e2b2831e8420aed09db7bc4-84605397";

       









	}
}
