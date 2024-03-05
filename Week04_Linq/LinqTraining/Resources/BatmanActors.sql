DROP TABLE IF EXISTS BatmanActors;

CREATE TABLE BatmanActors (
    ActorID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255)
);

INSERT INTO BatmanActors (ActorID, FirstName, LastName) VALUES
(1, 'Adam', 'West'),
(2, 'Michael', 'Keaton'),
(3, 'Val', 'Kilmer'),
(4, 'George', 'Clooney'),
(5, 'Christian', 'Bale'),
(6, 'Ben', 'Affleck');
