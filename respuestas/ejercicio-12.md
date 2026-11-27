# Ejercicio 12 — Service Discovery

**1. ¿Qué información mantiene Service Discovery?**

Mantiene una lista de los servicios de la plataforma y, para cada uno, qué copias existen, dónde están y si están funcionando.

**2. ¿Cómo se registran nuevas instancias?**

Cuando una copia arranca, se anuncia. En Docker Compose este registro lo hace Docker automáticamente al crear el contenedor. En otros sistemas lo hace la propia aplicación o un pequeño agente que la acompaña.

**3. ¿Cómo se detectan instancias no disponibles?**

Se las consulta de vez en cuando, como quien pregunta "¿seguís ahí?". Si una copia deja de responder durante un tiempo, se la saca de la lista. Cuando vuelve a funcionar, se la vuelve a agregar. Estas comprobaciones se conocen como revisiones de estado.

**4. ¿Qué relación existe con nombrado?**

Es la misma idea de siempre: uno pide un nombre y recibe una dirección. La diferencia está en que la respuesta no es una única dirección fija, sino una lista que se actualiza sola. El nombre sigue siendo estable; lo que cambia es el conjunto de copias al que apunta.

**5. ¿Por qué es importante en microservicios?**

Porque en una plataforma como la del caso los servicios se reinician, se multiplican y se reemplazan constantemente. Sin este mecanismo, cada cambio obligaría a editar configuraciones y a reiniciar a quienes los usan. Con él, la plataforma se adapta por sí sola y OrdersService sigue funcionando exactamente igual.

