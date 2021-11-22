using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class CategoriaBLL
	{
		#region Singleton
		private static readonly CategoriaBLL _instance = new CategoriaBLL();

		private CategoriaBLL()
		{
			//Implement here the initialization code
		}

		public static CategoriaBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Categoria categoria)
		{
			try
			{
				Factory.Current.GetRepositoryCategoria().Add(categoria);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Categoria categoria)
		{
			try
			{
				Factory.Current.GetRepositoryCategoria().Update(categoria);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Categoria> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryCategoria().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Categoria> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryCategoria().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
