USE [master]
GO
/****** Object:  Database [TafeSystem]    Script Date: 10/06/2022 12:19:10 AM ******/
CREATE DATABASE [TafeSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TafeSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TafeSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TafeSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TafeSystem_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TafeSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TafeSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TafeSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TafeSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TafeSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TafeSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TafeSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [TafeSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TafeSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TafeSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TafeSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TafeSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TafeSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TafeSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TafeSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TafeSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TafeSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TafeSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TafeSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TafeSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TafeSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TafeSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TafeSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TafeSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TafeSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TafeSystem] SET  MULTI_USER 
GO
ALTER DATABASE [TafeSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TafeSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TafeSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TafeSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TafeSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TafeSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TafeSystem] SET QUERY_STORE = OFF
GO
USE [TafeSystem]
GO
/****** Object:  Table [dbo].[Cluster]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cluster](
	[Cluster_ID] [int] NOT NULL,
	[ClusterName] [nvarchar](50) NOT NULL,
	[ClusterDescription] [nvarchar](500) NOT NULL,
 CONSTRAINT [Cluster_pk] PRIMARY KEY CLUSTERED 
(
	[Cluster_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClusterUnit]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClusterUnit](
	[Cluster_ID] [int] NOT NULL,
	[Unit_ID] [int] NOT NULL,
 CONSTRAINT [ClusterUnit_pk] PRIMARY KEY CLUSTERED 
(
	[Cluster_ID] ASC,
	[Unit_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[College]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[College](
	[College_ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CollegeLocation] [nvarchar](100) NOT NULL,
 CONSTRAINT [College_pk] PRIMARY KEY CLUSTERED 
(
	[College_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Course_ID] [int] NOT NULL,
	[Description] [nvarchar](700) NOT NULL,
	[HoursPerWeek] [int] NOT NULL,
	[Cost] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [Course_pk] PRIMARY KEY CLUSTERED 
(
	[Course_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseCluster]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCluster](
	[Cluster_ID] [int] NOT NULL,
	[Course_ID] [int] NOT NULL,
 CONSTRAINT [CourseCluster_pk] PRIMARY KEY CLUSTERED 
(
	[Cluster_ID] ASC,
	[Course_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrolment]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrolment](
	[Enrolment_ID] [int] NOT NULL,
	[Student_ID] [int] NOT NULL,
	[Course_ID] [int] NOT NULL,
	[Payment_ID] [int] NULL,
	[College_ID] [int] NOT NULL,
	[Semester_ID] [int] NOT NULL,
	[EnrolmentDate] [date] NOT NULL,
	[Result] [nvarchar](50) NOT NULL,
 CONSTRAINT [Enrolement_pk] PRIMARY KEY CLUSTERED 
(
	[Enrolment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Payment_ID] [int] NOT NULL,
	[FeePaid] [int] NOT NULL,
 CONSTRAINT [Payment_pk] PRIMARY KEY CLUSTERED 
(
	[Payment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[Semester_ID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [Semester_pk] PRIMARY KEY CLUSTERED 
(
	[Semester_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Student_ID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[StreetAddress] [nvarchar](50) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[State] [nvarchar](3) NOT NULL,
	[PostCode] [nchar](4) NOT NULL,
	[Mobile] [nchar](10) NOT NULL,
	[Gender] [nchar](1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [Student_pk] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Teacher_ID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[StreetAddress] [nvarchar](100) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[State] [nvarchar](3) NOT NULL,
	[PostCode] [nchar](4) NOT NULL,
	[Mobile] [nchar](10) NOT NULL,
	[Gender] [nchar](1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[BasedLocation] [nvarchar](50) NULL,
 CONSTRAINT [Teacher_pk] PRIMARY KEY CLUSTERED 
(
	[Teacher_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherTeaching]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherTeaching](
	[TeacherTeaching_ID] [int] NOT NULL,
	[Teacher_ID] [int] NOT NULL,
	[Course_ID] [int] NOT NULL,
	[College_ID] [int] NOT NULL,
	[Semester_ID] [int] NOT NULL,
	[EmploymentStatus] [nvarchar](20) NOT NULL,
 CONSTRAINT [TeacherTeaching_pk] PRIMARY KEY CLUSTERED 
(
	[TeacherTeaching_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Unit_ID] [int] NOT NULL,
	[UnitCode] [nvarchar](50) NOT NULL,
	[UnitType] [nvarchar](50) NOT NULL,
	[UnitDescription] [nvarchar](500) NOT NULL,
	[Grade] [nvarchar](50) NULL,
 CONSTRAINT [Unit_pk] PRIMARY KEY CLUSTERED 
(
	[Unit_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseCluster]  WITH CHECK ADD  CONSTRAINT [Cluster_CourseCluster_fk] FOREIGN KEY([Cluster_ID])
REFERENCES [dbo].[Cluster] ([Cluster_ID])
GO
ALTER TABLE [dbo].[CourseCluster] CHECK CONSTRAINT [Cluster_CourseCluster_fk]
GO
ALTER TABLE [dbo].[CourseCluster]  WITH CHECK ADD  CONSTRAINT [Course_CourseCluster_fk] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Course_ID])
GO
ALTER TABLE [dbo].[CourseCluster] CHECK CONSTRAINT [Course_CourseCluster_fk]
GO
ALTER TABLE [dbo].[Enrolment]  WITH CHECK ADD  CONSTRAINT [Enrolment_College_fk] FOREIGN KEY([College_ID])
REFERENCES [dbo].[College] ([College_ID])
GO
ALTER TABLE [dbo].[Enrolment] CHECK CONSTRAINT [Enrolment_College_fk]
GO
ALTER TABLE [dbo].[Enrolment]  WITH CHECK ADD  CONSTRAINT [Enrolment_Course_fk] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Course_ID])
GO
ALTER TABLE [dbo].[Enrolment] CHECK CONSTRAINT [Enrolment_Course_fk]
GO
ALTER TABLE [dbo].[Enrolment]  WITH CHECK ADD  CONSTRAINT [Enrolment_Payment_fk] FOREIGN KEY([Payment_ID])
REFERENCES [dbo].[Payment] ([Payment_ID])
GO
ALTER TABLE [dbo].[Enrolment] CHECK CONSTRAINT [Enrolment_Payment_fk]
GO
ALTER TABLE [dbo].[Enrolment]  WITH CHECK ADD  CONSTRAINT [Enrolment_Semester_fk] FOREIGN KEY([Semester_ID])
REFERENCES [dbo].[Semester] ([Semester_ID])
GO
ALTER TABLE [dbo].[Enrolment] CHECK CONSTRAINT [Enrolment_Semester_fk]
GO
ALTER TABLE [dbo].[Enrolment]  WITH CHECK ADD  CONSTRAINT [Enrolment_Student_fk] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Student_ID])
GO
ALTER TABLE [dbo].[Enrolment] CHECK CONSTRAINT [Enrolment_Student_fk]
GO
ALTER TABLE [dbo].[TeacherTeaching]  WITH CHECK ADD  CONSTRAINT [TeacherTeaching_College_fk] FOREIGN KEY([College_ID])
REFERENCES [dbo].[College] ([College_ID])
GO
ALTER TABLE [dbo].[TeacherTeaching] CHECK CONSTRAINT [TeacherTeaching_College_fk]
GO
ALTER TABLE [dbo].[TeacherTeaching]  WITH CHECK ADD  CONSTRAINT [TeacherTeaching_Course_fk] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Course_ID])
GO
ALTER TABLE [dbo].[TeacherTeaching] CHECK CONSTRAINT [TeacherTeaching_Course_fk]
GO
ALTER TABLE [dbo].[TeacherTeaching]  WITH CHECK ADD  CONSTRAINT [TeacherTeaching_Semester_fk] FOREIGN KEY([Semester_ID])
REFERENCES [dbo].[Semester] ([Semester_ID])
GO
ALTER TABLE [dbo].[TeacherTeaching] CHECK CONSTRAINT [TeacherTeaching_Semester_fk]
GO
ALTER TABLE [dbo].[TeacherTeaching]  WITH CHECK ADD  CONSTRAINT [TeacherTeaching_Teacher_fk] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[Teacher] ([Teacher_ID])
GO
ALTER TABLE [dbo].[TeacherTeaching] CHECK CONSTRAINT [TeacherTeaching_Teacher_fk]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCluster]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteCluster]
@clusterId int
AS
BEGIN
	DELETE Cluster Where Cluster.Cluster_ID = @clusterId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCollege]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteCollege]
@collegeId int
AS
BEGIN
    DELETE FROM College Where College_ID = @collegeId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCourse]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteCourse]
@courseId int
AS
BEGIN
	DELETE Course Where Course.Course_ID = @courseId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteSemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteSemester]
@semesterId int
AS
BEGIN
    DELETE FROM Semester Where Semester.Semester_ID = @semesterId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudent]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteStudent]
@studentId int
AS
BEGIN
    DELETE FROM Student WHERE Student_ID = @studentId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTeacher]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteTeacher]
@teacherId int
AS
BEGIN
    DELETE FROM Teacher WHERE Teacher.Teacher_ID = @teacherId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUnit]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_DeleteUnit]
@unitId int
AS
BEGIN
    DELETE FROM Unit WHERE [Unit_ID]  = @unitId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCluster]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertCluster]
	@clusterName nvarchar(50),
	@clusterDesc nvarchar(500),
	@unit1Id int,
	@unit2Id int,
	@unit3Id int

AS
BEGIN
BEGIN TRANSACTION
        DECLARE @clusterId int;
        SELECT @clusterId = coalesce((select max(Cluster_ID) + 1 from Cluster), 1)
    COMMIT
INSERT INTO ClusterUnit(Cluster_ID,Unit_ID ) Values
(@clusterId,@unit1Id),
(@clusterId,@unit2Id),
(@clusterId,@unit3Id);
INSERT INTO Cluster(Cluster_ID,ClusterName,ClusterDescription ) Values
(@clusterId, @clusterName,@clusterDesc);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCollege]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertCollege]
	@name nvarchar(50),
	@location nvarchar(150)
AS
BEGIN
	BEGIN TRANSACTION
        DECLARE @collegeID int;
        SELECT @collegeID = coalesce((select max(College_ID) + 1 from College), 1)
    COMMIT 
    INSERT INTO College(College_ID,[Name],CollegeLocation) VALUES (@collegeID,@name,@location);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCourse]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertCourse]
	@courseName nvarchar(50),
	@courseDesc nvarchar(700),
	@hoursPerWeek int,
	@cost int,
	@cluster1Id int,
	@cluster2Id int,
	@cluster3Id int

AS
BEGIN
BEGIN TRANSACTION
        DECLARE @courseId int;
        SELECT @courseId = coalesce((select max(Course_ID) + 1 from Course), 1)
    COMMIT
INSERT INTO Course(Course_ID,Name,Description, HoursPerWeek,Cost) VALUES
(@courseId, @courseName,@courseDesc,@hoursPerWeek,@cost);
INSERT INTO CourseCluster(Course_ID,Cluster_ID) Values
(@courseId,@cluster1Id),
(@courseId,@cluster2Id),
(@courseId,@cluster3Id);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertSemester]
	@start Date,
	@end Date
AS
BEGIN
	BEGIN TRANSACTION
        DECLARE @semesterID int;
        SELECT @semesterID = coalesce((select max(Semester_ID) + 1 from Semester), 1)
    COMMIT 
    INSERT INTO Semester(Semester_ID,StartDate,EndDate,Duration) VALUES (@semesterID,@start,@end,DATEDIFF(day,@start,@end));
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertStudent]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertStudent]
	@fname nvarchar(50),
	@lname nvarchar(50),
	@dob Date,
	@streetAdd nvarchar(50),
	@suburb nvarchar(50),
	@state nvarchar(50),
	@postcode nvarchar(50),
	@mobile nvarchar(50),
	@gender nvarchar(50),
	@email nvarchar(50)

AS
BEGIN
	BEGIN TRANSACTION
        DECLARE @StudentID int;
        SELECT @StudentID = coalesce((select max(Student_ID) + 1 from Student), 1)
    COMMIT 
    INSERT INTO Student(Student_ID,FirstName,LastName,DOB,StreetAddress,Suburb,[State],PostCode,Mobile,Gender,Email) 
	VALUES (@StudentID,@fname,@lname,@dob,@streetAdd,@suburb,@state,@postcode,@mobile,@gender,@email);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTeacher]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertTeacher]
	@fname nvarchar(50),
	@lname nvarchar(50),
	@dob Date,
	@streetAdd nvarchar(50),
	@suburb nvarchar(50),
	@state nvarchar(50),
	@postcode nvarchar(50),
	@mobile nvarchar(50),
	@gender nvarchar(50),
	@email nvarchar(50),
	@password nvarchar(50),
	@basedLocation nvarchar(50)

AS
BEGIN
	BEGIN TRANSACTION
        DECLARE @TeacherID int;
        SELECT @TeacherID = coalesce((select max(Teacher_ID) + 1 from Teacher), 1)
    COMMIT 
    INSERT INTO Teacher(Teacher_ID,FirstName,LastName,DOB,StreetAddress,Suburb,[State],PostCode,Mobile,Gender,Email,Password,BasedLocation) 
	VALUES (@TeacherID,@fname,@lname,@dob,@streetAdd,@suburb,@state,@postcode,@mobile,@gender,@email,@password,@basedLocation);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUnit]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_InsertUnit]
	@unitCode nvarchar(50),
	@unitType nvarchar(50),
	@unitDesc nvarchar(500)
AS
BEGIN
	BEGIN TRANSACTION
        DECLARE @UnitID int;
		DECLARE @Grade as nvarchar(50)='Competent/Not Competent';
        SELECT @UnitID = coalesce((select max(Unit_ID) + 1 from Unit), 1)
    COMMIT 
    INSERT INTO Unit(Unit_ID,UnitCode,UnitDescription,UnitType,Grade) VALUES (@UnitID,@unitCode,@unitDesc,@unitType,@Grade);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResetDataBase]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_ResetDataBase]
AS
BEGIN

    DELETE FROM [dbo].[CourseCluster]
    DELETE FROM [dbo].[ClusterUnit]
	DELETE FROM [dbo].[Cluster]
	DELETE FROM [dbo].[TeacherTeaching]
	DELETE FROM [dbo].[Enrolment]
	DELETE FROM [dbo].[Teacher]
	DELETE FROM [dbo].[Student]
	DELETE FROM [dbo].[Unit]
	DELETE FROM [dbo].[College]
	DELETE FROM [dbo].[Semester]
	DELETE FROM [dbo].[Payment]
	DELETE FROM [dbo].[Course]

	INSERT INTO Course(Course_ID,Name,Description, HoursPerWeek,Cost) VALUES
(1,'CertIV Programming','This qualification provides the skills and knowledge for an individual to develop basic programming skills in the most commonly used programming languages.',25,500),
(2,'Web Development Diploma','Web Development provides a solid base of knowledge and highly regarded skills to equip you to become a website developer.',30,2000),
(3,'Accounting Diploma','The nationally accredited Advanced Diploma of Accounting is designed for aspiring accounting managers and assistant accountants.',12,1500),
(4,'CertIV In Knitting','This qualification provides the skills and knowledge for an individual to develop all kinds of fabric.',25,500);


INSERT INTO Student(Student_ID, FirstName, LastName,DOB, StreetAddress, Suburb, State, PostCode,  Mobile, Gender,Email) VALUES 
(1, 'Stuart', 'Masia','2019-01-30',  '234 Regent Drive', 'GLEBE', 'NSW',  '2037',  '0499123123', 'M','euice@gmail.com'),
(2, 'Robert', 'Argyle','1985-05-18',  '19 Beauty Place', 'LEICHHARDT', 'NSW',  '2040',  '0499123125', 'M','cameron@att.net'),
(3, 'Hilde', 'Sorenson','2002-09-06',  '301 Chalmers Street', 'CHATSWOOD', 'NSW',  '2057',  '0499123126', 'F','mcrawfor@outlook.com'),
(4, 'Thomas', 'Williams', '2002-02-14', '98 Argent Street', 'ROCKLEA', 'NSW',  '2006',  '0499123127', 'M','cgreuter@yahoo.ca'),
(5, 'Gary', 'Zheng','2001-12-07',  '467 The Esplanade', 'HAZELVALE', 'NSW',  '2333', '0499123128', 'M','hstiles@verizon.net'),
(6, 'Natalie', 'Mylonas', '2001-11-30', '6 Travers Lane', 'PICTON', 'NSW', '2571',  '0499123129', 'F','isaacson@mac.com'),
(7, 'Manny', 'Reeves',  '2001-08-17','7-45 Market Street', 'LILYDALE', 'NSW',  '2460',  '0499123130', 'F','jfmulder@comcast.net'),
(8, 'Michael', 'Su', '2001-07-16', '43 Lilly Pilly Avenue', 'CAMDEN', 'NSW',  '2570',  '0499123131', 'M','tjensen@att.net'),
(9, 'Allan', 'Markson','1999-11-22', '4 Robertson Street', 'BRACKENDALE', 'NSW',  '2127',  '0499123132', 'M','mglee@comcast.net'),
(10, 'Kylie', 'Lee', '1999-11-15','22-118 Western Gardens', 'PUNCHBOWL', 'NSW',  '2565',  '0499123133', 'M','helger@live.com'),
(11, 'May', 'Tucker', '1999-10-24','37 Tulip Crescent', 'RUSE', 'NSW',  '2560', '0298607465',  'F','jdhedden@live.com'),
(12, 'Greg', 'Higgins', '1989-09-14', '61 Sunlight Avenue', 'MILLICENT', 'SA', '5280',  '0499123135', 'M','xtang@outlook.com'),
(13, 'Janine', 'Khoury','1988-04-23',  '55 Jamberro Street', 'KELLYVILLE', 'NSW', '2155',  '0499123136', 'F','munjal@comcast.net'),
(14, 'David', 'Jones','1991-07-16', 'P.O. Box 234', 'PARRAMATTA', 'NSW',  '2150',  '0499123137', 'M','leakin@sbcglobal.net'),
(15, 'Tony', 'Marchant','1990-11-28','3 Grose St', 'Richmond', 'NSW',  '2753', '0245784455',  'M','ubergeeb@me.com'),
(16, 'Kerry', 'Badopolas','1993-09-10',  '72 Kilcare Road', 'Blayney', 'NSW',  '2799', '0343434343',  'M','khris@msn.com'),
(17, 'Rodney', 'Roberts','1993-01-17','4 Grose St', 'Richmond', 'NSW',  '2753',  '0499123140', 'M','geeber@hotmail.com'),
(18, 'Charli', 'Brown','1997-03-08', '64 Downing Road','Lithgow', 'NSW',  '2794', '0468239000', 'F','loscar@sbcglobal.net'),
(19, 'Peter', 'Johnston', '1998-02-22','45 Dora Street', 'Killara', 'NSW',  '2077',  '0417234987', 'M','oormat@verizon.net');



INSERT INTO Teacher(Teacher_ID, FirstName, LastName, DOB, StreetAddress, Suburb, State,  PostCode, Mobile, Gender,Email,Password,BasedLocation) VALUES
(1, 'John', 'Smith', '1968-05-25', '135 Arrowfield St', 'PARRAMATTA', 'NSW', '2150',  '0499123142', 'M','JohnSmith@tafensw.au','John','TAFE NSW - Granville'),
(2, 'Betty', 'Nguyen', '1968-07-28',  '45 Glenrock Cl', 'MOOREBANK', 'NSW', '2170',  '0499129663', 'F','BettyNguyen@tafensw.au','Betty','TAFE NSW - Granville'),
(3, 'Jenny', 'Bennett', '1970-01-09',  '98 Tower St', 'NEWTOWN', 'NSW', '2042',  '0499275936', 'F','JennyBennett@tafensw.au','Jenny','TAFE NSW - Petersham'),
(4, 'Ian', 'Houlder', '1970-03-29',  '32 Ultimo Rd', 'ULTIMO', 'NSW', '2007',  '0499123145', 'M','IanHoulder@tafensw.au','Ian','TAFE NSW - Ultimo'),
(5, 'Bill', 'Hermatige', '1998-01-23', 'Hope Street', 'Granville', 'SA', '3345',  '0499127685', 'M','BillHermatige@tafensw.au','Bill','TAFE NSW - Campbelltown'),
(6, 'Annie', 'Walker', '1985-04-23','76 View Street', 'Landsvalle', 'ACT',  '2690',  '0499123124', 'F','AnnieWalker@tafensw.au','Annie','TAFE NSW - Granville'),
(7, 'Abby', 'Stewart', '1975-04-23','26 Smith Street', 'Northwood', 'NSW',  '2190',  '0499275926', 'F','AbbyStewart@tafensw.au','Abby','TAFE NSW - Petersham'),
(8, 'Andrew', 'Nguyen', '1988-04-23','2 Sham Street', 'Mandaine', 'NSW',  '2133',  '0499126304', 'M','AndrewNguyen@tafensw.au','Andrew','TAFE NSW - Ultimo');



INSERT INTO Unit(Unit_ID,UnitCode,UnitDescription,UnitType,Grade) Values
(1, 'ICTPRG430', 'Apply introductory object-oriented language skills', 'elective', 'Competent/Not Competent'),
(2, 'ICTPRG413', 'Use a library or pre-existing components', 'core', 'Competent/Not Competent'),
(3, 'ICTPRG403', 'Develop data-driven applications', 'core', 'Competent/Not Competent'),
(4, 'ICTPRG404','Test applications', 'core', 'Competent/Not Competent'),
(5, 'ICTPRG410','Build a user interface', 'elective', 'Competent/Not Competent'),
(6, 'ICTPRG402','Apply query language', 'core', 'Competent/Not Competent'),
(7, 'ICTDBS403','Create basic databases', 'core', 'Competent/Not Competent'),
(8, 'ICTSAD501','Model data objects', 'core', 'Competent/Not Competent'),
(9, 'ICTPRG427','Use XML effectively', 'elective', 'Competent/Not Competent'),
(10, 'ICTPRG409','Develop mobile applications', 'core', 'Competent/Not Competent'),
(11, 'ICTICT420','Develop client user interface', 'core', 'Competent/Not Competent'),
(12, 'ICTPRG415','Apply skills in object-oriented design', 'core', 'Competent/Not Competent'),
(13, 'ICTPRG419','Analyse software requirements', 'elective', 'Competent/Not Competent'),
(14, 'ICTICT418','Contribute to copyright, ethics and privacy in an ICT environment', 'elective', 'Competent/Not Competent'),
(15, 'ICTPRG405','Automate processes', 'core', 'Competent/Not Competent'),
(16, 'ICTPRG414','Apply introductory programming skills in another language', 'elective', 'Competent/Not Competent'),
(17, 'ICTPRG407','Write script for software applications', 'core', 'Competent/Not Competent'),
(18, 'ICTWEB431','Create and style simple markup language documents', 'core', 'Competent/Not Competent'),
(19, 'FNSACC608','Evaluate organisations financial performance', 'core', 'Competent/Not Competent'),
(20, 'FNSACC609','Evaluate financial risk', 'core', 'Competent/Not Competent'),
(21, 'FNSACC613','Prepare and analyse management accounting information', 'core', 'Competent/Not Competent'),
(22, 'FNSACC614','Prepare complex corporate financial reports', 'elective', 'Competent/Not Competent'),
(23, 'FNSACC511','Provide financial and business performance information', 'core', 'Competent/Not Competent'),
(24, 'FNSACC512','Prepare tax documentation for individuals', 'core', 'Competent/Not Competent'),
(25, 'FNSACC513','Manage budgets and forecasts', 'core', 'Competent/Not Competent'),
(26, 'FNSACC514','Prepare financial reports for corporate entities', 'elective', 'Competent/Not Competent'),
(27, 'FNSACC516','Implement and maintain internal control procedures', 'elective', 'Competent/Not Competent'),
(28, 'FNSACC517','Provide management accounting information', 'core', 'Competent/Not Competent'),
(29, 'FNSACC624','Monitor corporate governance activities', 'elective', 'Competent/Not Competent'),
(30, 'FNSINC601','Apply economic principles to work in the financial services industry', 'core', 'Competent/Not Competent'),
(31, 'FNSINC602','Interpret and use financial statistics and tools', 'core', 'Competent/Not Competent'),
(32, 'ICTPT232', 'Apply simple HTML', 'elective', 'Competent/Not Competent');


INSERT INTO Cluster(Cluster_ID,ClusterName,ClusterDescription ) Values
(1, 'Programming One','C# fundamentals'),
(2, 'Programming Two','C#, ADO.NET & Windows Presentation Foundation'),
(3, 'Smart Apps','XML, Web Services & Mobile Application'),
(4, 'Database','SQL'),
(5, 'System Analysis & Design','Unified Modelling Language'),
(6, 'Client Side Development','JavaScript, HTML, CSS'),
(7, 'Australian Taxation System','How Australian Taxation is conducted'),
(8, 'Financial Statement Analysis','Cash Flow Analysis'),
(9, 'Sustainability Accounting','Identifying and Managing Risks'),
(10, 'Data Analytics for Accounting','Monitoring and Improving Business Performance'),
(11, 'Data Analytics fodssdfsfsdfsfsfr Accounting','Monitoring and Improving Business Performance'),
(12,'Analytics of finances in Accounting','Monitoring and Improving Business Performance');
INSERT INTO CourseCluster(Course_ID,Cluster_ID) Values
(1,1),
(1,2),
(1,3),
(2,4),
(2,5),
(2,6),
(3,7),
(3,8),
(3,9),
(3,10),
(3,11),
(4,12);


INSERT INTO College(College_ID,Name,CollegeLocation) VALUES
(1,'TAFE NSW - Granville','136 William St, Granville NSW 2142'),
(2,'TAFE NSW - Liverpool','College St, Liverpool NSW 2170'),
(3,'TAFE NSW - Ultimo','651-731 Harris St, Ultimo NSW 2007'),
(4,'TAFE NSW - Bankstown','500 Chapel Rd, Bankstown NSW 2200'),
(5,'TAFE NSW - Petersham','299 Johnston St, Annandale NSW 2038'),
(6,'TAFE NSW - Ryde','250 Blaxland Rd, Ryde NSW 2112'),
(7,'TAFE NSW - Meadowbank','See St, Meadowbank NSW 2114'),
(8,'TAFE NSW - Campbelltown','181 Narellan Rd, Campbelltown NSW 2560');



INSERT INTO Semester(Semester_ID,StartDate,EndDate,Duration)Values
(1,'2019-02-09','2019-07-03',DATEDIFF(day,'2019-02-09','2019-07-03')),
(2,'2019-07-18','2019-12-04',DATEDIFF(day,'2019-07-18','2019-12-04')),
(3,'2020-02-09','2020-07-03',DATEDIFF(day,'2020-02-09','2020-07-03')),
(4,'2020-07-18','2020-12-04',DATEDIFF(day,'2020-07-18','2020-12-04')),
(5,'2021-02-09','2021-07-03',DATEDIFF(day,'2021-02-09','2021-07-03')),
(6,'2021-07-18','2021-12-04',DATEDIFF(day,'2021-07-18','2021-12-04')),
(7,'2022-02-09','2022-07-03',DATEDIFF(day,'2022-02-09','2022-07-03')),
(8,'2022-07-18','2022-12-04',DATEDIFF(day,'2022-07-18','2022-12-04'));



INSERT INTO ClusterUnit(Cluster_ID,Unit_ID ) Values
(1,1),
(1,2),
(2,3),
(2,4),
(2,5),
(3,6),
(3,7),
(3,8),
(4,9),
(4,10),
(4,11),
(5,12),
(5,13),
(5,14),
(6,15),
(6,16),
(6,17),
(6,18),
(7,19),
(7,20),
(8,21),
(8,22),
(8,23),
(8,24),
(9,25),
(9,26),
(9,27),
(9,28),
(10,29),
(10,30),
(10,31),
(11,29),
(11,30),
(11,31),
(12,1),
(12,2),
(12,3);



INSERT INTO TeacherTeaching(TeacherTeaching_ID,Teacher_ID,Course_ID,College_ID,Semester_ID,EmploymentStatus) VALUES
(1,1,2,4,1,'full-time'),
(2,2,1,1,1,'full-time'),
(3,2,2,2,2,'part-time'),
(4,3,2,3,3,'part-time'),
(5,3,3,6,1,'full-time'),
(6,3,1,1,4,'full-time'),
(7,4,2,2,2,'part-time'),
(8,5,2,5,3,'part-time'),
(9,6,3,1,1,'full-time'),
(10,7,1,4,1,'full-time'),
(11,8,2,8,2,'part-time'),
(12,7,3,3,1,'part-time'),
(13,5,2,5,5,'part-time'),
(14,6,3,7,6,'full-time'),
(15,7,1,6,7,'full-time'),
(16,8,3,7,8,'full-time'),
(17,7,1,4,8,'full-time'),
(18,3,1,8,1,'full-time'),
(19,4,2,7,7,'part-time'),
(20,2,2,8,3,'part-time'),
(21,1,3,6,7,'full-time'),
(22,1,3,4,6,'full-time'),
(23,2,3,5,8,'full-time');



insert INTO Payment(Payment_ID,FeePaid)VALUES
(1,500),
(2,1600),
(3,50),
(4,1000),
(5,1200),
(6,1500),
(7,2000),
(8,0),
(9,2000),
(10,1500),
(11,2000),
(12,1500),
(13,2000),
(14,1000),
(15,500),
(16,100),
(17,100),
(18,100),
(19,100);
INSERT INTO Enrolment(Enrolment_ID,Student_ID,Course_ID,College_ID,Semester_ID,Payment_ID,EnrolmentDate,Result)Values
(1,1,1,1,1,1,'2019-02-09','Satisfactory'),
(2,1,2,2,2,2,'2019-07-18','Unsatisfactory'),
(3,3,1,1,1,3,'2019-02-09','Withdrawn'),
(4,3,2,2,2,4,'2019-07-18','Satisfactory'),
(5,4,2,2,2,5,'2019-02-09','Satisfactory'),
(6,4,3,3,3,6,'2020-02-09','Satisfactory'),
(7,5,2,2,2,7,'2019-07-18','Unsatisfactory'),
(8,6,3,3,3,8,'2020-02-09','Withdrawn'),
(9,7,2,4,4,9,'2020-07-18','Satisfactory'),
(10,8,3,5,4,10,'2020-07-18','Satisfactory'),
(11,9,2,4,5,11,'2021-02-09','Satisfactory'),
(12,10,3,5,5,12,'2021-02-09','Unsatisfactory'),
(13,11,2,5,6,13,'2021-07-18','Satisfactory'),
(14,12,3,7,7,14,'2022-02-09','Ongoing'),
(15,13,2,8,7,15,'2022-02-09','Ongoing'),
(16,14,1,1,7,16,'2022-02-09','Ongoing'),
(17,15,2,3,8,17,'2022-05-18','Have yet to start'),
(18,14,1,2,8,18,'2022-05-18','Have yet to start'),
(19,15,2,4,8,19,'2022-05-18','Have yet to start');


END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllClusters]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllClusters]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
   Cluster.Cluster_ID,Cluster.ClusterName,Cluster.ClusterDescription, Unit.Unit_ID,Unit.UnitCode,
Unit.UnitType,Unit.UnitDescription,Unit.Grade FROM Cluster INNER JOIN
ClusterUnit ON Cluster.Cluster_ID = ClusterUnit.Cluster_ID
INNER JOIN Unit on ClusterUnit.Unit_ID = Unit.Unit_ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllClustersBySemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllClustersBySemester]
@startDate Date,
@endDate Date
AS
BEGIN
SET NOCOUNT ON;
   SELECT Cluster.Cluster_ID,Cluster.ClusterName,Cluster.ClusterDescription,
Unit.Unit_ID,Unit.UnitCode,Unit.UnitType,Unit.UnitDescription,Unit.Grade FROM Cluster
INNER JOIN CourseCluster ON CourseCluster.Cluster_ID = Cluster.Cluster_ID 
INNER JOIN Course ON CourseCluster.Course_ID = Course.Course_ID
inner join TeacherTeaching on TeacherTeaching.Course_ID = Course.Course_ID
INNER JOIN Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID
INNER JOIN ClusterUnit ON Cluster.Cluster_ID = ClusterUnit.Cluster_ID
INNER JOIN Unit on ClusterUnit.Unit_ID = Unit.Unit_ID
Where Semester.StartDate = @startDate AND Semester.EndDate = @endDate
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllColleges]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllColleges]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
   College.College_ID,
   College.[Name],
   College.CollegeLocation FROM College
END


GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllCourses]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllCourses]
AS
BEGIN
SET NOCOUNT ON;
   Select Course.Course_ID, Course.Description,Course.HoursPerWeek,Course.Cost,Course.[Name],
Cluster.Cluster_ID,Cluster.ClusterName,Cluster.ClusterDescription, Unit.Unit_ID,Unit.UnitCode,
Unit.UnitType,Unit.UnitDescription,Unit.Grade FROM Course
INNER JOIN CourseCluster ON CourseCluster.Course_ID = Course.Course_ID 
INNER JOIN Cluster ON CourseCluster.Cluster_ID = Cluster.Cluster_ID 
INNER JOIN ClusterUnit ON Cluster.Cluster_ID = ClusterUnit.Cluster_ID
INNER JOIN Unit on ClusterUnit.Unit_ID = Unit.Unit_ID ORDER BY Course.Course_ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllCoursesNotInSemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllCoursesNotInSemester]
AS
BEGIN
SET NOCOUNT ON;
   Select Course.Course_ID, Course.Description,Course.HoursPerWeek,Course.Cost,Course.[Name],
Cluster.Cluster_ID,Cluster.ClusterName,Cluster.ClusterDescription, Unit.Unit_ID,Unit.UnitCode,
Unit.UnitType,Unit.UnitDescription,Unit.Grade FROM Course
INNER JOIN CourseCluster ON CourseCluster.Course_ID = Course.Course_ID 
INNER JOIN Cluster ON CourseCluster.Cluster_ID = Cluster.Cluster_ID 
INNER JOIN ClusterUnit ON Cluster.Cluster_ID = ClusterUnit.Cluster_ID
INNER JOIN Unit on ClusterUnit.Unit_ID = Unit.Unit_ID 
FULL JOIN TeacherTeaching on  Course.Course_ID = TeacherTeaching.Course_ID
WHERE Course.Course_ID NOT IN (Select Course_ID from TeacherTeaching)
ORDER BY Course.Course_ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllSemesters]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllSemesters]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
   Semester.Semester_ID,
   Semester.StartDate,
   Semester.EndDate,
   Semester.Duration FROM Semester
END


GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllStudents]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllStudents]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
   Student_ID,
   FirstName,
   LastName,
   DOB,
   StreetAddress,
   Suburb,
   [State],
   PostCode,
   Mobile,
   Gender,
   Email
   FROM Student
END





GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllTeachers]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllTeachers]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllUnits]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllUnits]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
   Unit.Unit_ID,Unit.UnitCode,
Unit.UnitType,Unit.UnitDescription,Unit.Grade
   FROM Unit
END



GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllUnitsNotInCourseOrSemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_SelectAllUnitsNotInCourseOrSemester]
AS
BEGIN
SET NOCOUNT ON;
   SELECT 
Unit.Unit_ID,Unit.UnitCode,
Unit.UnitType,Unit.UnitDescription,Unit.Grade 
FROM Unit 
full join ClusterUnit on ClusterUnit.Unit_ID = Unit.Unit_ID 
full join Cluster on Cluster.Cluster_ID = ClusterUnit.Cluster_ID
full JOIN CourseCluster ON CourseCluster.Cluster_ID = Cluster.Cluster_ID 
Where Unit.Unit_ID NOT IN(Select ClusterUnit.Unit_ID FROM ClusterUnit) 
OR CourseCluster.Course_ID NOT IN(Select Course_ID from Course)
END



GO
/****** Object:  StoredProcedure [dbo].[sp_StudentEnrolments]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentEnrolments]
@studentId int
AS
BEGIN
   SELECT 
   Enrolment.Enrolment_ID,
   Enrolment.Student_ID,
   Enrolment.Course_ID,
   Enrolment.College_ID,
   Enrolment.Semester_ID,
   Enrolment.Payment_ID,
   Enrolment.EnrolmentDate,
   Enrolment.Result,
   Course.[Name],
   College.[Name]
   FROM Enrolment inner join Student on Student.Student_ID = Enrolment.Student_ID
   inner join Course on Enrolment.Course_ID = Course.Course_ID
   inner join College on Enrolment.College_ID = College.College_ID
   Where Student.Student_ID = @studentId
END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsByLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsByLocation]
@location NVARCHAR(50)
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   Inner join College on Enrolment.College_ID = College.College_ID where College.Name = @location
END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsBySemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsBySemester]
@startDate Date,
@endDate Date
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   Inner join Semester on Enrolment.Semester_ID = Semester.Semester_ID 
   where Semester.StartDate = @startDate AND Semester.EndDate = @endDate
END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsBySemesterAndLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsBySemesterAndLocation]
@startDate Date,
@endDate Date,
@location NVARCHAR(50)
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   Inner join College on Enrolment.College_ID = College.College_ID 
   Inner join Semester on Enrolment.Semester_ID = Semester.Semester_ID 
   where College.Name = @location
   AND Semester.StartDate = @startDate AND Semester.EndDate = @endDate
END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsBySemesterAndLocationAndStudyStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsBySemesterAndLocationAndStudyStatus]
@location NVARCHAR(50),
@startDate Date,
@endDate Date,
@studyStatus NVARCHAR(20)
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   Inner join Semester on Enrolment.Semester_ID = Semester.Semester_ID
   Inner join Course on Enrolment.Course_ID = Course.Course_ID
   Inner join College on Enrolment.College_ID = College.College_ID 
   where 
   (@studyStatus = 'full-time' AND Course.HoursPerWeek>= 20 AND Semester.StartDate = @startDate 
   AND Semester.EndDate = @endDate AND College.Name = @location) 
   OR
   (@studyStatus = 'part-time' AND Course.HoursPerWeek<20 AND Semester.StartDate = @startDate 
   AND Semester.EndDate = @endDate AND College.Name = @location)
END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsBySemesterAndStudyStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsBySemesterAndStudyStatus]
@startDate Date,
@endDate Date,
@studyStatus NVARCHAR(20)
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   Inner join Semester on Enrolment.Semester_ID = Semester.Semester_ID
   inner join Course on Enrolment.Course_ID = Course.Course_ID
   where (@studyStatus = 'full-time' AND Course.HoursPerWeek>= 20 AND Semester.StartDate = @startDate AND Semester.EndDate = @endDate) 
   OR(@studyStatus = 'part-time' AND Course.HoursPerWeek<20 AND Semester.StartDate = @startDate AND Semester.EndDate = @endDate)
END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsByStudyStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsByStudyStatus]
@studyStatus NVARCHAR(20)
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   inner join Course on Enrolment.Course_ID = Course.Course_ID
   Where  (@studyStatus = 'full-time' AND Course.HoursPerWeek>= 20) 
   OR(@studyStatus = 'part-time' AND Course.HoursPerWeek<20)


END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsByStudyStatusAndLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsByStudyStatusAndLocation]
@studyStatus NVARCHAR(20),
@location NVARCHAR(50)
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   inner join Course on Enrolment.Course_ID = Course.Course_ID
   Inner join College on Enrolment.College_ID = College.College_ID 
   Where  (@studyStatus = 'full-time' AND Course.HoursPerWeek>= 20 AND College.Name = @location) 
   OR(@studyStatus = 'part-time' AND Course.HoursPerWeek<20 AND College.Name = @location)


END





GO
/****** Object:  StoredProcedure [dbo].[sp_StudentsEnrolledNotPaid]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_StudentsEnrolledNotPaid]
AS
BEGIN
   SELECT 
   Student.Student_ID,
   Student.FirstName,
   Student.LastName,
   Student.DOB,
   Student.StreetAddress,
   Student.Suburb,
   Student.[State],
   Student.PostCode,
   Student.Mobile,
   Student.Gender,
   Student.Email
   FROM Student inner join Enrolment on Enrolment.Student_ID = Student.Student_ID
   Inner join Course on Enrolment.Course_ID = Course.Course_ID
   Inner join Payment on Enrolment.Payment_ID = Payment.Payment_ID
   where Payment.FeePaid < Course.Cost
   
END





GO
/****** Object:  StoredProcedure [dbo].[sp_TeacherCourses]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeacherCourses]
@teacherId int

AS
BEGIN
   SELECT Course.Course_ID, Course.[Name],Course.Description,Course.HoursPerWeek,Course.Cost FROM Course
   inner join TeacherTeaching on TeacherTeaching.Course_ID= Course.Course_ID
   Inner join Teacher on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID 
   where Teacher.Teacher_ID = @teacherId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersByLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersByLocation]
@location NVARCHAR(50)
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join College on TeacherTeaching.College_ID = College.College_ID where College.Name = @location

END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersByLocationAndEmploymentStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersByLocationAndEmploymentStatus]
@employmentStatus NVARCHAR(20),
@location NVARCHAR(50)
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join College on TeacherTeaching.College_ID = College.College_ID  
   where College.Name = @location AND TeacherTeaching.EmploymentStatus = @employmentStatus
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersByNotInBasedLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersByNotInBasedLocation]
@date Date
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join College on TeacherTeaching.College_ID = College.College_ID  
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID 
   where Teacher.BasedLocation != College.[Name] AND TeacherTeaching.EmploymentStatus = 'full-time'
   AND @date BETWEEN Semester.StartDate AND Semester.EndDate 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersBySemester]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersBySemester]
@startDate Date,
@endDate Date
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID 
   where Semester.StartDate = @startDate AND Semester.EndDate = @endDate

END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersBySemesterAndEmploymentStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersBySemesterAndEmploymentStatus]
@startDate Date,
@endDate Date,
@employmentStatus NVARCHAR(20)
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID 
   where TeacherTeaching.EmploymentStatus = @employmentStatus AND Semester.StartDate = @startDate AND Semester.EndDate = @endDate

END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersBySemesterAndLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersBySemesterAndLocation]
@startDate Date,
@endDate Date,
@location NVARCHAR(50)
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join College on TeacherTeaching.College_ID = College.College_ID  
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID 
   where College.Name = @location
   AND Semester.StartDate = @startDate AND Semester.EndDate = @endDate
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersBySemesterAndLocationAndEmploymentStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersBySemesterAndLocationAndEmploymentStatus]
@startDate Date,
@endDate Date,
@employmentStatus NVARCHAR(20),
@location NVARCHAR(50)
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   Inner join College on TeacherTeaching.College_ID = College.College_ID  
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID 
   where College.Name = @location
   AND Semester.StartDate = @startDate AND Semester.EndDate = @endDate AND TeacherTeaching.EmploymentStatus = @employmentStatus
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeacherSemesterCourse]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeacherSemesterCourse]
@teacherId int,
@start DATE,
@end DATE

AS
BEGIN
   SELECT Course.Course_ID, Course.[Name],Course.Description,Course.HoursPerWeek,Course.Cost FROM Course
   inner join TeacherTeaching on TeacherTeaching.Course_ID= Course.Course_ID
   Inner join Teacher on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID 
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID
   where Teacher.Teacher_ID = @teacherId AND Semester.StartDate = @start AND Semester.EndDate = @end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeacherSemesterLocation]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeacherSemesterLocation]
@teacherId int,
@start DATE,
@end DATE

AS
BEGIN
   SELECT College.College_ID, College.[Name],College.CollegeLocation FROM College 
   inner join TeacherTeaching on TeacherTeaching.College_ID= College.College_ID
   Inner join Teacher on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID 
   Inner join Semester on TeacherTeaching.Semester_ID = Semester.Semester_ID
   where Teacher.Teacher_ID = @teacherId AND Semester.StartDate = @start AND Semester.EndDate = @end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TeachersEmploymentStatus]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_TeachersEmploymentStatus]
@employmentStatus NVARCHAR(20)
AS
BEGIN
    SELECT 
   Teacher.Teacher_ID,
   Teacher.FirstName,
   Teacher.LastName,
   Teacher.DOB,
   Teacher.StreetAddress,
   Teacher.Suburb,
   Teacher.[State],
   Teacher.PostCode,
   Teacher.Mobile,
   Teacher.Gender,
   Teacher.Email,
   Teacher.[Password],
   Teacher.BasedLocation
   FROM Teacher inner join TeacherTeaching on TeacherTeaching.Teacher_ID = Teacher.Teacher_ID
   where TeacherTeaching.EmploymentStatus = @employmentStatus

END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStudent]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_UpdateStudent]
    @Id int,
	@fname nvarchar(50),
	@lname nvarchar(50),
	@dob Date,
	@streetAdd nvarchar(50),
	@suburb nvarchar(50),
	@state nvarchar(50),
	@postcode nvarchar(50),
	@mobile nvarchar(50),
	@gender nvarchar(50),
	@email nvarchar(50)

AS
BEGIN
	Update Student
	Set FirstName = ISNULL(NULLIF(@fname,''),FirstName),
	 LastName = ISNULL(NULLIF(@lname,''),LastName),
	 DOB = ISNULL(NULLIF(@dob,'9999-11-11'),DOB),
	 StreetAddress = ISNULL(NULLIF(@streetAdd,''),StreetAddress),
	 Suburb = ISNULL(NULLIF(@suburb,''),Suburb),
	 [State] = ISNULL(NULLIF(@state,''),[State]),
	 PostCode = ISNULL(NULLIF(@postcode,''),PostCode),
	 Mobile = ISNULL(NULLIF(@mobile,''),Mobile),
	 Gender = ISNULL(NULLIF(@gender,''),Gender),
	 Email = ISNULL(NULLIF(@email,''),Email)
	Where @Id = Student_ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTeacher]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_UpdateTeacher]
    @Id int,
	@fname nvarchar(50),
	@lname nvarchar(50),
	@dob Date,
	@streetAdd nvarchar(50),
	@suburb nvarchar(50),
	@state nvarchar(50),
	@postcode nvarchar(50),
	@mobile nvarchar(50),
	@gender nvarchar(50),
	@email nvarchar(50),
	@password nvarchar(50),
	@basedLocation nvarchar(50)

AS
BEGIN
	Update Teacher
	Set FirstName = ISNULL(NULLIF(@fname,''),FirstName),
	 LastName = ISNULL(NULLIF(@lname,''),LastName),
	 DOB = ISNULL(NULLIF(@dob,'9999-11-11'),DOB),
	 StreetAddress = ISNULL(NULLIF(@streetAdd,''),StreetAddress),
	 Suburb = ISNULL(NULLIF(@suburb,''),Suburb),
	 [State] = ISNULL(NULLIF(@state,''),[State]),
	 PostCode = ISNULL(NULLIF(@postcode,''),PostCode),
	 Mobile = ISNULL(NULLIF(@mobile,''),Mobile),
	 Gender = ISNULL(NULLIF(@gender,''),Gender),
	 Email = ISNULL(NULLIF(@email,''),Email),
	 [Password] = ISNULL(NULLIF(@password,''),[Password]),
	 BasedLocation = ISNULL(NULLIF(@basedLocation,''),BasedLocation)
	Where @Id = Teacher_ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserLogin]    Script Date: 10/06/2022 12:19:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_UserLogin]

(

        @email nvarchar(50),

        @password nvarchar(50)

)

as

declare @status int

if exists(select * from Teacher where Email=@email and [Password]=@password)

       set @status=1

else

       set @status=0

select @status
GO
USE [master]
GO
ALTER DATABASE [TafeSystem] SET  READ_WRITE 
GO
EXEC TafeSystem.dbo.sp_ResetDataBase;  
GO
