CREATE DATABASE CRUD

GO

USE CRUD

GO

CREATE TABLE student(
    [id] INT PRIMARY KEY IDENTITY NOT NULL,
    [name] VARCHAR (50) NULL,
    [gender] VARCHAR (50) NULL,
    [dob] DATETIME NULL,
    [contact] VARCHAR (50) NULL,
    [address] VARCHAR (MAX) NULL,
    [city] VARCHAR (50) NULL
)

GO

INSERT INTO student VALUES 
('Abdul Rahman','Male','2003-12-20','03052221517','ABC 123', 'Multan')

GO

-- All Procedures Queries --

-- SP_Insert 

CREATE PROCEDURE SP_Insert
@name varchar(50),
@gender varchar(50),
@dob datetime,
@contact varchar(50),
@address varchar(MAX),
@city varchar(50)
AS
INSERT INTO student VALUES(@name,@gender,@dob,@contact,@address,@city)

GO

-- SP_Update

CREATE PROCEDURE SP_Update
@id int,
@name varchar(50),
@gender varchar(50),
@dob datetime,
@contact varchar(50),
@address varchar(MAX),
@city varchar(50)
AS
UPDATE student
SET name=@name,gender=@gender,dob=@dob,contact=@contact,address=@address,city=@city
WHERE id=@id

GO

-- SP_Delete

CREATE PROCEDURE SP_Delete @id INT
AS
DELETE FROM student WHERE id=@id

GO

--  SP_SelectAll

CREATE PROCEDURE SP_SelectAll
AS 
SELECT * FROM student

GO

-- SP_Search 1

CREATE PROCEDURE SP_Search @search VARCHAR
AS
SELECT * FROM student WHERE 
id LIKE '%'+@search+'%'
OR name LIKE '%'+@search+'%'
OR gender LIKE '%'+@search+'%'
OR dob LIKE '%'+@search+'%'
OR contact LIKE '%'+@search+'%'
OR address LIKE '%'+@search+'%'
OR city LIKE '%'+@search+'%'

GO

-- SP_Search 2

--CREATE PROCEDURE SP_Search @search VARCHAR
--AS
--SELECT * FROM student WHERE 
--CONVERT(VARCHAR,id) + name + gender + 
--CONVERT(VARCHAR,dob) + contact + address + city
--LIKE '%'+@search+'%' 



