CREATE TABLE [dbo].[AnimalFriendliness]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Response]		NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.AnimalFriendliness] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[PeopleFriendliness]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Response]		NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.PeopleFriendliness] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Colors]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[CatColor]		NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Colors] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Breeds]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[CatBreed]		NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Breeds] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Lifestyle]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Type]			NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Lifestyle] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Play]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Activity]		NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Play] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Traits]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Type]			NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Traits] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Water]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Response]		NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Water] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Cats]
(
	[ID]					INT IDENTITY(1,1)		NOT NULL,
	[Name]					NVARCHAR(50)			NOT NULL,
	[Age]					FLOAT(50)				NOT NULL,
	[Sex]					NVARCHAR(50)			NOT NULL,
	[AnimalFriendID]		INT						NOT NULL,
	[BreedID]				INT						NOT NULL,
	[LifestyleID]			INT						NOT NULL,
	[ColorID]				INT						NOT NULL,
	[PlayID]				INT						NOT NULL,
	[TraitsID_1]			INT						NOT NULL,
	[TraitsID_2]			INT						NOT NULL,
	[TraitsID_3]			INT						NOT NULL,
	[PeopleFriendID]		INT						NOT NULL,
	[WaterID]				INT						NOT NULL,
	CONSTRAINT [PK_dbo.Cats] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.AnimalFriendID] FOREIGN KEY ([AnimalFriendID]) REFERENCES [dbo].[AnimalFriendliness] ([ID]),
	CONSTRAINT [FK_dbo.BreedID] FOREIGN KEY ([BreedID]) REFERENCES [dbo].[Breeds] ([ID]),
	CONSTRAINT [FK_dbo.LifestyleID] FOREIGN KEY ([LifestyleID]) REFERENCES [dbo].[Lifestyle] ([ID]),
	CONSTRAINT [FK_dbo.ColorID] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([ID]),
	CONSTRAINT [FK_dbo.PlayID] FOREIGN KEY ([PlayID]) REFERENCES [dbo].[Play] ([ID]),
	CONSTRAINT [FK_dbo.TraitsID_1] FOREIGN KEY ([TraitsID_1]) REFERENCES [dbo].[Traits] ([ID]),
	CONSTRAINT [FK_dbo.TraitsID_2] FOREIGN KEY ([TraitsID_2]) REFERENCES [dbo].[Traits] ([ID]),
	CONSTRAINT [FK_dbo.TraitsID_3] FOREIGN KEY ([TraitsID_3]) REFERENCES [dbo].[Traits] ([ID]),
	CONSTRAINT [FK_dbo.PeopleID] FOREIGN KEY ([PeopleFriendID]) REFERENCES [dbo].[PeopleFriendliness] ([ID]),
	CONSTRAINT [FK_dbo.WaterID] FOREIGN KEY ([WaterID]) REFERENCES [dbo].[Water] ([ID])
);