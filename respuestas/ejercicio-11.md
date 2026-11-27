# Ejercicio 11 — Múltiples instancias

Situación: la tienda crece y el servicio de inventario ya no alcanza con una sola copia. Ahora hay tres copias funcionando al mismo tiempo, cada una con su propia dirección, pero todas conocidas con el mismo nombre: `inventory-service`.

**1. ¿Debería OrdersService conocer las tres direcciones?**

No. Para OrdersService el inventario es un solo servicio, no tres máquinas distintas. Si el cliente conociera las tres direcciones, cada vez que se agregara o se retirara una copia habría que avisarle y cambiar su configuración. Lo correcto es que pida el servicio por su nombre y que el sistema decida qué copia atiende cada pedido.

**2. ¿Qué problemas generaría?**

- Las direcciones escritas en el cliente quedarían desactualizadas en cuanto una copia se reiniciara.
- Cada cambio en la cantidad de copias obligaría a modificar OrdersService y volver a desplegarlo.
- Si una de las copias dejara de responder, el cliente seguiría intentando usarla y aparecerían errores.
- El trabajo podría repartirse de manera desigual: una copia recibiría casi todo y las otras quedarían casi sin uso.
- En resumen: más mantenimiento, más errores y menos capacidad de crecer.

**3. ¿Qué mecanismo debería localizar las instancias?**

Un mecanismo que conozca el nombre del servicio y devuelva la lista de copias que están disponibles en ese momento. En Docker ya tenemos algo parecido con el servicio de nombres de la red. 

**4. ¿Cómo se relaciona con balanceo de carga?**

Cuando un mismo nombre tiene varias copias detrás, alguien debe elegir cuál atiende cada pedido. Eso es justamente balancear: repartir el trabajo para que ninguna copia se sobrecargue mientras las demás están libres. 

**5. ¿Qué ocurre si una instancia falla?**

Lo deseable es que esa copia deje de recibir pedidos y que las otras dos sigan atendiendo sin que OrdersService se entere. Para eso hace falta detectar que una copia no responde y sacarla de la lista de disponibles. Si no se hiciera, los clientes seguirían golpeando una puerta cerrada.

