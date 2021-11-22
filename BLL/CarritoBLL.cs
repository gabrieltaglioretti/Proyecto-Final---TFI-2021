using DAL.Factory;
using DOMAIN;
using SERVICIOS.BITACORA.BLL;
using SERVICIOS.BITACORA.DOMINIO;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class CarritoBLL
	{
		#region Singleton
		private static readonly CarritoBLL _instance = new CarritoBLL();

		private CarritoBLL()
		{
			//Implement here the initialization code
		}

		public static CarritoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Carrito carrito)
		{
			try
			{
				Factory.Current.GetRepositoryCarrito().Add(carrito);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Carrito carrito)
		{
			try
			{
				Factory.Current.GetRepositoryCarrito().Update(carrito);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Carrito> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryCarrito().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Carrito> GetOne(int id)
		{
			try
			{
				return Factory.Current.GetRepositoryCarrito().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}

		//////TEMPORAL PARA LA PRIMERA ENTREGA.
		///
		public static IEnumerable<Carrito> GetUserCart(string userid)
        {

			return Factory.Current.GetRepositoryCarrito().GetUserCart(userid);

        }

		public void Delete(int id)
		{
			try
			{
				Factory.Current.GetRepositoryCarrito().Delete(id);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

}
