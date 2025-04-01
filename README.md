# Livraria API

Este é um projeto de API para gerenciar uma livraria, um estoque ou sua estantes com suas coleções de livros, desenvolvido com .NET 8.

## Funcionalidades

- Adicionar um novo livro
- Buscar todos os livros
- Buscar um livro por ID
- Atualizar um livro existente
- Deletar um livro

## Estrutura do Projeto

- **Models/Livros.cs**: Define o modelo `Livro` com propriedades como `Id`, `Titulo`, `Autor`, `AnoPublicacao`, `Genero` e `Preco`.
- **Controllers/LivrosController.cs**: Controlador que gerencia as operações CRUD para os livros.
- **Data/ApiDbContext.cs**: Contexto do banco de dados configurado com Entity Framework Core.
- **Program.cs**: Configuração e inicialização do aplicativo.

## Instalação

1. Clone o repositório:
   git clone https://github.com/seu-usuario/livraria-api.git

2. Navegue até o diretório do projeto:
   cd livraria-api

3. Restaure as dependências:
   dotnet restore

4. Configure a string de conexão no arquivo `appsettings.json`:
   { "ConnectionStrings": { "DefaultConnection": "SuaStringDeConexaoAqui" } }

5. Execute as migrações para criar o banco de dados:
   dotnet ef database update

6. Inicie o aplicativo:
   dotnet run


## Uso

### Adicionar um Livro

POST /api/livros/AdicionarLivro

### Buscar Todos os Livros

GET /api/livros/MostrarTodosOsLivros

### Buscar um Livro por ID

GET /api/livros/BuscaLivro/{id}

### Atualizar um Livro

PUT /api/livros/AtualizarLivro/{id}

### Deletar um Livro

DELETE /api/livros/DeletarLivro/{id}

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a Licença MIT.

