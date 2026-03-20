# Islas 🏝️

Este directorio contiene las clases que representan las islas del juego AngryBirds.

## Clases

### IslaPajaro.cs

La clase `IslaPajaro` representa la isla donde viven los pájaros. Gestiona la colección de pájaros y sus operaciones.

**Propiedades:**
- `Nombre`: Nombre de la isla ("Isla Pájaro")
- `Pajaros`: Lista de pájaros que habitan la isla
- `PajarosFuertes`: Pájaros con fuerza mayor a 50 (solo lectura)
- `FuerzaTotal`: Suma de la fuerza de todos los pájaros fuertes (solo lectura)

**Métodos:**
- `AgregarPajaro(IPajaro)`: Agrega un nuevo pájaro a la isla
- `AplicarEvento(IEvento)`: Aplica un evento a todos los pájaros de la isla
- `Atacar(IslaCerdito)`: Lanza todos los pájaros contra la isla Cerdito

**Reglas:**
- Los pájaros fuertes son aquellos con fuerza > 50
- La fuerza total es la suma de las fuerzas de los pájaros fuertes
- Al atacar, cada pájaro impacta en el primer obstáculo disponible

---

### IslaCerdito.cs

La clase `IslaCerdito` representa la isla donde los cerdos tienen los huevos robados. Contiene obstáculos que deben ser destruidos.

**Propiedades:**
- `Nombre`: Nombre de la isla ("Isla Cerdito")
- `Obstaculos`: Lista de obstáculos en la isla
- `HuevosRecuperados`: Indica si todos los obstáculos fueron destruidos (solo lectura)

**Métodos:**
- `AgregarObstaculo(IObstaculo)`: Agrega un nuevo obstáculo a la isla
- `RecibirAtaque(IPajaro)`: Recibe el ataque de un pájaro en el primer obstáculo en pie
- `LimpiarObstaculosDestruidos()`: Elimina los obstáculos que ya no están en pie

**Reglas:**
- Los huevos se consideran recuperados cuando no hay obstáculos o todos están destruidos
- Cada ataque impacta en el primer obstáculo que está en pie
- Un obstáculo se destruye cuando su resistencia actual llega a 0 o menos

---

## Relaciones

```
IslaPajaro
└── Lista<IPajaro>
    ├── PajaroComun
    ├── Red
    ├── Bomb
    ├── Chuck
    ├── Terence
    └── Matilda

IslaCerdito
└── Lista<IObstaculo>
    ├── ParedVidrio
    ├── ParedMadera
    ├── ParedPiedra
    ├── CerditoObrero
    └── CerditoArmado
```

## Flujo de Ataque

1. `IslaPajaro.Atacar(IslaCerdito)` es llamado
2. Por cada pájaro en la isla:
   - Se obtiene el primer obstáculo en pie
   - Se llama a `obstaculo.RecibirAtaque(pajaro.Fuerza)`
   - El obstáculo reduce su resistencia actual
3. Después del ataque, se puede verificar `islaCerdito.HuevosRecuperados`

## Ejemplo de Uso

```csharp
// Crear isla Pájaro con pájaros
var islaPajaro = new IslaPajaro();
islaPajaro.AgregarPajaro(new Red(ira: 10));
islaPajaro.AgregarPajaro(new Chuck(velocidad: 80));

// Obtener información de la isla
var fuertes = islaPajaro.PajarosFuertes;
int fuerzaTotal = islaPajaro.FuerzaTotal;

// Crear isla Cerdito con obstáculos
var islaCerdito = new IslaCerdito();
islaCerdito.AgregarObstaculo(new CerditoObrero());
islaCerdito.AgregarObstaculo(new ParedVidrio(ancho: 3));

// Atacar
islaPajaro.Atacar(islaCerdito);

// Limpiar obstáculos destruidos
islaCerdito.LimpiarObstaculosDestruidos();

// Verificar si se recuperaron los huevos
if (islaCerdito.HuevosRecuperados)
{
    Console.WriteLine("¡Huevos recuperados!");
}
```

## Aplicar Eventos

```csharp
// Crear un evento
IEvento evento = new SesionManejoIra();

// Aplicar a la isla
islaPajaro.AplicarEvento(evento);

// También se puede con eventos complejos
var eventos = new List<IEvento>
{
    new InvasionCerditos(300),
    new SesionManejoIra()
};
islaPajaro.AplicarEvento(new SerieEventosDesafortunados(eventos));
```
