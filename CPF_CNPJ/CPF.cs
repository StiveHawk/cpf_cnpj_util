using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CPF_CNPJ
{
    public class CPF
    {
        public string SemMascara { get; private set; }

        public string ComMascara
        {
            get
            {
                if (Valido)
                {
                    var v1 = SemMascara.Substring(0, 3);
                    var v2 = SemMascara.Substring(3, 3);
                    var v3 = SemMascara.Substring(6, 3);
                    var v4 = SemMascara.Substring(9);

                    return $"{v1}.{v2}.{v3}-{v4}";
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

                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                
                if (SemMascara.Length != 11)
                    return false;

                string digito;
                int resto;

                string  tempCpf = SemMascara.Substring(0, 9);

                int soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;
                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return SemMascara.EndsWith(digito);
            }
        }

        public CPF(string valor)
        {
            if (valor != null)
                valor = Regex.Replace(valor, "[^\\d]+", string.Empty, RegexOptions.Compiled);

            SemMascara = valor;
        }

        public static CPF Parse(string cnpj)
        {
            return new CPF(cnpj);
        }

        public static bool TryParse(string cpf, out CPF obj)
        {
            obj = Parse(cpf);
            return obj.Valido;
        }
    }
}
