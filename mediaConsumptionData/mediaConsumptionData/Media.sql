CREATE TABLE [dbo].[Media] (
    [MediaID] INT           IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([MediaID] ASC)
)
