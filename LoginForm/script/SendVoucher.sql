-- proc get email for send voucher
create proc getEmailSendVoucher
@reward int
as
	begin
		select Email from Customers where Reward <= @reward
	end
go
-- proc get voucher for send mail to customer
create proc getVoucherSendMail
@id_type int
as
	begin
		declare @status int = 0
		if(exists(select Id_voucher from Vouchers where Status = @status))
		begin
			select a.Id_voucher from Vouchers a,TypesVoucher b where a.Status = 0 and b.ID_Type = @id_type
		end
	end
go
-- proc update voucher after send mail to customer
create proc UpdateVoucherForSend
@Id_voucher nvarchar(6)
as
	begin
		Update Vouchers set Status = 1 where Id_voucher = @Id_voucher
	end
go
-- update reward after send voucher mail to customer
create proc UpdateCustomerAfterSendVoucher
@email nvarchar(50)
as
	begin
		Update Customers set Reward = 0 where Email = @email
	end
go
-- proc get sale for configuration
create proc getConfigurationSale
@id int
as
	begin
		if(@id = 0)
			begin
				select ID_Type, Sale from TypesVoucher 
			end
		else
			begin
				select ID_Type, Sale from TypesVoucher where ID_Type = @id
			end
	end
go