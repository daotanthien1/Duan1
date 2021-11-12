alter table customers
add name nvarchar(50) not null

if OBJECT_ID ('sp_GetCustomers') is not null 
drop proc sp_GetCustomers
go 
create proc sp_GetCustomers
as
begin
      select  Name, Email, Gender,Id_customer,Reward  from Customers
end
-- exec sp_getcustomers
-- proc table
-- get data table

CREATE proc getDataTable
as
	begin
		select * from tables
	end
go
-- insert data table
create proc InsertDataTable
@name nvarchar(50), @Status nvarchar(20)
as
	begin
		insert into tables (name, Status) values(@name, @Status)
	end
go
-- Delete data table
create proc DeleteTable
@id int
as
	begin
		delete tables where ID_Table = @id
	end
go
-- search data table
create proc SearchTable
@name nvarchar(50)
as
	begin
		select * from tables where name like + '%' + @name + '%'
	end
go
-- update data table
create proc UpdateTable
@name nvarchar(50), @Status nvarchar(20), @id int
as
	begin
		if(not exists(select * from tables where name = @name))
		begin
			update tables set name = @name, Status = @Status where ID_Table = @id
		end
	end
go
=======
-- create proc for table
-- proc get table
go
create proc getDataTable
as
	begin
		select * from tables
	end
go
--proc insert table
create proc InsertDataTable
@name nvarchar(50), @Status nvarchar(20)
as
	begin
		insert into tables (name, Status) values(@name, @Status)
	end
go
-- proc update table
create proc UpdateTable
@name nvarchar(50), @Status nvarchar(20), @id int
as
	begin
		if(not exists(select * from tables where name = @name))
		begin
			update tables set name = @name, Status = @Status where ID_Table = @id
		end
	end
go
-- proc delete table
create proc DeleteTable
@id int
as
	begin
		delete tables where ID_Table = @id
	end
go
-- search name table
create proc SearchTable
@name nvarchar(50)
as
	begin
		select * from tables where name like + '%' + @name + '%'
	end


	if OBJECT_ID ('sp_CustomerUpdate') is not null 
drop proc sp_CustomerUpdate
go 
create PROCEDURE sp_CustomerUpdate(
                                          @Email   NVARCHAR(55),
                                          @Gender       NVARCHAR(10),
                                          @idCustomers       int,
                                          @reward int,
										  @name nvarchar(50))
AS
  BEGIN
        BEGIN
			if(not exists (select * from Customers where Email = @Email))
			begin
				update Customers
				set
				Email = @Email,
				Gender = @Gender,
				Reward = @reward,
				Name = @name
				where Id_customer = @idCustomers
			end
        END
END


if OBJECT_ID ('sp_CustomerSearch') is not null 
drop proc sp_CustomerSearch
go 
create PROCEDURE sp_CustomerSearch(@Email NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Email, Gender,Id_customer,Reward
			from Customers where Email like '%' + @Email + '%'
        END
END


select * from Employees

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GETNHANVIEN]
AS
BEGIN
		Select Id_role,Name,Gender,Email,Address,DayOfBirth,Salary from Employees
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_VAITRO]
AS
BEGIN
		SELECT * from Roles
END
GO

-- drop proc UPDATE_DATA_TO_EMPLOYEE
CREATE PROCEDURE [dbo].[UPDATE_DATA_TO_EMPLOYEE] 
@Id_role int,
@Name nvarchar(50),
@Gender int,
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date,
@Salary float
AS
BEGIN
		UPDATE Employees SET Id_role = Id_role,Address =  @Address, Gender = @Gender,
												Email = @Email, DayOfBirth = @DayOfBirth,Salary = @Salary,Name = @Name
												where Email = @Email
END
GO


CREATE PROCEDURE [dbo].[INSERT_DATA_TO_ROLES]
@Name nvarchar(20)
AS
BEGIN
		INSERT INTO ROLES(Name)
		VALUES(@Name)
END
GO


CREATE PROCEDURE [dbo].[UPDATE_DATA_TO_ROLES]
@id_role int,
@name nvarchar(50)
AS
BEGIN
		UPDATE Roles
		SET Name = @name 
		where Id_role = @id_role 
END
GO

exec UPDATE_DATA_TO_ROLES 34,'con à'
/****** Object:  StoredProcedure [dbo].[DELETE_DATA_FROM_ROLES]    Script Date: 11/5/2021 1:39:53 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DELETE_DATA_FROM_ROLES]
@name nvarchar(20)
AS
BEGIN
		DELETE FROM Roles
		where LOWER(Name) like N'%' + lower(@name) + '%'
END
GO


exec INSERT_DATA_TO_ROLES 'Quản thúc'
exec DELETE_DATA_FROM_ROLES 'Quản thúc'

/****** Object:  StoredProcedure [dbo].[GET_ROLES]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GET_ROLES]
AS
BEGIN
		Select Id_role,Name from Roles
END
GO

/****** Object:  StoredProcedure [dbo].[SEARCH_ROLES]    Script Date: 11/5/2021 1:39:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SEARCH_ROLES]
@Name nvarchar(50)
AS
BEGIN
		SET NOCOUNT ON;
		SELECT  Id_role,Name from Roles
		where LOWER(Name) like N'%' + lower(@Name) + '%'
END
GO

/****** Object:  StoredProcedure [dbo].[INSERT_VAITRO]    Script Date: 11/5/2021 1:39:53 PM ******/
--DBCC CHECKIDENT ('Roles', RESEED, 0) -- Reset identity to 0
--GO
--delete from Roles
--delete from Employees

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_VAITRO]
AS
BEGIN
		SELECT * from Roles
END
GO