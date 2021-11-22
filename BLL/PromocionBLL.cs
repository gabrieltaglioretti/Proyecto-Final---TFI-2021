using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL
/// <summary>
/// Clase Producto BLL - Logica relacionada al Objeto Producto
/// </summary>
{
	public class PromocionBLL
	{
		#region Singleton
		private static readonly PromocionBLL _instance = new PromocionBLL();

		private PromocionBLL()
		{
			//Implement here the initialization code
		}

		public static PromocionBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Promocion promocion)
		{
			try
			{
				Factory.Current.GetRepositoryPromocion().Add(promocion);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Promocion promocion)
		{
			try
			{
				Factory.Current.GetRepositoryPromocion().Update(promocion);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Promocion> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryPromocion().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Promocion> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryPromocion().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
