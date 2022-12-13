# Teste prático Icatú Seguros

Teste proposto pela Tech Recruiter Laíza para a vaga de Desenvolvedor na Icatu Seguros, para a evolução de uma Web API construída no padrão CQRS implementando uma nova funcionalidade de Registro de Compra com as atividades propostas no documento `Teste Pratico Sisprev.docx`.

## Conexão do Banco de Dados
Para instalarmos o banco de dados no nosso servidor local, precisamos alterar a string de conexão da API,
que está no arquivo `appsettings.json` na linha 3, localizado na pasta `SistemaCompras-v3\SistemaCompra.API\appsettings.json`, trocando o nome do servidor no campo (Server), salvando as alterações e no arquivo `SistemaCompraContext.cs` na linha 38 localizado na pasta  `SistemaCompras-v3\SistemaCompra.Infra.Data\SistemaCompraContext.cs`

`appsettings.json`
![StringConexaoAppSettings](https://user-images.githubusercontent.com/73179530/207450594-d5586ede-572c-4f0c-8a4c-4c486b653437.png)

`SistemaCompraContext.cs`
![StringConexaoSistemaCompraContext](https://user-images.githubusercontent.com/73179530/207450749-4a6c0b76-3aec-4ea0-8847-c9c2edba9202.png)


## Instalação

As migrações foram criadas com o comando no Console de Gerenciador de Pacotes do NuGet
```cmd
add-migration
```
Com a solução do projeto aberta, instale o banco de dados no servidor usando o comando update-database, no Console de Gerenciador de Pacotes do NuGet

```cmd
  update-database
```

Após a instalação poderemos ver que, consultando no banco de dados, também foi criado um Produto. Aplicando o seguinte comando no SQL SERVER Management Studio, poderemos listar todos os produtos.
```cmd
  USE SistemaCompraDb
    GO 
    SELECT TOP (1000) [Id]
      ,[Categoria]
      ,[Descricao]
      ,[Nome]
      ,[Preco]
      ,[Situacao]
    FROM [SistemaCompraDb].[dbo].[Produto]
```

Agora estamos prontos para rodar o projeto :).
    
## Ferramentas utilizadas

- .NET Core 3.1
- Swagger
- Entity Framework Core
- SQL SERVER 2019
- Microsoft SQL Server Management Studio 
- MediatR
- Visual Studio 2022

## Autor

- [@mateusrodsilva](https://www.github.com/mateusrodsilva)
