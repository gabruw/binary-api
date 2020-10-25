# Binary API

## Objetivo
API em ASP .NET Core 3.1 que tem como intuito manipular dados binários.

## Especificações
ASP .NET Core 3.1
MySQL 8

## Premissa
Está aplicação NÂO possuí o intuito de simplificar a resolução do problema ao máximo, e sim exemplificar implementações diversas
presentes no dia-a-dia do desenvolvedor como implementação de Design Patters, elaboração de testes, funcionalidades genéricas, etc...
Algumas implementações fora do escopo proposto foram adicionadas com o intuito de expandir a usabilidade.

## Básico
Para funcionalidade básica, envie uma requisição POST com o JSON no body (como no exemplo) para o método Left (v1/diff/left)
e outra para o método Right (v1/diff/right).

#### Exemplo
```
{
  value: "01010100 01100101 01110011 01110100 01100101"
}
```
Após envie uma requisção GET para o método StoreResult (v1/diff).

## Documentação das rotas

| Tipo    | Rota           | Método         | Descrição                                                                                        |
|---------|----------------|----------------|--------------------------------------------------------------------------------------------------|
| GET     | v1/diff        | StoreResult    | Recupera o ultimo valor carregado no método "Left" e "Right" e retorna a comparação entre ambos. |
| GET     | v1/diff/db     | DbResult       | Recupera os valores da base de dados e retorna a comparação entre ambos.                         |
| POST    | v1/diff/left   | Left           | Salva o valor na base de dados e o adiciona como ultimo valor a ser recuperado.                  |
| POST    | v1/diff/right  | Right          | Salva o valor na base de dados e o adiciona como ultimo valor a ser recuperado.                  |
| DELETE  | v1/diff/left   | DbRemoveLeft   | Remove o valor na base de dados.                                                                 |
| DELETE  | v1/diff/right  | DbRemoveRight  | Remove o valor na base de dados.                                                                 |
