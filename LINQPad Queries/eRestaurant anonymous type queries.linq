<Query Kind="Expression">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from food in Items
where food.MenuCategory.Description.Equals("Entree") &&
food.Active
orderby food.CurrentPrice descending
select new
			{
			 food.Description, 
			food.CurrentPrice,
			 food.CurrentCost, 
			Profit = food.CurrentPrice - food.CurrentCost
			} 