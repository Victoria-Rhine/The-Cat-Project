ALTER TABLE [dbo].[Traits] DROP CONSTRAINT [FK_dbo.Traits_Breed_ID];
DROP TABLE [dbo].[Breeds];

ALTER TABLE [dbo].[PTags] DROP CONSTRAINT [FK_dbo.PTags_Cats_ID2];
ALTER TABLE [dbo].[Traits] DROP CONSTRAINT [FK_dbo.Traits_Cats_ID];
DROP TABLE [dbo].[Cats];

ALTER TABLE [dbo].[Traits] DROP CONSTRAINT [FK_dbo.Traits_Color_ID];
DROP TABLE [dbo].[Colors];

ALTER TABLE [dbo].[PTags] DROP CONSTRAINT [FK_dbo.PTags_Personalities_ID];
DROP TABLE [dbo].[Personalities];

DROP TABLE [dbo].[PTags];

DROP TABLE [dbo].[Traits];