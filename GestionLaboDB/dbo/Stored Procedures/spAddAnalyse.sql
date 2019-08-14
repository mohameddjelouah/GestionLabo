CREATE PROCEDURE [dbo].[spAddAnalyse]


@Id int ,
@MaladeID int,
@Resultat NVARCHAR (MAX)
AS
begin
	
	set nocount on 

	insert into  dbo.Analyse (MaladeID,Resultat) values (@MaladeID,@Resultat) ;

end