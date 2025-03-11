# Projeto Atualização de Endereço em .NET com MySQL

Este projeto demonstra como atualizar um endereço utilizando .NET Core MVC, Entity Framework Core e MySQL como banco de dados relacional.

## Pré-requisitos

* .NET SDK (versão 6.0 ou superior)
* Visual Studio ou outro editor de código compatível com .NET
* MySQL Server instalado e configurado
* MySQL Workbench ou outra ferramenta de gerenciamento MySQL (opcional)

## Passo a Passo para Rodar o Projeto

1.  **Clone o repositório:**

    ```bash
    git clone git@github.com:everlansouza/ProjetoEdicaoEndereco.git
    cd ProjetoEdicaoEndereco
    ```

2.  **Restaure os pacotes NuGet:**

    Abra o projeto no Visual Studio ou execute o seguinte comando na raiz do projeto:

    ```bash
    dotnet restore
    ```

3.  **Configure o banco de dados MySQL:**

    * Crie um banco de dados no MySQL Server.
    * Atualize a string de conexão no arquivo `appsettings.json` com os detalhes do seu banco de dados MySQL.

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=<SEU_SERVIDOR>;Port=<SUA_PORTA>;Database=<NOME_DO_BANCO>;Uid=<SEU_USUARIO>;Pwd=<SUA_SENHA>;"
    }
    ```

    * Certifique-se de instalar o pacote NuGet `Pomelo.EntityFrameworkCore.MySql` para usar o MySQL com Entity Framework Core.

4.  **Execute as migrações do Entity Framework Core:**

    * **Importante:** Este projeto utiliza migrações do Entity Framework Core para criar e atualizar o esquema do banco de dados.
    * Abra o console do gerenciador de pacotes no Visual Studio ou execute os seguintes comandos na raiz do projeto:

    ```bash
    dotnet ef database update
    ```

    * Isso criará as tabelas do banco de dados MySQL com base nas entidades do seu projeto.
    * Caso tenha problemas com as migrations verifique a versão do pacote Pomelo.EntityFrameworkCore.MySql e se está compatível com a versão do seu .Net

5.  **Geração de dados automáticas (opcional):**

    * Para facilitar o teste, este projeto inclui a geração automática de dados para as tabelas do banco de dados.
    * Os dados serão gerados automaticamente durante a inicialização do aplicativo.
    * Se você precisar limpar o banco de dados e gerar novos dados, basta excluir o banco de dados e executar as migrações novamente.

6.  **Execute o projeto:**

    * No Visual Studio, pressione F5 ou execute o seguinte comando na raiz do projeto:

    ```bash
    dotnet run
    ```

    * O projeto será executado e um navegador será aberto com a aplicação.

7.  **Utilize a aplicação:**

    * Navegue até a página de atualização de endereço.
    * Preencha os campos com os dados do endereço.
    * Clique no botão "Salvar" para atualizar o endereço.

## Configuração do Banco de Dados MySQL

* Certifique-se de que o banco de dados MySQL tenha as tabelas necessárias para armazenar os dados do endereço.
* As tabelas devem ter as colunas correspondentes às propriedades das entidades do seu projeto.

## Configuração do Entity Framework Core

* Verifique se as entidades do seu projeto estão configuradas corretamente com as anotações de dados ou com a API Fluent.
* Certifique-se de que o contexto do banco de dados está configurado corretamente com a string de conexão e as entidades.
* Verifique se as migrações foram geradas e aplicadas corretamente.

## Observações

* Este README fornece um passo a passo genérico. Adapte-o às suas necessidades específicas.
* Certifique-se de que todas as dependências estejam instaladas corretamente.
* Verifique se as configurações do banco de dados MySQL e do Entity Framework Core estão corretas.
* Em caso de erros, consulte os logs do projeto e do banco de dados para obter mais informações.
