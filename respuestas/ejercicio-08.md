# Ejercicio 8 — Dockerizar los servicios

## Qué se hizo

Se creó un `Dockerfile` dentro de cada proyecto para empaquetar la aplicación y poder ejecutarla dentro de un contenedor. Ambos siguen la misma estructura, formada por dos etapas:

1. **Etapa de compilación**: parte de la imagen `sdk:9.0`, define `/src` como directorio de trabajo, copia el proyecto, restaura los paquetes y publica el resultado en `/app/publish`.
2. **Etapa de ejecución**: parte de la imagen `aspnet:9.0`, más liviana, copia únicamente el resultado de la etapa anterior y define el comando de arranque con `ENTRYPOINT`.

Esta forma de construir la imagen se conoce como compilación en dos etapas: se compila con todas las herramientas disponibles y se entrega una imagen final que solo contiene lo necesario para ejecutar la aplicación.

## Dockerfile de OrdersService

Es equivalente al de InventoryService. La única diferencia está en la última línea, porque el archivo generado al publicar se llama distinto:

```dockerfile
ENTRYPOINT ["dotnet", "OrdersService.dll"]
```

El resto de las instrucciones se mantiene igual: imágenes base, directorios, restauración y publicación.

## Archivos `.dockerignore`

Se agregó un archivo `.dockerignore` en cada proyecto con `bin`, `obj` y `.git`. Su función es impedir que Docker copie al contenedor los archivos generados por compilaciones locales en Windows. Esto evita que se mezclen archivos compilados para otro entorno y reduce el tamaño de lo que se envía al construir la imagen.

## Ajuste de la versión de .NET

Los proyectos declaran el destino `net9.0`. Las imágenes `8.0` que aparecen en el ejemplo de la consigna no pueden compilar ese destino y producen el error `NETSDK1045`. Por eso los Dockerfiles se ajustaron a `sdk:9.0` y `aspnet:9.0`. El código de las aplicaciones no se modificó.

## Comandos de verificación

```powershell
docker build -t inventory-img ./InventoryService
docker build -t orders-img ./OrdersService
docker images inventory-img orders-img
```

El resultado esperado es que ambas imágenes se construyan correctamente. La imagen de ejecución expone el servicio en el puerto 8080, que es el valor predeterminado de la imagen `aspnet`, y coincide con la dirección que utiliza OrdersService.

## Para qué sirve este ejercicio

Permite pasar de una aplicación que funciona solo en la máquina de desarrollo a una unidad que puede ejecutarse en cualquier sistema con Docker. Además, hacerlo en dos etapas separa claramente dos momentos distintos: preparar el código y ejecutarlo. Esa separación es la base para desplegar los servicios de forma reproducible.
