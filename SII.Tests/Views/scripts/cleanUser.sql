declare @userId int;
select @userId = (select UserId from UserProfile where UserName = 'user');

delete from webpages_UsersInRoles where UserId = @userId;
delete from webpages_Membership where UserId = @userId;
delete from UserProfile where UserId = @userId;