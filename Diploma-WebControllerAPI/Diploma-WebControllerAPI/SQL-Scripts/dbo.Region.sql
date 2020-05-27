CREATE TABLE [dbo].[Region] (
    [ID]               INT NOT NULL,
    [Map]              INT NOT NULL,
    [UtilityID]        INT NOT NULL,
    [RecycleFactoryID] INT NOT NULL,
	[CityID]		   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_RegionUtility] FOREIGN KEY ([UtilityID]) REFERENCES [dbo].[Utility] ([ID]),
    CONSTRAINT [FK_RegionRecycleFactory] FOREIGN KEY ([RecycleFactoryID]) REFERENCES [dbo].[RecycleFactory] ([ID]),
	CONSTRAINT [FK_RegionCity] FOREIGN KEY ([CityID]) REFERENCES [dbo].[City] ([ID])
);

