-- Create a new table called 'Employees' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
DROP TABLE dbo.Employees
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Employees
(
	SSN INT  PRIMARY KEY, -- primary key column
	FName NVARCHAR(50) NOT NULL,
	LName NVARCHAR(50) NOT NULL,
	Gender NVARCHAR(1),
	Birthdate date,
	DNUM INT,
	SuperSSN int


	-- Constraints
	constraint SuperSSN_FK_TO_SNN Foreign Key (SuperSSN)
	references Employees(SSN) 
);



--After creating Departments Table 

alter table Employees add constraint FK_DNUM_Employees_To_Departments_DNUM  Foreign key(DNUM)
references Departments(DNUM)


