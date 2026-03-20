# Abstract 📦

Este directorio contiene las clases abstractas que definen la estructura base del sistema AngryBirds.

## Clases

### Pajaro.cs

La clase `Pajaro` es una clase abstracta que representa el estado base de cualquier pájaro en la isla. Define la estructura común que todos los tipos de pájaros deben implementar.

**Herencia:** Implementa la interfaz `IPajaro`

**Propiedades:**
- `Ira`: Nivel de ira del pájaro (puede ser modificado)
- `Fuerza`: Fuerza del pájaro (solo lectura, implementada por subclases)
- `EsFuerte`: Indica si la fuerza es mayor a 50 (solo lectura)

**Métodos:**
- `Enfadarse()`: Método abstracto que debe ser implementado por cada tipo de pájaro

**Reglas:**
1. Cada subclase debe definir su propia fórmula de cálculo de fuerza
2. Cada subclase debe definir su propio comportamiento al enojarse
3. Un pájaro es fuerte cuando su fuerza supera los 50 puntos

**Excepciones:**
- Las subclases deben validar sus propios parámetros específicos

---

## Jerarquía de Clases

```
IPajaro (interfaz)
    ↑
Pajaro (abstracta)
    ├── PajaroComun (concreta)
    ├── Red (concreta)
    ├── Bomb (concreta)
    ├── Chuck (concreta)
    ├── Terence (concreta)
    └── Matilda (concreta)
```

---

## Interface IPajaro

La interfaz `IPajaro` define el contrato que todos los pájaros deben cumplir:

```csharp
public interface IPajaro
{
    int Ira { get; }
    int Fuerza { get; }
    bool EsFuerte { get; }
    
    void Enfadarse();
}
```

**Miembros:**
- `Ira`: Obtiene el nivel de ira actual
- `Fuerza`: Obtiene la fuerza calculada del pájaro
- `EsFuerte`: Indica si el pájaro es fuerte (fuerza > 50)
- `Enfadarse()`: Ejecuta la lógica de enojo específica del pájaro

---

## Comportamientos de Enojo

Cada tipo de pájaro implementa `Enfadarse()` de manera diferente:

| Pájaro | Comportamiento al Enfadarse |
|--------|----------------------------|
| PajaroComun | Duplica su ira |
| Red | Incrementa el contador de veces enojado |
| Bomb | Duplica su ira |
| Chuck | Duplica su velocidad |
| Terence | Incrementa el contador de veces enojado |
| Matilda | Pone un huevo de 2kg |

---

## Fórmulas de Fuerza

Cada tipo de pájaro calcula su fuerza de manera única:

| Pájaro | Fórmula |
|--------|---------|
| PajaroComun | `Ira × 2` |
| Red | `Ira × 10 × VecesEnojado` |
| Bomb | `Min(Ira × 2, TopeMaximo)` |
| Chuck | `150` (si vel ≤ 80) o `150 + 5 × (vel - 80)` |
| Terence | `Ira × VecesEnojado × Multiplicador` |
| Matilda | `(Ira × 2) + Σ(Peso de huevos)` |

---

## Ejemplo de Uso

```csharp
// Crear pájaros (usando clases concretas)
Pajaro pajaroComun = new PajaroComun(ira: 25);
Pajaro red = new Red(ira: 10);
Pajaro bomb = new Bomb(ira: 100);

// Verificar propiedades base
Console.WriteLine(pajaroComun.Ira);      // 25
Console.WriteLine(pajaroComun.EsFuerte); // True (50 > 50 es false, pero 25*2=50, no es fuerte)

// Usar polimorfismo
List<Pajaro> pajaros = new List<Pajaro>
{
    new PajaroComun(30),
    new Red(10),
    new Bomb(50)
};

// Enfadarse a todos
foreach (var pajaro in pajaros)
{
    pajaro.Enfadarse();
}

// Obtener pájaros fuertes
var fuertes = pajaros.Where(p => p.EsFuerte);

// Calcular fuerza total
int fuerzaTotal = fuertes.Sum(p => p.Fuerza);
```

---

## Notas de Implementación

- La clase `Pajaro` es abstracta, por lo que no puede ser instanciada directamente
- Cada subclase debe implementar la propiedad `Fuerza` con su propia lógica
- Cada subclase debe implementar el método `Enfadarse()` con su comportamiento específico
- La propiedad `EsFuerte` está implementada en la clase base y usa la propiedad `Fuerza`
