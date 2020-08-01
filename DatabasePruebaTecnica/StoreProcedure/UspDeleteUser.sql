CREATE PROCEDURE [dbo].[uspDeleteUser]
	-- Add the parameters for the stored procedure here
	 @id int
AS
BEGIN
	DELETE [dbo].[USER] WHERE id = @id
END
GO