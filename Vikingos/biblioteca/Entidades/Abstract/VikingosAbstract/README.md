# VikingosAbstract 🛡️

Este directorio contiene las clases abstractas base que definen el comportamiento común de los vikingos.

## Clases

### Vikingo.cs

La clase `Vikingo` es una clase abstracta que representa el estado base de cualquier guerrero vikingo. Define la estructura común que todos los tipos de vikingos deben implementar.

**Herencia:** Implementa la interfaz `IProductividad`

**Propiedades:**
- `Productivo`: Indica si el vikingo es productivo (solo lectura protegida)
- `Casta`: Obtiene la casta actual del vikingo (solo lectura protegida)

**Métodos:**
- `SubirCasta()`: Sube al vikingo a la siguiente casta aplicando los beneficios correspondientes
- `ChequearProductividad()`: Método abstracto que debe ser implementado por cada tipo de vikingo para verificar su productividad

**Reglas:**
1. Por defecto, un vikingo nace con la casta `Jarl` si no se especifica otra
2. No se puede subir de casta si ya se alcanzó la casta máxima (Thrall)
3. Cada tipo de vikingo debe definir sus propias reglas de productividad

**Excepciones:**
- `InvalidOperationException`: Se lanza cuando se intenta subir de casta habiendo alcanzado la casta máxima (Thrall)
- `ArgumentException`: Se lanza cuando el vikingo no cumple los requisitos de productividad específicos de su tipo

---

## Jerarquía de Clases

```
IProductividad (interfaz)
    ↑
Vikingo (abstracta)
    ├── Soldado (concreta)
    └── Granjero (concreta)
```

## Sistema de Castas

El sistema de castas sigue la siguiente jerarquía:

```
Jarl → Karl → Thrall
```

- **Jarl**: Casta inicial. Permite subir a Karl.
- **Karl**: Casta intermedia. Permite subir a Thrall. Aplica beneficios al subir.
- **Thrall**: Casta máxima. No permite subir más.

## Ejemplo de Uso

```csharp
// Crear un vikingo (a través de una clase concreta)
Soldado soldado = new Soldado(arma: 5);

// Verificar la casta actual
Console.WriteLine(soldado.Casta); // Jarl

// Subir de casta
soldado.SubirCasta(); // Ahora es Karl
soldado.SubirCasta(); // Ahora es Thrall

// Intentar subir nuevamente lanzará InvalidOperationException
soldado.SubirCasta(); // ❌ Excepción: "Ha alcanzado la casta máxima, aventurero :D"
```

## Notas de Implementación

- La clase `Vikingo` es abstracta, por lo que no puede ser instanciada directamente
- Cada subclase debe implementar el método `ChequearProductividad()` con sus propias reglas
- El método `SubirCasta()` aplica automáticamente los beneficios de la nueva casta llamando a `AplicarBeneficios()` en la instancia de la casta
