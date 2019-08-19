CREATE PROCEDURE [dbo].[spEditMalade]



	@Id int ,
	@Nom NVARCHAR (200),
	@Prenom NVARCHAR (200),
	@Birthday DATETIME2
	AS
begin
	set nocount on;
	update Malades set Nom = @Nom,Prenom = @Prenom,Birthday = @Birthday where Id = @Id;
end