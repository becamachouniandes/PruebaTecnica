CREATE PROCEDURE [dbo].[uspCreateUser]
	-- Add the parameters for the stored procedure here
	 @name VARCHAR(MAX),
	 @birth_date DATETIME,
	 @gender VARCHAR(1)
AS
BEGIN
	 INSERT INTO [dbo].[USER]([name],[birth_date],[gender])
	 VALUES(@name,@birth_date,@gender)
END
GO