CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id,
		   FirstName,
		   LastName
	FROM [dbo].[User] WITH (NOLOCK)
	WHERE Id = @Id;
END