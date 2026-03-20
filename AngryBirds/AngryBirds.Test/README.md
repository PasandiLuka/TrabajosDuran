# AngryBirds.Test 🧪

Este proyecto contiene las pruebas unitarias del proyecto AngryBirds, implementadas con **xUnit**.

## Descripción

El proyecto `AngryBirds.Test` verifica el correcto funcionamiento de todas las entidades del dominio AngryBirds a través de pruebas unitarias automatizadas.

## Estruct del Proyecto

```
AngryBirds.Test/
├── TestRed.cs
├── TestBomb.cs
├── TestChuck.cs
├── TestTerence.cs
├── TestMatilda.cs
├── TestPajaroComun.cs
├── TestIslaPajaro.cs
├── TestIslaCerdito.cs
├── TestObstaculos.cs
├── TestEventos.cs
└── AngryBirds.Test.csproj
```

## Tecnologías

- **xUnit 2.9.2** - Framework de testing
- **Microsoft.NET.Test.Sdk 17.12.0** - SDK de pruebas
- **coverlet.collector 6.0.2** - Colección de cobertura de código
- **xunit.runner.visualstudio 2.8.2** - Integración con Visual Studio

## Cobertura de Pruebas

| Clase | Archivo de Test | Cantidad de Tests |
|-------|-----------------|-------------------|
| `Red` | TestRed.cs | 4 |
| `Bomb` | TestBomb.cs | 5 |
| `Chuck` | TestChuck.cs | 5 |
| `Terence` | TestTerence.cs | 5 |
| `Matilda` | TestMatilda.cs | 5 |
| `PajaroComun` | TestPajaroComun.cs | 4 |
| `IslaPajaro` | TestIslaPajaro.cs | 5 |
| `IslaCerdito` | TestIslaCerdito.cs | 7 |
| `Obstaculos` | TestObstaculos.cs | 9 |
| `Eventos` | TestEventos.cs | 8 |

**Total:** 54 pruebas unitarias

## Ejecutar Pruebas

### Desde la línea de comandos

```bash
# Ejecutar todas las pruebas
dotnet test AngryBirds.sln

# Ejecutar con detalle
dotnet test AngryBirds.sln --verbosity normal

# Ejecutar con cobertura
dotnet test AngryBirds.sln --collect:"XPlat Code Coverage"
```

### Desde Visual Studio

1. Abrir `AngryBirds.sln`
2. Ir a **Test > Run All Tests** (Ctrl+R, A)
3. O usar **Test Explorer** para ejecutar pruebas individuales

## Convenciones de Nomenclatura

Las pruebas siguen el patrón **Cuando-Entonces**:

```csharp
[Fact]
public void CuandoCreoUnRed_DebeCrearConLosDatosCorrectos()
{
    // Arrange
    int ira = 10;
    Red red = new Red(ira);

    // Act & Assert
    Assert.Equal(ira, red.Ira);
    Assert.Equal(1, red.VecesEnojado);
}
```

### Patrones de Nombre

| Patrón | Descripción | Ejemplo |
|--------|-------------|---------|
| `CuandoCreoX_DebeY` | Pruebas de construcción | `CuandoCreoUnRed_DebeCrearConLosDatosCorrectos` |
| `CuandoX_DebeY` | Pruebas de comportamiento | `CuandoRedSeEnoja_DebeIncrementarVecesEnojado` |
| `CuandoX_ConY_DebeZ` | Pruebas con condiciones | `CuandoFuerzaSuperaTope_DebeRespetarTopeMaximo` |
| `X_DebeY` | Pruebas simples | `RedConIraSuficiente_DebeSerFuerte` |

## Tipos de Pruebas

### Pruebas de Construcción
Verifican que los objetos se crean con los valores correctos:

```csharp
[Fact]
public void CuandoCreoUnBomb_DebeCrearConLosDatosCorrectos()
{
    Bomb bomb = new Bomb(ira: 100);
    Assert.Equal(100, bomb.Ira);
    Assert.Equal(200, bomb.Fuerza);
}
```

### Pruebas de Comportamiento
Verifican que los métodos producen el efecto esperado:

```csharp
[Fact]
public void CuandoChuckSeEnoja_DebeDuplicarVelocidad()
{
    Chuck chuck = new Chuck(velocidad: 50);
    chuck.Enfadarse();
    Assert.Equal(100, chuck.Velocidad);
}
```

### Pruebas de Excepciones
Verifican que se lanzan las excepciones correctas:

```csharp
[Fact]
public void CuandoSeteoMultiplicadorInvalido_DebeArrojarExcepcion()
{
    Terence terence = new Terence(10);
    Assert.Throws<ArgumentException>(() => terence.SetMultiplicador(0));
}
```

### Pruebas de Cálculo
Verifican fórmulas y cálculos complejos:

```csharp
[Fact]
public void CuandoVelocidadSupera80_DebeCalcularFuerzaAdicional()
{
    Chuck chuck = new Chuck(velocidad: 90);
    Assert.Equal(200, chuck.Fuerza); // 150 + 5×10
}
```

## Referencias

- Referencia a `AngryBirds.Core`

## Ejemplo Completo de Test

```csharp
using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestRed
{
    [Fact]
    public void CuandoRedSeEnojaVariasVeces_DebeCalcularFuerzaCorrectamente()
    {
        // Arrange
        Red red = new Red(ira: 5);

        // Act
        red.Enfadarse();
        red.Enfadarse();
        red.Enfadarse();

        // Assert
        Assert.Equal(4, red.VecesEnojado);
        Assert.Equal(200, red.Fuerza); // 5 × 10 × 4
    }
}
```

## Ver Más

- [Documentación de xUnit](https://xunit.net/docs)
- [AngryBirds.Core README](../AngryBirds.Core/README.md)
