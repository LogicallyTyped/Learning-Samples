CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	-- we normaly don't delete records, but in this case we do
	DELETE
	FROM [dbo].[User]
	WHERE Id = @Id;
END
