using DAL.Contrats;
using DOMAIN;
using System;
using System.Configuration;
using SERVICIOS;

namespace DAL.Factory
{
    public sealed class Factory
	{

		#region Singleton
		private static readonly Factory _instance = new Factory();

		private Factory()
		{
		}

		public static Factory Current
		{
			get { return _instance; }
		}
		#endregion




		public IRepositoryCarrito<Carrito> GetRepositoryCarrito()
		{

			string namespacename = ApplicationSettings.Current.RepositorioSQL + ".CarritoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryCarrito<Carrito>)instancia;

		}

		public IRepositoryCategoria<Categoria> GetRepositoryCategoria()
		{

			string namespacename = ConfigurationManager.AppSettings["RepositorioSQL"] + ".CategoriaRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryCategoria<Categoria>)instancia;

		}
		public IRepositoryCompra<Compra> GetRepositoryCompra()
		{

			string namespacename = ConfigurationManager.AppSettings["RepositorioSQL"] + ".CompraRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryCompra<Compra>)instancia;

		}

		public IRepositoryPedido<Pedido> GetRepositoryPedido()
		{

			string namespacename = ApplicationSettings.Current.RepositorioSQL + ".PedidoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryPedido<Pedido>)instancia;

		}
		public IRepositoryProducto<Producto> GetRepositoryProducto()
		{
			

			string namespacename = ApplicationSettings.Current.RepositorioSQL + ".ProductoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryProducto<Producto>)instancia;

		}

		public IRepositoryProductoNoSQL<Producto> GetRepositoryProductoNoSQL()
		{

			string namespacename = "DAL.Repositories.FireBase.ProductoNoSQLRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryProductoNoSQL<Producto>)instancia;

		}
		public IRepositoryPago<Pago> GetRepositoryPago()
		{

			string namespacename = ApplicationSettings.Current.RepositorioSQL + ".PagoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryPago<Pago>)instancia;

		}

		public IRepositoryCuenta<Cuenta> GetRepositoryCuenta()
		{

			string namespacename = ConfigurationManager.AppSettings["RepositorioSQL"] + ".PagoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryCuenta<Cuenta>)instancia;

		}

	}
}