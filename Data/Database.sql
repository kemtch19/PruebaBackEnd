-- Active: 1717615863432@@b474fvggbtm9xuakiwtz-mysql.services.clever-cloud.com@3306@b474fvggbtm9xuakiwtz

-- Tabla de Students
CREATE Table Students(
  Id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  Names VARCHAR(125) NOT NULL,
  BirthDate DATE NOT NULL,
  Address VARCHAR(125) NOT NULL,
  Email VARCHAR(125) NOT NULL
);

--Tabla de Enrollments
CREATE Table Enrollments(
  Id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  DateEnrollments DATE NOT NULL,
  Status ENUM("Active", "Inactive"),
  StudentId INT NOT NULL,
  CourseId INT NOT NULL,
  Foreign Key (StudentId) REFERENCES Students(Id),
  Foreign Key (CourseId) REFERENCES Courses(Id)
);

-- Tabla de Courses
CREATE Table Courses(
  Id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  Name VARCHAR(125) NOT NULL,
  Description TEXT NOT NULL,
  Schedule VARCHAR(125) NOT NULL,
  Duration VARCHAR(25) NOT NULL,
  Capacity INT NOT NULL,
  TeacherId INT NOT NULL,
  Foreign Key (TeacherId) REFERENCES Teachers(Id)
);

-- Tabla de Teachers
CREATE Table Teachers(
  Id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  Names VARCHAR(125) NOT NULL,
  Specialty VARCHAR(125) NOT NULL,
  Phone VARCHAR(25) NOT NULL,
  Email VARCHAR(125) NOT NULL,
  YearsExperience INT NOT NULL
)

INSERT INTO Enrollments(`DateEnrollments`, `StudentId`, `CourseId`, `Status`) VALUES
("2024-07-21", 1, 2, "Active");

INSERT INTO Courses(`Name`, `Description`, `Schedule`, `Duration`, `Capacity`, `TeacherId`) VALUES
("Ciberseguridad", "La ciberseguridad es la práctica de defender las computadoras, los servidores, los dispositivos móviles, los sistemas electrónicos, las redes y los datos de ataques maliciosos.", "Mañana", "20 horas", 20, 1);

INSERT INTO Students(`Names`, `BirthDate`, `Address`, `Email`) VALUES
("Daniel", "2024-05-30", "Calle 23 a sur 23-23", "test@gmail.com");

insert INTO Teachers(`Names`, `Specialty`, `Phone`, `Email`, `YearsExperience`) VALUES  
("Camilo", "Inglés", "41123213", "teacher@gmail.com", 2);

SELECT * from `Enrollments`;

DROP Table `Enrollments`;

show TABLES;