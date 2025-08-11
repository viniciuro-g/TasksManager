# API de Gerenciamento de Tarefas (TasksManager API)

## 📖 Sobre o Projeto

API RESTful para gerenciamento de tarefas (To-Do List), desenvolvida como um projeto de portfólio para demonstrar habilidades em desenvolvimento backend com o ecossistema .NET. A aplicação segue os princípios da Clean Architecture para garantir um código organizado, testável e de fácil manutenção.

---

## 📸 Demonstração (Swagger UI)

![Screenshot da Interface do Swagger mostrando os endpoints da API de Tarefas](https://github.com/user-attachments/assets/67e0a2a4-454b-4535-af49-5936dabbe514)

---

## ✨ Funcionalidades Principais

- **CRUD Completo** para Tarefas (Criar, Ler, Atualizar, Deletar).
- Estrutura de projeto profissional seguindo os padrões da **Clean Architecture**.
- Persistência de dados em um banco de dados **SQLServer**.
- Validações de regras de negócio na camada de serviço.

---

## 🛠️ Tecnologias Utilizadas

- **Backend:**
  - [.NET 8.0](https://dotnet.microsoft.com/pt-br/download)
  - [ASP.NET Core 8.0](https://dotnet.microsoft.com/en-us/apps/aspnet)
  - [Entity Framework Core 8.0](https://docs.microsoft.com/pt-br/ef/core/)
- **Banco de Dados:**
  - [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- **Arquitetura e Padrões de Design:**
  - Clean Architecture
  - Padrão Repository
  - Injeção de Dependência (DI)

---

## 🚀 Como Executar o Projeto Localmente

Siga os passos abaixo para rodar a aplicação no seu ambiente de desenvolvimento.

**Pré-requisitos:**
- [.NET 8.0 SDK](https://dotnet.microsoft.com/pt-br/download)
- Visual Studio 2022 ou VS Code (com extensão C#)

**Passos:**

1. **Clone o repositório:**
   ```sh
   git clone https://github.com/viniciuro-g/TasksManager.git
   ```

2. **Restaure as dependências:**
   ```sh
   dotnet restore
   ```

3. **Execute a Aplicação:**
   ```sh
   dotnet run --project Tarefas.Api
   ```
   Isso iniciará a API e criará o arquivo de banco de dados `tarefas.db` na pasta `Tarefas.Api` se ele não existir.

4. **Acesse a Documentação da API:**
   A interface do Swagger UI abrirá automaticamente no seu navegador. Caso contrário, acesse:
   - `https://localhost:7xxx/swagger` (substitua `7xxx` pela porta exibida no terminal)

---

## 📋 Documentação da API (Endpoints)

A API expõe os seguintes endpoints para manipulação de tarefas:

| Ação | Verbo HTTP | URL |
|---|---|---|
| Listar Todas as Tarefas | `GET` | `/api/tarefas` |
| Buscar Tarefa por ID | `GET` | `/api/tarefas/{id}` |
| Criar Nova Tarefa | `POST` | `/api/tarefas` |
| Atualizar Tarefa | `PATCH` | `/api/tarefas/{id}` |
| Deletar Tarefa | `DELETE`| `/api/tarefas/{id}` |
| Concluir Tarefa | `DELETE`| `/api/tarefas/{id}/concluir` |

---

## 👨‍💻 Autor

Projeto desenvolvido por **[Vinícius Rodrigues]**.

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/viniciuro-g)
[![LinkedIn](https://img.shields.io/badge/linkedin-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](www.linkedin.com/in/vinícius-rodrigues-a0a3b1271)

👋 Entre em contato!

---
