# Diagrama UML - Vikingos

## Diagrama de Clases

```mermaid
classDiagram
    %% Interfaz
    class IProductividad {
        <<Interface>>
        +void ChequearProductividad()
    }

    %% Clases Abstractas
    class Vikingo {
        <<abstract>>
        +bool Productivo
        +Casta Casta
        +void SubirCasta()
        +void ChequearProductividad()*
    }

    class Casta {
        <<abstract>>
        +static Casta Jarl
        +static Casta Karl
        +static Casta Thrall
        +Casta? SubirCasta()*
        +bool CanSubirCasta()*
        +void AplicarBeneficios()*
    }

    %% Clases Concretas de Castas
    class JarlCasta {
        <<Casta Inicial>>
    }

    class KarlCasta {
        <<Casta Intermedia>>
    }

    class ThrallCasta {
        <<Casta Máxima>>
    }

    %% Tipos de Vikingos
    class Soldado {
        +int Arma
        +int VidasCobradas
        +void SetArma(int)
        +void SetVidasCobradas(int)
        +void IncrementarVidasCobradas(Soldado)
    }

    class Granjero {
        +float Hectareas
        +int CantHijos
        +void SetHectareas(float)
        +void SetCantHijos(int)
    }

    %% Expedición
    class Expedicion {
        +List~Vikingo~ Vikingos
        +int RealizarExpedicion(Lugar)
        +void AgregarVikingo(Vikingo)
        +void SetVikingos(List~Vikingo~)
    }

    %% Lugar y sus componentes
    class Lugar {
        +Capital? Capital
        +Aldea? Aldea
    }

    class Capital {
        +int CantDefensores
        +float Botin
        +float RiquezaTierra
        +float BotinTotal()
    }

    class Aldea {
        +Iglesia? Iglesia
        +Amurallada? Amurallada
    }

    class Iglesia {
        +float Crucifijos
        +float BotinCrucifijos()
    }

    class Amurallada {
        +int MinimoVikingos
    }

    %% Relaciones
    IProductividad <|.. Vikingo : implements
    Vikingo <|-- Soldado : inherits
    Vikingo <|-- Granjero : inherits
    Vikingo --> Casta : association (1)
    Casta <|-- JarlCasta : inherits
    Casta <|-- KarlCasta : inherits
    Casta <|-- ThrallCasta : inherits
    Expedicion --> Vikingo : composition (1..*)
    Expedicion --> Lugar : association
    Lugar --> Capital : aggregation (0..1)
    Lugar --> Aldea : aggregation (0..1)
    Aldea --> Iglesia : aggregation (0..1)
    Aldea --> Amurallada : aggregation (0..1)
```

## Descripción de Clases

### Clases Abstractas

| Clase | Descripción |
|-------|-------------|
| `Vikingo` | Clase base abstracta para todos los tipos de vikingos. Implementa `IProductividad`. |
| `Casta` | Clase base abstracta para el sistema de castas. Implementa patrón Singleton con propiedades estáticas. |

### Clases Concretas de Castas

| Clase | Descripción |
|-------|-------------|
| `JarlCasta` | Representa la casta inicial. Singleton accesible vía `Casta.Jarl`. |
| `KarlCasta` | Representa la casta intermedia. Singleton accesible vía `Casta.Karl`. |
| `ThrallCasta` | Representa la casta máxima. Singleton accesible vía `Casta.Thrall`. |

### Tipos de Vikingos

| Clase | Atributos | Productividad |
|-------|-----------|---------------|
| `Soldado` | `Arma`, `VidasCobradas` | ≥20 vidas cobradas |
| `Granjero` | `Hectareas`, `CantHijos` | ≥2 hectáreas por hijo |

### Sistema de Expediciones

| Clase | Descripción |
|-------|-------------|
| `Expedicion` | Contiene una lista de vikingos productivos y realiza expediciones a lugares. |
| `Lugar` | Puede contener una Capital y/o una Aldea. |
| `Capital` | Tiene defensores y riqueza de tierra. Calcula botín total. |
| `Aldea` | Tiene una Iglesia O una estructura Amurallada (exclusivo). |
| `Iglesia` | Contiene crucifijos que se convierten en botín (x2.5). |
| `Amurallada` | Requiere mínimo de vikingos para ser saqueada. |

## Patrones de Diseño Utilizados

1. **Strategy**: Las clases de castas encapsulan el comportamiento de cada casta.
2. **Singleton**: Las castas (Jarl, Karl, Thrall) son singletons accesibles mediante propiedades estáticas.
3. **Template Method**: La clase `Vikingo` define el método `SubirCasta()` que usa métodos abstractos de `Casta`.
