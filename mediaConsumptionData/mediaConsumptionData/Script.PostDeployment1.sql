/*MERGE INTO Media AS Target 
USING (VALUES 
        (1, 'Movie'), 
        (2, 'Book'), 
        (3, 'Television'),
		(4, 'Video Game'),
		(5, 'Internet'),
		(6, 'Music')
) 
AS Source (MediaID, Title) 
ON Target.MediaID = Source.MediaID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Title) 
VALUES (Title);


MERGE INTO Users AS Target
USING (VALUES 
        (1, 'Jimmy', 'jimmy@yahoo.com', 'Cool1234'), 
        (2, 'Lucy', 'lucy@yahoo.com', 'Cool1234')
)
AS Source (UserID, UserName, Email, Password)
ON Target.UserID = Source.UserID
WHEN NOT MATCHED BY TARGET THEN
INSERT (UserName, Email, Password)
VALUES (UserName, Email, Password);


MERGE INTO Log AS Target
USING (VALUES 
	(1, 'Weezer-White Album', 8, .5, 1, 6),
	(2, 'The Dark Knight', 10, 2.5, 1, 1),
	(3, 'Weezer-Green Album', 8, .5, 2, 6),
	(4, '1984', 8, 20, 2, 2)
)
AS Source (LogID, Title, Rating, Time, UserID, MediaID)
ON Target.UserID = Source.UserID
WHEN NOT MATCHED BY TARGET THEN
INSERT (Title, Rating, Time, UserID, MediaID)
VALUES (Title, Rating, Time, UserID, MediaID);*/