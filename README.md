# TP1 - TL2 - 2024

## Ejercicio 2) a) Tipos de relaciones:

### Por agregación:

* Pedido - Cadete: El pedido debe subsistir si el cadete es eliminado y pasar a ser de otro cadete.
* Cadete - Cadeteria: La cadetería es donde se concentran los cadetes, por lo que si uno deja de existir, el otro tiene que seguir subsistiendo.

### Por composición:

* Cliente - Pedido: Si se elimina el cliente, se debe eliminar el pedido.

## 2) b) Métodos de clase:

### Clase Cadetería

* AltaPedido()
* AltaCadete()
* BajaCadete()
* ReasignarCadete()
* ModificarCadete()

### Clase Cadete

* AsignarPedido()
* ListarPedidos()
* CambiarEstadoPedido()
* EliminarPedido()

## 2) c) Encapsulamiento

A nivel general todos los atributos tienen que estar de manera privada, con sus respectivos getters y setters, en casos particulares se deja los métodos públicos para que se puedan acceder.

## 2) d) Constructores

Los constructores de cadetería y cadete los crearía con sus respectivos atributos, ya que son independientes entre sí. El de pedidos lo crearía además de con sus atributos, con los de cliente, ya que esta clase esta contenida en pedido.