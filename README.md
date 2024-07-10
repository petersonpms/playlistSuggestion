# Serviço de Sugestão de playlist baseado na temperatura da cidade

## Padrão de API
A API criada é uma Cloud Function em .Net Core, resolve o problema apresentado e também tem ótimo desempenho/custo benefício para o tamanho do projeto
Injeção de Dependência e frameworks do Google Functions e Google Datastore, também o framework Newtonsoft.Json para tratamento dos dados recebidos na API

## Arquitetura
Foi utilizado uma arquitetura simples de 4 camadas
* API - (endpoint)
* Domain - Objetos de negócios (DTOs - Objetos de Transferência de Dados, Enums, etc)
* Service - Camada de Lógica/Regras de negócios
* Infra - Comunicação com banco e API's externas

## Infraestrutura
Foi utilizado conexão com banco de dados não relacional do Google Datastore para trazer a playlist
Comunicação com API do hgbrasil/weather para trazer dados de previsão do tempo por cidade
