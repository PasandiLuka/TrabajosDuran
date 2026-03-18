# Expedición 🚢

Este directorio contiene la clase que gestiona las expediciones vikingas.

## Clases

### Expedicion.cs

La clase `Expedicion` gestiona el grupo de asalto vikingo. Su responsabilidad principal es filtrar a los vikingos productivos y determinar si un ataque a un lugar tiene éxito.

**Propiedades:**
- `Vikingos`: Lista de vikingos que forman parte de la expedición (solo lectura)

**Métodos:**

| Método | Descripción |
|--------|-------------|
| `Expedicion(List<Vikingo>)` | Constructor que inicializa la expedición. Solo agrega vikingos que son productivos. |
| `RealizarExpedicion(Lugar)` | Ejecuta la expedición a un lugar específico y devuelve un código de resultado. |
| `AgregarVikingo(Vikingo)` | Agrega un nuevo vikingo a la expedición (debe ser productivo). |
| `SetVikingos(List<Vikingo>)` | Reemplaza completamente la lista de vikingos de la expedición. |

**Códigos de Retorno de RealizarExpedicion:**

| Código | Significado |
|--------|-------------|
| 1 | Expedición a capital exitosa |
| 2 | Expedición a aldea exitosa |
| 3 | Expedición a capital fallida (no rentable) |
| 4 | Expedición a aldea fallida (no rentable) |
| 5 | Expedición mixta parcialmente exitosa |

---

## Reglas de Negocio

### Para Capitales
- **Éxito:** La cantidad de vikingos debe ser mayor o igual a la cantidad de defensores
- **Rentabilidad:** El botín total × 3 debe ser mayor o igual a la cantidad de vikingos

### Para Aldeas con Iglesia
- **Rentabilidad:** El botín de crucifijos debe ser mayor o igual a 15

### Para Aldeas Amuralladas
- **Éxito:** La cantidad de vikingos debe ser mayor o igual al mínimo requerido

---

## Comportamiento del Constructor

Al crear una expedición, el constructor:
1. Itera sobre la lista de vikingos proporcionada
2. Verifica la productividad de cada vikingo llamando a `ChequearProductividad()`
3. Solo agrega a la expedición los vikingos que son productivos
4. Silenciosamente omite los vikingos no productivos (no lanzan excepción)

---

## Ejemplo de Uso

```csharp
// Crear vikingos productivos
var soldado = new Soldado(arma: 5);
soldado.SetVidasCobradas(25);

var granjero = new Granjero(hectareas: 10, cantHijos: 4);

// Crear expedición (automáticamente filtra vikingos no productivos)
var expedicion = new Expedicion(new List<Vikingo> { soldado, granjero });

// Crear lugar objetivo
var capital = new Capital(cantDefensores: 2, riquezaTierra: 2.5f);
var lugar = new Lugar(capital: capital, aldea: null);

// Realizar expedición
int resultado = expedicion.RealizarExpedicion(lugar);

switch (resultado)
{
    case 1:
        Console.WriteLine("¡Expedición a capital exitosa!");
        break;
    case 3:
        Console.WriteLine("Expedición a capital fallida.");
        break;
}

// Agregar más vikingos
expedicion.AgregarVikingo(nuevoVikingo);

// Reemplazar toda la lista
expedicion.SetVikingos(nuevaListaDeVikingos);
```

---

## Excepciones

| Método | Excepción | Condición |
|--------|-----------|-----------|
| `AgregarVikingo` | `ArgumentException` | El vikingo no es productivo |
| `SetVikingos` | `ArgumentException` | Alguno de los vikingos no es productivo |
| `RealizarExpedicion` | `ArgumentException` | La expedición no es rentable (solo para casos puros: capital o aldea) |

---

## Notas Importantes

1. **Filtrado automático:** El constructor filtra automáticamente los vikingos no productivos
2. **Validación estricta:** Los métodos `AgregarVikingo` y `SetVikingos` lanzan excepción si un vikingo no es productivo
3. **Resultados mixtos:** Cuando hay tanto capital como aldea, el método retorna códigos sin lanzar excepciones, permitiendo al llamador decidir cómo manejar los resultados parciales
