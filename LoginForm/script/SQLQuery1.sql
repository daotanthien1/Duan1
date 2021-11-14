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
select * from bills
insert into Customers (Email, name,Gender) values
('tungnh230802@gmail.com','tung','nam')
select *from Customers
select * from Employees
select * from Bills_detail
select * from TypesOfBeverage
select * from Beverages
insert into Bills (DateCheckIn,DateCheckOut,Id_table,Id_customer,Id_employee)
values(GETDATE(), null, 3,1,1)

insert into Bills (DateCheckIn,DateCheckOut,Id_table,Id_customer,Id_employee)
values(GETDATE(), null, 1,1,1)

insert into Bills (DateCheckIn,DateCheckOut,Id_table,Id_customer,Id_employee, status)
values(GETDATE(), GETDATE(), 3,1,1, 1)

-- insert billdetail
insert into Bills_detail(Id_beverage,Id_bill,Quantity)
values (2,4,10)
go


-- drop proc getUnCheckBill
create proc getUncheckBill
@Id_table int
as
begin
	select * from bills 
	where Id_table = @Id_table and status = 0
end
go

exec getUncheckBill 3
go

-- drop proc getListBillDetail
create proc getListBillDetail 
@idBill int
as
begin 
	select * from Bills_detail
	where Id_bill = @idBill
end
go

-- drop proc getListMenu
create proc getListMenu
@Id_table int
as
begin
	select bv.Name,bd.Quantity, bv.Price, bd.totalPrice from Bills_detail as bd, Bills as b, Beverages as bv
	where bd.Id_bill = b.Id_bill and bd.Id_beverage = bv.Id_beverage
	and b.Id_table = @Id_table and B.status = 0
end
go

exec getListMenu 3

alter table Bills_detail
add totalPrice float null

alter table Bills_detail
add Id_Voucher varchar(6) null


alter table Bills_detail
add constraint fk_billDetail_id_voucher 
foreign key(Id_Voucher) references vouchers(Id_voucher)

-- drop proc getSumprice
go
create proc getSumprice
@id_table int 
as 
begin 
	select sum(bd.totalPrice) from Bills_detail as bd, Bills as b
	where bd.Id_bill = b.Id_bill and b.Id_table = @id_table and B.status = 0
end
go

create proc sp_GetBeverageById
@id_type int
as
begin
            SELECT name,price,id_type,id_beverage,image
            FROM   beverages where Id_type = @id_type

end
go


exec sp_GetBeverageById 1
