# Digital Wallet API

## Visão Geral
A Digital Wallet API é um serviço RESTful projetado para gerenciar carteiras digitais e transações financeiras. Ele fornece funcionalidades para autenticação de usuário, gerenciamento de carteira e processamento de transações. Esta API é construída em C# com .NET Core e utiliza PostgreSQL como banco de dados relacional.

## Características
- User Authentication with JWT
- Create and manage user accounts
- Check wallet balance
- Add funds to wallets
- Transfer funds between users
- List transfers with optional date filtering

## Tecnologias Empregadas
- C# com .NET Core
- PostgreSQL para banco de dados
- Entity Framework Core para acesso de dados
- Swagger para dpcumentação dos endpoints das API's e teste.

## Informações iniciais

### Pré requisitos
- .NET SDK (última versão)
- PostgreSQL
- IDE or text editor (ex., utilizado o Visual Studio Code)

### Instalação
1. Clone o repositório:
   ```
   git clone https://github.com/yourusername/DigitalWalletAPI.git
   cd DigitalWalletAPI
   ```

2. Atualizar o `appsettings.json` com sua PostgreSQL connection string.
   ```
    {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=DigitalWalletDB;Username=your_username;Password=your_password"
  },
  "Jwt": {
    "Key": "your_secret_key",
    "Issuer": "your_issuer",
    "Audience": "your_audience",
    "DurationInMinutes": 60
  },
  "SeedData": {
    "Enable": true
  }
}
   ```

3. Executar o migrations para o banco de dados:
   ```
   dotnet ef database update
   ```

4. Propagar o banco de dados com dados iniciais:
   ```
   dotnet run
   ```

### Executar a aplicação
Para executar a aplicação, usar o comando de linha:
```
dotnet run
```

### Acesso às API's
Depois que o aplicativo estiver em execução, você poderá acessar a API em `http://localhost:5000`. A IU do Swagger pode ser acessada em `http://localhost:5000/swagger` para testar os endpoints.

## API Endpoints
- **Authentication**
  - POST `/api/auth/login` - Login and receive a JWT token.

- **User Management**
  - POST `/api/users` - Cria novos usuários.
  - GET `/api/users/{id}` - Recupera os dados dos usuários.

- **Wallet Management**
  - GET `/api/wallets/{userId}/balance` - Verifica o balanço da carteira.
  - POST `/api/wallets/{userId}/add` - Adiciona fundos a carteira.

- **Transfer Management**
  - POST `/api/transfers` - Cria uma transferência entre usuários.
  - GET `/api/transfers/{userId}` - Listar transferências para um usuário com filtragem de data opcional.

## Contribuições
Contribuições são bem-vindas! Envie uma solicitação pull ou abra um problema para sugestões ou melhorias.

## License
Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para obter detalhes.