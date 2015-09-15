<Query Kind="Expression">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//where clause samples
//List all tables that hold more than 3 people
from row in Tables
where row.Capacity > 3
select row

//list all items that have more than 500 calories and sellf for more than $10
from foodies in Items
where foodies.Calories > 500
&& foodies.CurrentPrice > 10.00m
select foodies
//list all items that have more than 500 calories and are Entrees on the menu
//HINT: navigational properties of the database and LINQPad knowledge
from foodies in Items
where foodies.Calories > 500
&& foodies.MenuCategory.Description.Equals("Entree")
select foodies
