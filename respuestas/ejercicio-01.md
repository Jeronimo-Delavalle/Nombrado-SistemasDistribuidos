# Ejercicio 1 — Crear una red Docker

**1. ¿Qué función cumple una red Docker?**

Proporciona un medio de comunicación privado entre contenedores. Los mantiene aislados de otras redes, les asigna direcciones dentro de un rango propio y les ofrece un servicio de nombres para que puedan encontrarse por su nombre.

**2. ¿Qué servicios pueden comunicarse en ella?**

Pueden comunicarse los contenedores conectados a esa red. En este caso, `inventory-service` y `orders-service`, que fueron iniciados con la opción que los une a `ecommerce-network`. Los contenedores que no pertenezcan a esa red no pueden hacerlo directamente.

**3. ¿Qué relación tiene con la resolución de nombres?**

La red constituye el espacio de nombres en el que viven los contenedores. Al crearla, Docker habilita un servicio de nombres asociado que conoce los nombres de sus miembros y los traduce a sus direcciones. Por eso, dentro de esa red, escribir `inventory-service` es suficiente para dirigirse al contenedor correcto.
