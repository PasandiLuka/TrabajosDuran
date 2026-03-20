# AngryBirds 🐦

Solución del proyecto AngryBirds implementando el dominio del juego clásico de pájaros vs cerditos.

## Descripción

Este proyecto implementa las reglas de negocio del juego AngryBirds, incluyendo:
- Diferentes tipos de pájaros con comportamientos únicos
- Sistema de fuerza basado en ira, velocidad y otros factores
- Islas (Pájaro y Cerdito) con sus respectivas funcionalidades
- Obstáculos con diferentes resistencias
- Eventos que afectan el estado de los pájaros

## Estructura del Proyecto

```
AngryBirds/
├── AngryBirds.sln
├── AngryBirds.slnx
├── AngryBirds.Core/       # Biblioteca de dominio
│   ├── Entidades/
│   ├── Interfaces/
│   ├── Enum/
│   └── README.md
└── AngryBirds.Test/       # Pruebas unitarias
    └── README.md
```

## Requisitos

- **.NET 9.0** o superior

## Construcción

```bash
# Compilar el proyecto
dotnet build AngryBirds.sln
```

## Ejecutar Pruebas

```bash
# Ejecutar todas las pruebas
dotnet test AngryBirds.sln

# Ejecutar con detalle
dotnet test AngryBirds.sln --verbosity normal
```

## Uso Básico

```csharp
using AngryBirds.Core.Entidades.Pajaros;
using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Entidades.Obstaculos;

// Crear pájaros
var red = new Red(ira: 10);
var chuck = new Chuck(velocidad: 80);
var bomb = new Bomb(ira: 100);

// Crear isla Pájaro y agregar pájaros
var islaPajaro = new IslaPajaro();
islaPajaro.AgregarPajaro(red);
islaPajaro.AgregarPajaro(chuck);
islaPajaro.AgregarPajaro(bomb);

// Obtener pájaros fuertes (fuerza > 50)
var fuertes = islaPajaro.PajarosFuertes;
int fuerzaTotal = islaPajaro.FuerzaTotal;

// Crear isla Cerdito con obstáculos
var islaCerdito = new IslaCerdito();
islaCerdito.AgregarObstaculo(new CerditoObrero());
islaCerdito.AgregarObstaculo(new ParedVidrio(ancho: 5));

// Atacar
islaPajaro.Atacar(islaCerdito);

// Verificar si se recuperaron los huevos
bool recuperados = islaCerdito.HuevosRecuperados;
```

## Tipos de Pájaros

| Pájaro | Fórmula de Fuerza | Comportamiento al Enfadarse |
|--------|------------------|----------------------------|
| **PajaroComun** | Ira × 2 | Duplica su ira |
| **Red** | Ira × 10 × VecesEnojado | Incrementa contador de enojo |
| **Bomb** | Min(Ira × 2, 9000) | Duplica su ira |
| **Chuck** | 150 (≤80 km/h) o 150 + 5×(vel-80) | Duplica su velocidad |
| **Terence** | Ira × VecesEnojado × Multiplicador | Incrementa contador de enojo |
| **Matilda** | (Ira × 2) + Σ(Huevos) | Pone un huevo de 2kg |

## Obstáculos

| Obstáculo | Resistencia |
|-----------|-------------|
| Pared de Vidrio | 10 × ancho |
| Pared de Madera | 25 × ancho |
| Pared de Piedra | 50 × ancho |
| Cerdito Obrero | 50 (fijo) |
| Cerdito Armado | 10 × resistencia del casco |

## Eventos

| Evento | Efecto |
|--------|--------|
| SesionManejoIra | Disminuye ira en 5 (excepto Chuck) |
| InvasionCerditos | Enoja a los pájaros según cantidad de cerditos |
| FiestaSorpresa | Enoja solo a los homenajeados |
| SerieEventosDesafortunados | Ejecuta múltiples eventos secuencialmente |

## Patrones de Diseño

- **Herencia:** Todos los pájaros heredan de `Pajaro` (abstracta)
- **Interfaces:** `IPajaro`, `IIsla`, `IObstaculo`, `IEvento`
- **Strategy:** Eventos con comportamiento encapsulado
- **Composición:** Islas contienen colecciones de pájaros/obstáculos

## Pruebas Unitarias

El proyecto incluye **54 pruebas unitarias** que cubren:
- Construcción de objetos
- Cálculo de fuerzas
- Comportamiento de enojo
- Eventos de la isla
- Ataques a obstáculos
- Recuperación de huevos

## Documentación

- [AngryBirds.Core](AngryBirds.Core/README.md) - Documentación del proyecto principal
- [AngryBirds.Test](AngryBirds.Test/README.md) - Documentación de pruebas
- [Entidades](AngryBirds.Core/Entidades/README.md) - Detalle de entidades
- [Interfaces](AngryBirds.Core/Interfaces/README.md) - Contratos del sistema

## Inspiración

Este proyecto sigue la estructura del proyecto **Vikingos**, manteniendo:
- Organización de carpetas (Entidades, Interfaces, Enum)
- Patrones de diseño similares
- Convenciones de nomenclatura
- Sistema de documentación con README.md

## Autor

Proyecto desarrollado como ejercicio académico.
