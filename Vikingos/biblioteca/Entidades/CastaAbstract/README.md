# CastaAbstract 🏅

Este directorio contiene las implementaciones concretas de cada casta del sistema Vikingos.

## Clases

### JarlCasta.cs

La clase `JarlCasta` representa la casta **Jarl**, la casta inicial de los vikingos.

**Herencia:** Extiende de `Casta`

**Comportamiento:**
- `SubirCasta()`: Devuelve la casta `Karl`
- `CanSubirCasta()`: Devuelve `true` (puede subir a Karl)
- `AplicarBeneficios(Vikingo)`: Aplica beneficios específicos según el tipo de vikingo:
  - **Soldado:** Incrementa el arma en 10 puntos
  - **Granjero:** Incrementa 2 hectáreas y 2 hijos

**Uso:**
```csharp
// Forma correcta (usa el singleton)
Vikingo v = new Granjero(10, 2, Casta.Jarl);

// Forma incorrecta (crea instancia nueva innecesaria)
Vikingo v = new Granjero(10, 2, new JarlCasta()); // ❌ EVITAR
```

---

### KarlCasta.cs

La clase `KarlCasta` representa la casta **Karl**, la casta intermedia de los vikingos.

**Herencia:** Extiende de `Casta`

**Comportamiento:**
- `SubirCasta()`: Devuelve la casta `Thrall`
- `CanSubirCasta()`: Devuelve `true` (puede subir a Thrall)
- `AplicarBeneficios(Vikingo)`: Aplica beneficios específicos según el tipo de vikingo:
  - **Soldado:** Incrementa el arma en 10 puntos
  - **Granjero:** Incrementa 2 hectáreas y 2 hijos

**Uso:**
```csharp
// Forma correcta (usa el singleton)
Vikingo v = new Soldado(50, Casta.Karl);

// Forma incorrecta (crea instancia nueva innecesaria)
Vikingo v = new Soldado(50, new KarlCasta()); // ❌ EVITAR
```

---

### ThrallCasta.cs

La clase `ThrallCasta` representa la casta **Thrall**, la casta máxima de los vikingos.

**Herencia:** Extiende de `Casta`

**Comportamiento:**
- `SubirCasta()`: Devuelve `null` (no hay casta superior)
- `CanSubirCasta()`: Devuelve `false` (es la casta máxima)
- `AplicarBeneficios(Vikingo)`: No aplica beneficios (es la casta máxima)

**Uso:**
```csharp
// Forma correcta (usa el singleton)
if (vikingo.Casta == Casta.Thrall) { ... }

// Forma incorrecta (crea instancia nueva innecesaria)
if (vikingo.Casta == new ThrallCasta()) { ... } // ❌ EVITAR
```

---

## Relación con la Clase Base

```
Casta (abstracta)
    ↑
    ├── JarlCasta
    ├── KarlCasta
    └── ThrallCasta
```

## Flujo de Progresión

```
JarlCasta → KarlCasta → ThrallCasta
   ↓           ↓           ↓
  Inicio    Intermedio    Máximo
```

## Beneficios por Tipo de Vikingo

### Al subir de Jarl a Karl:

| Tipo de Vikingo | Beneficio |
|----------------|-----------|
| Soldado | +10 al nivel de arma |
| Granjero | +2 hectáreas, +2 hijos |

### Al subir de Karl a Thrall:

| Tipo de Vikingo | Beneficio |
|----------------|-----------|
| Soldado | +10 al nivel de arma |
| Granjero | +2 hectáreas, +2 hijos |

## Notas Importantes

1. **Singleton:** Todas las instancias de casta son gestionadas por la clase base `Casta` a través de las propiedades estáticas `Jarl`, `Karl` y `Thrall`
2. **No instanciar manualmente:** Nunca crear nuevas instancias de estas clases directamente
3. **Thread-safe:** Las instancias singleton son seguras para usar en entornos multi-hilo
