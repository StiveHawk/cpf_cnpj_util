# Utilidades de CPF e CNPJ

## CPF

[Visualize a classe](https://github.com/StiveHawk/cpf_cnpj_util/blob/master/CPF_CNPJ/CPF.cs)

Usando Parse:
```
var cpf = CPF.Parse("00000000000")
var valido = cpf.Valido;
var semMascara = cpf.SemMascara;
var comMascara = cpf.ComMascara;
```

Usando TryParse:
```
CPF cpf = null;
if(CPF.TryParse("00000000000", out cpf))
	// Código com CPF válido
```

## CNPJ

[Visualize a classe](https://github.com/StiveHawk/cpf_cnpj_util/blob/master/CPF_CNPJ/CNPJ.cs)

Usando Parse:
```
var cnpj = CNPJ.Parse("00000000000000")
var valido = cnpj.Valido;
var semMascara = cnpj.SemMascara;
var comMascara = cnpj.ComMascara;
```

Usando TryParse:
```
CNPJ cnpj = null;
if(CNPJ.TryParse("00000000000000", out cnpj))
	// Código com CNPJ válido
```

## CPF + CNPJ
Para situações em que não importa se o documento for CPF ou CNPJ, desde seja válido. É necessário incluir as classes CPF e CNPJ no projeto.

[Visualize a classe](https://github.com/StiveHawk/cpf_cnpj_util/blob/master/CPF_CNPJ/CPF_CNPJ.cs)

Usando Parse:
```
var documento = CPF_CNPJ.Parse("00000000000")
var valido = documento.Valido;
var semMascara = documento.SemMascara;
var comMascara = documento.ComMascara;
```

Usando TryParse:
```
CPF_CNPJ documento = null;
if(CPF_CNPJ.TryParse("00000000000", out documento))
	// Código com documento válido
```