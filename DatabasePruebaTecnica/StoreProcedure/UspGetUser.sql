CREATE PROCEDURE [dbo].[uspGetUser]
	-- Add the parameters for the stored procedure here
	 @id int
AS
BEGIN
	SELECT TOP 1 * FROM [dbo].[USER] where id  = @id

RETURN
END
GO
