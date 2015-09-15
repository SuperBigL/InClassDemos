<Query Kind="Expression">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from food in Items
group food by food.MenuCategory.Description 

//requires the creation of an anonymous type
from food in Items
group food by new {food.MenuCategory.Description, food.CurrentPrice}