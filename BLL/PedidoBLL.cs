using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class PedidoBLL
	{
		#region Singleton
		private static readonly PedidoBLL _instance = new PedidoBLL();

		private PedidoBLL()
		{
			//Implement here the initialization code
		}

		public static PedidoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Pedido pedido)
		{
			try
			{
				Factory.Current.GetRepositoryPedido().Add(pedido);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Pedido pedido)
		{
			try
			{
				Factory.Current.GetRepositoryPedido().Update(pedido);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Pedido> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryPedido().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Pedido> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryPedido().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
