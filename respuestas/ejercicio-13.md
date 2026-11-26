# Ejercicio 13 — Kubernetes

Cuando la plataforma crece, Docker Compose se queda pequeño y se recurre a Kubernetes, que administra los contenedores repartidos en varias máquinas. En Kubernetes, una copia de un servicio se llama Pod. Los Pods son temporales: si uno falla, se crea otro en su lugar, pero con otro nombre y otra dirección.

**1. ¿Qué problema de nombrado resuelve Kubernetes Service?**

Le da al servicio de inventario un nombre y una dirección estables aunque los Pods que hay detrás cambien. Es el mismo problema visto en el ejercicio 4, pero resuelto de forma automática y para un conjunto mucho más grande de máquinas.

**2. ¿Por qué no conviene referenciar directamente las direcciones de los Pods?**

Porque un Pod no está pensado para durar. Si se cae y se crea otro, la dirección cambia y OrdersService estaría llamando a un lugar que ya no existe. Sería como guardar el teléfono de una persona que se fue de la empresa: el número sigue escrito, pero ya no lleva a nadie.

**3. ¿Qué ocurre si un Pod es reemplazado?**

Kubernetes lo detecta, retira el Pod antiguo de la lista y coloca al nuevo en su lugar. El nombre del servicio sigue apuntando al grupo de Pods que están disponibles en ese momento. La aplicación que realiza la petición no participa en ese cambio.

**4. ¿El cliente necesita conocer el cambio?**

No. OrdersService continúa pidiendo `inventory-service`, que dentro de Kubernetes tiene un nombre más completo que incluye el espacio al que pertenece el servicio. Kubernetes se encarga de llevar cada pedido a un Pod que esté funcionando.

**5. ¿Cómo se relaciona con transparencia de ubicación?**

Es la misma cadena de siempre: nombre, resolución, dirección y servicio. Lo nuevo es que Kubernetes mantiene la correspondencia actualizada sin que nadie tenga que intervenir, incluso cuando hay muchas copias repartidas en distintas máquinas. El cliente sigue viendo siempre el mismo nombre.

## Para qué sirve este ejercicio

Comprobar que la idea del TP no depende de una herramienta concreta. Docker, Docker Compose y Kubernetes usan mecanismos distintos, pero todos persiguen lo mismo: que quien usa un servicio no tenga que preocuparse por dónde está ni por cuántas copias hay.
