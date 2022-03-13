# CRUD
CRUD para cadastrar pedidos de pagamento


Essa é uma aplicação de desenvolvimento de um CRUD para cadastrar pedidos de pagamento para produtos.


pacotes instalados:

Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation versão:5.0.10
Microsoft.EntityFrameworkCore versão:5.0.2
Microsoft.EntityFrameworkCore.Design versão:5.0.2
Microsoft.EntityFrameworkCore.SqlServer versão:5.0.2
Microsoft.EntityFrameworkCore.Tools versão:5.0.2

na linha 10 do arquivo appsettings.Development.json alterar id e password.

O migration foi criado utilizando o comando abaixo:
Add-Migration CriandoTabelaPedidos -Context BancoContext

para criar o banco de dados foi utilizado o comando abaixo:
Update-Database -Context BancoContext
