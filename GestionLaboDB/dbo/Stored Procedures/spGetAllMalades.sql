CREATE PROCEDURE [dbo].[spGetAllMalades]

AS
begin
	set nocount on;
	SELECT * from dbo.Malades;
end