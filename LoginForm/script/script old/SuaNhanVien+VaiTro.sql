-- Search Employee --

alter PROCEDURE [dbo].[SEARCH_EMPLOYEE]
@Name nvarchar(50),
@Id_role int
AS
BEGIN
		SET NOCOUNT ON;
		SELECT  Id_role,Name,Gender,Email,Address,DayOfBirth,Salary from Employees
		where LOWER(Name) like N'%' + lower(@Name) + '%' and Id_role = @Id_role and isDelete = 0
END
GO

--Login --

alter PROCEDURE [dbo].[LOGIN] @EMAIL VARCHAR(50), @PASSWORD NVARCHAR(100)
AS 
BEGIN
	DECLARE @STATUS INT
	IF EXISTS(SELECT * FROM Employees 
	WHERE Email = @EMAIL AND Password = @PASSWORD AND isDelete = 0)
		BEGIN
			SET @STATUS = 1
		END
	ELSE 
		SET @STATUS = 0
	SELECT @STATUS
END
GO

-- VaitroPhanQuyen --
CREATE PROCEDURE LayVaiTroNV @email varchar(50)
AS
BEGIN
	Declare @Status int,@vaitro int
	Set @vaitro = (select Id_role from Employees where Email = @email)
if (@vaitro = 1)
	set @Status = 1
else	
	set @Status = 0

select @Status
END

--Tim Id_employee--
alter PROCEDURE LayId_EMP @email varchar(50)
AS
BEGIN
	select Id_employee from Employees where Email = @email
END