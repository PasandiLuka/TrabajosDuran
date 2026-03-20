# Entidades 🐦

Este directorio contiene todas las entidades del dominio del proyecto AngryBirds. Las entidades representan los objetos principales del sistema y su lógica de negocio.

## Estructura del Directorio

```
Entidades/
├── Pajaros/           # Tipos concretos de pájaros
│   ├── PajaroComun.cs
│   ├── Red.cs
│   ├── Bomb.cs
│   ├── Chuck.cs
│   ├── Terence.cs
│   └── Matilda.cs
│
├── Islas/             # Gestión de islas
│   ├── IslaPajaro.cs
│   └── IslaCerdito.cs
│
├── Obstaculos/        # Obstáculos en la isla Cerdito
│   ├── ParedVidrio.cs
│   ├── ParedMadera.cs
│   ├── ParedPiedra.cs
│   ├── CerditoObrero.cs
│   └── CerditoArmado.cs
│
├── Eventos/           # Eventos que afectan la isla
│   ├── SesionManejoIra.cs
│   ├── InvasionCerditos.cs
│   ├── FiestaSorpresa.cs
│   └── SerieEventosDesafortunados.cs
│
├── Abstract/
│   └── Pajaro.cs      # Clase abstracta base de pájaros
│
└── README.md
```

## Descripción de Subdirectorios

### 🐦 Pajaros
Contiene las clases que representan los diferentes tipos de pájaros que habitan la isla Pájaro:
- **PajaroComun**: Pájaro básico cuya fuerza es el doble de su ira
- **Red**: Pájaro rencoroso cuya fuerza multiplica por las veces que se enojó
- **Bomb**: Pájaro con tope máximo de fuerza (9000 por defecto)
- **Chuck**: Pájaro cuya fuerza depende de su velocidad
- **Terence**: Pájaro rencoroso con multiplicador configurable
- **Matilda**: Pájaro que pone huevos al enojarse

### 🏝️ Islas
Contiene las clases que representan las islas del juego:
- **IslaPajaro**: Isla donde viven los pájaros, gestiona la colección de pájaros
- **IslaCerdito**: Isla donde los cerdos tienen los huevos robados y obstáculos

### 🧱 Obstaculos
Contiene las clases que representan los obstáculos que los pájaros deben derribar:
- **ParedVidrio**: Resistencia = 10 × ancho
- **ParedMadera**: Resistencia = 25 × ancho
- **ParedPiedra**: Resistencia = 50 × ancho
- **CerditoObrero**: Resistencia fija de 50
- **CerditoArmado**: Resistencia = 10 × resistencia del casco/escudo

### 🎭 Eventos
Contiene las clases que representan los eventos que afectan la isla Pájaro:
- **SesionManejoIra**: Tranquiliza a los pájaros (disminuye ira en 5)
- **InvasionCerditos**: Enoja a los pájaros según cantidad de cerditos
- **FiestaSorpresa**: Enoja solo a los homenajeados
- **SerieEventosDesafortunados**: Ejecuta múltiples eventos secuencialmente

### 📦 Abstract
Contiene las clases abstractas que definen la estructura base del sistema:
- **Pajaro**: Clase base abstracta para todos los pájaros

## Clases Principales

### IslaPajaro

La clase `IslaPajaro` gestiona la colección de pájaros de la isla. Contiene la lógica para obtener los pájaros fuertes y calcular la fuerza total de la isla.

**Propiedades:**
- `Pajaros`: Lista de pájaros que habitan la isla
- `PajarosFuertes`: Pájaros con fuerza mayor a 50
- `FuerzaTotal`: Suma de la fuerza de todos los pájaros fuertes

**Métodos:**
- `AgregarPajaro(IPajaro)`: Agrega un nuevo pájaro a la isla
- `AplicarEvento(IEvento)`: Aplica un evento a todos los pájaros
- `Atacar(IslaCerdito)`: Lanza todos los pájaros contra la isla Cerdito

### IslaCerdito

La clase `IslaCerdito` gestiona los obstáculos que protegen los huevos robados.

**Propiedades:**
- `Obstaculos`: Lista de obstáculos en la isla
- `HuevosRecuperados`: Indica si todos los obstáculos fueron destruidos

**Métodos:**
- `AgregarObstaculo(IObstaculo)`: Agrega un nuevo obstáculo
- `RecibirAtaque(IPajaro)`: Recibe el ataque de un pájaro en el primer obstáculo
- `LimpiarObstaculosDestruidos`: Elimina los obstáculos ya destruidos

## Patrones de Diseño Utilizados

1. **Herencia:** Todos los pájaros heredan de `Pajaro`
2. **Interfaces:** `IPajaro`, `IIsla`, `IObstaculo`, `IEvento`
3. **Strategy:** Sistema de eventos con comportamiento encapsulado
4. **Composición:** `IslaPajaro` contiene `IPajaro`, `IslaCerdito` contiene `IObstaculo`

## Ejemplo de Uso Completo

```csharp
// Crear pájaros
var red = new Red(ira: 10);
var chuck = new Chuck(velocidad: 50);
var bomb = new Bomb(ira: 100);

// Crear isla Pájaro
var islaPajaro = new IslaPajaro();
islaPajaro.AgregarPajaro(red);
islaPajaro.AgregarPajaro(chuck);
islaPajaro.AgregarPajaro(bomb);

// Obtener pájaros fuertes
var fuertes = islaPajaro.PajarosFuertes; // Todos tienen fuerza > 50

// Calcular fuerza total de la isla
int fuerzaTotal = islaPajaro.FuerzaTotal;

// Crear isla Cerdito con obstáculos
var islaCerdito = new IslaCerdito();
islaCerdito.AgregarObstaculo(new CerditoObrero());
islaCerdito.AgregarObstaculo(new ParedVidrio(ancho: 5));

// Atacar la isla Cerdito
islaPajaro.Atacar(islaCerdito);

// Verificar si se recuperaron los huevos
bool recuperados = islaCerdito.HuevosRecuperados;
```
