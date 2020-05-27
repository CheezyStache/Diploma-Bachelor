CREATE TABLE [dbo].[Utility]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Ready] BIT NOT NULL, 
    [LocationID] INT NOT NULL, 
    [UtilityOptionsID] INT NOT NULL,
	CONSTRAINT FK_UtilityLocation FOREIGN KEY (LocationID)
	REFERENCES [dbo].[Location](ID),
	CONSTRAINT FK_UtilityUtilityOptions FOREIGN KEY (UtilityOptionsID)
	REFERENCES [dbo].[UtilityOptions](ID)
)
