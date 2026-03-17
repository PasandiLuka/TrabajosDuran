# Proyecto Vikingos 🛡️🪓

## 📖 Funcionalidad del Proyecto
El **Proyecto Vikingos** es una simulación orientada a objetos que permite gestionar expediciones. El sistema evalúa las características de diferentes tipos de vikingos (como Soldados y Granjeros) para determinar si son "productivos". Luego, permite agrupar a estos vikingos en expediciones para atacar distintos lugares (Aldeas o Capitales). El núcleo del programa calcula de forma automática si la expedición tiene los números suficientes para superar las defensas enemigas y si el botín obtenido hace que el ataque sea rentable.

## Documentacion Tecnica
- [Documentacion](./detalles.md)

## 🏗️ Estructura del Proyecto
La solución está dividida en tres partes principales para mantener una arquitectura limpia:
* **`biblioteca/`**: Es el corazón del sistema. Contiene toda la lógica de negocio, las interfaces, los enumerados y las entidades del dominio (Vikingos, Lugares, Expediciones).
* **`Consola/`**: Es el punto de entrada ejecutable del programa, pensado para interactuar con la lógica desarrollada en la biblioteca.
* **`TestUnitarios/`**: Proyecto dedicado a las pruebas automatizadas para asegurar que las reglas de negocio y los cálculos funcionen correctamente.

## 💻 Tecnologías Utilizadas
* **Lenguaje:** C#
* **Framework:** .NET 9.0
* **Testing:** xUnit (con soporte para Coverlet para cobertura de código)

## 🚀 Instalación y Ejecución
Sigue estos pasos para probar el proyecto en tu entorno local:

1. **Clonar el repositorio:**
~~~bash
    git clone https://github.com/PasandiLuka/TrabajosDuran.git
    cd Vikingos
~~~

2. **Compilar la solución**
~~~bash
    dotnet build
~~~

3. **Ejectuar los test unitarios**
~~~bash
    dotnet test
~~~