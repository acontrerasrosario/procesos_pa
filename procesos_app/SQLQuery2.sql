DECLARE @profesor VARCHAR(MAX)

SET @profesor = 'cb032e50-5ee4-420d-8827-67a9ce6eabf4'


SELECT pa.SubjectId FROM [dbo].[ProfesorAutorizacions] pa
join [dbo].[Subjects] s on pa.SubjectId = s.Id
WHERE  @profesor!= pa.ProfesorId
and pa.SubjectId not in 
				(SELECT paa.SubjectId FROM [dbo].[ProfesorAutorizacions] paa
WHERE paa.ProfesorId = @profesor)




SELECT u.Id AS IDPROF, u.FirstName AS NOMBRE, tp.Id AS TANDAID, sch.Id AS SCHEDULE														
	FROM [dbo].[AspNetUsers] u
	JOIN [dbo].[AspNetUserRoles] ur ON (u.Id = ur.UserId)
	JOIN [dbo].[AspNetRoles] r ON (ur.RoleId = r.Id)
	JOIN [dbo].[TandaProfesors] tp ON (u.Id = tp.ProfesorId)
	JOIN [dbo].[Schedules] sch ON (tp.TandaId = sch.Id)
	WHERE r.Name = 'Profesor' 


DECLARE @classroomid int

SET @classroomid = 4


SELECT sch.[Name], (CASE sch.[Day] 
								WHEN 0 THEN 'LUNES'
								WHEN 1 THEN 'MARTES'
								WHEN 2 THEN 'MIERCOLES'
								WHEN 3 THEN 'JUEVES'
								WHEN 4 THEN 'VIERNES'
								ELSE 'SABADO'
								END) AS DIA,
								
					sch.StartTime, sch.EndTime

FROM [dbo].[Schedules] sch




SELECT s.[Name], (CASE s.[Day] 
								WHEN 0 THEN 'LUNES y Miercoles'
								WHEN 1 THEN 'MARTES'
								WHEN 2 THEN 'MIERCOLES'
								WHEN 3 THEN 'JUEVES'
								WHEN 4 THEN 'VIERNES'
								ELSE 'SABADO'
								END) AS DIA,
								
					s.StartTime, s.EndTime

FROM [dbo].[Schedules] s
JOIN [dbo].[SectionSchedules] ss on (s.Id= ss.ScheduleId)
JOIN [dbo].[Sections] sec on (ss.SectionId= sec.Id)
WHERE s.Id not in 
				(SELECT sch.Id AS HORARIO_ID FROM [dbo].[ClassRooms] r
				JOIN [dbo].[Sections] secc on r.Id = secc.ClassRoomId
				JOIN [dbo].[SectionSchedules] secs on secc.Id = secs.SectionId
				JOIN [dbo].[Schedules] sch on secs.ScheduleId = sch.Id
				WHERE secc.ClassRoomId = 6)




SELECT * FROM [dbo].[Trimesters] t
WHERE GETDATE() BETWEEN t.Inicio and t.Fin






