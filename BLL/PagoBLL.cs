using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class PagoBLL
	{
		#region Singleton
		private static readonly PagoBLL _instance = new PagoBLL();

		private PagoBLL()
		{
			//Implement here the initialization code
		}

		public static PagoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Pago pago)
		{
			try
			{
				Factory.Current.GetRepositoryPago().Add(pago);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Pago pago)
		{
			try
			{
				Factory.Current.GetRepositoryPago().Update(pago);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<Pago> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryPago().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Pago> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryPago().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
