# Ejercicio 9 — Docker Compose

## Qué se hizo

Se creó un archivo `docker-compose.yml` en la raíz del proyecto que define los dos servicios de la aplicación y la red que los conecta:

```yaml
services:
  inventory-service:
    build: ./InventoryService
    networks:
      - ecommerce-network

  orders-service:
    build: ./OrdersService
    depends_on:
      - inventory-service
    networks:
      - ecommerce-network

networks:
  ecommerce-network:
    driver: bridge
```

## Explicación de cada parte

- `services`: agrupa los contenedores que forman la aplicación. En este caso, los dos servicios web.
- `build`: indica la carpeta que contiene el `Dockerfile` de cada servicio, por lo que Compose construye las imágenes a partir del código fuente.
- `networks`: conecta ambos servicios a la red `ecommerce-network`, declarada al final del archivo con el controlador `bridge`.
- `depends_on`: expresa que `orders-service` debe iniciarse después de `inventory-service`. Conviene aclarar que esta opción respeta el orden de arranque, pero no garantiza que la API del inventario ya esté lista para responder; por eso puede ser necesario esperar unos segundos antes de probar la llamada.

## Nombres, direcciones y resolución

Compose crea una red propia y registra en ella los nombres de los servicios definidos en el archivo. Esos nombres —`inventory-service` y `orders-service`— pasan a ser los nombres lógicos que pueden utilizar los contenedores entre sí.

Las direcciones IP, en cambio, son asignadas automáticamente por Docker dentro de esa red y no aparecen escritas en el archivo ni en el código. Cuando `orders-service` solicita `http://inventory-service:8080/...`, el servicio de nombres interno de Docker traduce ese nombre a la dirección correspondiente.

Esto reproduce, con servicios reales, lo que ya se había observado en los ejercicios 1 a 5: el cliente conoce el nombre, no la ubicación. Si el contenedor se recrea y recibe otra dirección, la relación nombre-dirección se actualiza y el cliente no necesita cambios.

## Cómo se ejecuta

```powershell
docker compose up --build
docker compose ps
docker compose logs orders-service
docker compose down
```

`up --build` construye las imágenes y levanta los servicios; `ps` muestra los contenedores y sus nombres; `logs` permite revisar la salida de OrdersService; y `down` detiene y retira los contenedores y la red.

## Para qué sirve este ejercicio

Reunir en un solo archivo la definición de todos los contenedores, sus nombres, sus dependencias y la red que comparten. De esta forma, un entorno completo se puede levantar con un único comando y reproducir en otra máquina sin repetir instrucciones manuales. Es el paso natural entre tener dos imágenes separadas y tener una aplicación distribuida funcionando como un conjunto.
