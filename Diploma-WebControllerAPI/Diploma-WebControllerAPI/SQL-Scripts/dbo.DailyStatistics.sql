CREATE TABLE [dbo].[DailyStatistics]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME2 NOT NULL, 
    [AvgTime] BIGINT NULL, 
    [AvgPetrolAmount] INT NULL, 
    [PetrolAmount] INT NOT NULL, 
    [AvgDynamicChangesCount] INT NULL, 
    [DynamicChangesCount] INT NOT NULL, 
    [AvgContainersCount] INT NULL, 
    [ContainersCount] INT NOT NULL, 
    [UtilitiesCount] INT NOT NULL, 
    [RegionsCount] INT NOT NULL, 
    [FactoriesCount] INT NOT NULL,
	[CityID] INT NOT NULL, 
	[CountryStatisticsID] INT NULL, 
	CONSTRAINT FK_DailyStatisticsCity FOREIGN KEY (CityID) 
	REFERENCES [dbo].[City](ID),
	CONSTRAINT FK_DailyStatisticsCountryStatistics FOREIGN KEY (CountryStatisticsID) 
	REFERENCES [dbo].[CountryDailyStatistics](ID),
)
