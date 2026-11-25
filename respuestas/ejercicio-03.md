# Ejercicio 3 — Crear un cliente

## ¿Quién resolvió el nombre?

La resolución la realizó el servicio de nombres interno de Docker. En la consulta `nslookup inventory-service` esto se observa en la línea `Server:`, que indica `127.0.0.11`. Esa dirección identifica al resolvedor que Docker coloca dentro de cada contenedor conectado a la red.

Las tres herramientas utilizadas mostraron el mismo resultado desde ángulos distintos: `ping` confirmó que el nombre es alcanzable, `nslookup` mostró quién respondió y `getent hosts` comprobó que el propio sistema del contenedor también obtiene la dirección.

## ¿Fue necesario conocer la IP?

No. En ningún momento se escribió una dirección numérica: se utilizó solamente el nombre `inventory-service`. La dirección apareció como resultado de la consulta, no como datos de partida.

## ¿Qué ventaja presenta?

La ventaja principal es la independencia respecto de la ubicación. Si el contenedor se detiene y se crea nuevamente con el mismo nombre, las aplicaciones que lo buscan por ese nombre no requieren cambios. Esto simplifica la configuración y reduce los errores provocados por direcciones desactualizadas.
