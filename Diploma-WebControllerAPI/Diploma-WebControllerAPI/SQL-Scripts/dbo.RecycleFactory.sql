CREATE TABLE [dbo].[RecycleFactory]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Ready] BIT NOT NULL, 
    [LocationID] INT NOT NULL,
	CONSTRAINT FK_RecycleFactoryLocation FOREIGN KEY (LocationID) 
	REFERENCES [dbo].[Location](ID)
)
