﻿create database DuAn1;
GO

use DuAn1;
GO

create table Roles
(
	Id_role int identity primary key,
	Name nvarchar(20) NOT NULL
);
Go

create table Employees
(
	Id_role int NOT NULL,
	Gender nvarchar(10) NOT NULL, -- nam || nữ
	Email nvarchar(50) NOT NULL,
	Address nvarchar(100) NOT NULL,
	Password varchar(100) DEFAULT('1292201552198220877194054219216496220885'),
	DayOfBirth date NOT NULL,
	Id_employee int identity(1,1) primary key NOT NULL,
	Name nvarchar(50) NOT NULL,
	Salary float NOT NULL,
	constraint fk_idRole foreign key (Id_role) references Roles (Id_role)
);
Go

Create table TypesVoucher
(
	ID_Type int identity primary key not null,
	Sale float not null -- loại giảm giá (vd:20%,30%,...)
)
GO

create table Vouchers
(
	Id_voucher varchar(6) primary key,
	DateBegin date not null default(getdate()),
	DateEnd date,
	Id_employee int not null,
	ID_Type int not null,
	Status int not null DEFAULT(0), -- chưa dùng || đã dùng
	constraint FK_Id_employe_voucher foreign key (Id_employee) references Employees(Id_employee),
	constraint FK_Id_TypeVoucher_voucher foreign key (ID_Type) references TypesVoucher(ID_Type)
);
Go


create table Shifts
(
	TimeBegin VARCHAR(10) not null,
	TimeEnd VARCHAR(10) not null,
	Id_shift int primary key,
);
Go

create table Schedules
(
	Id_schedule int identity primary key,
	Id_employee int not null,
	Id_shift int not null,
	Days int, -- các ngày nhân viên làm trong tuần (vd: 234 thì làm t2,t3,t4)
	constraint FK_Id_employee_schedule foreign key (Id_employee) references Employees(Id_employee),
	constraint FK_Id_Shift foreign key (Id_shift) references Shifts(Id_shift)
);
Go

create table TypesOfIngredient
(
	Id_type int identity primary key not null,
	Name nvarchar(50)
);
Go

create table Suppliers
(
	Name nvarchar(50) not null,
	Id_supplier int identity primary key not null,
	Email nvarchar(50) not null,
	Address nvarchar(100) not null
);
Go

create table Ingredients
(
	Id_ingredient int identity primary key,
	Name nvarchar(100) not null,
	Id_supplier int not null,
	Id_type int not null,
	Price float not null,
	Constraint FK_ID_Type foreign key(Id_type) references TypesOfIngredient(Id_type),
	Constraint FK_ID_supplier foreign key (Id_supplier) references Suppliers(Id_supplier)
);
Go

create table InputBills
(
	ID_Bill int identity primary key,
	DateCheckIn datetime not null default(getdate()),
	ID_employee int not null,
	Constraint FK_ID_employee foreign key (ID_employee) references employees(ID_employee)
)

Create table units -- đơn vị (vd:kg,lít,..)
(
	ID_unit int identity primary key,
	Name nvarchar(20)
)

Create table InputBillsDetaill
(
	Id_BillDetaill int identity primary key,
	quantity float not null,
	Id_unit int not null,
	Id_Ingredient int not null,
	ID_Bill int not null,
	Constraint FK_ID_unit foreign key(Id_unit) references units(Id_unit),
	Constraint FK_ID_ingredient foreign key(Id_Ingredient) references Ingredients(Id_Ingredient),
	Constraint FK_ID_InputBills foreign key(ID_Bill) references InputBills(ID_Bill),
)

create table TypesOfBeverage
(
	Id_type int identity primary key,
	Name nvarchar(50) not null
);
Go

create table Beverages
(
	Name nvarchar(55) not null,
	Price float not null,
	Id_type int not null,
	Id_beverage int primary key identity,
	Image nvarchar(500) not null,
	constraint FK_Id_type_Beverages foreign key (Id_type) references TypesOfBeverage (Id_type)
);
Go

create table Bills_detail
(
	Id_bill int primary key identity,
	Quantity int not null,
	Id_beverage int not null,
	constraint FK_Id_beverage_Bill_detail foreign key(Id_beverage) references Beverages(Id_beverage)
);
Go

create table Customers
(
	Email nvarchar(50) not null,
	Gender nvarchar(10) not null, -- nam || nữ
	Id_customer int primary key identity,
	Reward int not null default(0) -- điểm khách hàng thân thiết
);
Go

Create table tables
(
	ID_Table int primary key identity,
	name nvarchar(50) not null,
	Status nvarchar(20) not null default(N'trống') -- có người || trống
)

create table Bills(
	Id_employee int not null,
	Id_bill int primary key identity,
	Id_customer int not null,
	Id_table int  not null,
	DateCheckIn date  not null,
	Constraint FK_Id_employee_Employee foreign key (Id_employee) references Employees(Id_employee),
	Constraint FK_Id_bill_BillDetail foreign key(Id_bill) references Bills_detail (Id_bill),
	constraint FK_Id_customer foreign key(Id_customer) references Customers(Id_customer),
	constraint FK_Id_table foreign key(Id_table) references tables(Id_table)
);
go

-- drop proc dbo.LOGIN
CREATE PROCEDURE [dbo].[LOGIN] @EMAIL VARCHAR(50), @PASSWORD NVARCHAR(100)
AS 
BEGIN
	DECLARE @STATUS INT
	IF EXISTS(SELECT * FROM Employee 
	WHERE Email = @EMAIL AND Password = @PASSWORD)
		SET @STATUS = 1
	ELSE 
		SET @STATUS = 0
	SELECT @STATUS
END
GO


/****** Object:  StoredProcedure [dbo].[FORGOT_PASSWORD]    Script Date: 11/5/2021 1:37:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FORGOT_PASSWORD] @EMAIL varchar(50)
AS
BEGIN
	Declare @STATUS int

if exists(select Id_employee from Employee where Email = @EMAIL)
	set @STATUS = 1
else
	set @STATUS = 0
select @STATUS
END
GO

/****** Object:  StoredProcedure [dbo].[CHANGE_PASSWORD]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CHANGE_PASSWORD] 
@EMAIL varchar(50),
@OLDPASS nvarchar(50),
@NEWPASS nvarchar(50)
AS
BEGIN
		DECLARE @OP varchar(50)
		SELECT @OP = Password from Employee where Email = @EMAIL
		IF @OP = @OLDPASS
		BEGIN 
		UPDATE Employee SET Password = @NEWPASS where Email = @EMAIL
		return 1
		END
		ELSE
		return -1
END
GO

/****** Object:  StoredProcedure [dbo].[INSERT_DATA_TO_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_DATA_TO_EMPLOYEE] 
@Id_role int,
@Name nvarchar(50),
@Gender int,
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date,
@Salary float,
@Password varchar(50)
AS
BEGIN
		INSERT INTO Employee(Id_role,Gender,Email,Address,Password,DayOfBirth,Name,Salary)
		VALUES(@Id_role,@Gender,@Email,@Address,@Password,@DayOfBirth,@Name,@Salary)
END
GO

/****** Object:  StoredProcedure [dbo].[UPDATE_DATA_TO_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPDATE_DATA_TO_EMPLOYEE] 
@Name nvarchar(50),
@Gender int,
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date
AS
BEGIN
		UPDATE Employee SET Address =  @Address, Gender = @Gender,
												Email = @Email, DayOfBirth = @DayOfBirth
												where Email = @Email
		
END
GO

/****** Object:  StoredProcedure [dbo].[UPDATE_DATA_TO_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DELETE_DATA_FROM_EMPLOYEE] @Email varchar(50)
AS
BEGIN
		DELETE from Employee 
		where Email = @Email
END
GO

/****** Object:  StoredProcedure [dbo].[SEARCH_EMPLOYEE]    Script Date: 11/5/2021 1:39:53 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SEARCH_EMPLOYEE]
@Name nvarchar(50)
AS
BEGIN
		SET NOCOUNT ON;
		SELECT  Name,Gender,Id_role,Email,Address,DayOfBirth,Salary from Employee 
		where Name like '%' + @Name + '%'
END
GO

--@tenNv nvarchar(50)
--AS
--BEGIN
--			Set nocount on;
--			select Email,TenNV,DiaChi,VaiTro,TinhTrang from NhanVien 
--			where TenNV like '%' + @tenNv + '%'
--END


-- Beverage
-- beverage insert
if OBJECT_ID ('sp_BeverageInsert') is not null 
drop proc sp_BeverageInsert
go 
create PROCEDURE sp_BeverageInsert(
                                          @Name   NVARCHAR(55),
                                          @Price       int,
                                          @id_type        int,
                                          @image nvarchar(500))
AS
  BEGIN

        BEGIN
			insert into Beverages(Name,Price,Id_type,Image)
			values(@Name,@Price,@id_type,@image)
        END
	END

-- exec sp_BeverageInsert 'Tra Sua',50000,1,'sdfsdf'
-- beverage update
if OBJECT_ID ('sp_BeverageUpdate') is not null 
drop proc sp_BeverageUpdate
go 
create PROCEDURE sp_BeverageUpdate(
                                          @Name   NVARCHAR(55),
                                          @Price       int,
                                          @id_type        int,
                                          @image nvarchar(500),
										  @id_beverage int)
AS
  BEGIN

        BEGIN
			update Beverages
			set Name = @Name,
				Price = @Price,
				Id_type = @id_type,
				Image = @image
			where Id_beverage = @id_beverage

        END
	END

--	exec sp_BeverageUpdate 'trasua1',60000,1,'eeeee',1
--  beverage delete
if OBJECT_ID ('sp_BeverageDelete') is not null 
drop proc sp_BeverageDelete
go 
create PROCEDURE sp_BeverageDelete(@Name   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			delete Beverages
			where Name like '%'+@Name+'%'
        END
	END

--	exec sp_BeverageDelete 3
-- beverage search
if OBJECT_ID ('sp_BeverageSearch') is not null 
drop proc sp_BeverageSearch
go 
create PROCEDURE sp_BeverageSearch(@Name   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name,Price,Id_type,Id_beverage,Image
			from	Beverages where Name like '%'+@Name+'%'

        END
	END

-- exec sp_BeverageSearch 'trasua1'

-- TypeOfBeverage
-- TypeOfBeverage insert
if OBJECT_ID ('sp_TypeOfBeverageInsertDeleteSearch') is not null 
drop proc sp_TypeOfBeverageInsertDeleteSearch
go 
create PROCEDURE sp_TypeOfBeverageInsertDeleteSearch(   @Name   NVARCHAR(55),
										@StatementType nvarchar(20) = '')
AS
  BEGIN
	IF @StatementType = 'Insert'
        BEGIN
			insert into TypesOfBeverage(Name)
			values(@Name)
        END
	IF @StatementType = 'Delete'
        BEGIN
			delete TypesOfBeverage
			where Name like '%'+@Name+'%'
        END
	IF @StatementType = 'Search'
        BEGIN
			select Id_type, Name 
			from TypesOfBeverage where Name like '%'+@Name+'%'
        END
	END
-- exec sp_TypeOfBeverageInsertDeleteSearch 'Tra Sua','Delete'

if OBJECT_ID ('sp_TypeOfBeverageUpdate') is not null 
drop proc sp_TypeOfBeverageUpdate
go 
create PROCEDURE sp_TypeOfBeverageUpdate (  @Name   NVARCHAR(55),
											@id_type int)
										
AS
  BEGIN
		update TypesOfBeverage
		set Name = @Name
		where Id_type = @id_type
	END
-- exec sp_TypeOfBeverageUpdate 'nuocngot1',2

-- ****** SimpleForMe ******

-- INGREDIENT
-- Insert Ingredient
if OBJECT_ID ('sp_IngredientInsert') is not null 
drop proc sp_IngredientInsert
go 
create PROCEDURE sp_IngredientInsert (@Name nvarchar(100),
									  @Id_supplier int,
									  @Id_type int,
								 	  @Price float)
										
AS
  BEGIN
		insert into Ingredients(Name,Id_supplier,Id_type,Price)
		values(@Name,@Id_supplier,@Id_type,@Price)
	END
-- exec sp_IngredientInsert 'Duong', 1, 1, 20000

--Update Ingredient
if OBJECT_ID ('sp_IngredientUpdate') is not null 
drop proc sp_IngredientUpdate
go 
create PROCEDURE sp_IngredientUpdate(@Name nvarchar(100),
									  @Id_supplier int,
									  @Id_type int,
								 	  @Price float,
									  @Id_ingredient int)
AS
  BEGIN
		update Ingredients
		set Name = @Name,
			Id_supplier = @Id_supplier,
			Id_type = @Id_type,
			Price = @Price
		where Id_ingredient = @Id_ingredient
	END
-- exec sp_IngredientUpdate 'Bot ngot', 1, 1, 50000, 1

-- Delete Ingredient
if OBJECT_ID ('sp_IngredientDelete') is not null 
drop proc sp_IngredientDelete
go 
create PROCEDURE sp_IngredientDelete(@Id_ingredient int)
AS
  BEGIN
		delete Ingredients
		where Id_ingredient = @Id_ingredient
	END
-- exec sp_IngredientDelete 1

-- Search Ingredient
if OBJECT_ID ('sp_IngredientSearch') is not null 
drop proc sp_IngredientSearch
go 
create PROCEDURE sp_IngredientSearch(@Name NVARCHAR(100))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_type, Price, Id_supplier
			from Ingredients where Name like '%' + @Name + '%'
        END
	END
-- exec sp_IngredientSearch 'Bot ngot'

-- TYPE OF INGREDIENT
-- Insert Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientInsert') is not null 
drop proc sp_TypeOfIngredientInsert
go 
create PROCEDURE sp_TypeOfIngredientInsert (@Name nvarchar(50))
										
AS
  BEGIN
		insert into TypesOfIngredient(Name)
		values(@Name)
	END
-- exec sp_TypeOfIngredientInsert 'Bot'

-- Update Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientUpdate') is not null 
drop proc sp_TypeOfIngredientUpdate
go 
create PROCEDURE sp_TypeOfIngredientUpdate(@Name nvarchar(50),
										   @Id_type int)
AS
  BEGIN
		update TypesOfIngredient
		set Name = @Name
		where Id_type = @Id_type
	END
-- exec sp_TypeOfIngredientUpdate 'Dau', 1

-- Delete Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientDelete') is not null 
drop proc sp_TypeOfIngredientDelete
go 
create PROCEDURE sp_TypeOfIngredientDelete(@Id_type int)
AS
  BEGIN
		delete TypesOfIngredient
		where Id_type = @Id_type
	END
-- exec sp_TypeOfIngredientDelete 1

-- Search Type of Ingredient
if OBJECT_ID ('sp_TypeOfIngredientSearch') is not null 
drop proc sp_TypeOfIngredientSearch
go 
create PROCEDURE sp_TypeOfIngredientSearch(@Name NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_type
			from TypesOfIngredient where Name like '%' + @Name + '%'
        END
	END
-- exec sp_TypeOfIngredientSearch 'Dau'

-- SUPPLIER
-- Insert Supplier
if OBJECT_ID ('sp_SupplierInsert') is not null 
drop proc sp_SupplierInsert
go 
create PROCEDURE sp_SupplierInsert (@Name nvarchar(50),
									@Email nvarchar(50),
									@Address nvarchar(100))
									
AS
  BEGIN
		insert into Suppliers(Name, Email, Address)
		values(@Name, @Email, @Address)
	END
-- exec sp_SuppliersInsert 'Dong A', 'donga@gmail.com', 'Binh Thanh'

-- Update Supplier
if OBJECT_ID ('sp_SupplierUpdate') is not null 
drop proc sp_SupplierUpdate
go 
create PROCEDURE sp_SupplierUpdate(@Name nvarchar(50),
								   @Email nvarchar(50),
								   @Address nvarchar(100),
								   @Id_supplier int)
AS
  BEGIN
		update Suppliers
		set Name = @Name,
			Email = @Email,
			Address = @Address
		where Id_supplier = @Id_supplier
	END
-- exec sp_SupplierUpdate 'Dong Au', 'dongau@gmail.com', 'Binh Chanh', 1

-- Delete Supplier
if OBJECT_ID ('sp_SupplierDelete') is not null 
drop proc sp_SupplierDelete
go 
create PROCEDURE sp_SupplierDelete(@Id_supplier int)
AS
  BEGIN
		delete Suppliers
		where Id_supplier = @Id_supplier
	END
-- exec sp_SupplierDelete 1

-- Search Supplier
if OBJECT_ID ('sp_SupplierSearch') is not null 
drop proc sp_SupplierSearch
go 
create PROCEDURE sp_SupplierSearch(@Name NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_supplier
			from Suppliers where Name like '%' + @Name + '%'
        END
	END
-- exec sp_SupplierSearch 'Dong A'
