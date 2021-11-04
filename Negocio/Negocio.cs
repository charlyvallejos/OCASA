using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocasa.Entidades;

namespace Ocasa.Negocio
{
    public partial class Negocio
    {
        public static Entidades.Cliente getCliente()
        {
            Entidades.Cliente oCliente = new Entidades.Cliente();
            try
            {
                oCliente = Datos.Datos.getCliente();
                return oCliente;
            }
            catch
            {
                return null;
            }
        }

        public static Entidades.Cliente getClientexId(int idCliente)
        {
            Entidades.Cliente oCliente = new Entidades.Cliente();
            try
            {
                oCliente = Datos.Datos.getClientexId(idCliente);
                return oCliente;
            }
            catch
            {
                return null;
            }
        }

        public static int UpdateCliente(Entidades.Cliente oCliente)
        {
            int ok = 0;
            try
            {
                ok = Datos.Datos.UpdateCliente(oCliente);
                return ok;
            }
            catch
            {
                return 0;
            }
        }

        public static int AltaCliente(Entidades.Cliente oCliente)
        {
            int ok = 0;
            try
            {
                ok = Datos.Datos.AltaCliente(oCliente);
                return ok;
            }
            catch
            {
                return 0;
            }
        }
         
    }
}
