CREATE PROCEDURE [dbo].[spAddMalade]



@Id int ,
@Nom NVARCHAR (200),
@Prenom NVARCHAR (200),
@Birthday DATETIME2
AS
begin
	
	set nocount on 

	insert into  dbo.Malades (Nom,Prenom,Birthday) values (@Nom,@Prenom,@Birthday); SELECT CAST(SCOPE_IDENTITY() as int) ;

end