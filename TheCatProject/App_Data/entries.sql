INSERT INTO [dbo].[Cats](Name, Age, Sex)
	VALUES
	('Sam', 8, 'Male'),
	('Sawyer', 8, 'Male'),
	('Phineas', 5, 'Male'),
	('Jaguar', 5, 'Female'),
	('Trouble', 5, 'Male'),
	('Petunia', 1, 'Female'),
	('Bart', 2, 'Male'),
	('Mama Cat', 6, 'Female');

INSERT INTO [dbo].[Traits](CatID, ColorID, BreedID)
	VALUES
	(1, 20, 5),
	(2, 19, 37),
	(3, 34, 37),
	(4, 28, 37),
	(5, 34, 37),
	(6, 18, 20),
	(7, 18, 37),
	(8, 34, 37);

INSERT INTO [dbo].[PTags](CID, FirstTrait, SecondTrait, ThirdTrait)
	VALUES
	(1, 42, 26, 33),
	(2, 41, 39, 20),
	(3, 31, 6, 7),
	(4, 20, 23, 30),
	(5, 38, 34, 25),
	(6, 25, 14, 22),
	(7, 27, 41, 15),
	(8, 18, 27, 2);