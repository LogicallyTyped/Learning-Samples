CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[User] (FirstName, LastName)
	VALUES (@FirstName, @LastName);
	SELECT SCOPE_IDENTITY() AS Id; -- Return the Id of the newly inserted record
END