select * from tables
go

-- update data table
-- drop proc UpdateTable
create proc [dbo].[UpdateTable]
@name nvarchar(50), @Status nvarchar(20), @id int
as
	begin
			update tables set name = @name, Status = @Status where ID_Table = @id
	end

-- order ==================================================================
select * from tables
insert into Customers (Email, name,Gender) values
('tungnh230802@gmail.com','tung','nam')
select *from Customers
select * from Employees

select * from TypesOfBeverage
select * from Beverages
insert into Bills (DateCheckIn,DateCheckOut,Id_table,Id_customer,Id_employee)
values(GETDATE(), null, 3,1,3)
