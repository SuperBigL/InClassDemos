<Query Kind="Expression">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

Waiters.ToList();

Waiters.First(person => person.FirstName.StartsWith("B"))

Waiters.Skip(5)