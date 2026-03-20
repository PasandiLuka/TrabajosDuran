# Eventos 🎭

Este directorio contiene las clases que representan los eventos que pueden ocurrir en la isla Pájaro.

## Clases

### SesionManejoIra.cs

La clase `SesionManejoIra` representa una sesión de manejo de la ira conducida por Matilda.

**Efecto:** Disminuye la ira de todos los pájaros en 5 unidades.

**Excepciones:**
- **Chuck**: No se ve afectado por este evento (nada lo tranquiliza)

**Pájaros afectados:**
| Pájaro | Efecto |
|--------|--------|
| PajaroComun | Ira -= 5 (mínimo 0) |
| Red | Ira -= 5 (mínimo 0) |
| Bomb | Ira -= 5 (mínimo 0) |
| Terence | Ira -= 5 (mínimo 0) |
| Matilda | Ira -= 5 (mínimo 0) |
| Chuck | Sin efecto |

---

### InvasionCerditos.cs

La clase `InvasionCerditos` representa una invasión de cerditos a la isla.

**Propiedades:**
- `CantidadCerditos`: Cantidad de cerditos que invaden

**Efecto:** Enoja a todos los pájaros una vez por cada 100 cerditos que invaden.

**Cálculo:**
```
Veces que enoja = CantidadCerditos / 100 (división entera)
```

**Ejemplos:**
| Cerditos | Veces que enoja |
|----------|-----------------|
| 50 | 0 |
| 100 | 1 |
| 250 | 2 |
| 300 | 3 |

---

### FiestaSorpresa.cs

La clase `FiestaSorpresa` representa una fiesta sorpresa en la isla.

**Propiedades:**
- `Homenajeados`: Lista de pájaros homenajeados

**Efecto:** Hace enojar solamente a los pájaros homenajeados.

**Casos especiales:**
- Si no hay homenajeados (lista vacía o null), no ocurre ningún efecto

---

### SerieEventosDesafortunados.cs

La clase `SerieEventosDesafortunados` representa una secuencia de eventos que ocurren uno después del otro.

**Propiedades:**
- `Eventos`: Lista de eventos que se ejecutarán secuencialmente

**Efecto:** Ejecuta todos los eventos en orden, uno después del otro.

**Comportamiento:**
- Los eventos se aplican en el orden en que fueron agregados
- Cada evento se completa antes de que comience el siguiente

---

## Interface IEvento

Todos los eventos implementan la interface `IEvento`:

```csharp
public interface IEvento
{
    void Aplicar(IslaPajaro isla);
}
```

---

## Jerarquía

```
IEvento (interfaz)
├── SesionManejoIra
├── InvasionCerditos
├── FiestaSorpresa
└── SerieEventosDesafortunados
```

---

## Ejemplo de Uso

### Sesión de Manejo de Ira

```csharp
var isla = new IslaPajaro();
isla.AgregarPajaro(new PajaroComun(ira: 20));
isla.AgregarPajaro(new Chuck(velocidad: 50));

var evento = new SesionManejoIra();
isla.AplicarEvento(evento);

// PajaroComun: Ira = 15 (20 - 5)
// Chuck: Ira = 50 (sin cambio)
```

### Invasión de Cerditos

```csharp
var isla = new IslaPajaro();
var red = new Red(ira: 10);
isla.AgregarPajaro(red);

var evento = new InvasionCerditos(cantidadCerditos: 300);
isla.AplicarEvento(evento);

// red.VecesEnojado = 4 (1 inicial + 3 por la invasión)
// red.Fuerza = 10 × 10 × 4 = 400
```

### Fiesta Sorpresa

```csharp
var isla = new IslaPajaro();
var red = new Red(ira: 10);
var chuck = new Chuck(velocidad: 50);
isla.AgregarPajaro(red);
isla.AgregarPajaro(chuck);

var evento = new FiestaSorpresa(homenajeados: new List<IPajaro> { red });
isla.AplicarEvento(evento);

// red.VecesEnojado = 2 (se enojó por ser homenajeado)
// chuck.Velocidad = 50 (sin cambio, no era homenajeado)
```

### Serie de Eventos Desafortunados

```csharp
var isla = new IslaPajaro();
var red = new Red(ira: 10);
isla.AgregarPajaro(red);

var eventos = new List<IEvento>
{
    new InvasionCerditos(100),  // Enoja 1 vez
    new SesionManejoIra()        // Disminuye ira en 5
};

var serie = new SerieEventosDesafortunados(eventos);
isla.AplicarEvento(serie);

// Después de InvasionCerditos: red.VecesEnojado = 2
// Después de SesionManejoIra: red.Ira = 5 (10 - 5)
```

---

## Combinación de Eventos

Los eventos pueden combinarse para crear situaciones complejas:

```csharp
// Crear una secuencia compleja
var eventos = new List<IEvento>
{
    new InvasionCerditos(500),           // Enoja 5 veces
    new FiestaSorpresa(new List<IPajaro> { red }), // Red se enoja 1 vez más
    new SesionManejoIra()                 // Todos se tranquilizan (excepto Chuck)
};

var serie = new SerieEventosDesafortunados(eventos);
isla.AplicarEvento(serie);
```
