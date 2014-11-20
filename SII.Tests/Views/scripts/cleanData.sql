use [SII.Models.SIIContext];

delete Entrances;

delete from barreras where barrera = 'Barrera prueba';
delete from barreras where barrera = 'Barrera prueba 2';

delete from Visits where AnnouncementId > 1;
delete from Announcements where id > 1;

delete from Campus where Code = 'UNITEG';
delete from Campus where Code = 'UNISPS';
