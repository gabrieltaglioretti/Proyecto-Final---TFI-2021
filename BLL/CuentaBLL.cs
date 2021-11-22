using DAL.Factory;
using DOMAIN;
using System;
using System.Collections.Generic;



namespace BLL

{
	public class CuentaBLL
	{
		#region Singleton
		private static readonly CuentaBLL _instance = new CuentaBLL();

		private CuentaBLL()
		{
			//Implement here the initialization code
		}

		public static CuentaBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Cuenta cuenta)
		{
			try
			{
				Factory.Current.GetRepositoryCuenta().Add(cuenta);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Update(Cuenta cuenta)
		{
			try
			{
				Factory.Current.GetRepositoryCuenta().Update(cuenta);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static IEnumerable<Cuenta> GetAll()
		{
			try
			{
				return Factory.Current.GetRepositoryCuenta().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static IEnumerable<Cuenta> GetOne(Guid id)
		{
			try
			{
				return Factory.Current.GetRepositoryCuenta().GetOne(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
