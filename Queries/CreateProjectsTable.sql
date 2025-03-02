-- Create a new table called 'Projects' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Projects', 'U') IS NOT NULL
DROP TABLE dbo.Projects
GO

-- Create the table in the specified schema
CREATE TABLE dbo.Projects
(
    PNum INT  PRIMARY KEY, -- primary key column
    PName NVARCHAR(50) NOT NULL,
    Location NVARCHAR(50) NOT NULL,
    City NVARCHAR(50) ,
    DNUM INT NOT NULL,
    

    -- Constraints 
    Constraint FK_DNUM_Projects_To_DNUM_Departments Foreign Key (DNUM)
    references Departments(DNUM)
);
