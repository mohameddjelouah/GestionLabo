CREATE PROCEDURE [dbo].[spGetMalade]
	
@Id int
	AS
begin
	set nocount on;
	SELECT * from dbo.Malades where Id = @Id;
end