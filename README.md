# 🎯 Introduce

This project is built with **ASP.NET Core**, designed following **Clean Architecture principles** and implementing **CQRS (Command Query Responsibility Segregation)** with **MediatR**.  

The goal of this project is to provide a scalable, testable, and maintainable foundation for enterprise-grade backend systems.

---

## 🚀 Overview

- **CQRS with MediatR**
  - Separation of **commands** (write operations) and **queries** (read operations).
  - Each use case is represented as a request/handler, improving readability and testability.

- **Clean Architecture**
  - Independent layers: `Domain`, `Application`, `Infrastructure`, `Api`.
  - High maintainability and easy to extend.

- **Entity Framework Core**
  - Database access with repositories and unit of work patterns.
  - LINQ queries with projection for optimized performance.

- **Validation & Mapping**
  - Request validation using **FluentValidation**.
  - DTO mapping using **AutoMapper**.

---

## 🏗️ Architecture Overview

```text
┌───────────────────────────┐
│        Presentation       │  → ASP.NET Core Web API (Controllers, Swagger)
└─────────────┬─────────────┘
              │
┌─────────────▼─────────────┐
│        Application        │  → CQRS (Commands & Queries), MediatR, DTOs, Services
└─────────────┬─────────────┘
              │
┌─────────────▼─────────────┐
│           Core            │  → Base core
└─────────────┬─────────────┘
              │
┌─────────────▼─────────────┐
│       Infrastructure      │  → EF Core, Entities, Repository, UnitOfWork, External Services
└───────────────────────────┘
