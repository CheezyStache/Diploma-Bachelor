CREATE TABLE [dbo].[CityUtilities]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [CityID] INT NOT NULL, 
    [UtilityID] INT NOT NULL,
	CONSTRAINT FK_CityUtilitiesCity FOREIGN KEY (CityID)
	REFERENCES [dbo].[City](ID),
	CONSTRAINT FK_CityUtilitiesUtility FOREIGN KEY (UtilityID)
	REFERENCES [dbo].[Utility](ID)
)
