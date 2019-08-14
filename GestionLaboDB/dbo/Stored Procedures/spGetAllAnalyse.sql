CREATE PROCEDURE [dbo].[spGetAllAnalyse]


@Id int 
	
AS
begin
	set nocount on;
	SELECT * from dbo.Analyse
	where MaladeID = @Id ;
end