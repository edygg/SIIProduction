declare @userId int;
select @userId = (select UserId from UserProfile where UserName = 'user');

delete from webpages_UsersInRoles where UserId = @userId;
delete from webpages_Membership where UserId = @userId;
delete from UserProfile where UserId = @userId;


declare @guardiaId int;
select @guardiaId = (select UserId from UserProfile where UserName = 'guardia');

delete from webpages_UsersInRoles where UserId = @guardiaId;
delete from webpages_Membership where UserId = @guardiaId;
delete from UserProfile where UserId = @guardiaId;

declare @guardia2Id int;
select @guardia2Id = (select UserId from UserProfile where UserName = 'guardia2');

delete from webpages_UsersInRoles where UserId = @guardia2Id;
delete from webpages_Membership where UserId = @guardia2Id;
delete from UserProfile where UserId = @guardia2Id;