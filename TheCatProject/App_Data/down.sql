ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.AnimalFriendID];
DROP TABLE [dbo].[AnimalFriendliness];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.BreedID];
DROP TABLE [dbo].[Breeds];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.ColorID];
DROP TABLE [dbo].[Colors];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.LifestyleID];
DROP TABLE [dbo].[Lifestyle];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.PeopleID];
DROP TABLE [dbo].[PeopleFriendliness];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.PlayID];
DROP TABLE [dbo].[Play];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.TraitsID_1];
ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.TraitsID_2];
ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.TraitsID_3];
DROP TABLE [dbo].[Traits];

ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [FK_dbo.WaterID];
DROP TABLE [dbo].[Water];

DROP TABLE [dbo].[Cats];