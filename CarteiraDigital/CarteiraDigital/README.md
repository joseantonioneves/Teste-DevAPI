# Carteira Digital API

## Descrição
Este projeto é uma API para gerenciamento de uma carteira digital, implementada em C# utilizando o padrão de Design Driven Development (DDD). A API permite a criação, atualização e exclusão de entidades relacionadas à carteira digital. Caso houver interesse de uma versão em Python sugiro a utilização do framework ``FastApi``.

## Estrutura do Projeto
A estrutura do projeto é organizada em camadas, seguindo os princípios do DDD:

- **Application**: Contém serviços que lidam com a lógica de aplicação.
- **Domain**: Contém entidades, interfaces e objetos de valor que representam o núcleo do domínio.
- **Infrastructure**: Contém a implementação de repositórios e o contexto de dados.
- **API**: Contém controladores que expõem os endpoints da API.

## Configuração do Ambiente
1. Certifique-se de ter o .NET SDK instalado em sua máquina.
2. Clone o repositório:
   ```
   git clone <URL_DO_REPOSITORIO>
   ```
3. Navegue até o diretório do projeto:
   ```
   cd CarteiraDigital
   ```
4. Restaure as dependências:
   ```
   dotnet restore
   ```

## Execução
Para executar a API, utilize o seguinte comando:
```
dotnet run --project src/API/CarteiraDigital.API.csproj
```

## Testes
Os testes podem ser executados utilizando o comando:
```
dotnet test
```

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença
Este projeto está licenciado sob a MIT License. Veja o arquivo LICENSE para mais detalhes.