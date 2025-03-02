-- Create a new table called 'dbo' in schema 'Departments'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL
DROP TABLE dbo.Departments
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Departments
(
	DNUM INT PRIMARY KEY, -- primary key column
	DName NVARCHAR(50) NOT NULL,
	
	ManagerId int,
	Hiredate date

	--Constraint
	Constraint FK_ManagerID_Departments_To_Employees_SSN Foreign key (ManagerID)
	references Employees(SSN) 
);

