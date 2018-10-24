using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPF_CNPJ.Tests
{
    [TestClass]
    public class CNPJTests
    {
        [DataTestMethod]
        [DataRow("54.440.765/0001-71")]
        [DataRow("24717367000199")]
        public void CNPJ_Parse_ResultadoValido(string cnpj) => Assert.IsTrue(CNPJ.Parse(cnpj).Valido);

        [DataTestMethod]
        [DataRow("54.440.765/0001-70")]
        [DataRow("24717367000190")]
        public void CNPJ_Parse_ResultadoInvalido(string cnpj) => Assert.IsFalse(CNPJ.Parse(cnpj).Valido);

        [DataTestMethod]
        [DataRow("54.440.765/0001-71", "54440765000171")]
        [DataRow("24717367000199", "24717367000199")]
        public void CNPJ_SemMascara_ValorValido_StringCorrespondeComOriginal(string conteudo, string semMascara) => Assert.AreEqual(CNPJ.Parse(conteudo).SemMascara, semMascara);

        [DataTestMethod]
        [DataRow("54.440.765/0001-70", "54440765000170")]
        [DataRow("24717367000190", "24717367000190")]
        public void CNPJ_SemMascara_ValorInvalido_StringCorrespondeComOriginal(string conteudo, string semMascara) => Assert.AreEqual(CNPJ.Parse(conteudo).SemMascara, semMascara);

        [DataTestMethod]
        [DataRow("54.440.765/0001-71", "54.440.765/0001-71")]
        [DataRow("24717367000199", "24.717.367/0001-99")]
        public void CNPJ_ComMascara_ValorValido_StringCorrespondeComOriginal(string conteudo, string comMascara) => Assert.AreEqual(CNPJ.Parse(conteudo).ComMascara, comMascara);

        [DataTestMethod]
        [DataRow("54.440.765/0001-70")]
        [DataRow("24717367000190")]
        public void CNPJ_ComMascara_ValorInvalido_RetornaBranco(string conteudo) => Assert.IsTrue(string.IsNullOrWhiteSpace(CNPJ.Parse(conteudo).ComMascara));
    }
}
