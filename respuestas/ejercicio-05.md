# Ejercicio 5 — DNS tradicional

## Comparación entre el DNS de Internet y la resolución interna de Docker

| Aspecto | DNS de Internet | Resolución interna de Docker |
|---|---|---|
| Alcance | Público y de alcance mundial | Privado, limitado a una red de Docker |
| Quién responde | Servidores distribuidos en zonas | Servidor interno de la red, visible como `127.0.0.11` |
| Qué resuelve | Dominios como `www.google.com` | Nombres de contenedores como `inventory-service` |
| Cómo se mantiene | Los responsables de cada dominio actualizan sus registros | Docker actualiza la información al crear o eliminar contenedores |
| Estabilidad | Relativamente estable | Cambia con frecuencia, porque los contenedores son temporales |
| Relación entre ambos | Es el destino final de las consultas externas | Si no reconoce el nombre, lo reenvía al DNS del host |

## Observación principal

Cuando la consulta se hace desde el host, la línea `Server:` muestra el servidor DNS configurado en Windows. Cuando se hace desde un contenedor, esa línea muestra `127.0.0.11`, incluso para un dominio público como `www.google.com`. Esto ocurre porque el contenedor siempre pregunta primero a su resolvedor interno; si el nombre no pertenece a la red, Docker reenvía la consulta al servidor del host y devuelve la respuesta.

En definitiva, ambos mecanismos cumplen la misma función general —traducir un nombre en una dirección— pero trabajan en ámbitos distintos y con información de naturaleza diferente. El de Docker es dinámico y de alcance local; el de Internet es jerárquico, público y administrado por muchas organizaciones.
