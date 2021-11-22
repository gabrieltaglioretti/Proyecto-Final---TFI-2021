using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL
/// <summary>
/// Clase Producto BLL - Logica relacionada al Objeto Producto
/// </summary>
{
	public class ProductoBLL
	{
		#region Singleton
		private static readonly ProductoBLL _instance = new ProductoBLL();

		private ProductoBLL()
		{
			//Implement here the initialization code
		}

		public static ProductoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Producto producto)
		{
			try
			{
				//ESCRIBE EN AMBOS REPOSITORIOS A LA VEZ.
				Factory.Current.GetRepositoryProducto().Add(producto);
                Factory.Current.GetRepositoryProductoNoSQL().Add(producto);


            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Producto producto)
		{
			try
			{
				Factory.Current.GetRepositoryProducto().Update(producto);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Producto> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryProducto().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Producto> GetOne(int id)
		{
			try
			{
				return Factory.Current.GetRepositoryProducto().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}

		
	}


}
