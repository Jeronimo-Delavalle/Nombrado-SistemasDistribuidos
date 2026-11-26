# Ejercicio 6 — InventoryService en C#

Se creó una aplicación web con el comando `dotnet new webapi -n InventoryService --use-controllers` y se agregó un controlador encargado de responder las consultas sobre el inventario.

El controlador define la ruta `api/[controller]`. Dado que la clase se llama `InventoryController`, la parte variable se sustituye por `inventory`. El método `Get` recibe un parámetro `productId` y responde a las peticiones del tipo `GET /api/inventory/P001`.

La respuesta entregada es un objeto con tres datos: el identificador del producto solicitado, un valor de stock y el nombre de la máquina que atendió la petición. Este último dato permite distinguir posteriormente entre distintas copias del servicio.

La aplicación se inició con `dotnet run` y el endpoint se probó mediante `curl.exe`, comprobando que la respuesta se devuelve correctamente en formato JSON.


