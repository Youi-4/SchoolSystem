This is a school system application I had created in a previous assessment using the .net core 3.1 framework.
It was developed using a three-layer architecture(Model Layer, Business Layer and Client Layer).

To start application you must have Visual Studio installed as well as a Microsoft SQL Server Management Studio. 
Then run the TafeSystemDataBaseScript sql script to create the database that is compatible with the application.
Next run the TafeSystem.sln with visual studio.

To login, the email and password must be in the Teacher table inside the TafeSystem database. 
One of the emails inside the database which can be used to login is JohnSmith@tafensw.au and password:John


This application required the following business rules when tasked to create it:

A student can enrol in two courses in the same semester. The enrolments must be at the same college.
A student may not be enrolled in a semester
A course can be taught at more than one college/location.
A college/location can run at more than one course.
A teacher can teach more than one course and a course can be taught by more than one teacher
A course consists of clusters of units and a teacher is assigned to a cluster
A unit can appear in in many courses
A course can run at more than one location and a location may run more than one course
A course runs over one semester and each semester consists of two terms (9 weeks each) 
A course consists of core and elective units 
A cluster of units may consist of core and elective units 
A teacher can only teach one cluster in a course 
To pass any unit, all the assessments associated with the units must be passed

It also required the following business requirements:

Display all the courses and locations for a teacher teaching the courses any semester.
Display all the courses which are not offered in the any semester.
Display all the units/subjects which are not allocated to any course in any semester.
Display cluster units for any course and semester.
Display history of all the courses a teacher has taught in the past.
Display all the teachers based on a particular location.
Display results of any student for a course and semester.
Display enrolments of any student for a course and semester.
Display timetable for a course being offered at all locations.
Display a list of all part time teachers for a semester and location.
Display students who have enrolled but have not paid the fees.
Display part time/full time students for a semester and location
Display all the full time teachers who are teaching at locations other than their based location.
