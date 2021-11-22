using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class FavoritoBLL
	{
		#region Singleton
		private static readonly FavoritoBLL _instance = new FavoritoBLL();

		private FavoritoBLL()
		{
			//Implement here the initialization code
		}

		public static FavoritoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Favorito favorito)
		{
			try
			{
				Factory.Current.GetRepositoryFavorito().Add(favorito);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Favorito favorito)
		{
			try
			{
				Factory.Current.GetRepositoryFavorito().Update(favorito);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Favorito> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryFavorito().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Favorito> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryFavorito().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
