@automated
#language:ru-ru
Функция: Решение квадратного уравнения 

Сценарий: Игровой объект может перемещаться по прямой 
Дано космический корабль находится в точке пространства с координатами (12, 5)
И имеет мгновенную скорость (-5, 3)
Когда происходит прямолинейное равномерное движение без деформации
Тогда космический корабль перемещается в точку пространства с координатами (7, 8) 


Сценарий: Если невозможно определить текущее положение игрового объекта в пространстве, то перемещение по прямой невозможно 
Дано космический корабль, положение в пространстве которого невозможно определить
И имеет мгновенную скорость (-5, 3)
Когда происходит прямолинейное равномерное движение без деформации
Тогда возникает ошибка Exception 


Сценарий: Если невозможно определить мгновенную скорость игрового объекта, то перемещение по прямой невозможно 
Дано космический корабль находится в точке пространства с координатами (12, 5)
И скорость корабля определить невозможно
Когда происходит прямолинейное равномерное движение без деформации
Тогда возникает ошибка Exception 


Сценарий: Если невозможно изменить положение игрового объекта в пространстве, то перемещение по прямой невозможно 
Дано космический корабль находится в точке пространства с координатами (12, 5)
И имеет мгновенную скорость (-5, 3)
И изменить положение в пространстве космического корабля невозможно
Когда происходит прямолинейное равномерное движение без деформации
Тогда возникает ошибка Exception




Сценарий: Если топлива достаточно, то перемещение по прямой возможно
Дано космический корабль имеет топливо в объеме 40 ед
И имеет скорость расхода топлива при движении 2 ед
Когда происходит прямолинейное равномерное движение без деформации
Тогда новый объем топлива космического корабля равен 38 ед 

Сценарий: Если недостаточно количества топлива, то перемещение по прямой невозможно
Дано космический корабль имеет топливо в объеме 1 ед
И имеет скорость расхода топлива при движении 2 ед
Когда происходит прямолинейное равномерное движение без деформации
Тогда возникает ошибка Exception




Сценарий: Игровой объект может вращаться вокруг собственной оси 
Дано космический корабль имеет угол наклона 45 град к оси OX
И имеет мгновенную угловую скорость 45 град
Когда происходит вращение вокруг собственной оси
Тогда угол наклона космического корабля к оси OX составляет 90 град

Сценарий: Если невозможно определить угол наклона к оси OX космического корабля, то вращение вокруг собственной оси  невозможно 
Дано космический корабль, угол наклона которого невозможно определить
И имеет мгновенную угловую скорость 45 град
Когда происходит вращение вокруг собственной оси
Тогда возникает ошибка Exception

Сценарий: Если невозможно определить мгновенную угловую скорость космического корабля, то вращение вокруг собственной оси  невозможно 
Дано космический корабль имеет угол наклона 45 град к оси OX
И мгновенную угловую скорость невозможно определить
Когда происходит вращение вокруг собственной оси
Тогда возникает ошибка Exception 


Сценарий: Если невозможно установить новый угол наклона космического корабля космического корабля, то вращение вокруг собственной оси  невозможно 
Дано космический корабль имеет угол наклона 45 град к оси OX
И имеет мгновенную угловую скорость 45 град
И невозможно изменить уголд наклона к оси OX космического корабля
Когда происходит вращение вокруг собственной оси
Тогда возникает ошибка Exception