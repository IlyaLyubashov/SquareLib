--В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. 
--Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
select p.name, cg.name from Product p
left join ProductGroup pcg
on p.id = pcg.product_id
join Category cg
on pcg.group_id = cg.id;