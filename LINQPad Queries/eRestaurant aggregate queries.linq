<Query Kind="Expression">
  <Connection>
    <ID>d7f12ea0-1fde-4a03-a5e8-0dedfe763ab7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from category in MenuCategories
select new
{
    Category = category.Description,
    Items = category.Items.Count()
}

from category in MenuCategories
select new
{
    Category = category.Description,
    Items = (from x in category.Items select x).Count()
}

(from theBill in BillItems
where theBill.BillID == 104
select theBill.SalePrice * theBill.Quantity).Sum()

BillItems
	.Where (theBill => theBill.BillID == 104)
	.Select(theBill => theBill.SalePrice + theBill.Quantity)
	.Sum()
	
(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Count()).Average()
	
	