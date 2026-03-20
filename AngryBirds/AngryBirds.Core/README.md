# AngryBirds.Core 🐦

Este proyecto contiene toda la lógica de negocio y las entidades del dominio del juego AngryBirds.

## Descripción

La biblioteca `AngryBirds.Core` implementa el dominio del juego AngryBirds, incluyendo:
- Pájaros con diferentes comportamientos y cálculos de fuerza
- Islas (Pájaro y Cerdito) con sus respectivas funcionalidades
- Obstáculos que los pájaros deben derribar
- Eventos que afectan a los pájaros de la isla

## Estructura del Proyecto

```
AngryBirds.Core/
├── Entidades/
│   ├── Abstract/        # Clases abstractas base
│   ├── Pajaros/         # Tipos concretos de pájaros
│   ├── Islas/           # Gestión de islas
│   ├── Obstaculos/      # Obstáculos en la isla Cerdito
│   └── Eventos/         # Eventos que afectan la isla
├── Interfaces/          # Contratos del dominio
├── Enum/                # Enumeraciones
└── AngryBirds.Core.csproj
```

## Tecnologías

- **.NET 9.0**
- **C# 13**
- **Nullable Reference Types** habilitado

## Patrones de Diseño

1. **Herencia:** Todos los pájaros heredan de `Pajaro` (abstracta)
2. **Interfaces:** Contratos para `IPajaro`, `IIsla`, `IObstaculo`, `IEvento`
3. **Strategy:** Eventos con comportamiento encapsulado
4. **Composición:** Islas contienen colecciones de pájaros/obstáculos

## Clases Principales

### Pájaros
| Clase | Descripción |
|-------|-------------|
| `PajaroComun` | Pájaro básico, fuerza = ira × 2 |
| `Red` | Pájaro rencoroso, fuerza = ira × 10 × veces enojado |
| `Bomb` | Pájaro con tope de fuerza (9000) |
| `Chuck` | Fuerza depende de la velocidad |
| `Terence` | Pájaro rencoroso con multiplicador |
| `Matilda` | Pone huevos al enojarse |

### Islas
| Clase | Descripción |
|-------|-------------|
| `IslaPajaro` | Gestiona la colección de pájaros |
| `IslaCerdito` | Gestiona los obstáculos y huevos robados |

### Obstáculos
| Clase | Resistencia |
|-------|-------------|
| `ParedVidrio` | 10 × ancho |
| `ParedMadera` | 25 × ancho |
| `ParedPiedra` | 50 × ancho |
| `CerditoObrero` | 50 (fijo) |
| `CerditoArmado` | 10 × resistencia del casco |

### Eventos
| Clase | Efecto |
|-------|--------|
| `SesionManejoIra` | Disminuye ira en 5 (excepto Chuck) |
| `InvasionCerditos` | Enoja según cantidad de cerditos |
| `FiestaSorpresa` | Enoja solo a homenajeados |
| `SerieEventosDesafortunados` | Ejecuta eventos secuencialmente |

## Ejemplo de Uso

```csharp
using AngryBirds.Core.Entidades.Pajaros;
using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Entidades.Obstaculos;
using AngryBirds.Core.Entidades.Eventos;

// Crear pájaros
var red = new Red(ira: 10);
var chuck = new Chuck(velocidad: 80);

// Crear isla Pájaro
var islaPajaro = new IslaPajaro();
islaPajaro.AgregarPajaro(red);
islaPajaro.AgregarPajaro(chuck);

// Crear isla Cerdito con obstáculos
var islaCerdito = new IslaCerdito();
islaCerdito.AgregarObstaculo(new CerditoObrero());
islaCerdito.AgregarObstaculo(new ParedVidrio(ancho: 5));

// Atacar
islaPajaro.Atacar(islaCerdito);

// Verificar resultado
if (islaCerdito.HuevosRecuperados)
{
    Console.WriteLine("¡Huevos recuperados!");
}
```

## Referencias

- No tiene dependencias externas
- Es referenciado por `AngryBirds.Test`

## Ver Más

- [Entidades](Entidades/README.md) - Detalle de las entidades del dominio
- [Interfaces](Interfaces/README.md) - Contratos del sistema
- [Enum](Enum/README.md) - Enumeraciones del proyecto
