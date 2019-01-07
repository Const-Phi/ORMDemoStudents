create table Faculty.Professors (
    Id int primary key
  , FullName nvarchar(255) not null
)

create table Faculty.Subjects (
    Id int primary key
  , FullName nvarchar(255) not null
)

create table Faculty.ProfessorToSubjects (
    Id int primary key
  , Professor_Id int foreign key references Faculty.Professors(Id)
  , Subject_Id int foreign key references Faculty.Subjects(Id)
)

insert into Faculty.Professors values 
    (1, N'Филипченко Константин Михайлович')
  , (2, N'Васильева Марина Алексеевна')

 insert into Faculty.Subjects values 
    (1, N'Компьютерные технологии в системах управления')
  , (2, N'Алгоритмизация и технологии программирования')
  , (3, N'Компьютерная графика')
  , (4, N'Электромеханические системы')

insert into Faculty.ProfessorToSubjects values 
    (1, 1, 1)
  , (2, 2, 1)
  , (3, 1, 2)
  , (4, 2, 2)
  , (5, 1, 3)
  , (6, 2, 4)