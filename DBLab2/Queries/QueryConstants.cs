using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.Queries
{
    public class QueryConstants
    {
        public static string Query1Text = "Find Names of All Ingredients from a Selected Menu";
        public static string Query2Text = "Find Names of All Seasons that Have a Selected Dish in One of Their Menus";
        public static string Query3Text = "Find All Orders that Contain a Selected Dish";
        public static string Query4Text = "Find Names of All Menus that belong to a selected season";
        public static string Query5Text = "Find Names of All Dishes that contain a selected Ingredient";
        public static string Query6Text = "Find Names of All Menus that have at least all the dishes that has another selected menu";
        public static string Query7Text = "Find All Orders that ordered exactly the same food as a selected order";
        public static string Query8Text = "Find Names of All Menus that have all their dishes available in a selected season";

        public static string Query1Content = "select Name from Ingredients where Ingredients.Id in ( select Ingredient_Id	from IngredientDishes where Dish_Id in ( select Dish_Id from MenuDishes	where Menu_Id in (	select Id from Menus where Name = '{0}')))";
        public static string Query2Content = "select Name from Seasons where Seasons.Id in(select SeasonId from Menus where Menus.Id in (select Menu_Id from MenuDishes where Dish_Id in (select Id from Dishes where Dishes.Name = '{0}')))";
        public static string Query3Content = "select * from Orders where Orders.Id in (select Order_Id from OrderDishes where Dish_Id in (select Id from Dishes where Dishes.Name ='{0}' ))";
        public static string Query4Content = "select Name from Menus where SeasonId in (select Id from Seasons where Seasons.Name = '{0}')";
        public static string Query5Content = "select Name from Dishes where Id in (select dish_id from IngredientDishes where Ingredient_Id in (select Id from Ingredients where Name = '{0}'))";
        public static string Query6Content = "select Name from Menus where Id in (select M.Menu_Id from MenuDishes M where not exists ((select Id from Dishes where Id in (select Dish_Id from MenuDishes where Menu_Id = '{0}')) except (select Id from Dishes where Id in (select Dish_Id from MenuDishes where Menu_Id <> '{0}' and Menu_Id = M.Menu_Id))))";
        public static string Query7Content = "select * from Orders where Id in ( select Order_Id from OrderDishes O where (not exists ((select Dish_Id from OrderDishes where Order_Id = '{0}') except (select Dish_Id from OrderDishes where Order_Id <> '{0}' and Order_Id = O.Order_Id))) and (not exists ((select Dish_Id from OrderDishes where Order_Id <> '{0}' and Order_Id = O.Order_Id) except (select Dish_Id from OrderDishes where Order_Id = '{0}'))))";
        public static string Query8Content = "select Name from Menus where Id in (select M.Menu_Id from MenuDishes M where not exists ((select Id from Dishes where Id in (select Dish_Id from MenuDishes where Menu_Id = M.Menu_Id)) except (select Id from Dishes where Id in (select Dish_Id from MenuDishes where Menu_Id in ( select Id from Menus where SeasonId = '{0}')))))";
    }
}
