# Preguntas teóricas (ejercicios 1 a 5)

## 1. Nombre, identificador y dirección

**1. ¿Qué diferencia existe entre el nombre `inventory-service` y la dirección `172.18.0.5`?**

El nombre es una etiqueta elegida por las personas para referirse al servicio de forma legible y estable. La dirección es el dato numérico que indica dónde se encuentra el servicio dentro de la red en un momento determinado. El nombre permanece aunque la dirección cambie.

**2. ¿Qué se entiende por nombre dentro de un sistema distribuido?**

Es la forma de designar un recurso para poder pedirlo sin necesidad de saber dónde está ubicado físicamente. Cumple la función de identificarlo y de permitir que distintos componentes hablen de él de la misma manera.

**3. ¿Qué se entiende por identificador?**

Es un dato que permite distinguir un recurso de los demás. Puede ser un nombre legible o un código asignado por el sistema. Su función principal es que no haya confusión entre dos recursos distintos.

**4. ¿Qué se entiende por dirección?**

Es el dato que permite ubicar y contactar al recurso dentro de una red. Indica un lugar concreto en un momento concreto, y por eso puede variar con el tiempo.

**5. ¿Una dirección puede utilizarse como identificador? Justifique.**

Puede utilizarse en un momento dado porque efectivamente distingue un recurso de otro. Sin embargo, no es una buena práctica: si el recurso se reinicia o se recrea, la dirección cambia y deja de representarlo. Un identificador conviene que sea estable; por eso se prefiere usar nombres y dejar que el sistema traduzca el nombre a la dirección vigente.

**6. ¿Puede una misma entidad tener diferentes nombres? Proporcione un ejemplo.**

Sí. Un mismo servicio puede conocerse por más de un nombre. Por ejemplo, el servicio de inventario puede llamarse `inventory-service` dentro de la red de Docker y, al mismo tiempo, `api.inventory.empresa.com` desde el exterior. Ambos nombres llevan al mismo recurso.

**7. ¿Puede un mismo nombre representar diferentes instancias de un servicio?**

Sí. Cuando un servicio se ejecuta en varias copias o réplicas, todas comparten el mismo nombre y cada una tiene su propia dirección. El nombre representa al servicio en conjunto, no a una copia determinada.

## 2. Resolución de nombres

**1. ¿Qué significa resolver un nombre?**

Significa convertir el nombre que escribe una aplicación en la dirección que permite contactar al recurso buscado. Es el paso intermedio entre lo que la persona escribe y lo que la red necesita para comunicarse.

**2. ¿Qué componente transforma `inventory-service` en una dirección?**

El servicio de nombres interno de Docker, que funciona como un pequeño servidor DNS dentro de la red creada. Es el que aparece como `Server: 127.0.0.11` en la consulta `nslookup`.

**3. ¿Por qué conviene utilizar nombres en lugar de IP configuradas directamente?**

Porque los nombres son estables y comprensibles. La dirección puede cambiar sin que las aplicaciones tengan que enterarse. Además, se evita tener que editar archivos de configuración cada vez que un contenedor se recrea.

**4. ¿Qué ocurre si `inventory-service` cambia su dirección IP?**

El servicio de nombres actualiza la relación entre el nombre y la nueva dirección. Las aplicaciones que usan el nombre siguen funcionando sin ninguna modificación.

**5. ¿Qué relación existe entre resolución de nombres y transparencia de ubicación?**

La resolución es el mecanismo que hace posible la transparencia de ubicación. Gracias a ella, el cliente no necesita conocer ni controlar dónde está el recurso: solo conoce su nombre. El cambio de ubicación queda oculto para quien lo utiliza.

## 3. Espacios de nombres

**1. ¿Qué es un espacio de nombres?**

Es un conjunto de nombres organizados según reglas comunes y bajo una autoridad determinada. Dentro de ese conjunto cada nombre tiene un lugar propio y no se confunde con otro.

**2. ¿Corresponde a un esquema plano o jerárquico?**

Corresponde a un esquema jerárquico, porque el nombre está formado por partes ordenadas de mayor a menor alcance.

**3. Identifique los diferentes niveles del nombre `api.inventory.empresa.com`.**

- `com`: zona de primer nivel.
- `empresa`: dominio principal registrado dentro de esa zona.
- `inventory`: subdominio que identifica al área o servicio de inventario.
- `api`: último nivel, que señala un servicio más específico dentro de esa área.
- La raíz del sistema de nombres queda implícita al final.

**4. ¿Qué ventajas presenta un espacio de nombres jerárquico?**

Ordena los nombres, permite repartir la responsabilidad entre distintas autoridades, facilita agregar nuevos nombres sin que se choquen y hace que cada nombre transmita información sobre aquello que designa.

**5. ¿Por qué DNS utiliza una estructura jerárquica?**

Porque la cantidad de nombres es muy grande y cambia constantemente. Repartir la información en niveles permite que cada organización administre solo su parte, sin depender de un único lugar que deba conocer todo.

## 4. DNS

**1. ¿Qué función cumple DNS?**

Traduce nombres legibles en direcciones IP y entrega información asociada a esos nombres. Es el servicio que permite que una persona escriba un dominio y que la red sepa con qué equipo debe comunicarse.

**2. ¿Por qué DNS puede considerarse un sistema distribuido?**

Porque la información no está concentrada en una sola máquina. Está repartida entre muchos servidores que se encargan de distintas zonas y que se consultan entre sí para llegar a una respuesta.

**3. ¿Qué información almacena un servidor DNS?**

Almacena registros que asocian nombres con direcciones y otros datos relacionados, como alias o información de correo. En el caso de Docker, esa información es más simple: nombre de contenedor y dirección dentro de la red.

**4. ¿Qué diferencia existe entre un nombre de dominio y una dirección IP?**

El nombre de dominio es la referencia legible para las personas; la dirección IP es la referencia numérica que usa la red. El dominio puede permanecer igual durante mucho tiempo, mientras que la dirección puede cambiar.

**5. ¿Qué ventajas proporciona el uso de caché?**

Permite responder más rápido y reducir la cantidad de consultas. La contrapartida es que una respuesta guardada puede quedar desactualizada, por lo que se define un tiempo de validez después del cual se vuelve a consultar.

**6. ¿Qué ocurriría si las aplicaciones tuvieran que conocer directamente las IP de todos los servicios?**

Cada cambio de dirección obligaría a modificar la configuración de todos los clientes que lo usan. El sistema sería frágil, difícil de mantener y muy propenso a errores, especialmente cuando los servicios se crean, se reinician o se multiplican.
