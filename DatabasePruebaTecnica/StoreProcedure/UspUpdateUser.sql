CREATE PROCEDURE [dbo].[uspUpdateUser]
	-- Add the parameters for the stored procedure here
	 @id int,
	 @name VARCHAR(MAX),
	 @birth_date DATETIME,
	 @gender VARCHAR(1)
AS
BEGIN
	 UPDATE [dbo].[USER] SET [name] = @name , [birth_date]  = @birth_date,[gender] = @gender
	 WHERE id = @id
END
GO
