--get product categories
select cat_name
from category cat
inner join prod_cat pc 
on cat.id = pc.cat_id 
where pc.prod_id = 3;