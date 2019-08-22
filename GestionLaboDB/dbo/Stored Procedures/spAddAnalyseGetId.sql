CREATE PROCEDURE [dbo].[spAddAnalyseGetId]


@Id int ,
@MaladeID int,
@Resultat NVARCHAR (MAX)
AS
begin
	
	set nocount on 

	insert into  dbo.Analyse (MaladeID,Resultat) values (@MaladeID,@Resultat) ; SELECT CAST(SCOPE_IDENTITY() as int) ;

end