CREATE DATABASE University;

USE University;

GO

CREATE SCHEMA Library;

CREATE TABLE Library.Books
(
	Id    INT           PRIMARY KEY
   ,Title NVARCHAR(255)
)


INSERT INTO Library.Books
VALUES(1, N'Займёмся исследованием операций');


SELECT * FROM Library.Books
