# Entidades 🏛️

Este directorio contiene todas las entidades del dominio del proyecto Vikingos. Las entidades representan los objetos principales del sistema y su lógica de negocio.

## Estructura del Directorio

```
Entidades/
├── Lugares/           # Clases relacionadas con lugares a expedicionar
│   ├── Aldea.cs
│   ├── Amurallada.cs
│   ├── Capital.cs
│   ├── Iglesia.cs
│   └── Lugar.cs
│
├── VikingosTipo/      # Tipos concretos de vikingos
│   ├── Soldado.cs
│   └── Granjero.cs
│
├── Abstract/
│   ├── VikingosAbstract/  # Clases abstractas base de vikingos
│   │   └── Vikingo.cs
│   └── Casta/         # Sistema de castas abstracto
│       └── Casta.cs
│
├── CastaAbstract/     # Implementaciones concretas de castas
│   ├── JarlCasta.cs
│   ├── KarlCasta.cs
│   └── ThrallCasta.cs
│
├── Expedicion/        # Gestión de expediciones
│   └── Expedicion.cs
│
└── README.md
```

## Descripción de Subdirectorios

### 🏰 Lugares
Contiene las clases que representan los diferentes lugares que pueden ser objetivo de una expedición vikinga:
- **Lugar**: Entidad agrupadora de objetivos
- **Capital**: Objetivo mayor con defensores y riqueza
- **Aldea**: Objetivo menor con subestructuras
- **Iglesia**: Fuente de botín mediante crucifijos
- **Amurallada**: Estructura defensiva que requiere mínimo de vikingos

### ⚔️ VikingosTipo
Contiene las clases que representan los tipos concretos de vikingos:
- **Soldado**: Vikingo especializado en combate
- **Granjero**: Vikingo especializado en agricultura

### 📦 Abstract
Contiene las clases abstractas que definen la estructura base del sistema:
- **VikingosAbstract/Vikingo**: Clase base abstracta para todos los vikingos
- **Casta/Casta**: Clase abstracta que define el sistema de castas

### 🏅 CastaAbstract
Contiene las implementaciones concretas del sistema de castas:
- **JarlCasta**: Casta inicial
- **KarlCasta**: Casta intermedia
- **ThrallCasta**: Casta máxima

### 🚢 Expedicion
Contiene la clase que gestiona las expediciones vikingas:
- **Expedicion**: Gestiona el grupo de asalto, filtra vikingos productivos y determina el éxito de los ataques

## Clases Principales

### Expedicion

La clase `Expedicion` gestiona el grupo de asalto vikingo. Filtra a los vikingos para asegurarse de llevar solo a los productivos y contiene la lógica principal para determinar si un ataque tiene éxito.

**Propiedades:**
- `Vikingos`: Lista de vikingos que forman parte de la expedición

**Métodos:**
- `RealizarExpedicion(Lugar)`: Realiza una expedición a un lugar específico
- `AgregarVikingo(Vikingo)`: Agrega un nuevo vikingo a la expedición
- `SetVikingos(List<Vikingo>)`: Reemplaza la lista de vikingos

**Códigos de Retorno de RealizarExpedicion:**
| Código | Significado |
|--------|-------------|
| 1 | Expedición a capital exitosa |
| 2 | Expedición a aldea exitosa |
| 3 | Expedición a capital fallida (no rentable) |
| 4 | Expedición a aldea fallida (no rentable) |
| 5 | Expedición mixta parcialmente exitosa |

## Patrones de Diseño Utilizados

1. **Herencia:** `Soldado` y `Granjero` heredan de `Vikingo`
2. **Interfaces:** `Vikingo` implementa `IProductividad`
3. **Strategy:** Sistema de castas con comportamiento encapsulado
4. **Singleton:** Castas como instancias únicas
5. **Composición:** `Expedicion` contiene `Vikingo`, `Lugar` contiene `Capital`/`Aldea`

## Ejemplo de Uso Completo

```csharp
// Crear vikingos
var soldado = new Soldado(arma: 5);
soldado.SetVidasCobradas(25);

var granjero = new Granjero(hectareas: 10, cantHijos: 4);

// Crear expedición (solo incluye vikingos productivos)
var expedicion = new Expedicion(new List<Vikingo> { soldado, granjero });

// Crear lugar objetivo
var capital = new Capital(cantDefensores: 2, riquezaTierra: 2.5f);
var lugar = new Lugar(capital: capital, aldea: null);

// Realizar expedición
int resultado = expedicion.RealizarExpedicion(lugar);
```
