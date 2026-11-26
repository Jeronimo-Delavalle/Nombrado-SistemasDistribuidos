# Ejercicio 2 — Crear el servicio de inventario

## Datos registrados

| Dato | Valor |
|---|---|
| Nombre | `inventory-service` |
| Dirección IP | 172.18.0.2 |
| Red | `ecommerce-network` |
| Estado | `running` |

## Análisis de la diferencia entre nombre y dirección

El nombre fue asignado por nosotros al crear el contenedor y es el que utilizamos en los comandos y en las aplicaciones. La dirección fue asignada automáticamente por Docker al conectarlo a la red, y corresponde a su ubicación dentro de esa red en este momento.

La diferencia importante es la estabilidad. El nombre permanece mientras el servicio exista con esa identidad; la dirección depende del momento y de las demás direcciones ocupadas. Por ello conviene razonar en términos de nombres y dejar que el sistema determine la dirección correspondiente.
