CREATE TABLE [dbo].[RegionDailyStatistics]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME2 NOT NULL,
    [AvgTime] BIGINT NULL, 
    [AvgPetrolAmount] INT NULL,
    [AvgDynamicChangesCount] INT NULL,
    [AvgContainersCount] INT NULL,
    [UtilityID] INT NOT NULL, 
    [RegionID] INT NOT NULL,
	CONSTRAINT FK_RegionDailyStatisticsUtility FOREIGN KEY (UtilityID) 
	REFERENCES [dbo].[Utility](ID),
	CONSTRAINT FK_RegionDailyStatisticsRegion FOREIGN KEY (RegionID) 
	REFERENCES [dbo].[Region](ID),
)
