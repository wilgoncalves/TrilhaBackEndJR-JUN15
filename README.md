# Trilha Inicial BackEnd Jr

## **Descrição:** 

Projeto de criação de API para gerenciamento de tarefas através de registro e autenticação de usuário. Os endpoints compõem operações de CRUD (criar, ler, atualizar e deletar).

- Para o projeto, intitulado "Gerenciador de Tarefas", foi utilizado a versão do .NET 6.0.

- Linguagem utilizada: C#.

- Pacotes necessários para a execução do projeto: 
Microsoft.AspNetCore.Authentication Version = 2.2.0
Microsoft.EntityFrameworkCore.Design Version = 5.0.10 
Microsoft.EntityFrameworkCore.Sqlite Version = 5.0.10
Microsoft.AspNetCore.Authentication.JwtBearer Version = 5.0.10

- Utilizou-se JWT Bearer para configurar o token necessário para validação de usuários.

- Banco de dados utilizado: SQLite.

- Criação do TokenService.cs para gerar token de acesso. Para acessar as funcionalidades, se faz necessário o uso do token disponibilizado através da autenticação de usuário.

## **Endpoints de Usuário:**

**POST** para inserir nome de usuário e senha.

![registro-de-usuario](https://github.com/user-attachments/assets/4f3d1990-2cfa-4abe-91cf-2ad143b69961)

**POST** para autenticação de um usuário e criação de token para acesso autorizado.

![autenticação](https://github.com/user-attachments/assets/ed65f8db-4d0d-4a79-a125-45298b54601f)

## Validando autorização através do token fornecido na autenticação de usuário.

![autorizaçaõ](https://github.com/user-attachments/assets/dcbec8e8-c2a7-4e68-9080-990b6b9687a5)

## **Endpoints de Tarefas:**

**GET** para visualizar tarefas do gerenciador. 

**GET** by ID permite visualização de tarefas através do id de usuário.

**POST** para inserção de novas tarefas.

![post tarefas](https://github.com/user-attachments/assets/ae820416-40b8-4c29-9fd0-c7c228873d2b)

**PUT** by ID para modificar/atualizar tarefa através do id.

![put tarefas](https://github.com/user-attachments/assets/ef56e6e3-f5b5-4dcd-86ac-c58d968b8963)

**DELETE** para excluir tarefa do gerenciador.








