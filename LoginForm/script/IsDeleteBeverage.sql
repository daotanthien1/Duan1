--beverage isdelete
alter table Beverages
add isDelete bit DEFAULT(0)

update Beverages set isDelete = 0
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


		--get
if OBJECT_ID ('sp_GetBeverage') is not null 
drop proc sp_GetBeverage
go 
create proc sp_GetBeverage
as
begin
            SELECT name,price,id_type,id_beverage,image,isdelete
            FROM   beverages where isdelete = 0

end
go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


		
		--delete
if OBJECT_ID ('sp_BeverageDelete') is not null 
drop proc sp_BeverageDelete
go 
create PROCEDURE sp_BeverageDelete(@id_beverage   int)
AS
  BEGIN

        BEGIN
			UPDATE Beverages SET isDelete = 1 
			where id_beverage = @id_beverage
        END
	END
	--search
if OBJECT_ID ('sp_BeverageSearch') is not null 
drop proc sp_BeverageSearch
go 
create PROCEDURE sp_BeverageSearch(@Name   NVARCHAR(55),@Col   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			set nocount on;
			if @col = 'Name'
			begin
				select Name,Price,Id_type,Id_beverage,Image,isdelete
				from	Beverages where Name like '%'+@Name+'%' and isDelete = 0
			end
			if @col = 'Price'
			begin
				select Name,Price,Id_type,Id_beverage,Image
				from	Beverages where	price like '%'+@Name+'%' and isDelete = 0
			end
			if @col = 'Id_type'
			begin
				select Name,Price,Id_type,Id_beverage,Image
				from	Beverages where Id_type like '%'+@Name+'%' and isDelete = 0
			end
			if @col = 'Id_beverage'
			begin
				select Name,Price,Id_type,Id_beverage,Image
				from	Beverages where Id_beverage like '%'+@Name+'%' and isDelete = 0
			end
			if @col = 'Image'
			begin
				select Name,Price,Id_type,Id_beverage,Image
				from	Beverages where Image like '%'+@Name+'%' and isDelete = 0
			end
        END
	END