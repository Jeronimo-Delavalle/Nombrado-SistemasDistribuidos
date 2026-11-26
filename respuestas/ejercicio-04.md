# Ejercicio 4 — Cambio de dirección

**1. ¿Cambió la IP?**

La dirección puede cambiar, porque al eliminar el contenedor su dirección vuelve al grupo de direcciones disponibles y Docker asigna una al crear el nuevo contenedor. En algunas ejecuciones la dirección se repite, ya que Docker suele reutilizar la que quedó libre. En este caso la dirección no cambió.

**2. ¿Cambió el nombre?**

No. El contenedor se creó nuevamente con el mismo nombre, `inventory-service`, y conectado a la misma red. El nombre se mantuvo porque fue definido por nosotros, no por Docker.

**3. ¿Fue necesario modificar el cliente?**

No. La consulta desde `orders-service` siguió siendo `nslookup inventory-service`, exactamente igual que antes. El cliente no necesitó conocer la dirección nueva ni cambiar su configuración.

**4. ¿Qué relación tiene con la transparencia de ubicación?**

Este ejercicio muestra esa propiedad de forma concreta: el servicio cambió de instancia y, por lo tanto, pudo cambiar de ubicación dentro de la red; sin embargo, quien lo utiliza sigue refiriéndose a él de la misma manera. La resolución de nombres se encarga de mantener actualizada la correspondencia, de modo que el cambio de ubicación no se percibe desde el cliente.
