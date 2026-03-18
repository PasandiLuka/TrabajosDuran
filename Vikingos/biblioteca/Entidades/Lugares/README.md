# Lugares 🏰

Este directorio contiene las clases que representan los diferentes lugares que pueden ser objetivo de una expedición vikinga.

## Clases

### Lugar.cs

La clase `Lugar` es una entidad agrupadora que define el objetivo geográfico de una expedición. Un lugar puede contener:
- Una **Capital** (objetivo mayor)
- Una **Aldea** (objetivo menor)
- Ambas simultáneamente

**Regla de validación:** Un lugar debe tener al menos una capital o una aldea. Si se intenta crear un lugar sin ninguno de estos componentes, se lanzará una `InvalidOperationException`.

**Propiedades:**
- `Capital`: Obtiene la capital del lugar (puede ser null)
- `Aldea`: Obtiene la aldea del lugar (puede ser null)

---

### Capital.cs

La clase `Capital` representa una capital que puede ser saqueada por una expedición vikinga.

**Propiedades:**
- `CantDefensores`: Cantidad de defensores de la capital (debe ser positivo)
- `Botin`: Botín actual de la capital
- `RiquezaTierra`: Riqueza de la tierra de la capital (debe ser positivo)

**Métodos:**
- `BotinTotal()`: Calcula el botín total de la capital (cantidad de defensores × riqueza de la tierra)
- `SetCantDefensores(int)`: Establece una nueva cantidad de defensores
- `SetBotin(float)`: Establece un nuevo valor para el botín
- `SetRiquezaTierra(float)`: Establece un nuevo valor para la riqueza de la tierra

**Validaciones:**
- Los defensores deben ser un valor positivo
- La riqueza de la tierra debe ser un valor positivo
- El botín debe ser un valor no negativo

---

### Aldea.cs

La clase `Aldea` representa una aldea que puede tener una iglesia o ser amurallada, pero **no ambas simultáneamente**.

**Propiedades:**
- `Iglesia`: Obtiene la iglesia de la aldea (puede ser null)
- `Amurallada`: Obtiene la información de amurallado de la aldea (puede ser null)

**Regla de validación:** Una aldea debe tener una iglesia o ser amurallada, pero no ambas. Si se intenta crear una aldea con ambas o sin ninguna, se lanzará una `InvalidOperationException`.

---

### Iglesia.cs

La clase `Iglesia` representa una iglesia en una aldea. Las iglesias almacenan crucifijos que pueden ser convertidos en botín.

**Propiedades:**
- `Crucifijos`: Cantidad de crucifijos en la iglesia (debe ser positivo)

**Métodos:**
- `BotinCrucifijos()`: Calcula el botín obtenido de los crucifijos (crucifijos × 2.5)
- `SetCrucifijos(float)`: Establece una nueva cantidad de crucifijos

**Validaciones:**
- Los crucifijos deben tener un valor positivo

---

### Amurallada.cs

La clase `Amurallada` representa una aldea amurallada. Las aldeas amuralladas requieren una cantidad mínima de vikingos para ser saqueadas.

**Propiedades:**
- `MinimoVikingos`: Cantidad mínima de vikingos requeridos para saquear la aldea (debe ser positivo)

**Validaciones:**
- El mínimo de vikingos debe ser un valor positivo

---

## Relaciones

```
Lugar
├── Capital (opcional)
└── Aldea (opcional)
    ├── Iglesia (opcional, exclusivo con Amurallada)
    └── Amurallada (opcional, exclusivo con Iglesia)
```

## Ejemplo de Uso

```csharp
// Crear una capital
Capital capital = new Capital(cantDefensores: 10, riquezaTierra: 2.5f);

// Crear una iglesia
Iglesia iglesia = new Iglesia(crucifijos: 15);

// Crear una aldea con iglesia
Aldea aldea = new Aldea(iglesia: iglesia);

// Crear un lugar con capital y aldea
Lugar lugar = new Lugar(capital: capital, aldea: aldea);
```
