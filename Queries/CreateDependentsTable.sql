-- Create a new table called 'dbo' in schema 'Dependents'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Dependents', 'U') IS NOT NULL
DROP TABLE dbo.Dependents
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Dependents
(
	EmployeeSSN INT  , -- primary key column
	DependentID NVARCHAR(50) NOT NULL,
	DependentName NVARCHAR(50) NOT NULL,
	Gender NVARCHAR(1),
	Birthdate DATE 
	
	--Constraints
	Constraint CompositPK Primary Key (EmployeeSSN , DependentID),
	Constraint FK_EmployeeSSN_Dependents_TO_Employees_SSN Foreign Key (EmployeeSSN)
	references Employees(SSN)


);


