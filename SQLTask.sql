/*������� 1 - ������� �������� ������
1) ������� ������������� ��������, ��� ��������, ����� � �����
*/
SELECT [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[Color]
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
/*
2) ������� ������������ ���������, ���, ����� � �������
*/
SELECT [CustomerID]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Phone]
  FROM [AdventureWorksLT2019].[SalesLT].[Customer]
/*
������� 2 - ���������� ������ (�������� �������������, �������� � ����� �������� + ������� ������� �����������)
1) ������� ��� �������� ������� �����
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Color = 'Black'
 /*
2) ������� ��� �������� ������� � ������ ����� ��� ���������� ������
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Color IN('Black','Silver','Multi')
/*
3) ������� ��� �������� ������� ��� �������
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Color IN('Black','Yellow')
/*
4) ������� �������� ��� ������� �� ������
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight is null
/*
5) ������� �������� ��� ������� ������ 1000
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight >1000
/*
6) ������� �������� ��� ������� ������ 6000
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight <6000
/*
7) ������� �������� ��� ������� ������ 2000 � ������ 5000 (������������ �������� BETWEEN)
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where Weight between 2000 and 5000
/*
8) ������� �������� ����� �������� ������� ���������� � BK ��� BB (LIKE)
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where ProductNumber Like 'B[K,B]%'
/*
9) ������� ��������, ������� ������� ��� �� �����������
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  where SellEndDate is null
/*
������� 3 - ����������
1) ������� �������� ������������ �� �����
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Color
/*
2) ������� �������� ������������ �� ����� �� ����������� � �� ���� �� ��������
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Color ASC, Weight DESC
/*
3) ������� �������� ������������ �� ������ �������� �� �����������, � �� ������ ����� ��������
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by ProductNumber ASC, Weight DESC
/*
������� 4 - ��������� (paging, �������� �� ���������)
1) ������� 10 ������ ���������
*/
SELECT TOP 10 *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
/*
2) ������� 10 ������ ��������� �� ���������������  �� ����
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Weight 
  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
/*
3) ������� 10 ��������� ��������� �� ��������������� �� ����
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Weight 
  OFFSET (Select Count(*)-10 from [AdventureWorksLT2019].[SalesLT].[Product])ROWS FETCH NEXT 10 ROWS ONLY
/*
4) ������� 10 "������" ��������� (2-� ��������, ������ �������� 10) �� ��������������� �� ����
*/
SELECT *
  FROM [AdventureWorksLT2019].[SalesLT].[Product]
  Order by Weight 
  OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY
/*
������� 5 - ���������� (joins)
1) ������� �� ��������, ���, �����, ����, ��� � ����, �� ������� ������� � ������ (� ���������)
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
2) ������� ������������ ���������, ���, ����� � �������, �����, ������, �������� ��� � �����
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
3) ������� �� ��������, ���, �����, ��������� (������������) � ������������ (���� ����)
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
������� 6 - �����������
1) ���������� ����� ���-�� ���������
*/
select count(*)
from SalesLT.Product
/*
2) ���������� ���-�� ���������, ������� ������� ���������
*/
select count(*)
from SalesLT.Product prod
where prod.SellEndDate is not null
/*
3) ���������� ���-�� ���������, ��� ������� �� ������
*/
select count(*)
from SalesLT.Product prod
where prod.Weight is null
/*
4) ���������� ������� ��� ���������, ��� ������� �� ������
*/
select avg(prod.Weight)
from SalesLT.Product prod
where prod.Weight is not null
/*
5) ���������� ������� ��� ���� ���������
*/
select avg(prod.Weight)
from SalesLT.Product prod
/*
6) ��������� ���� � ��� ��� ��� ���������
*/
select max(prod.Weight) 'Max'
	  ,min(prod.Weight) 'Min'
from SalesLT.Product prod
/*
7) ������������� �������� �� ����������, ������� �� ���������, �������� � ���-�� ��������� � ���������, ��������� ��� ��������� � ���������, ���� ��� � ���������, ��� ��� � ���������, ������� ��� � ���������
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
8) ������������� �������� �� ����������, ������� �� ���������, �������� � ��������� ��� ��������� � ���������
*/
select prodCat.ProductCategoryID
      ,prodCat.Name		
	  ,sum(prod.Weight) 'Sum'
from SalesLT.Product prod
	join SalesLT.ProductCategory prodCat
	on prod.ProductCategoryID = prodCat.ProductCategoryID
Group by prodCat.ProductCategoryID,prodCat.Name
/*
9) �� ���������� ����������� ������� ������ ��, ���������, ��� ������� MAX, MIN, SUM ��� AVG NULL
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
10) �� ���������� ����������� ������� ������ �� ���������, ��� ������� ���� ��� ����� 10000
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
������� 7 - ����������� (��� ��� ���� ����� �������� ���, � ��� ���������)+ADO
1) ������� �� � ��� ��������� � ��������� ��������� ���� ��������� � ���, ������� ���� �������
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
2) ������� ���� ���������� � ������� ���� ������ ����� ���� ��������� ������ ����������� 40 � ����� ���������
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
3) ������� �� � ��� ���� ����������, � ������� ��������� ��������� �������� ��������� ����� 15000
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