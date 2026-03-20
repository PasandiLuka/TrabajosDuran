# Obstáculos 🧱

Este directorio contiene las clases que representan los obstáculos que los pájaros deben derribar para recuperar los huevos.

## Clases

### ParedVidrio.cs

La clase `ParedVidrio` representa una pared de vidrio que bloquea el camino.

**Propiedades:**
- `Ancho`: Ancho de la pared
- `Resistencia`: Calculada como `10 × Ancho` (solo lectura)
- `ResistenciaActual`: Resistencia restante después de los ataques
- `EstaEnPie`: Indica si la pared aún está en pie (solo lectura)

**Métodos:**
- `RecibirAtaque(int fuerza)`: Reduce la resistencia actual según la fuerza del ataque

**Reglas:**
- La resistencia inicial es `10 × Ancho`
- La pared cae cuando `ResistenciaActual <= 0`

---

### ParedMadera.cs

La clase `ParedMadera` representa una pared de madera que bloquea el camino.

**Propiedades:**
- `Ancho`: Ancho de la pared
- `Resistencia`: Calculada como `25 × Ancho` (solo lectura)
- `ResistenciaActual`: Resistencia restante después de los ataques
- `EstaEnPie`: Indica si la pared aún está en pie (solo lectura)

**Métodos:**
- `RecibirAtaque(int fuerza)`: Reduce la resistencia actual según la fuerza del ataque

**Reglas:**
- La resistencia inicial es `25 × Ancho`
- La pared cae cuando `ResistenciaActual <= 0`

---

### ParedPiedra.cs

La clase `ParedPiedra` representa una pared de piedra que bloquea el camino.

**Propiedades:**
- `Ancho`: Ancho de la pared
- `Resistencia`: Calculada como `50 × Ancho` (solo lectura)
- `ResistenciaActual`: Resistencia restante después de los ataques
- `EstaEnPie`: Indica si la pared aún está en pie (solo lectura)

**Métodos:**
- `RecibirAtaque(int fuerza)`: Reduce la resistencia actual según la fuerza del ataque

**Reglas:**
- La resistencia inicial es `50 × Ancho`
- La pared cae cuando `ResistenciaActual <= 0`

---

### CerditoObrero.cs

La clase `CerditoObrero` representa un cerdito obrero que bloquea el camino.

**Propiedades:**
- `Resistencia`: Fija en 50 (solo lectura)
- `ResistenciaActual`: Resistencia restante después de los ataques
- `EstaEnPie`: Indica si el cerdito aún está en pie (solo lectura)

**Métodos:**
- `RecibirAtaque(int fuerza)`: Reduce la resistencia actual según la fuerza del ataque

**Reglas:**
- La resistencia inicial es 50
- El cerdito cae cuando `ResistenciaActual <= 0`

---

### CerditoArmado.cs

La clase `CerditoArmado` representa un cerdito con equipo de protección (casco o escudo).

**Propiedades:**
- `ResistenciaCasco`: Resistencia del casco/escudo
- `Resistencia`: Calculada como `10 × ResistenciaCasco` (solo lectura)
- `ResistenciaActual`: Resistencia restante después de los ataques
- `EstaEnPie`: Indica si el cerdito aún está en pie (solo lectura)

**Métodos:**
- `RecibirAtaque(int fuerza)`: Reduce la resistencia actual según la fuerza del ataque

**Reglas:**
- La resistencia inicial es `10 × ResistenciaCasco`
- El cerdito cae cuando `ResistenciaActual <= 0`

---

## Comparación de Resistencias

| Obstáculo | Fórmula | Ejemplo | Resistencia |
|-----------|---------|---------|-------------|
| ParedVidrio | 10 × Ancho | Ancho=5 | 50 |
| ParedMadera | 25 × Ancho | Ancho=4 | 100 |
| ParedPiedra | 50 × Ancho | Ancho=3 | 150 |
| CerditoObrero | Fija | - | 50 |
| CerditoArmado | 10 × ResistenciaCasco | Casco=15 | 150 |

---

## Jerarquía de Interfaces

```
IObstaculo (interfaz)
├── ParedVidrio
├── ParedMadera
├── ParedPiedra
├── CerditoObrero
└── CerditoArmado
```

## Interface IObstaculo

Todos los obstáculos implementan la interface `IObstaculo`:

```csharp
public interface IObstaculo
{
    int Resistencia { get; }
    bool EstaEnPie { get; }
    void RecibirAtaque(int fuerza);
}
```

---

## Ejemplo de Uso

```csharp
// Crear obstáculos
var vidrio = new ParedVidrio(ancho: 5);    // Resistencia: 50
var madera = new ParedMadera(ancho: 4);    // Resistencia: 100
var piedra = new ParedPiedra(ancho: 3);    // Resistencia: 150
var obrero = new CerditoObrero();          // Resistencia: 50
var armado = new CerditoArmado(casco: 20); // Resistencia: 200

// Verificar resistencia
Console.WriteLine(vidrio.Resistencia); // 50
Console.WriteLine(vidrico.EstaEnPie);  // True

// Recibir ataque
vidrio.RecibirAtaque(fuerza: 60);
Console.WriteLine(vidrio.EstaEnPie);   // False (50 - 60 = -10)

// Ataque múltiple
madera.RecibirAtaque(40);
Console.WriteLine(madera.ResistenciaActual); // 60
madera.RecibirAtaque(40);
Console.WriteLine(madera.ResistenciaActual); // 20
madera.RecibirAtaque(20);
Console.WriteLine(madera.EstaEnPie);         // False
```
