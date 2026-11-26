# Ejercicio 10 — Recrear la infraestructura

## Qué se hizo

Se ejecutó `docker compose down` para detener y eliminar los contenedores y la red creados en el ejercicio 9, y luego `docker compose up -d` para levantarlos nuevamente. Antes y después se consultó:

```powershell
docker network inspect nombrado_ecommerce-network
```

## Datos observados

### La red

| Dato | Antes (ejercicio 9) | Después (ejercicio 10) |
|---|---|---|
| Nombre | `nombrado_ecommerce-network` | Igual |
| Identificador | `e7b521378d65...` | `7176e72c1690...` (distinto) |
| Fecha de creación | 2026-11-25 04:26:43 UTC | 2026-11-26 23:26:49 UTC |
| Controlador | `bridge` | Igual |
| Subred | `172.19.0.0/16` | Igual |
| Puerta de enlace | `172.19.0.1` | Igual |

### Los contenedores

| Dato | Antes | Después |
|---|---|---|
| Contenedor de inventario | `nombrado-inventory-service-1` | Igual |
| IP de inventario | `172.19.0.2/16` | `172.19.0.2/16` |
| ID del contenedor de inventario | `264fc089685e...` | `207714ff0d2a...` (distinto) |
| MAC de inventario | `ba:27:71:21:b2:ea` | `2a:d4:f7:4c:4d:fa` (distinta) |
| Contenedor de pedidos | `nombrado-orders-service-1` | Igual |
| IP de pedidos | `172.19.0.3/16` | `172.19.0.3/16` |
| ID del contenedor de pedidos | `a8a0384d3345...` | `2137d3c36a55...` (distinto) |
| MAC de pedidos | `62:e7:fc:59:a4:d0` | `9a:eb:7a:48:5a:82` (distinta) |

## Análisis

**1. ¿Cambiaron las direcciones IP?**

No: en esta ejecución se repitieron (`172.19.0.2` para inventario y `172.19.0.3` para pedidos). Esto no significa que sean fijas. Al eliminar la red, sus direcciones volvieron al grupo de direcciones disponibles; al crear una red nueva con la misma subred y en el mismo orden de arranque, Docker asignó las mismas. Si el orden hubiera sido otro o hubiera existido otro contenedor ocupando esas direcciones, el resultado habría sido distinto.

**2. ¿Cambió entonces algo?**

Sí, y es lo importante del ejercicio. La red tiene un identificador nuevo, los contenedores tienen identificadores nuevos, los puntos de conexión y las direcciones físicas también son nuevos, y las fechas de creación confirman que todo se construyó otra vez. Es decir: la infraestructura se recreó por completo; solo las direcciones IP coincidieron por cómo se hizo la asignación.

**3. ¿Necesitó modificaciones el cliente?**

No. `OrdersService` continúa utilizando `http://inventory-service:8080/...`, exactamente igual que en el ejercicio 9. No se escribió ninguna dirección IP en el código. El nombre definido en `docker-compose.yml` sigue vigente y el servicio de nombres de la red lo asocia con la dirección que esté en vigor en cada momento, en este caso `172.19.0.2`.

**4. ¿Qué relación tiene con la transparencia de ubicación?**

Este ejercicio la confirma a mayor escala que el ejercicio 4. Todo lo que ocurrió por debajo —nueva red, nuevos contenedores, nuevas direcciones físicas y, potencialmente, nuevas IP— no produjo ningún cambio en quien consume el servicio. El cliente solo conoce el nombre; la resolución se encarga de mantenerlo apuntando a la entidad correcta. Esa es precisamente la definición de transparencia de ubicación.

## Observación sobre los nombres

Compose antepone el nombre del proyecto (`nombrado`) al nombre de cada contenedor y agrega el número de instancia (`-1`). Dentro de la red, los servicios también son reconocidos por los nombres cortos `inventory-service` y `orders-service`, que son los que utiliza la aplicación.

## Para qué sirve este ejercicio

Comprobar que un sistema completo puede desmontarse y volverse a levantar sin que los clientes se modifiquen. Además, deja preparado el terreno para el ejercicio 11: si un mismo nombre puede corresponder a varias instancias, el siguiente paso es analizar cómo se distribuye el trabajo entre ellas.
