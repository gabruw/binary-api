# Binary API

## Objetivo
API em ASP .NET Core 3.1 que tem como intuito manipular dados binários.

## Especificações
ASP .NET Core 3.1
MySQL 8

## Premissa
Está aplicação NÃO possuí o intuito de simplificar a resolução do problema ao máximo, e sim exemplificar implementações diversas
presentes no dia-a-dia do desenvolvedor como implementação de Design Patters, elaboração de testes, funcionalidades genéricas, etc...
Algumas implementações fora do escopo proposto foram adicionadas com o intuito de expandir a usabilidade.

### Executando a Aplicação
1. Na pasta raiz do projeto, busque pelo caminho "~/Api/Api/bin/Debug/netcoreapp3.1"
2. No caminho, execute o arquivo "Api.exe"

### Executando os Testes
#### Visual Studio 2019
1. Pressione "Ctrl + E, T" ou abra o "Gerenciador de Testes"
2. Use o menu para executar os testes

#### Comando
1. Abra uma janela do terminal na pasta raiz do projeto
2. Execute o comando "dotnet test"
3. Aguarde o resultado dos testes

## Básico
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
