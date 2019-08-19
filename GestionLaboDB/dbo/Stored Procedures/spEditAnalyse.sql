CREATE PROCEDURE [dbo].[spEditAnalyse]


@Id int ,
@MaladeID int,
@Resultat NVARCHAR (MAX)
AS
begin
	
	set nocount on 

	update Analyse set Resultat = @Resultat  where Id = @Id and MaladeID = @MaladeID;

end