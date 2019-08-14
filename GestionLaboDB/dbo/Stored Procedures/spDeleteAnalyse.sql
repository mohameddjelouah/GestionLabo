CREATE PROCEDURE [dbo].[spDeleteAnalyse]


@Id int ,
@MaladeID int
AS
begin
	
	set nocount on 

	delete from dbo.Analyse where Id = @Id and MaladeID = @MaladeID ;

end