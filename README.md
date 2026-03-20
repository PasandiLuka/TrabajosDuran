# TrabajosDuran 📚

> **Contiene diferentes proyectos para refrescar la memoria**

Este repositorio alberga una colección de proyectos desarrollados como parte de trabajos académicos y profesionales. Cada proyecto está diseñado para practicar y mantener frescos los conocimientos en desarrollo de software, patrones de diseño, arquitectura limpia y pruebas unitarias.

## Proyectos

### 🐦 AngryBirds

El **Proyecto AngryBirds** es una implementación del dominio del juego clásico de pájaros vs cerditos. El sistema modela diferentes tipos de pájaros con comportamientos únicos, calcula sus fuerzas basándose en diversos factores (ira, velocidad, huevos), y gestiona el ataque a la isla Cerdito para recuperar los huevos robados.

#### Estructura del Proyecto AngryBirds

La solución sigue una arquitectura limpia dividida en dos proyectos:

* **`AngryBirds.Core/`**: Biblioteca de dominio que contiene toda la lógica de negocio:
  * **Entidades/Pajaros**: Tipos de pájaros (Red, Chuck, Bomb, Terence, Matilda, PajaroComun)
  * **Entidades/Islas**: Gestión de islas (IslaPajaro, IslaCerdito)
  * **Entidades/Obstaculos**: Obstáculos (ParedVidrio, ParedMadera, ParedPiedra, CerditoObrero, CerditoArmado)
  * **Entidades/Eventos**: Eventos (SesionManejoIra, InvasionCerditos, FiestaSorpresa)
  * **Entidades/Abstract**: Clase abstracta base Pajaro
  * **Interfaces**: Contratos del dominio (IPajaro, IIsla, IObstaculo, IEvento)
  * **Enum**: Enumeraciones del sistema

* **`AngryBirds.Test/`**: Proyecto de pruebas unitarias con xUnit para verificar el correcto funcionamiento de todas las entidades.

#### Documentación Técnica

- [Documentación AngryBirds](./AngryBirds/README.md)
- [AngryBirds.Core](./AngryBirds/AngryBirds.Core/README.md)
- [AngryBirds.Test](./AngryBirds/AngryBirds.Test/README.md)

#### Tecnologías Utilizadas

* **Lenguaje:** C#
* **Framework:** .NET 9.0
* **Testing:** xUnit

#### Instalación y Ejecución

```bash
cd AngryBirds
dotnet build
dotnet test
```

---

### 🛡️ Vikingos

El **Proyecto Vikingos** es una simulación orientada a objetos que permite gestionar expediciones vikingas. El sistema evalúa las características de diferentes tipos de vikingos (como Soldados y Granjeros) para determinar si son "productivos". Luego, permite agrupar a estos vikingos en expediciones para atacar distintos lugares (Aldeas o Capitales). El núcleo del programa calcula de forma automática si la expedición tiene los números suficientes para superar las defensas enemigas y si el botín obtenido hace que el ataque sea rentable.

#### Estructura del Proyecto Vikingos

La solución está dividida en dos partes principales para mantener una arquitectura limpia:

* **`biblioteca/`**: Es el corazón del sistema. Contiene toda la lógica de negocio, las interfaces, los enumerados y las entidades del dominio organizadas en:
  * **Entidades/Lugares**: Clases relacionadas con los lugares a expedicionar (Aldea, Capital, Iglesia, Amurallada, Lugar)
  * **Entidades/VikingosTipo**: Tipos de vikingos (Soldado, Granjero)
  * **Entidades/Abstract/VikingosAbstract**: Clase abstracta base Vikingo
  * **Entidades/Abstract/Casta**: Sistema de castas (Jarl, Karl, Thrall)
  * **Entidades/CastaAbstract**: Implementaciones concretas de cada casta
  * **Interfaces**: Contratos del dominio (IProductividad)
  * **Enum**: Enumerados del sistema

* **`TestUnitarios/`**: Proyecto dedicado a las pruebas automatizadas para asegurar que las reglas de negocio y los cálculos funcionen correctamente.

#### Documentación Técnica

- [Documentación Vikingos](./Vikingos/detalles.md)
- [Biblioteca Vikingos](./Vikingos/biblioteca/Entidades/README.md)

#### Tecnologías Utilizadas

* **Lenguaje:** C#
* **Framework:** .NET 9.0
* **Testing:** xUnit (con soporte para Coverlet para cobertura de código)

#### Instalación y Ejecución

```bash
cd Vikingos
dotnet build
dotnet test
```
