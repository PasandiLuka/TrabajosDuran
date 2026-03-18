# Documentación Técnica y Arquitectura ⚙️

Este documento detalla el diseño del modelo de dominio del sistema (ubicado en el proyecto `biblioteca`), sus relaciones y la responsabilidad de cada clase.

### Volver al README principal:
- [Main](./README.md)

## 🔗 Relaciones entre Clases
El proyecto se apoya fuertemente en los pilares de la Programación Orientada a Objetos:
* **Herencia:** Las clases `Soldado` y `Granjero` heredan de la clase abstracta base `Vikingo`.
* **Interfaces:** La clase `Vikingo` implementa la interfaz `IProductividad`, obligando a definir las reglas de productividad específicas en cada una de sus clases derivadas.
* **Composición y Agregación:**
  * Una `Expedicion` agrupa una lista de objetos `Vikingo`.
  * Un `Lugar` está compuesto por una `Capital` y/o una `Aldea`.
  * Una `Aldea` tiene una relación exclusiva: puede contener una `Iglesia` o una estructura `Amurallada`, pero no ambas simultáneamente.

## 📦 Detalle y Uso de Clases

### Entidades Core (Vikingos)
* **`Vikingo` (Abstracta):** Define el estado base de cualquier guerrero (su casta actual y si es productivo). Define los métodos abstractos para subir de casta y chequear la productividad.
* **`Soldado`:** Especializado en combate. Depende de la cantidad de vidas cobradas y sus armas para ser productivo. Al subir de casta, mejora su armamento.
* **`Granjero`:** Especializado en agricultura. Su productividad se basa en tener suficientes hectáreas para mantener a sus hijos.
* **`Casta` (Enum):** Define la jerarquía social del sistema (`Jarl`, `Karl`, `Thrall`).

### Entidades de Logística (Expedición)
* **`Expedicion`:** Gestiona el grupo de asalto. Filtra a los vikingos para asegurarse de llevar solo a los productivos y contiene la lógica principal (`RealizarExpedicion`) para determinar matemáticamente si un ataque a un lugar tiene éxito o fracasa.

### Entidades de Entorno (Lugares)
* **`Lugar`:** Entidad agrupadora que define el objetivo geográfico de una expedición.
* **`Capital`:** Objetivo mayor defendido por un número de soldados y con una riqueza específica de la tierra. Su cruce define el botín total a saquear.
* **`Aldea`:** Objetivo menor que obliga a los vikingos a interactuar con subestructuras.
* **`Iglesia`:** Componente de la aldea que proporciona un botín directo a través de crucifijos.
* **`Amurallada`:** Estructura defensiva de la aldea que exige un número mínimo de vikingos para ser penetrada.

### Utilidades
* **`Validador`:** Clase estática de utilidad utilizada en todo el proyecto para sanitizar entradas (por ejemplo, asegurar que no se ingresen valores negativos en constructores o setters).

## Diagrama de Clases:

![Diagrama de clases](./UML.svg)