INSERT INTO bills (Id_employee, Id_bill, Id_customer, Id_table,DateCheckIn,DateCheckOut,status)
VALUES (1,41,1,2,GETDATE(),GETDATE(),1);
select * from bills
INSERT INTO inputbills (ID_Bill,DateCheckIn,ID_employee,SumPrice)
VALUES (17,GETDATE(),1,1000);

SET IDENTITY_INSERT [dbo].[Bills] on

select * from bills where convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1;
---
drop proc sp_GetBillsNguyenLieuToday
create proc sp_GetBillsDoUongToday
as
begin
		select * from bills where convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
end
go
--drop proc sp_GetBillsNguyenLieuToday
create proc sp_GetBillsNguyenLieuToday
as
begin
		select * from inputbills where convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) 
end
go
--exec sp_GetBillsNguyenLieuToday
--drop proc sp_GetBillsDetailDoUong
create proc sp_GetBillsDetailDoUong( @id_bill int)
as
begin
	select * from Bills_detail where Id_bill = @id_bill 
end
go
-- drop proc sp_GetBillsDetailNL
create proc sp_GetBillsDetailNL( @id_bill int)
as
begin
	
	select * from InputBillsDetaill 
	where InputBillsDetaill.Id_bill = @id_bill 
end
go
-- exec sp_GetBillsDetailNL 11
if OBJECT_ID ('sp_BillDeleteDoUong') is not null 
drop proc sp_BillDeleteDoUong
go 
create PROCEDURE sp_BillDeleteDoUong(@id_bill int)
AS
  BEGIN

        BEGIN
			delete bills
			where Id_bill = @id_bill
        END
END

if OBJECT_ID ('sp_BillDeleteNL') is not null 
drop proc sp_BillDeleteNL
go 
create PROCEDURE sp_BillDeleteNL(@id_bill int)
AS
  BEGIN

        BEGIN
			delete InputBills
			where Id_bill = @id_bill
        END
END

if OBJECT_ID ('sp_BillsDetailDeleteNL') is not null 
drop proc sp_BillsDetailDeleteNL
go 
create PROCEDURE sp_BillsDetailDeleteNL(@id_bill int)
AS
  BEGIN

        BEGIN
			delete InputBillsDetaill
			where Id_BillDetaill = @id_bill
        END
END

if OBJECT_ID ('sp_BillsDetailDeleteDoUong') is not null 
drop proc sp_BillsDetailDeleteDoUong
go 
create PROCEDURE sp_BillsDetailDeleteDoUong(@id_bill int)
AS
  BEGIN

        BEGIN
			delete Bills_detail
			where Id_bill_detaill = @id_bill
        END
END
--exec sp_BillsDetailDeleteDoUong 33
-- exec sp_GetBillsDetailDoUong 31

if OBJECT_ID ('sp_UpdateBillsDetailDoUong') is not null 
drop proc sp_UpdateBillsDetailDoUong
go 
create PROCEDURE sp_UpdateBillsDetailDoUong(@quantity int,@id_bill int)
AS
  BEGIN

        BEGIN
			update Bills_detail
			set Quantity = @quantity
			where Id_bill_detaill = @id_bill
        END
END

if OBJECT_ID ('sp_UpdateBillsDetailNL') is not null 
drop proc sp_UpdateBillsDetailNL
go 
create PROCEDURE sp_UpdateBillsDetailNL(@quantity int,@id_bill int)
AS
  BEGIN

        BEGIN
			update InputBillsDetaill
			set Quantity = @quantity
			where Id_BillDetaill = @id_bill
        END
END
-- drop proc sp_BillsDetailSearch
create PROCEDURE sp_BillsDetailSearch(@Name   NVARCHAR(55),@Col   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			set nocount on;
			if @col = 'Id_Employee'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where Id_employee like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			if @col = 'Id_bill'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where Id_bill like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			if @col = 'Id_customer'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where Id_customer like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			if @col = 'Id_table'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where Id_table like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			if @col = 'DateCheckIn'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where DateCheckIn like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			if @col = 'DateCheckOut'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where DateCheckOut like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			if @col = 'status'
			begin
				select Id_employee,Id_bill,Id_customer,Id_table,DateCheckIn,DateCheckOut,status
				from Bills where status like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) and status = 1
			end
			
        END
	END

create PROCEDURE sp_InputBillsDetailSearch(@Name   NVARCHAR(55),@Col   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			set nocount on;
			if @col = 'ID_Bill'
			begin
				select ID_Bill, DateCheckIn,ID_employee,SumPrice
				from InputBills where ID_Bill like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) 
			end
			if @col = 'DateCheckIn'
			begin
				select ID_Bill, DateCheckIn,ID_employee,SumPrice
				from InputBills where DateCheckIn like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) 
			end
			if @col = 'ID_employee'
			begin
				select ID_Bill, DateCheckIn,ID_employee,SumPrice
				from InputBills where ID_employee like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102)  
			end
			if @col = 'SumPrice'
			begin
				select ID_Bill, DateCheckIn,ID_employee,SumPrice
				from InputBills where SumPrice like '%'+@Name+'%' and convert(varchar(10), DateCheckIn, 102) 
    = convert(varchar(10), getdate(), 102) 
			end
        END
	END