# Servi�o de Sugest�o de playlist baseado na temperatura da cidade

## Padr�o de API
A API criada � uma Cloud Function em .Net Core, resolve o problema apresentado e tamb�m tem �timo desempenho/custo benef�cio para o tamanho do projeto
Inje��o de Depend�ncia e frameworks do Google Functions e Google Datastore, tamb�m o framework Newtonsoft.Json para tratamento dos dados recebidos na API

## Arquitetura
Foi utilizado uma arquitetura simples de 4 camadas
* API - (endpoint)
* Domain - Objetos de neg�cios (DTOs - Objetos de Transfer�ncia de Dados, Enums, etc)
* Service - Camada de L�gica/Regras de neg�cios
* Infra - Comunica��o com banco e API's externas

## Infraestrutura
Foi utilizado conex�o com banco de dados n�o relacional do Google Datastore para trazer a playlist
Comunica��o com API do hgbrasil/weather para trazer dados de previs�o do tempo por cidade
