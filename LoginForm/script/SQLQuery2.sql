
-- 
create proc sp_CreateCustomer
@Email nvarchar(50), 
@Gender nvarchar(10),
@name nvarchar(50)
as
begin
	if not exists (select * from Customers where Email = @Email)
	begin
		insert into Customers (Email, Gender, name)
		values(@Email,@Gender,@name)
	end
end
select * from Customers
go


go
alter proc getIdCustomer
@email varchar(50)
as
begin
	select Id_customer from Customers where Email = @Email
end


go
create proc getMaxIdCustomer
as
begin 
	select max(id_customer) from Customers	
end
go


go

create proc addCustomer 
@idcus int,@idBill int
as
begin 
	update Bills set Id_customer = @idcus
	where Id_bill = @idBill
end


go
-- drop proc FindCustomerById

create proc sp_FindCustomerById
@email varchar(50)
as
begin
	select * from Customers 
	where Email = @email
end




go
create proc getTotalPriceBill
@idBill int
as 
begin
	select SUM(totalPrice) from Bills_detail 
	where Id_bill = @idBill
end



go
create proc ChangeReward
@id_Customer int, @Point int
as
begin
	declare @Rewad int = 0;
	select @Rewad = reward from Customers
	where Id_customer = @id_Customer

	update Customers set Reward = @Rewad + @Point 
	where Id_customer = @id_Customer
end

go

create proc getRewardCustomer
@id_cutomer int
as
begin
	select Reward from Customers
	where Id_customer = @id_cutomer
end

go
alter proc [dbo].[getVoucherSendMail]
@id_type int
as
	begin
		declare @status int = 0
		if(exists(select Id_voucher from Vouchers where Status = @status))
		begin
			select * from Vouchers a,TypesVoucher b where a.Status = 0 and b.ID_Type = @id_type
		end
	end
GO
