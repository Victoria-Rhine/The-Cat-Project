ALTER TABLE [dbo].[PTags] DROP CONSTRAINT [FK_dbo.PTags_Personalities_ID];
DROP TABLE [dbo].[Personalities];

ALTER TABLE [dbo].[PTags] DROP CONSTRAINT [FK_dbo.PTags_Cats_ID2];
ALTER TABLE [dbo].[Traits] DROP CONSTRAINT [FK_dbo.Traits_Cats_ID];
DROP TABLE [dbo].[Cats];

DROP TABLE [dbo].[Traits];

DROP TABLE [dbo].[PTags];

