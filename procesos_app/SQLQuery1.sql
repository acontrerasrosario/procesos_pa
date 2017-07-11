-- DISPONIBILIDAD DEL PROFESOR



SELECT prof.NOMBRE, sec.[Name] , subj.[Name], sch.[Name] ,(CASE sch.[Day] 
																	WHEN 0 THEN 'LUNES'
																	WHEN 1 THEN 'MARTES'
																	WHEN 2 THEN 'MIERCOLES'
																	WHEN 3 THEN 'JUEVES'
																	WHEN 4 THEN 'VIERNES'
																	ELSE 'SABADO'
																	END) AS DIA, 
								DATEPART(HOUR, sch.StartTime)  AS HORA_INICIO,
								DATEPART(HOUR, sch.EndTime)  AS HORA_FIN
FROM Sections sec
JOIN [dbo].[Subjects] subj ON (sec.SubjectId = subj.Id)
JOIN [dbo].[SectionSchedules] ss ON (sec.Id = ss.SectionId)
JOIN [dbo].[Schedules] sch ON (ss.ScheduleId = sch.Id)
JOIN 
	(SELECT u.Id AS IDPROF, u.FirstName AS NOMBRE, tp.Id AS TANDAID, sch.Id AS SCHEDULE														
	FROM [dbo].[AspNetUsers] u
	JOIN [dbo].[AspNetUserRoles] ur ON (u.Id = ur.UserId)
	JOIN [dbo].[AspNetRoles] r ON (ur.RoleId = r.Id)
	JOIN [dbo].[TandaProfesors] tp ON (u.Id = tp.ProfesorId)
	JOIN [dbo].[Schedules] sch ON (tp.TandaId = sch.Id)
	WHERE r.Name = 'Profesor' ) prof
ON (sch.Id = prof.SCHEDULE)
JOIN [dbo].[ProfesorAutorizacions] pa ON (subj.Id = pa.SubjectId)
WHERE prof.IDPROF IN 
					(SELECT paa.ProfesorId 
					FROM [dbo].[ProfesorAutorizacions] paa
					WHERE paa.SubjectId = subj.Id)