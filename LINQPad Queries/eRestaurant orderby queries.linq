<Query Kind="Expression">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//orderby

from food in Items
orderby food.Description
select food

from food in Items
orderby food.Description
select food

from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
select food

from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
where food.MenuCategory.Equals("Entrees")

select food