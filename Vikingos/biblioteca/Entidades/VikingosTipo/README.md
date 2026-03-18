# VikingosTipo ⚔️

Este directorio contiene las clases que representan los diferentes tipos de vikingos concretos que pueden formar parte de una expedición.

## Clases

### Soldado.cs

La clase `Soldado` representa un vikingo especializado en combate. Los soldados son productivos cuando han cobrado al menos 20 vidas.

**Herencia:** `Soldado` extiende de `Vikingo` (clase abstracta)

**Propiedades:**
- `Arma`: Nivel del arma del soldado (debe ser positivo)
- `VidasCobradas`: Cantidad de vidas cobradas por el soldado

**Métodos:**
- `ChequearProductividad()`: Verifica si el soldado es productivo (debe tener al menos 20 vidas cobradas)
- `AplicarBeneficioCasta()`: Aplica los beneficios de subir de casta (incrementa el arma en 10 puntos cuando sube a Karl)
- `SetArma(int)`: Establece un nuevo valor para el arma
- `SetVidasCobradas(int)`: Establece un nuevo valor para las vidas cobradas
- `IncrementarVidasCobradas(Soldado)`: Incrementa en 1 las vidas cobradas de otro soldado

**Reglas de Productividad:**
1. Un soldado es productivo si ha cobrado al menos 20 vidas
2. Un soldado Jarl no puede tener un arma mayor a 0

**Validaciones:**
- El arma debe tener un valor positivo
- Las vidas cobradas deben ser un valor no negativo

---

### Granjero.cs

La clase `Granjero` representa un vikingo especializado en agricultura. Los granjeros son productivos cuando tienen al menos 2 hectáreas por hijo.

**Herencia:** `Granjero` extiende de `Vikingo` (clase abstracta)

**Propiedades:**
- `Hectareas`: Cantidad de hectáreas que posee el granjero (debe ser positivo)
- `CantHijos`: Cantidad de hijos del granjero

**Métodos:**
- `ChequearProductividad()`: Verifica si el granjero es productivo (debe tener al menos 2 hectáreas por hijo)
- `AplicarBeneficioCasta()`: Aplica los beneficios de subir de casta (incrementa 2 hectáreas y 2 hijos cuando sube a Karl)
- `SetHectareas(float)`: Establece un nuevo valor para las hectáreas
- `SetCantHijos(int)`: Establece un nuevo valor para la cantidad de hijos

**Reglas de Productividad:**
- Un granjero es productivo cuando tiene al menos 2 hectáreas por hijo

**Validaciones:**
- Las hectáreas deben tener un valor positivo
- La cantidad de hijos debe ser un valor no negativo

---

## Herencia

```
Vikingo (abstracta)
├── Soldado
└── Granjero
```

## Ejemplo de Uso

```csharp
// Crear un soldado
Soldado soldado = new Soldado(arma: 5, casta: Casta.Jarl);
soldado.SetVidasCobradas(25);
soldado.ChequearProductividad(); // Ahora es productivo

// Crear un granjero
Granjero granjero = new Granjero(hectareas: 10, cantHijos: 4);
granjero.ChequearProductividad(); // Es productivo (10 >= 4 * 2)

// Subir de casta
soldado.SubirCasta(); // Ahora es Karl, su arma aumenta en 10
```
