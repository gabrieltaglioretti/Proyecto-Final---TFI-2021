using SERVICIOS.ENCRIPTACION;
using SERVICIOS.SEGURIDAD.DOMINIO;
using System;

namespace SERVICIOS.INTEGRIDAD
{
    public static class IntegridadBLL
    {
        public static void AgregarHash(Usuario usuario)
        {
            try 
            { 
                
                string cadenaDV = usuario.nombreusuario + usuario.contraseña;

                decimal dvh = HelperEncrypt.CalcularHash(cadenaDV);

                usuario.DVH = dvh;


            }
            catch (Exception ex)

            {
                throw ex;
            }
         }

        public static void ActualizarDVV()
        {

            decimal dvv = 0;

            foreach (var item in UsuarioDAL.GetAll())
            {
                dvv += item.DVH;
            }

            IntegridadDAL.ActualizarDVV(dvv);

        }

        public static void ValidarIntegridad()
        {
            try
            {
                decimal DVV_original = IntegridadDAL.LeerDVV();

                int nro_fila = 1;
                decimal DVH = 0;
                decimal DVV = 0;

                foreach (var item in UsuarioDAL.GetAll())
                {
                    string original = item.nombreusuario + item.contraseña;
                    decimal encriptado = HelperEncrypt.CalcularHash(original);

                    DVH += encriptado;
                    DVV += item.DVH;

                    if (item.DVH != encriptado)
                    {
                        //MessageBox.Show("El Registro número " + nro_fila + " presenta errores de integridad, posible alteracion de Usuario y/o Contraseña");
                        //Application.Exit();
                    }
                    nro_fila++;
                }

                if (DVV_original != DVV)
                {
                    //MessageBox.Show("Inconsistencias a nivel entidad. Posibles insert o delete de registros");
                    //Application.Exit();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }




}
