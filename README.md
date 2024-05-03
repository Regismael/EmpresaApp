# EmpresaApp

O **EmpresaApp** é um aplicativo para controle de empresas e seus funcionários, fornecendo operações CRUD (Create, Read, Update, Delete).

## Requisitos

Certifique-se de ter instalado o EntityFramework para interação com o banco de dados.

## Configuração do Banco de Dados

Antes de executar o aplicativo, crie um banco de dados com o nome **BDEmpresaApp**. 

Em seguida, obtenha a connection string e insira-a na classe `DataContext`.

```csharp
public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseSqlServer("sua_connection_string_aqui");
        
    }
}