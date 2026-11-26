# Ejercicio 7 — OrdersService

Se creó una segunda aplicación web, `OrdersService`, que actúa como cliente del servicio de inventario. Su controlador utiliza `HttpClient` para solicitar:

`http://inventory-service:8080/api/inventory/P001`

El elemento relevante no es la ruta de la API, sino el nombre del servidor: se escribió `inventory-service` en lugar de una dirección numérica.

## Comparación entre la IP directa y el nombre lógico

| IP directa | Nombre lógico |
|---|---|
| Queda fija en el código o en la configuración | Se mantiene igual aunque cambie la dirección |
| Si el contenedor se recrea, la referencia puede dejar de funcionar | El servicio de nombres actualiza la correspondencia automáticamente |
| Obliga a modificar y volver a desplegar el cliente | No requiere cambios en el cliente |
| No transmite información sobre el servicio | Indica claramente de qué servicio se trata |

Tal como se observó en el Ejercicio 4, el contenedor de inventario puede cambiar de dirección sin que su nombre se modifique. Emplear el nombre lógico permite que `OrdersService` siga funcionando en esa situación. La IP directa, en cambio, crea una dependencia rígida entre el cliente y una ubicación concreta, lo que resulta inconveniente en un sistema donde los servicios se reinician o se multiplican.
 
