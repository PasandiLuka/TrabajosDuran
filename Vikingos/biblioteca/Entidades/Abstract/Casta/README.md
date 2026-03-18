# Casta 👑

Este directorio contiene la clase abstracta que define el sistema de castas del proyecto Vikingos.

## Clases

### Casta.cs

La clase `Casta` es una clase abstracta que representa la casta de un vikingo. Implementa el **patrón Strategy** para encapsular el comportamiento de cada casta y el **patrón Singleton** para garantizar una única instancia por tipo de casta.

**Propiedades Singleton:**
- `Jarl`: Obtiene la instancia singleton de la casta Jarl (casta inicial)
- `Karl`: Obtiene la instancia singleton de la casta Karl (casta intermedia)
- `Thrall`: Obtiene la instancia singleton de la casta Thrall (casta máxima)

**Métodos Abstractos:**
- `SubirCasta()`: Obtiene la instancia de casta superior (o null si es la máxima)
- `CanSubirCasta()`: Verifica si se puede subir de casta
- `AplicarBeneficios(Vikingo)`: Aplica los beneficios de subir de casta al vikingo

---

## Patrones de Diseño Implementados

### Patrón Singleton

Los atributos estáticos `Jarl`, `Karl` y `Thrall` implementan el patrón Singleton. Cada uno proporciona una única instancia de su respectiva casta que se comparte en toda la aplicación.

**Beneficios:**
1. **Memoria eficiente:** Solo una instancia por tipo de casta en toda la aplicación
2. **Consistencia:** Todas las referencias a `Casta.Jarl` apuntan al mismo objeto
3. **Performance:** No se crean objetos nuevos cada vez que se necesita una casta
4. **Thread-safe:** Las propiedades estáticas son inicializadas de forma segura

### Patrón Strategy

La clase `Casta` implementa el patrón Strategy para encapsular el comportamiento de cada casta en clases separadas (`JarlCasta`, `KarlCasta`, `ThrallCasta`).

---

## Jerarquía de Castas

```
Casta (abstracta)
    ├── JarlCasta (concreta) - Casta inicial
    ├── KarlCasta (concreta) - Casta intermedia
    └── ThrallCasta (concreta) - Casta máxima
```

## Flujo de Castas

```
Jarl → Karl → Thrall
       ↑       ↑
    (puede  (puede
     subir)  subir)
```

---

## Ejemplo de Uso

```csharp
// Forma correcta de usar las castas (usa el singleton)
Vikingo v = new Granjero(hectareas: 10, cantHijos: 2, casta: Casta.Jarl);

// Comparación de castas
if (vikingo.Casta == Casta.Thrall)
{
    Console.WriteLine("¡Es un Thrall, la casta máxima!");
}

// Subir de casta
vikingo.SubirCasta(); // Ahora es Karl
```

## Notas de Implementación

- **No crear instancias manualmente:** Siempre usar las propiedades estáticas `Casta.Jarl`, `Casta.Karl`, `Casta.Thrall`
- **Las castas son inmutables:** Una vez obtenida una instancia, su comportamiento es fijo
- **Los beneficios se aplican automáticamente:** Al llamar a `SubirCasta()` en un vikingo, los beneficios de la nueva casta se aplican automáticamente
