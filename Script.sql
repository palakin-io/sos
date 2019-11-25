CREATE DATABASE AccentureAccademyMovieDb;
GO

USE AccentureAccademyMovieDb;
GO

CREATE TABLE Movie
(
	id int primary key identity (1,1),
	Title Varchar(200) not null,
	ReleaseDate date not null,
	runningTime int not null,
	CONSTRAINT UQ_TITLE UNIQUE(Title, ReleaseDate),
	CONSTRAINT CHK_DURATION CHECK(runningTime between 1 and 500)
);
GO

INSERT INTO Movie
	(Title, ReleaseDate, runningTime)
VALUES
	('Terminator', '2019-10-31', 128)