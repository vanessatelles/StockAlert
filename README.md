# C# Challenge

O objetivo do sistema é avisar, via e-mail, caso a cotação de um ativo da B3 caia mais do que certo nível, ou suba acima de outro.
A decisão de compra e venda é definida pela comparação entre os valores de referência e o valor obtido em tempo real pela API. 

Essa decisão é então repassada em formato de token para o método responsável pelo envio da mensagem, o qual irá disparar um e-mail para o destinatário contendo uma das seguintes mensagens:

`` Sugestion: Sell {stock_symbol}.``

`` Sugestion: Buy {stock_symbol}.``

Quando nenhum dos dois casos são aplicáveis, o envio do e-mail não é realizado e a seguinte mensagem é mostrada no console:

``No action needed.`` 

O sistema realiza esse monitoramento do ativo a cada **2 minutos**.


## Execução do programa
### Argumentos necessários

Aplicação de console, deve ser chamado via linha de comando com 3 seguintes parâmetros:

1- O ativo a ser monitorado;

2- O preço de referência para venda;

3- O preço de referência para compra;

#### Exemplo de chamada

`` StockAlert.exe PETR4 22.67 22.59``


## API de cotação

### TwelveData

A empresa TwelveData disponibiliza uma API para dados do mercado financeiro. Uma vez feito o cadastro é disponibilizada uma chave a qual possibilita realizar 800 chamadas por dia. Foi utilizado o endpoint referente a ***Real-time Price*** o qual retorna o valor atual do ativo no momento da consulta.

A requisição HTTP é feita da seguinte forma:

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

O programa lê de um arquivo de configuração ``app.config`` as informações de configurações de acesso ao servidor de SMTP que irá enviar a mensagem e o endereço de e-mail do destinatário dos alertas.
```c#
Hostname key: "server"
Port key: "port"
Username key: "username"
Sender e-mail key: "sender"
Receiver e-mail key: "receiver"
Password key: "password"
```

### API key

Para utilizar a API de cotação é necessário utilizar uma chave, a mesma é resgatada do arquivo de configuração ``app.config``.

```c#
TwelveData API key: "apiKey"
```

## Erros

### Valores de Referência

Quando algum dos três argumentos não são passado o programa é encerrado e é mostrada a seguinte mensagem:

``Fail: Missing argument.`` 

Se é passado algum argumento a mais o programa é encerrado e é mostrada a seguinte mensagem:

``Fail: Too many argument.`` 

### Servidor SMTP 

Quando o sistema não consegue realizar a conexão com o servidor SMTP o programa é encerrado e na tela é mostrado um log do erro.

### API de cotação

Quando o sistema não consegue fazer a aquisição de dados da API o valor do ativo é dado como nulo, o programa é encerrado e a seguinte mensagem é exibida:

`` Fail: Error with StockAPI.``
