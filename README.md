# Nombrado en Sistemas Distribuidos — Caso práctico

Sistemas Distribuidos – ISI – UTN FRCU

## Objetivo

Aplicar los conceptos de nombrado, resolución de nombres y transparencia
de ubicación en una plataforma de comercio electrónico usando Docker,
servicios ASP.NET Core y Docker Compose.

## Requisitos

- Docker Desktop (modo Linux containers)
- .NET SDK 8.0
- Git

## Estructura del repositorio

- `InventoryService/`: Web API que devuelve el stock de un producto.
- `OrdersService/`: Web API cliente que llama a InventoryService por nombre.
- `docker-compose.yml`: define ambos servicios y la red `ecommerce-network`.


## Cómo ejecutar

```powershell
cd C:\SD\Nombrado
docker compose up --build
docker compose ps
docker compose logs orders-service