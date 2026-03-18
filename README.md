# TrabajosDuran

Este repositorio contiene proyectos desarrollados como parte de trabajos académicos y profesionales.

## Proyectos

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

#### Tecnologías Utilizadas

* **Lenguaje:** C#
* **Framework:** .NET 9.0
* **Testing:** xUnit (con soporte para Coverlet para cobertura de código)

#### Instalación y Ejecución

Sigue estos pasos para probar el proyecto en tu entorno local:

1. **Clonar el repositorio:**
```bash
git clone https://github.com/PasandiLuka/TrabajosDuran.git
cd Vikingos
```

2. **Compilar la solución:**
```bash
dotnet build
```

3. **Ejecutar los test unitarios:**
```bash
dotnet test
```
