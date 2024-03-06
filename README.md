# ComprasPublicas

**Descrição:**

* Uma aplicação web CRUD (Criar, Ler, Atualizar, Excluir) criada com ASP.NET 6.0.
* Implementa os princípios de arquitetura Domain-Driven Design (DDD) para uma base de código limpa e fácil de manter.
* Utiliza Entity Framework Core para acesso a dados, migrações de banco de dados.

**Tecnologias:**

* ASP.NET Core 6.0
* Entity Framework Core
* C#

## Começando

**Pré-requisitos:**

* .NET 6.0 SDK ([https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download))
* Visual Studio 2022 ou Visual Studio Code
* Uma instância do SQL Server (LocalDB ou SQL Server completo)

**Configuração:**

1. Clone o repositório.
2. Atualize a string de conexão em `appsettings.json` (e potencialmente `appsettings.Development.json`) para apontar para o seu banco de dados SQL Server.
3. Abra a solução no IDE de sua preferência.

## Executando a Aplicação

1. **Migrações:**
    * Certifique-se de que seu banco de dados existe.
    * Se você não aplicou migrações anteriormente, execute o seguinte comando no Package Manager Console ou terminal (da raiz do projeto):
       ```bash
       dotnet ef database update -p Infra -s Api
       ```
2. **Executando a Aplicação:**
    * **Do Visual Studio:** Pressione F5 ou clique o botão "Iniciar".
    * **Da linha de comando:**
       ```bash
       dotnet run -p Api
       ```

## Estrutura do Projeto

* **Api**
    * Controllers para manipular os endpoints da API.
    * Modelos/DTOs para transferência de dados.
    * Serviços para lógica da aplicação (podem residir na camada Application)
* **Application**
    * Lógica de negócio principal.
    * Interfaces para repositórios e outras dependências.
* **Domain**
    * Entidades, objetos de valor, e lógica de domínio.
    * Agregados (se aplicável).
* **Infra**
    * Implementações de acesso a dados (repositórios).
    * Configurações do Entity Framework Core.

## Database Bundle (Pacote de Banco de Dados)

* Um *database bundle* foi incluído para cenários de migração offline.
* O *bundle* está localizado dentro do projeto `Infra`.
* Para regenerar o *bundle*:
  ```bash
  dotnet ef migrations bundle -s Api -p Infra --configuration Bundle
