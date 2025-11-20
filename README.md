# Bernhoeft.GRT.Teste – Módulo de Avisos

Este módulo foi desenvolvido seguindo a arquitetura já existente no projeto, mantendo os princípios adotados pela equipe, incluindo **CQRS**, **MediatR** e separação clara entre **Commands**, **Queries**, **Handlers**, **Requests** e **Responses**.

## 🧩 Arquitetura e Padrões Utilizados

### ✔️ CQRS (Command Query Responsibility Segregation)

O projeto segue o padrão CQRS para separar operações de **leitura** (Queries) e **escrita** (Commands), trazendo maior organização, testabilidade e clareza na responsabilidade das classes.

### ✔️ MediatR

O fluxo de requisições foi estruturado utilizando o **Mediator Pattern**, permitindo que controladores façam apenas o envio da request, enquanto a lógica fica totalmente isolada nos handlers.

### ✔️ Continuidade do Padrão Existente

Todo o desenvolvimento respeitou o padrão arquitetural do projeto, incluindo naming conventions, estrutura de pastas, retorno usando `OperationResult<>` e requests com `SetIdProperty`.

---

## 📌 Endpoints Implementados (AvisosController)

A controller possui endpoints para gerenciar avisos:

* `GET /avisos` – Lista todos os avisos
* `GET /avisos/{id}` – Busca aviso pelo ID
* `POST /avisos` – Adiciona novo aviso
* `PUT /avisos/{id}` – Atualiza aviso existente
* `DELETE /avisos/{id}` – Inativa aviso

Todos os endpoints utilizam **MediatR** e retornam `IDocumentationRestResult<>` conforme o padrão da aplicação.

---

## 🧪 Testes Criados

Foram desenvolvidos testes unitários para os handlers, garantindo:

* Chamadas corretas aos repositórios
* Retorno adequado do `OperationResult`
* Comportamento esperado para Create, Update e Delete

Principais validações:

* `IsSuccessTypeResult` quando as operações são concluídas
* `Data` nula para comandos que retornam payload vazio
* Verificação do número de chamadas ao repositório com *Moq*

---

## 📁 Estrutura Geral do Módulo

```
IntegrationTests/
Application/
 └── Handlers/
 └── Requests/
 └── Responses/
Controllers/
Repositories/
```