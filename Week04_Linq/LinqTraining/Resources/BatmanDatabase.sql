DROP TABLE IF EXISTS BatmanMovies;

CREATE TABLE BatmanFilms (
    FilmID INT PRIMARY KEY,
    FilmTitle VARCHAR(255),
    ReleaseYear INT,
    ActorID INT
);

INSERT INTO BatmanFilms (FilmID, FilmTitle, ReleaseYear, ActorID) VALUES                          
(1, 'Batman: The Movie', 1966, 1),                                                          
(2, 'Batman', 1989, 2),                                                                     
(3, 'Batman Returns', 1992, 3),                                                             
(4, 'Batman Forever', 1995, 4),                                                             
(5, 'Batman & Robin', 1997, 4),                                                             
(6, 'Batman Begins', 2005, 5),                                                              
(7, 'The Dark Knight', 2008, 5),                                                            
(8, 'The Dark Knight Rises', 2012, 5),                                                      
(9, 'Batman v Superman: Dawn of Justice', 2016, 6),                                         
(10, 'The Lego Batman Movie', 2017, 5),                                                     
(11, 'Justice League', 2017, 6),                                                            
(12, 'Zack Snyder''s Justice League', 2021, 6); 


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
