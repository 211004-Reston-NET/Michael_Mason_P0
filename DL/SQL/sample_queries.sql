--get product categories
SELECT cat.cat_name
FROM category cat, product prod
WHERE prod.id = 1

--get product categories
select cat_name
from category cat
inner join prod_cat_junc pcr 
on cat.id = pcr.cat_id 
where pcr.prod_id = 1;