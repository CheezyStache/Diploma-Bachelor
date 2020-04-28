CREATE TABLE [dbo].[Trip]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Time] BIGINT NULL, 
    [PetrolAmount] INT NULL, 
    [DynamicChangesCount] INT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [InProgress] BIT NOT NULL, 
    [UtilityID] INT NOT NULL,
	CONSTRAINT FK_TripUtility FOREIGN KEY (UtilityID)
	REFERENCES [dbo].[Utility](ID)
)
