--*******Create customer *********
/*INSERT INTO Customers ([Name],Address,City,State, PhoneNumber)
VALUES  ('Clark Kent','123 E Main St','Metropolis','NY',2105551212),
		('Bruce Wayne','456 Arkham Ave','Gotham','NY',3025555121),
		('Lois Lane','243 S 1st Ave','Metropolis','NY',3333333781)*/

-- cLARK CUST ID 1,BRUCE CUST ID 2, Lois cust id 3

--**** Create order *****
/*INSERT Orders (CustomerId, OrderTotal, OrderStatusId, OrderDate)
VALUES (3,10,2,'January 16,2018 18:30')*/

--******* Pizza order******
/*INSERT OrderItems(OrderId, SizeId, CrustId, Cheese,Sausage,Peperoni,Bacon,Onion,GreenPepper,Mushroom)
VALUES (3,1,1,0,1,1,1,1,0,1)*/

-- ***** Show all open orders ****
/*SELECT * FROM Orders
INNER JOIN Customers ON Orders.CustomerId = Customers.CustomerId
INNER JOIN OrderItems ON Orders.OrderId = OrderItems.OrderId
WHERE OrderStatusId = 1	
ORDER BY Orders.OrderDate	*/

/*UPDATE Orders SET [OrderDate] = 'January 15,2018'
WHERE OrderId =3 */

-- ***** how many pizzas were ordered today? ******
/*SELECT COUNT(*)AS pizzas
FROM OrderItems
INNER JOIN Orders ON OrderItems.OrderId = Orders.OrderId
WHERE Orders.OrderDate > 'January 16,2018' */

-- ***** Total gross for today? ******
/*SELECT SUM(OrderTotal) AS 'Total gross' 
FROM Orders
WHERE OrderDate > 'January 16,2018'; */




