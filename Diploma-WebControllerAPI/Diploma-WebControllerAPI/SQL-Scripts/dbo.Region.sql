CREATE TABLE [dbo].[Region]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Map] INT NOT NULL, 
    [UtilityID] INT NOT NULL, 
    [RecycleFactoryID] INT NOT NULL,
	CONSTRAINT FK_RegionUtility FOREIGN KEY (UtilityID)
	REFERENCES [dbo].[Utility](ID),
	CONSTRAINT FK_RegionRecycleFactory FOREIGN KEY (RecycleFactoryID)
	REFERENCES [dbo].[RecycleFactory](ID)
)
