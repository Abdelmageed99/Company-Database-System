-- Create a new table called 'Locations' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Locations', 'U') IS NOT NULL
DROP TABLE dbo.Locations
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Locations
(
	DNUM INT , -- primary key column
	LOcationID int NOT NULL,
	LOcation NVARCHAR(50) NOT NULL

	--Constraint
	Constraint Locations_CompositeKey primary Key (DNum, LocationID),
	Constraint FK_DNUM_Locations_To_Departments_DNUM Foreign Key (DNUM)
    references Departments(DNUM)


);
