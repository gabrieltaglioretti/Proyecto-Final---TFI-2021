using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class CompraBLL
	{
		#region Singleton
		private static readonly CompraBLL _instance = new CompraBLL();

		private CompraBLL()
		{
			//Implement here the initialization code
		}

		public static CompraBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Compra compra)
		{
			try
			{
				Factory.Current.GetRepositoryCompra().Add(compra);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Compra compra)
		{
			try
			{
				Factory.Current.GetRepositoryCompra().Update(compra);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Compra> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryCompra().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Compra> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryCompra().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
