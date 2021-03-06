# Binary API

## Objetivo
API em ASP .NET Core 3.1 que tem como intuito manipular dados binários.

## Especificações Técnicas
- [X] MySQL 8
- [X] ASP .NET Core 3.1
- [X] Entity Framework Core

## Testes efetuados
- [X] Testes Unitários
- [X] Testes de Integração
- [X] Testes de Mutação

## Premissa
Está aplicação NÃO possuí o intuito de simplificar a resolução do problema ao máximo, e sim exemplificar implementações diversas
presentes no dia-a-dia do desenvolvedor como implementação de Design Patters, elaboração de testes, funcionalidades genéricas, etc...
Algumas implementações fora do escopo proposto foram adicionadas com o intuito de expandir a usabilidade.

### Executando os Testes

#### Testes Unitários e de Integração

##### Visual Studio 2019
1. Pressione "Ctrl + E, T" ou abra o "Gerenciador de Testes"
2. Use o menu para executar os testes

##### Comando
1. Abra uma janela do terminal na pasta raiz do projeto
2. Execute o comando "dotnet test"
3. Aguarde o resultado dos testes

#### Testes de Mutação
Para executar este tipo de teste, é necessário possuir o "Stryker Mutator" instalado globalmente. Maiores informações podem ser
obtidas através do link: https://stryker-mutator.io/

##### Padrão
1. Abra uma janela do terminal na pasta raiz do projeto e busque pelo caminho do projeto relativo ao tipo de teste
que desejar
2. Execute o comando "dotnet stryker -p {caminho}", onde o "{caminho}" é relativo aos projeto envolvidos no teste
3. Aguarde o resultado dos testes
4. Acesse a pasta "StrykerOutput" e selecione a pasta do ultimo "report" efetuado
5. Execute o arquivo ".html"

##### Stryker Config
1. Abra uma janela do terminal na pasta raiz do projeto e busque pelo caminho do projeto relativo ao tipo de teste
que desejar
2. Execute o comando "dotnet stryker"
3. Aguarde o resultado dos testes
4. Acesse a pasta "StrykerOutput" e selecione a pasta do ultimo "report" efetuado
5. Execute o arquivo ".html"

## Básico

### Migrations

#### Visual Studio 2019
1. No menu "Exibir", selecione o submenu "Outras Janelas" e clique em "Console do Gerenciador de Pacotes"
2. No console, selecione o "Projeto padrão" como "Repository"
3. Digite e execute a seguinte linha "Add-Migration {nome}", onde o "{nome}" é relativo ao nome da migração
que deve ser definida pelo executor da aplicação (Exemplo VS2019-A)
4. Após a finalização do corregamento, execute o comando "Update-Database {nome}", onde o "{nome}" é relativo ao nome da migração
que foi gerada no passo anterior (Exemplo VS2019-B)

##### Exemplo VS2019-A
```
Add-Migration FirstMigration
```

##### Exemplo VS2019-B
```
Update-Database FirstMigration
```

#### Comando
1. Na pasta raiz do projeto, busque pelo caminho "~/Repository"
2. Execute uma instância do Powershell apartir desta pasta
3. Digite e execute a seguinte linha "dotnet ef migrations add {nome}", onde o "{nome}" é relativo ao nome da migração
que deve ser definida pelo executor da aplicação (Exemplo VS2019-C)
4. Após a finalização do corregamento, execute o comando "Update-Database {nome}", onde o "{nome}" é relativo ao nome da migração
que foi gerada no passo anterior (Exemplo VS2019-D)

##### Exemplo VS2019-C
```
dotnet ef migrations add FirstMigration
```

##### Exemplo VS2019-D
```
dotnet ef database update FirstMigration
```

### Executando a Aplicação
1. Na pasta raiz do projeto, busque pelo caminho "~/Api/bin/Debug/netcoreapp3.1"
2. No caminho, execute o arquivo "Api.exe"

### Usabilidade

Para funcionalidade básica, envie uma requisição POST com o JSON no body (como no exemplo) para o método Left (v1/diff/left)
e outra para o método Right (v1/diff/right).

#### Exemplo
```
{
  value: "01010100 01100101 01110011 01110100 01100101"
}
```
Após envie uma requisção GET para o método StorageResult (v1/diff).

## Documentação das rotas

| Tipo    | Rota             | Método         | Parâmetro                    | Descrição                                                                                        |
|---------|------------------|----------------|------------------------------|--------------------------------------------------------------------------------------------------|
| GET     | v1/diff          | StorageResult  | N/A                          | Recupera o ultimo valor carregado no método "Left" e "Right" e retorna a comparação entre ambos. |
| GET     | v1/diff/db       | DbResult       | leftId: Long - rightId: Long | Recupera os valores da base de dados e retorna a comparação entre ambos.                         |
| GET     | v1/diff/db/left  | DbGetAllLeft   | N/A 						 | Recupera todos os valores "Left" da base de dados.                                               |
| GET     | v1/diff/db/right | DbGetAllRight  | N/A 						 | Recupera todos os valores "Right" da base de dados.   						                    |
| POST    | v1/diff/left     | Left           | value: String                | Salva o valor na base de dados e o adiciona como ultimo valor a ser recuperado.                  |
| POST    | v1/diff/right    | Right          | value: String                | Salva o valor na base de dados e o adiciona como ultimo valor a ser recuperado.                  |
| DELETE  | v1/diff/db/left  | DbRemoveLeft   | id: Long                     | Remove o valor na base de dados.                                                                 |
| DELETE  | v1/diff/db/right | DbRemoveRight  | id: Long                     | Remove o valor na base de dados.                                                                 |
