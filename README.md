# Banco Digital - GraphQL API

**Banco Digital** é uma API desenvolvida em **.NET 8** com **GraphQL** e **Entity Framework**, criada como estudo prático sobre o uso do GraphQL em APIs REST-like e a implementação de **testes automatizados com xUnit**.

---

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **GraphQL (HotChocolate)**
- **Entity Framework Core**
- **MySQL**
- **xUnit** (testes unitários)
- **InMemory Database** (para fins de teste)

---

## 🎯 Objetivo do Projeto

O objetivo principal é explorar:
- A construção de APIs com **GraphQL**, substituindo endpoints REST convencionais.
- O uso do **Entity Framework Core** para persistência de dados com **MySQL**.
- A criação de **testes unitários** eficazes com **xUnit**.
  
Este projeto simula operações bancárias básicas (depósito, saque e consulta de saldo) com uma arquitetura limpa e organizada.

---

## 🧩 Estrutura GraphQL

### Queries

**Consultar Saldo**

```graphql
query {
  saldo(conta: 1)
}
```

### Mutations

**Depositar**

```graphql
mutation {
  depositar(conta: 1, valor: 500) {
    id
    titular
    saldo
  }
}
```

**Sacar**

```graphql
mutation {
  sacar(conta: 1, valor: 200) {
    id
    titular
    saldo
  }
}
```

---

## ⚙️ Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/gustavo-cazarini/BancoDigital.git
cd BancoDigital
```

### 2. Configurar o banco de dados

No arquivo appsettings.json, configure a connection string para o seu servidor MySQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BancoDigitalDB;User=root;Password=suasenha;"
}
```

### 3. Restaurar dependências

```bash
dotnet restore
```

### 4. Rodar as migrations e criar o banco

Execute o comando abaixo dentro do projeto principal (ex: BancoDigital.Api):

```bash
dotnet ef database update
```

> Caso o comando dotnet ef não seja reconhecido, instale o pacote globalmente:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 5. Executar a API

```bash
dotnet run --project BancoDigital.Api
```

---

## 🧪 Testes

O projeto utiliza **xUnit** para testar as regras de negócio da `ContaService`, como:

- Impedir saque com saldo insuficiente
- Atualizar saldo após depósito
- Validar consulta de saldo

Para executar os testes:

```bash
dotnet test
```

---

## 📘 Exemplo de Uso

Exemplo de consulta e mutation no **Banana Cake Pop** (playground do HotChocolate):

```graphql
mutation {
    depositar(conta: 1, valor: 1000) {
        id
        saldo
    }
}

query {
    saldo(conta:  1)
}
```

----------

## 🧠 Aprendizados

Durante o desenvolvimento deste projeto, foram explorados:

-   Criação de **schemas GraphQL** com HotChocolate.
    
-   Integração entre **GraphQL e Entity Framework**.
    
-   Escrita de **testes unitários** para garantir integridade das operações bancárias.
    
-   Organização de **serviços e queries/mutations** com **boas práticas** (Clean Code e SOLID).