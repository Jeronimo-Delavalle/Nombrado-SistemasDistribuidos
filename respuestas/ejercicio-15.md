# Ejercicio 15 — Conclusión

A lo largo del caso práctico se repitió siempre el mismo camino. OrdersService pide un nombre, por ejemplo `inventory-service`; un mecanismo lo transforma en una dirección —el servicio de nombres de Docker, y más adelante un sistema de descubrimiento o Kubernetes—; esa dirección permite llegar finalmente al servicio que devuelve el stock. Esa cadena se resume así:

**NOMBRE → RESOLUCIÓN → DIRECCIÓN → ENTIDAD / SERVICIO**

Los ejercicios 4 y 10 mostraron la primera razón por la que esto es necesario. El contenedor de inventario se detuvo, se eliminó y se creó de nuevo; su dirección podía cambiar, pero su nombre no. Como OrdersService nunca escribió una dirección, no hizo falta modificarlo. Sin los nombres, cada reinicio habría obligado a editar el cliente y a desplegarlo otra vez.

Los ejercicios 11, 12 y 13 mostraron la segunda razón. Un mismo nombre puede representar varias copias del servicio, y entre todas se reparte el trabajo. Si una copia falla, las demás continúan atendiendo y la lista se actualiza sola. El cliente tampoco participa en esos cambios: sigue pidiendo el mismo nombre y recibe siempre una copia disponible.

En conjunto, los nombres son fundamentales porque separan dos cosas que en un sistema distribuido cambian todo el tiempo: **qué se quiere** y **dónde está**. Los componentes se reinician, se mudan, se multiplican y se reemplazan; el nombre permanece y la resolución se encarga de mantenerlo apuntando a la entidad correcta. Docker, Docker Compose y Kubernetes cambian las herramientas, pero no la idea: ocultar esos cambios a quien usa el servicio.
