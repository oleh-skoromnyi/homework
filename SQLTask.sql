/*Задание 1 - простая проекция данных
1) Вывести Идентификатор продукта, имя продукта, номер и цвета
*/
SELECT [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[Color]
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
/*
2) вывести идентификтор кастомера, фио, емейл и телефон
*/
SELECT [CustomerID]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Phone]
  FROM [AdventureWorksLT2019].[SalesLT].[Customer]
/*
Задание 2 - фильтрация данных (выводить идентификатор, название и номер продукта + атрибут который упоминается)
1) Вывести все продукты черного цвета
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Color = 'Black'
 /*
2) Вывести все продукты черного И серого цвета ИЛИ нескольких цветов
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Color IN('Black','Silver','Multi')
/*
3) Вывести все продукты черного ИЛИ желтого
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Color IN('Black','Yellow')
/*
4) Вывести продукты Вес которых не указан
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight is null
/*
5) Вывести продукты вес которых больше 1000
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight >1000
/*
6) Вывести продукты вес которых меньше 6000
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight <6000
/*
7) Вывести продукты вес которых больше 2000 и меньше 5000 (использовать оператор BETWEEN)
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight between 2000 and 5000
/*
8) Вывести продукты номер продукта которых начинается с BK ИЛИ BB (LIKE)
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where ProductNumber Like 'B[K,B]%'
/*
9) Вывести продукты, продажи которых еще не закончились
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where SellEndDate is null
/*
Задание 3 - сортировка
1) Вывести продукты отсортировав по цвету
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Color
/*
2) Вывести продукты отсортировав по цвету по возростанию и по весу по убыванию
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Color ASC, Weight DESC
/*
3) Вывести продукты отсортировав по номеру продукта по возростанию, и по убываю весеа продукта
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by ProductNumber ASC, Weight DESC
/*
Задание 4 - пагинация (paging, разбивка по страницам)
1) Вывести 10 первых продуктов
*/
SELECT TOP 10 *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
/*
2) Вывести 10 первых продуктов из отсортированных  по весу
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Weight 
  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
/*
3) Вывести 10 последних продуктов из отсортированных по весу
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Weight 
  OFFSET (Select Count(*)-10 from [AdventureWorksLT2019].[SalesLT].[Product])ROWS FETCH NEXT 10 ROWS ONLY
/*
4) Вывести 10 "вторых" продуктов (2-я страница, размер страницы 10) из отсортированных по весу
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Weight 
  OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY
/*
Задание 5 - соединения (joins)
1) Вывести ид продукта, имя, номер, цвет, вес и цену, по которой продали и скидку (в процентах)
*/
SELECT prod.ProductID
	  ,prod.Name
	  ,prod.ProductNumber
	  ,prod.Color
	  ,prod.Weight
	  ,sod.UnitPrice
	  ,sod.UnitPriceDiscount*100 'Discount in procent'
  FROM [SalesLT].[SalesOrderDetail] sod
   JOIN SalesLT.Product prod
   on sod.ProductID = prod.ProductID
/*
2) Вывести идентификтор кастомера, фио, емейл и телефон, город, страну, почтовый код и адрес
*/
SELECT customer.CustomerID
	  ,customer.LastName
	  ,customer.MiddleName
	  ,customer.FirstName
	  ,customer.EmailAddress
	  ,customer.Phone
	  ,addr.City
	  ,addr.CountryRegion
	  ,addr.PostalCode
	  ,addr.AddressLine1
	  ,addr.AddressLine2
  FROM [SalesLT].[Customer] customer
  JOIN SalesLT.CustomerAddress custAddr
  on customer.CustomerID = custAddr.CustomerID
  JOIN SalesLT.Address addr
  on addr.AddressID = custAddr.AddressID
/*
3) Вывести ид продукта, имя, номер, категорию (родительскую) и подкатегорию (если есть)
*/
select 
	 prod.ProductID
	,prod.Name
	,prod.ProductNumber
	,(Select prodCat1.Name 
	  from SalesLT.ProductCategory prodCat1 
	  where prodCat.ParentProductCategoryID=prodCat1.ProductCategoryID) 'Parent product category'
	,prodCat.Name
from SalesLT.Product prod
	JOIN SalesLT.ProductCategory prodCat
	ON prod.ProductCategoryID = prodCat.ProductCategoryID
/*
Задание 6 - группировка
1) Подсчитать общее кол-во продуктов
*/
select count(*)
from SalesLT.Product
/*
2) Подсчитать кол-во продуктов, продажи которых закончены
*/
select count(*)
from SalesLT.Product prod
where prod.SellEndDate is not null
/*
3) Подсчитать кол-во продуктов, вес которых не указан
*/
select count(*)
from SalesLT.Product prod
where prod.Weight is null
/*
4) Подсчитать средний вес продуктов, для которых он указан
*/
select avg(prod.Weight)
from SalesLT.Product prod
where prod.Weight is not null
/*
5) Подсчитать средний вес ВСЕХ продуктов
*/
select avg(prod.Weight)
from SalesLT.Product prod
/*
6) Вычислить макс и мин вес для продуктов
*/
select max(prod.Weight) 'Max'
	  ,min(prod.Weight) 'Min'
from SalesLT.Product prod
/*
7) Сгруппировать продукты по категориям, вывести ид категории, название и кол-во продуктов в категории, суммарный вес продуктов в категории, макс вес в категории, мин вес в категории, средний вес в категории
*/
select prodCat.ProductCategoryID
      ,prodCat.Name		
	  ,sum(prod.Weight) 'Sum'
	  ,max(prod.Weight) 'Max'
	  ,min(prod.Weight) 'Min'
	  ,avg(prod.Weight) 'Avg'
from SalesLT.Product prod
	join SalesLT.ProductCategory prodCat
	on prod.ProductCategoryID = prodCat.ProductCategoryID
Group by prodCat.ProductCategoryID,prodCat.Name
/*
8) Сгруппировать продукты по категориям, вывести ид категории, название и суммарный вес продуктов в категории
*/
select prodCat.ProductCategoryID
      ,prodCat.Name		
	  ,sum(prod.Weight) 'Sum'
from SalesLT.Product prod
	join SalesLT.ProductCategory prodCat
	on prod.ProductCategoryID = prodCat.ProductCategoryID
Group by prodCat.ProductCategoryID,prodCat.Name
/*
9) Из результата предыдущего запроса убрать те, категории, для которых MAX, MIN, SUM ИЛИ AVG NULL
*/
select prodCat.ProductCategoryID
      ,prodCat.Name		
	  ,sum(prod.Weight) 'Sum'
	  ,max(prod.Weight) 'Max'
	  ,min(prod.Weight) 'Min'
	  ,avg(prod.Weight) 'Avg'
from SalesLT.Product prod
	join SalesLT.ProductCategory prodCat
	on prod.ProductCategoryID = prodCat.ProductCategoryID
Group by prodCat.ProductCategoryID,prodCat.Name
Having sum(prod.Weight) is not null 
	   and max(prod.Weight)  is not null 
	   and min(prod.Weight)  is not null 
	   and avg(prod.Weight)  is not null 
/*
10) Из результата предыдущего вывести только те категории, для которых макс вес более 10000
*/
select prodCat.ProductCategoryID
      ,prodCat.Name		
	  ,sum(prod.Weight) 'Sum'
	  ,max(prod.Weight) 'Max'
	  ,min(prod.Weight) 'Min'
	  ,avg(prod.Weight) 'Avg'
from SalesLT.Product prod
	join SalesLT.ProductCategory prodCat
	on prod.ProductCategoryID = prodCat.ProductCategoryID
Group by prodCat.ProductCategoryID,prodCat.Name
Having sum(prod.Weight) is not null 
	   and max(prod.Weight)  is not null 
	   and min(prod.Weight)  is not null 
	   and avg(prod.Weight)  is not null 
	   and max(prod.Weight) > 10000

/*
Задание 7 - комплексное (тут уже надо самим подумать что, и как применить)+ADO
1) Вывести ид и имя категории и суммарную стоимость всех продуктов в ней, который были проданы
*/
select 
	 pc.ProductCategoryID
	,pc.Name
	,SUM(sod.UnitPrice) 'Total price of sold'
from SalesLT.Product prod
	JOIN SalesLT.ProductCategory pc
	ON pc.ProductCategoryID = prod.ProductCategoryID
	JOIN SalesLT.SalesOrderDetail sod
	ON sod.ProductID = prod.ProductID
Group by pc.ProductCategoryID,pc.Name
/*
2) Вывести всех кастомеров у который макс скидка когда либо купленого товара составбляет 40 и более процентов
*/
Select * 
from SalesLT.Customer cust1
	Where cust1.CustomerID IN(
		select cust.CustomerID
		from SalesLT.SalesOrderHeader soh
			JOIN SalesLT.Customer cust
			ON cust.CustomerID = soh.CustomerID
			JOIN SalesLT.SalesOrderDetail sod
			ON sod.SalesOrderID = soh.SalesOrderID
			group by cust.CustomerID
			having MAX(sod.UnitPriceDiscount)*100>=40)
/*
3) Вывести ид и фио всех кастомеров, у который суммарная стоимость купленых продуктов более 15000
*/
Select cust1.CustomerID
	  ,cust1.FirstName
	  ,cust1.MiddleName
	  ,cust1.LastName
from SalesLT.Customer cust1
	Where cust1.CustomerID IN(
		select cust.CustomerID
		from SalesLT.SalesOrderHeader soh
			JOIN SalesLT.Customer cust
			ON cust.CustomerID = soh.CustomerID
			JOIN SalesLT.SalesOrderDetail sod
			ON sod.SalesOrderID = soh.SalesOrderID
			group by cust.CustomerID
			having SUM(sod.UnitPrice)>15000)