CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,
		   FirstName,
		   LastName
	FROM [dbo].[User] WITH (NOLOCK);
END