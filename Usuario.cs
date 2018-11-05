using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocaMensagens
{
    public class Usuario
    {
        public int iCodigo { get; set; }
        public string sNome { get; set; }
        public int iQtdJogosGanhos { get; set; }

        public Usuario()
        {
            this.iCodigo = 0;
            this.sNome = "";
            this.iQtdJogosGanhos = 0;
        }

        public override string ToString()
        {
            return sNome;
        }
    }
}
