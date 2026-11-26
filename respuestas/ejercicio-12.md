# Ejercicio 12 — Service Discovery

La idea puede compararse con una central que mantiene actualizada la lista de sucursales abiertas de una cadena. Uno pregunta por la cadena, no por una sucursal concreta, y la central dice cuáles están disponibles ahora mismo.

**1. ¿Qué información mantiene Service Discovery?**

Mantiene una lista de los servicios de la plataforma y, para cada uno, qué copias existen, dónde están y si están funcionando. En el caso práctico, podría decir: "inventory-service tiene tres copias disponibles y las tres responden". Esa información cambia con el tiempo.

**2. ¿Cómo se registran nuevas instancias?**

Cuando una copia arranca, se anuncia: "soy inventory-service, estoy aquí y estoy lista". En Docker Compose este registro lo hace Docker automáticamente al crear el contenedor. En otros sistemas lo hace la propia aplicación o un pequeño agente que la acompaña.

**3. ¿Cómo se detectan instancias no disponibles?**

Se las consulta de vez en cuando, como quien pregunta "¿seguís ahí?". Si una copia deja de responder durante un tiempo, se la saca de la lista. Cuando vuelve a funcionar, se la vuelve a agregar. Estas comprobaciones se conocen como revisiones de estado.

**4. ¿Qué relación existe con nombrado?**

Es la misma idea de siempre: uno pide un nombre y recibe una dirección. La diferencia está en que la respuesta no es una única dirección fija, sino una lista que se actualiza sola. El nombre sigue siendo estable; lo que cambia es el conjunto de copias al que apunta.

**5. ¿Por qué es importante en microservicios?**

Porque en una plataforma como la del caso los servicios se reinician, se multiplican y se reemplazan constantemente. Sin este mecanismo, cada cambio obligaría a editar configuraciones y a reiniciar a quienes los usan. Con él, la plataforma se adapta por sí sola y OrdersService sigue funcionando exactamente igual.

## Para qué sirve este ejercicio

Entender que el nombrado no se limita a traducir un nombre en una dirección, sino que puede mantener viva la lista de lugares donde ese servicio está disponible. Es el paso siguiente natural después de ver que un mismo nombre puede corresponder a varias copias.
