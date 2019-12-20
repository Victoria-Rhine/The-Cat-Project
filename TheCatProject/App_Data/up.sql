CREATE TABLE [dbo].[Cats]
(
	[ID]			INT IDENTITY(1,1)		NOT NULL,
	[Name]			NVARCHAR(50)			NOT NULL,
	[Age]			FLOAT(50)				NOT NULL,
	[Sex]			NVARCHAR(50)			NOT NULL,
	CONSTRAINT [PK_dbo.Cats] PRIMARY KEY CLUSTERED ([ID] ASC)
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

CREATE TABLE [dbo].[Traits]
(
	[ID]				INT IDENTITY(1,1)	NOT NULL,
	[CatID]				INT					NOT NULL,
	[ColorID]			INT					NOT NULL,
	[BreedID]			INT					NOT NULL,
	CONSTRAINT [PK_dbo.Traits] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Traits_Cats_ID] FOREIGN KEY ([CatID]) REFERENCES [dbo].[Cats] ([ID]),
	CONSTRAINT [FK_dbo.Traits_Color_ID] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([ID]),
	CONSTRAINT [FK_dbo.Traits_Breed_ID] FOREIGN KEY ([BreedID]) REFERENCES [dbo].[Breeds] ([ID])
);

CREATE TABLE [dbo].[Personalities]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[Type]			NVARCHAR(50)		NOT NULL,	
	CONSTRAINT [PK_dbo.Personalities] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[PTags]
(
	[ID]			INT IDENTITY(1,1)	NOT NULL,
	[CID]			INT					NOT NULL,
	[FirstTrait]	INT					NOT NULL,
	[SecondTrait]	INT					NOT NULL,
	[ThirdTrait]	INT					NOT NULL,
	CONSTRAINT [PK_dbo.PTags] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.PTags_Cats_ID2] FOREIGN KEY ([CID]) REFERENCES [dbo].[Cats] ([ID]),
	CONSTRAINT [FK_dbo.PTags_Personalities_ID1] FOREIGN KEY ([FirstTrait]) REFERENCES [dbo].[Personalities] ([ID]),	
	CONSTRAINT [FK_dbo.PTags_Personalities_ID2] FOREIGN KEY ([SecondTrait]) REFERENCES [dbo].[Personalities] ([ID]),
	CONSTRAINT [FK_dbo.PTags_Personalities_ID3] FOREIGN KEY ([ThirdTrait]) REFERENCES [dbo].[Personalities] ([ID])
);