use University

create schema Faculty

create table Faculty.Groups (
    Id int primary key
  , Name nvarchar(10) not null
)

create table Faculty.Students (
    Id int primary key 
  , FullName nvarchar(255) not null
  , Group_Id int foreign key references Faculty.Groups(Id) 
)


insert into Faculty.Groups values (1, N'ТУУ-151')

select * from Faculty.Groups

insert into Faculty.Students values 
(1, N'Антонов Дмитрий', 1),
(2, N'Тимофеева Ольга', 1),
(3, N'Патутин Дмитрий', 1)

select * from Faculty.Students
