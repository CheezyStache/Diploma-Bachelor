CREATE TABLE [dbo].[TripContainers]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [TripID] INT NOT NULL, 
    [ContainerID] INT NOT NULL,
	CONSTRAINT FK_TripContainersTrip FOREIGN KEY (TripID)
	REFERENCES [dbo].[Trip](ID),
	CONSTRAINT FK_TripContainersContainer FOREIGN KEY (ContainerID)
	REFERENCES [dbo].[Container](ID)
)
