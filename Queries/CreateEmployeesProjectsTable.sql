
-- Create a new table called 'EmoloyeesProjects' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.EmoloyeesProjects', 'U') IS NOT NULL
DROP TABLE dbo.EmoloyeesProjects
GO
-- Create the table in the specified schema
CREATE TABLE dbo.EmoloyeesProjects
(
    EmployeeSSN INT, 
    ProjectNum INT,

    workingHours INT


    -- Constraints

    Constraint CompositePK PRIMARY KEY (EmployeeSSN, ProjectNum),

    Constraint FK_EmployeeSSN_EmoloyeesProjects_To_Employess_SSN FOREIGN KEY(EmployeeSSN)
    REFERENCES Employees(SSN),

    Constraint FK_ProjectNum_EmoloyeesProjects_To_Projects_PNum FOREIGN KEY(ProjectNum)
    REFERENCES Projects(PNum)

);
