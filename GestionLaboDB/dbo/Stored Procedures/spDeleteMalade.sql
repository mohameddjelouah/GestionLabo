CREATE PROCEDURE [dbo].[spDeleteMalade]



@Id int
AS
begin
	
	set nocount on 

	delete from dbo.Malades where Id = @Id;
	
	

end