using SERVICIOS.BITACORA.BLL;
using SERVICIOS.BITACORA.DOMINIO;
using SERVICIOS.ENCRIPTACION;
using SERVICIOS.SEGURIDAD.DOMINIO;
using System;
using System.IO;

namespace SERVICIOS.LOGIN
{
    public class LoginBLL
    {        
        public static void ValidarLogin(string user, string pass, string idioma)
        {               
            try
            {
                Usuario usuario = new Usuario();
                usuario.nombreusuario = user;
                usuario.contraseña = HelperEncrypt.EncodePasswordMd5(pass);

                UsuarioBLL.Sesion(user, idioma);

                UsuarioBLL.BuscarUsuario(usuario);

                Bitacora bitacora = new Bitacora();

                    bitacora.fecha = DateTime.Now;
                    bitacora.mensaje = "Inicio de Sesion Correcto";
                    bitacora.severidad = Bitacora.Severidad.INFO;
                    bitacora.usuario = UsuarioBLL.ObtenerUsuario();
                    bitacora.tipo = Bitacora.TipoLog.USUARIO;

                BitacoraBLL.Grabar(bitacora);
            }

            catch (Exception ex)
            {
                BitacoraCritica bitacoraCritica = new BitacoraCritica();

                bitacoraCritica.fecha = DateTime.Now;
                bitacoraCritica.mensaje = "(Serializable)Intento de Inicio de Sesion Incorrecto";
                bitacoraCritica.severidad = BitacoraCritica.Severidad.WARNING;
                bitacoraCritica.usuario = UsuarioBLL.ObtenerUsuario();
                bitacoraCritica.tipo = BitacoraCritica.TipoLog.USUARIO;

                BitacoraBLL.GrabarBitacoraCritica(bitacoraCritica);
                                                                              
                //string path = @"C:\Users\Administrator\Desktop\BitacoraCriticaNonSerialized.txt";
                //string texto = bitacoraCritica.fecha + bitacoraCritica.mensaje + bitacoraCritica.severidad + bitacoraCritica.usuario + bitacoraCritica.tipo;
                //File.AppendAllLines(path, new String[] { texto });
                
                throw ex;      
            }
        }
    }
}
