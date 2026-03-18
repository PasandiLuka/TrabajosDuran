# Documentación Técnica y Arquitectura ⚙️

Este documento detalla el diseño del modelo de dominio del sistema (ubicado en el proyecto `biblioteca`), sus relaciones y la responsabilidad de cada clase.

## 📁 Estructura del Proyecto

La arquitectura del proyecto está organizada de la siguiente manera:

```
biblioteca/
├── Entidades/
│   ├── Lugares/           # Clases relacionadas con lugares a expedicionar
│   │   ├── Aldea.cs
│   │   ├── Amurallada.cs
│   │   ├── Capital.cs
│   │   ├── Iglesia.cs
│   │   └── Lugar.cs
│   ├── VikingosTipo/      # Tipos concretos de vikingos
│   │   ├── Soldado.cs
│   │   └── Granjero.cs
│   ├── Abstract/
│   │   ├── VikingosAbstract/  # Clases abstractas base de vikingos
│   │   │   └── Vikingo.cs
│   │   └── Casta/         # Sistema de castas abstracto
│   │       └── Casta.cs
│   ├── CastaAbstract/     # Implementaciones concretas de castas
│   │   ├── JarlCasta.cs
│   │   ├── KarlCasta.cs
│   │   └── ThrallCasta.cs
│   └── Expedicion/        # Gestión de expediciones
│       └── Expedicion.cs
├── Interfaces/
│   └── IProductividad.cs  # Contrato de productividad
└── Enum/
    └── Casta.cs           # Enumerado de castas (legacy)
```

### Volver al README principal:
- [Main](../../README.md)
- [Vikingos README](./README.md)

## 🔗 Relaciones entre Clases

El proyecto se apoya fuertemente en los pilares de la Programación Orientada a Objetos:

* **Herencia:** Las clases `Soldado` y `Granjero` heredan de la clase abstracta base `Vikingo` (ubicada en `Abstract/VikingosAbstract`).
* **Interfaces:** La clase `Vikingo` implementa la interfaz `IProductividad`, obligando a definir las reglas de productividad específicas en cada una de sus clases derivadas.
* **Composición y Agregación:**
  * Una `Expedicion` agrupa una lista de objetos `Vikingo`.
  * Un `Lugar` está compuesto por una `Capital` y/o una `Aldea`.
  * Una `Aldea` tiene una relación exclusiva: puede contener una `Iglesia` o una estructura `Amurallada`, pero no ambas simultáneamente.
* **Patrón Strategy:** El sistema de castas implementa el patrón Strategy para encapsular el comportamiento de cada casta (Jarl, Karl, Thrall).
* **Patrón Singleton:** Las castas (Jarl, Karl, Thrall) son instancias únicas que se comparten en toda la aplicación.

## 📦 Detalle y Uso de Clases

### Entidades Core (Vikingos)

#### Abstract/VikingosAbstract/Vikingo.cs
* **`Vikingo` (Abstracta):** Define el estado base de cualquier guerrero (su casta actual y si es productivo). Define los métodos abstractos para subir de casta y chequear la productividad.

#### VikingosTipo/Soldado.cs
* **`Soldado`:** Especializado en combate. Depende de la cantidad de vidas cobradas y sus armas para ser productivo. Al subir de casta, mejora su armamento.

#### VikingosTipo/Granjero.cs
* **`Granjero`:** Especializado en agricultura. Su productividad se basa en tener suficientes hectáreas para mantener a sus hijos.

### Sistema de Castas

#### Abstract/Casta/Casta.cs
* **`Casta` (Abstracta):** Clase base que define el comportamiento común de todas las castas. Implementa el patrón Singleton para las instancias Jarl, Karl y Thrall.

#### CastaAbstract/JarlCasta.cs
* **`JarlCasta`:** Representa la casta inicial de los vikingos. Permite subir a Karl.

#### CastaAbstract/KarlCasta.cs
* **`KarlCasta`:** Representa la casta intermedia. Permite subir a Thrall.

#### CastaAbstract/ThrallCasta.cs
* **`ThrallCasta`:** Representa la casta máxima. No permite subir más.

### Entidades de Logística (Expedición)

#### Expedicion/Expedicion.cs
* **`Expedicion`:** Gestiona el grupo de asalto. Filtra a los vikingos para asegurarse de llevar solo a los productivos y contiene la lógica principal (`RealizarExpedicion`) para determinar matemáticamente si un ataque a un lugar tiene éxito o fracasa.

### Entidades de Entorno (Lugares)

#### Lugares/Lugar.cs
* **`Lugar`:** Entidad agrupadora que define el objetivo geográfico de una expedición.

#### Lugares/Capital.cs
* **`Capital`:** Objetivo mayor defendido por un número de soldados y con una riqueza específica de la tierra. Su cruce define el botín total a saquear.

#### Lugares/Aldea.cs
* **`Aldea`:** Objetivo menor que obliga a los vikingos a interactuar con subestructuras.

#### Lugares/Iglesia.cs
* **`Iglesia`:** Componente de la aldea que proporciona un botín directo a través de crucifijos.

#### Lugares/Amurallada.cs
* **`Amurallada`:** Estructura defensiva de la aldea que exige un número mínimo de vikingos para ser penetrada.

## Diagrama de Clases:

![Diagrama de clases](./UML.svg)
