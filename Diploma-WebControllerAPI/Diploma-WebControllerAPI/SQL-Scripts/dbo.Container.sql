CREATE TABLE [dbo].[Container]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Full] BIT NOT NULL, 
    [LastGather] DATETIME2 NULL, 
    [LastUpdate] DATETIME2 NULL, 
    [RegionID] INT NOT NULL, 
    [LocationID] INT NOT NULL,
	CONSTRAINT FK_ContainerRegion FOREIGN KEY (RegionID)
	REFERENCES [dbo].[Region](ID),
	CONSTRAINT FK_ContainerLocation FOREIGN KEY (LocationID)
	REFERENCES [dbo].[Location](ID)
)
