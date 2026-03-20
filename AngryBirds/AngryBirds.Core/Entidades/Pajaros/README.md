# Pájaros 🐦

Este directorio contiene las clases que representan los diferentes tipos de pájaros que pueden atacar a los cerditos.

## Clases

### PajaroComun.cs

La clase `PajaroComun` representa un pájaro básico de la isla. Su comportamiento es el más simple de todos.

**Herencia:** `PajaroComun` extiende de `Pajaro` (clase abstracta)

**Propiedades:**
- `Ira`: Nivel de ira del pájaro
- `Fuerza`: Fuerza del pájaro (calculada como `Ira × 2`)
- `EsFuerte`: Indica si la fuerza es mayor a 50

**Métodos:**
- `Enfadarse()`: Duplica la ira del pájaro

**Reglas:**
- La fuerza siempre es el doble de la ira

---

### Red.cs

La clase `Red` representa al pájaro rojo, conocido por ser rencoroso.

**Herencia:** `Red` extiende de `Pajaro` (clase abstracta)

**Propiedades:**
- `Ira`: Nivel de ira de Red
- `VecesEnojado`: Cantidad de veces que se enojó
- `Fuerza`: Calculada como `Ira × 10 × VecesEnojado`

**Métodos:**
- `Enfadarse()`: Incrementa en 1 la cantidad de veces que se enojó

**Reglas:**
- Red comienza con `VecesEnojado = 1`
- Cada vez que se enoja, incrementa el contador
- Su fuerza es multiplicativa con las veces que se enojó

---

### Bomb.cs

La clase `Bomb` representa al pájaro negro explosivo con un límite máximo de fuerza.

**Herencia:** `Bomb` extiende de `Pajaro` (clase abstracta)

**Propiedades:**
- `Ira`: Nivel de ira de Bomb
- `Fuerza`: Calculada como `Ira × 2`, con tope máximo
- `TopeMaximoActual`: Tope máximo de fuerza (por defecto 9000)

**Métodos:**
- `Enfadarse()`: Duplica la ira del pájaro

**Reglas:**
- La fuerza no puede superar el `TopeMaximoActual`
- El tope máximo puede ser modificado estáticamente

---

### Chuck.cs

La clase `Chuck` representa al pájaro amarillo cuya fuerza depende de su velocidad.

**Herencia:** `Chuck` extiende de `Pajaro` (clase abstracta)

**Propiedades:**
- `Velocidad`: Velocidad actual en km/h
- `Ira`: Igual a la velocidad
- `Fuerza`: Calculada según la velocidad

**Cálculo de Fuerza:**
| Velocidad | Fórmula | Resultado |
|-----------|---------|-----------|
| ≤ 80 km/h | Fija | 150 |
| > 80 km/h | 150 + 5 × (velocidad - 80) | Variable |

**Métodos:**
- `Enfadarse()`: Duplica la velocidad

**Reglas:**
- Hasta 80 km/h, la fuerza es constante (150)
- Cada km/h por encima de 80 suma 5 puntos de fuerza

---

### Terence.cs

La clase `Terence` representa al pájaro rojo gigante, hermano mayor de Red.

**Herencia:** `Terence` extiende de `Pajaro` (clase abstracta)

**Propiedades:**
- `Ira`: Nivel de ira de Terence
- `VecesEnojado`: Cantidad de veces que se enojó
- `Multiplicador`: Multiplicador de fuerza (puede cambiar)
- `Fuerza`: Calculada como `Ira × VecesEnojado × Multiplicador`

**Métodos:**
- `Enfadarse()`: Incrementa en 1 la cantidad de veces que se enojó
- `SetMultiplicador(int)`: Establece un nuevo multiplicador

**Validaciones:**
- El multiplicador debe ser un valor positivo

**Reglas:**
- Terence comienza con `VecesEnojado = 1` y `Multiplicador = 1`

---

### Matilda.cs

La clase `Matilda` representa al pájaro blanco que pone huevos al enojarse.

**Herencia:** `Matilda` extiende de `Pajaro` (clase abstracta)

**Propiedades:**
- `Ira`: Nivel de ira de Matilda
- `Huevos`: Lista de huevos puestos
- `Fuerza`: Calculada como `(Ira × 2) + Suma(Fuerza de huevos)`

**Métodos:**
- `Enfadarse()`: Pone un huevo de 2 kilos
- `AgregarHuevo(Huevo)`: Agrega un huevo adicional

---

### Huevo.cs

La clase `Huevo` representa un huevo puesto por Matilda.

**Propiedades:**
- `Peso`: Peso del huevo en kilos
- `Fuerza`: Igual al peso del huevo

---

## Herencia

```
Pajaro (abstracta)
├── PajaroComun
├── Red
├── Bomb
├── Chuck
├── Terence
└── Matilda
```

## Comparación de Fuerzas

| Pájaro | Fórmula de Fuerza | Ejemplo (ira=10) |
|--------|------------------|------------------|
| PajaroComun | Ira × 2 | 20 |
| Red | Ira × 10 × VecesEnojado | 100 (1 vez) |
| Bomb | Min(Ira × 2, 9000) | 20 |
| Chuck | 150 (≤80) o 150 + 5×(vel-80) | 150 (vel=50) |
| Terence | Ira × VecesEnojado × Multiplicador | 10 (1 vez, mult=1) |
| Matilda | (Ira × 2) + Σ(Huevos) | 20 (sin huevos) |

## Ejemplo de Uso

```csharp
// Crear un Red
Red red = new Red(ira: 10);
Console.WriteLine(red.Fuerza); // 100

// Red se enoja
red.Enfadarse();
Console.WriteLine(red.Fuerza); // 200 (10 × 10 × 2)

// Crear un Chuck
Chuck chuck = new Chuck(velocidad: 90);
Console.WriteLine(chuck.Fuerza); // 200 (150 + 5×10)

// Chuck se enoja
chuck.Enfadarse();
Console.WriteLine(chuck.Fuerza); // 350 (150 + 5×40)

// Crear una Matilda
Matilda matilda = new Matilda(ira: 15);
matilda.Enfadarse(); // Pone un huevo
Console.WriteLine(matilda.Fuerza); // 32 (15×2 + 2)
```
