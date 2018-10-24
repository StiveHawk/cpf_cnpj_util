using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CPF_CNPJ
{
    public class CNPJ
    {
        public string SemMascara { get; private set; }

        public string ComMascara
        {
            get
            {
                if (Valido)
                {
                    var v1 = SemMascara.Substring(0, 2);
                    var v2 = SemMascara.Substring(2, 3);
                    var v3 = SemMascara.Substring(5, 3);
                    var v4 = SemMascara.Substring(8, 4);
                    var v5 = SemMascara.Substring(12);

                    return $"{v1}.{v2}.{v3}/{v4}-{v5}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        
        public bool Valido
        {
            get
            {
                if (string.IsNullOrEmpty(SemMascara))
                    return false;

                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                
                if (SemMascara.Length != 14)
                    return false;

                int resto;
                string digito;

                string tempCnpj = SemMascara.Substring(0, 12);
                int soma = 0;

                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                resto = (soma % 11);

                if (resto < 2) resto = 0;
                else resto = 11 - resto;

                digito = resto.ToString();

                tempCnpj = tempCnpj + digito;

                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);

                if (resto < 2) resto = 0;
                else resto = 11 - resto;

                digito = digito + resto.ToString();

                return SemMascara.EndsWith(digito);
            }
        }

        public CNPJ(string valor)
        {
            if (valor != null)
                valor = Regex.Replace(valor, "[^\\d]+", string.Empty, RegexOptions.Compiled);

            SemMascara = valor;
        }

        public static CNPJ Parse(string cnpj)
        {
            return new CNPJ(cnpj);
        }

        public static bool TryParse(string cnpj, out CNPJ obj)
        {
            obj = Parse(cnpj);
            return obj.Valido;
        }
    }
}
