
~~~mermaid

classDiagram
class Vikingo{
    <<abstract>>
    + bool productivo
}

class Soldado{
    + Casta casta
	+ string arma
	+ int vidasCobradas
}

class Granjero{
    + Casta casta
	+ int hectareas
	+ int cantidadHijos
}

class Expedicion{
    + List<Vikingo> vikingos
}

class Casta{
    <<enum>>
    Jarl
    Karl
    Thrall
}

class Capital{
    +Atributo
}

class Aldea{
    +Atributo
}

class AldeaAmurallada{
    +Atributo
}

Vikingo <-- Soldado
Vikingo <-- Granjero

~~~