select Name from Menus where Id in 
(select M.Menu_Id from MenuDishes M where 
not exists 
((select Id from Dishes where Id in (select Dish_Id from MenuDishes where Menu_Id = M.Menu_Id))
except
(select Id from Dishes where Id in (select Dish_Id from MenuDishes where Menu_Id in (
select Id from Menus where SeasonId = '8')))))