using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CPF_CNPJ
{
    public class CPF_CNPJ
    {
        public CPF CPF { get; private set; }
        public CNPJ CNPJ { get; private set; }

        public string SemMascara { get; private set; }

        public string ComMascara
        {
            get
            {
                if (CPF.Valido) return CPF.ComMascara;
                if (CNPJ.Valido) return CNPJ.ComMascara;
                return string.Empty;
            }
        }

        public bool Valido
        {
            get
            {
                return CPF.Valido || CNPJ.Valido;
            }
        }

        private CPF_CNPJ(string valor)
        {
            if (valor != null)
                SemMascara = Regex.Replace(valor, "[^\\d]+", string.Empty, RegexOptions.Compiled);

            this.CNPJ = CNPJ.Parse(SemMascara);
            this.CPF = CPF.Parse(SemMascara);
        }

        public static CPF_CNPJ Parse(string documento)
        {
            return new CPF_CNPJ(documento);
        }

        public static bool TryParse(string documento, out CPF_CNPJ obj)
        {
            obj = new CPF_CNPJ(documento);
            return obj.Valido;
        }
    }
}
