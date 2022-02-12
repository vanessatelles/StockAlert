# C# Challenge

O objetivo do sistema � avisar, via e-mail, caso a cota��o de um ativo da B3 caia mais do que certo n�vel, ou suba acima de outro.
A decis�o de compra e venda � definida pela compara��o entre os valores de refer�ncia e o valor obtido em tempo real pela API. 

Essa decis�o � ent�o repassada em formato de token para o m�todo respons�vel pelo envio da mensagem, o qual ir� disparar um e-mail para o destinat�rio contendo uma das seguintes mensagens:

`` Sugestion: Sell {stock_symbol}.``

`` Sugestion: Buy {stock_symbol}.``

Quando nenhum dos dois casos s�o aplic�veis, o envio do e-mail n�o � realizado e a seguinte mensagem � mostrada no console:

``No action needed.`` 

O sistema realiza esse monitoramento do ativo a cada **2 minutos**.


## Execu��o do programa
### Argumentos necess�rios

Aplica��o de console, deve ser chamado via linha de comando com 3 seguintes par�metros:

1- O ativo a ser monitorado;

2- O pre�o de refer�ncia para venda;

3- O pre�o de refer�ncia para compra;

#### Exemplo de chamada

`` StockAlert.exe PETR4 22.67 22.59``


## API de cota��o

### TwelveData

A empresa TwelveData disponibiliza uma API para dados do mercado financeiro. Uma vez feito o cadastro � disponibilizada uma chave a qual possibilita realizar 800 chamadas por dia. Foi utilizado o endpoint referente a ***Real-time Price*** o qual retorna o valor atual do ativo no momento da consulta.

A requisi��o HTTP � feita da seguinte forma:

```
https://api.twelvedata.com/price?symbol=stock_symbol&apikey=your_api_key
``` 

E retorna um JSON com a seguinte estrutura:

```json
{
    "price": "200.99001"
}
```

## App.config

### Servidor SMTP

O programa l� de um arquivo de configura��o ``app.config`` as informa��es de configura��es de acesso ao servidor de SMTP que ir� enviar a mensagem e o endere�o de e-mail do destinat�rio dos alertas.
```c#
Hostname key: "server"
Port key: "port"
Username key: "username"
Sender e-mail key: "sender"
Receiver e-mail key: "receiver"
Password key: "password"
```

### API key

Para utilizar a API de cota��o � necess�rio utilizar uma chave, a mesma � resgatada do arquivo de configura��o ``app.config``.

```c#
TwelveData API key: "apiKey"
```

## Erros

### Valores de Refer�ncia

Quando algum dos tr�s argumentos n�o s�o passado o programa � encerrado e � mostrada a seguinte mensagem:

``Fail: Missing argument.`` 

Se � passado algum argumento a mais o programa � encerrado e � mostrada a seguinte mensagem:

``Fail: Too many argument.`` 

### Servidor SMTP 

Quando o sistema n�o consegue realizar a conex�o com o servidor SMTP o programa � encerrado e na tela � mostrado um log do erro.

### API de cota��o

Quando o sistema n�o consegue fazer a aquisi��o de dados da API o valor do ativo � dado como nulo, o programa � encerrado e a seguinte mensagem � exibida:

`` Fail: Error with StockAPI.``
