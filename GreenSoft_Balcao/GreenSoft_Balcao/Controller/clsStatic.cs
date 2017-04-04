using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSoft_Balcao.Controller
{
    public static class clsStatic
    {
        public static List<string> lsUnidades
        {
            get
            {
                List<string> lista = new List<string>();
                lista.Add("KG");
                lista.Add("UN");
                lista.Add("TO");
                return lista;
            }
        }

        public static Data.Usuario Usuario { get; set; }
        public static bool bSaiu = false;
        public static bool bSolicitaLogin = false;
        public static Data.Cliente cliente;
        public static Data.Produto produto;
        public static Data.Usuario usuario_temp;
    }
}
