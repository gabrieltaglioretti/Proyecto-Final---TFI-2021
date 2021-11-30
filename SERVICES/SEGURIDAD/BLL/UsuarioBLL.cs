using System;
using SERVICIOS.SEGURIDAD.DAL;
using SERVICIOS.SEGURIDAD.DOMINIO;
using System.Collections.Generic;
using System.Drawing;

namespace SERVICIOS.SEGURIDAD.BLL
{
    public static class UsuarioBLL
    
    {
        public static bool BuscarUsuario(Usuario usuario)
        {
            try
            {
                if (UsuarioDAL.BuscarUsuario(usuario))
                {
                    return true;
                }

                else
                {
                    throw new Exception("ERROR: Usuario o Contraseña incorrecta.");                    
                }

            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private static string user;
        private static string idiomaUsuario = "es-ES";

        public static string ObtenerUsuario()
        {
            return user;
        }

        public static void Sesion(string username, string idioma)
        {
            user = username;
            if (idioma != null) idiomaUsuario = idioma;
        }

        public static string GetIdioma()
        {
            return idiomaUsuario;
        }

        public static Usuario GetOne() 
        {
            return UsuarioDAL.GetOne(user);            
        }

        public static string GetId()

        {
            Usuario usuario = new Usuario();

            usuario = GetOne();

            string id = usuario.idUsuario;

            return id;
        }       

        public static IEnumerable<Usuario> TodosUsuarios()
        {
            try
            {
                return UsuarioDAL.GetAll();
        }
            catch (Exception)
            {
                throw;
            }
        }

        //public static Image GetPhoto(string username) 
        //{
        //    return UsuarioDAL.GetUserImage(username);
        //}

        /////////////////////////////////////////////////////////////////////////

        public static IEnumerable<Patente> GetPatentesAsignadas(string userId)
        {
            try
            {
                return Usuario_PatenteDAL.Current.GetPatentesAsignadas(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<Patente> GetPatentesDisponibles(string userId)
        {
            try
            {
                return Usuario_PatenteDAL.Current.GetPatentesDisponibles(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static void AddUsuarioPatente(Usuario usuario, Patente patente)
        {
            try
            {
                Usuario_PatenteDAL.Current.AddUsuarioPatente(usuario.idUsuario, patente.idfamilia);

            }
            catch (Exception ex)
            {
            }
        }

        public static void DeleteUsuarioPatente(Usuario usuario, Patente patente)
        {
            try
            {
                Usuario_PatenteDAL.Current.DeleteUsuarioPatente(usuario.idUsuario, patente.idfamilia);
            }

            catch (Exception ex)
            {
            }
        }

        public static IEnumerable<Familia> GetFamiliasAsignadas(string userId)
        {
            try
            {
                return Usuario_FamiliaDAL.Current.GetFamiliasAsignadas(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<Familia> GetFamiliasDisponibles(string userId)
        {
            try
            {
                return Usuario_FamiliaDAL.Current.GetFamiliasDisponibles(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void AddUsuarioFamilia(Usuario usuario, Familia familia)
        {
            try
            {
                Usuario_FamiliaDAL.Current.AddUsuarioFamilia(usuario.idUsuario, familia.idfamilia);

            }
            catch (Exception ex)
            {
            }
        }

        public static void DeleteUsuarioFamilia(Usuario usuario, Familia familia)
        {
            try
            {
                Usuario_FamiliaDAL.Current.DeleteUsuarioFamilia(usuario.idUsuario, familia.idfamilia);

            }
            catch (Exception ex)
            {
            }
        }






    }


}

