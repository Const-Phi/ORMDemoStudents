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
    (1, N'���������� ���������� ����������')
  , (2, N'��������� ������ ����������')

 insert into Faculty.Subjects values 
    (1, N'������������ ���������� � �������� ����������')
  , (2, N'�������������� � ���������� ����������������')
  , (3, N'������������ �������')
  , (4, N'������������������� �������')

insert into Faculty.ProfessorToSubjects values 
    (1, 1, 1)
  , (2, 2, 1)
  , (3, 1, 2)
  , (4, 2, 2)
  , (5, 1, 3)
  , (6, 2, 4)