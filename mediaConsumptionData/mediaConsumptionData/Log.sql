CREATE TABLE [dbo].[Log] (
    [LogID] INT IDENTITY (1, 1) NOT NULL,
	[Title]    NVARCHAR (50) NULL,
    [Rating]        DECIMAL(4, 2) NULL,
	[Time]        DECIMAL(6, 2) NULL,
    [UserID]     INT NOT NULL,
    [MediaID]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([LogID] ASC),
    CONSTRAINT [FK_dbo.Log_dbo.Media_MediaID] FOREIGN KEY ([MediaID]) 
        REFERENCES [dbo].[Media] ([MediaID]),
    CONSTRAINT [FK_dbo.Log_dbo.Users_UserID] FOREIGN KEY ([UserID]) 
        REFERENCES [dbo].[Users] ([UserID])
)