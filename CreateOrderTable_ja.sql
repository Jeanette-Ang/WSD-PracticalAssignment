/* 2. Create ORDER table */

/* 2.1: Create ORDER table */
CREATE TABLE ORDERTABLE (
OrderID INT NOT NULL,
FoodDescription NCHAR(50) NOT NULL,
DeliveryAddress NCHAR(50) NOT NULL,
DeliveryDate NCHAR(50) NOT NULL,
DeliveryTime NCHAR(50) NOT NULL,
EmailAddress NCHAR(50) NOT NULL,
ContactNumber NCHAR(8) NOT NULL,
OrderStatus NCHAR(50) NOT NULL,
CONSTRAINT OrderPK PRIMARY KEY CLUSTERED (OrderID)
);