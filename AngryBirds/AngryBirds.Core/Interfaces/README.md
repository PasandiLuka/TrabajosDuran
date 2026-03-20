# Interfaces 🔌

Este directorio contiene las interfaces que definen los contratos del dominio del proyecto AngryBirds.

## Interfaces

### IPajaro.cs

La interfaz `IPajaro` define el contrato que todos los pájaros deben implementar.

```csharp
public interface IPajaro
{
    int Ira { get; }
    int Fuerza { get; }
    bool EsFuerte { get; }
    
    void Enfadarse();
}
```

**Miembros:**
| Miembro | Tipo | Descripción |
|---------|------|-------------|
| `Ira` | `int` | Nivel de ira actual del pájaro |
| `Fuerza` | `int` | Fuerza calculada del pájaro |
| `EsFuerte` | `bool` | Indica si la fuerza es mayor a 50 |
| `Enfadarse()` | `void` | Ejecuta la lógica de enojo específica |

**Implementaciones:**
- `Pajaro` (clase abstracta base)
  - `PajaroComun`
  - `Red`
  - `Bomb`
  - `Chuck`
  - `Terence`
  - `Matilda`

---

### IIsla.cs

La interfaz `IIsla` define el contrato básico para todas las islas.

```csharp
public interface IIsla
{
    string Nombre { get; }
}
```

**Miembros:**
| Miembro | Tipo | Descripción |
|---------|------|-------------|
| `Nombre` | `string` | Nombre de la isla |

**Implementaciones:**
- `IslaPajaro`
- `IslaCerdito`

---

### IObstaculo.cs

La interfaz `IObstaculo` define el contrato que todos los obstáculos deben implementar.

```csharp
public interface IObstaculo
{
    int Resistencia { get; }
    bool EstaEnPie { get; }
    
    void RecibirAtaque(int fuerza);
}
```

**Miembros:**
| Miembro | Tipo | Descripción |
|---------|------|-------------|
| `Resistencia` | `int` | Resistencia total del obstáculo |
| `EstaEnPie` | `bool` | Indica si el obstáculo aún no fue destruido |
| `RecibirAtaque(int)` | `void` | Aplica daño al obstáculo |

**Implementaciones:**
- `ParedVidrio`
- `ParedMadera`
- `ParedPiedra`
- `CerditoObrero`
- `CerditoArmado`

---

### IEvento.cs

La interfaz `IEvento` define el contrato que todos los eventos deben implementar.

```csharp
public interface IEvento
{
    void Aplicar(IslaPajaro isla);
}
```

**Miembros:**
| Miembro | Tipo | Descripción |
|---------|------|-------------|
| `Aplicar(IslaPajaro)` | `void` | Aplica el efecto del evento a la isla |

**Implementaciones:**
- `SesionManejoIra`
- `InvasionCerditos`
- `FiestaSorpresa`
- `SerieEventosDesafortunados`

---

## Diagrama de Interfaces

```
┌─────────────────┐
│    IPajaro      │
├─────────────────┤
│ + Ira: int      │
│ + Fuerza: int   │
│ + EsFuerte: bool│
│ + Enfadarse()   │
└─────────────────┘
          ↑
          │ (implementado por)
          │
    ┌──────────┐
    │  Pajaro  │ (abstracta)
    └──────────┘
          │
          │ (heredan)
          ↓
    ┌─────────────────────────────────┐
    │ PajaroComun │ Red │ Bomb │ ... │
    └─────────────────────────────────┘


┌─────────────────┐
│    IIsla        │
├─────────────────┤
│ + Nombre: string│
└─────────────────┘
          ↑
          │ (implementado por)
          │
    ┌────────────────────┐
    │ IslaPajaro         │
    │ IslaCerdito        │
    └────────────────────┘


┌─────────────────┐
│   IObstaculo    │
├─────────────────┤
│ + Resistencia   │
│ + EstaEnPie     │
│ + RecibirAtaque │
└─────────────────┘
          ↑
          │ (implementado por)
          │
    ┌──────────────────────────────────┐
    │ ParedVidrio │ ParedMadera │ ... │
    └──────────────────────────────────┘


┌─────────────────┐
│    IEvento      │
├─────────────────┤
│ + Aplicar()     │
└─────────────────┘
          ↑
          │ (implementado por)
          │
    ┌─────────────────────────────────────┐
    │ SesionManejoIra │ InvasionCerditos │
    │ FiestaSorpresa  │ SerieEventos...  │
    └─────────────────────────────────────┘
```

---

## Ejemplo de Uso con Interfaces

```csharp
// Usar interface IPajaro
IPajaro pajaro = new Red(ira: 10);
Console.WriteLine(pajaro.Fuerza); // 100
pajaro.Enfadarse();

// Usar interface IObstaculo
IObstaculo obstaculo = new ParedVidrio(ancho: 5);
obstaculo.RecibirAtaque(fuerza: 60);
Console.WriteLine(obstaculo.EstaEnPie); // False

// Usar interface IEvento
IEvento evento = new SesionManejoIra();
isla.AplicarEvento(evento);

// Polimorfismo con interfaces
List<IPajaro> pajaros = new List<IPajaro>
{
    new Red(10),
    new Chuck(50),
    new Bomb(100)
};

foreach (var p in pajaros)
{
    if (p.EsFuerte)
    {
        p.Enfadarse();
    }
}
```

---

## Beneficios del Uso de Interfaces

1. **Desacoplamiento:** El código depende de abstracciones, no de implementaciones concretas
2. **Testabilidad:** Fácil de mockear en tests unitarios
3. **Flexibilidad:** Permite cambiar implementaciones sin modificar el código cliente
4. **Polimorfismo:** Permite tratar diferentes tipos de manera uniforme
