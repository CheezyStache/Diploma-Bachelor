CREATE TABLE [dbo].[CountryDailyStatistics]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME2 NOT NULL, 
    [CitiesCount] INT NOT NULL, 
    [AvgTime] BIGINT NULL, 
    [AvgPetrolAmount] INT NULL, 
    [PetrolAmount] INT NOT NULL, 
    [AvgDynamicChangesCount] INT NULL, 
    [DynamicChangesCount] INT NOT NULL, 
    [AvgContainersCount] INT NULL, 
    [ContainersCount] INT NOT NULL, 
    [UtilitiesCount] INT NOT NULL, 
    [RegionsCount] INT NOT NULL, 
    [FactoriesCount] INT NOT NULL
)
