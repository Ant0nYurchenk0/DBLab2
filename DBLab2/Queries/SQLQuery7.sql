select Id from Orders where Id in (
select Order_Id from OrderDishes O where
(not exists 
((select Dish_Id from OrderDishes where Order_Id = '4')
except
(select Dish_Id from OrderDishes where Order_Id <> '4' and Order_Id = O.Order_Id)))
and
(not exists
((select Dish_Id from OrderDishes where Order_Id <> '4' and Order_Id = O.Order_Id)
except
(select Dish_Id from OrderDishes where Order_Id = '4'))))