using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPF_CNPJ.Tests
{
    [TestClass]
    public class CPFTests
    {
        [DataTestMethod]
        [DataRow("711.152.428-49")]
        [DataRow("79940727208")]
        public void CPF_Parse_ResultadoValido(string cpf) => Assert.IsTrue(CPF.Parse(cpf).Valido);

        [DataTestMethod]
        [DataRow("711.152.428-40")]
        [DataRow("79940727200")]
        public void CPF_Parse_ResultadoInvalido(string cpf) => Assert.IsFalse(CPF.Parse(cpf).Valido);

        [DataTestMethod]
        [DataRow("711.152.428-49", "71115242849")]
        [DataRow("79940727208", "79940727208")]
        public void CPF_SemMascara_ValorValido_StringCorrespondeComOriginal(string conteudo, string semMascara) => Assert.AreEqual(CPF.Parse(conteudo).SemMascara, semMascara);

        [DataTestMethod]
        [DataRow("711.152.428-40", "71115242840")]
        [DataRow("79940727200", "79940727200")]
        public void CPF_SemMascara_ValorInvalido_StringCorrespondeComOriginal(string conteudo, string semMascara) => Assert.AreEqual(CPF.Parse(conteudo).SemMascara, semMascara);

        [DataTestMethod]
        [DataRow("711.152.428-49", "711.152.428-49")]
        [DataRow("79940727208", "799.407.272-08")]
        public void CPF_ComMascara_ValorValido_StringCorrespondeComOriginal(string conteudo, string comMascara) => Assert.AreEqual(CPF.Parse(conteudo).ComMascara, comMascara);

        [DataTestMethod]
        [DataRow("711.152.428-40")]
        [DataRow("79940727200")]
        public void CPF_ComMascara_ValorInvalido_RetornaBranco(string conteudo) => Assert.IsTrue(string.IsNullOrWhiteSpace(CPF.Parse(conteudo).ComMascara));
    }
}
