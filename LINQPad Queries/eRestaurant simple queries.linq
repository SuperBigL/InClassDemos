<Query Kind="Statements">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

Waiters

//Query to also view Waiter Data
from item in Waiters
select item

//method syntax to view Waiter data
Waiters.Select (item => item)

//alter the query syntax into a C# statement
var results = from item in Waiters
select item;
results.Dump();

//once the query has been create, tested, you will be able to 
//transfer the query with minor modoifications into your
public list<pocoObject> SomeBLLMethodName()
{
	//connect to your DAL Object : var contextvariable
	//do your query
	var results = from item in contextvariable.Waiters 
	select item;
	return results.ToList();
}}