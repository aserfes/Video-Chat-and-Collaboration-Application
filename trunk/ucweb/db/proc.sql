SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[_usplu_get_time_zones]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [_usplu_get_time_zones]
AS
 
Set NoCount On



select
	time_zone_id,
	time_zone_name
from lu_time_zone
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_select_image]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_select_image]
(
@incident_id int,
@field nvarchar(50)
)
AS
 
Set NoCount On

DECLARE @sqlCommand varchar(1000)
SET @sqlCommand = ''SELECT '' + @field + '' from uc_log where incident_id = '' + CAST( @incident_id as varchar(10) )
EXEC (@sqlCommand)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_SEARCH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_SEARCH]
(
@keyword	nvarchar(50)
)
AS
 
Set NoCount On



select

	KbArticleId,
	Lang,
	LastReviewedDate,
	Title,
	Summary,
	Body,
	Keywords,
	InsertDate,
	InsertUser,
	UpdateDate,
	UpdateUser,
	row_version

from SEARCH

where
--	contains (Title, @keyword )
--or	contains (Summary, @keyword )
--or	contains (Body, @keyword )
--or	contains (Keywords, @keyword )

	Title		like ''%'' + @keyword + ''%''
or	Summary		like '''' + @keyword + ''''
or	Body		like '''' + @keyword + ''''
or	Keywords	like ''%'' + @keyword + ''%''
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_select]
(
@agent_id	int
)
AS
 
Set NoCount On


select
	
	a.agent_id,
	a.agent_guid,
	a.user_id,
	a.first_name,
	a.last_name,
	a.email,
	a.phone,

	a.public_enabled,

	a.date_created,
	a.date_updated,
	a.date_deleted,

	(select count(group_id)	from uc_group_agent	where agent_id = a.agent_id)	as group_cnt,
	(select count(skill_id)	from uc_agent_skill	where agent_id = a.agent_id)	as skill_cnt,
	(select count(language_id)	from uc_agent_language	where agent_id = a.agent_id)	as language_cnt

from uc_agent a

where a.is_deleted = 0
	and (a.agent_id = @agent_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_get_languages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_get_languages]
(
@agent_id	int
)
AS
 
Set NoCount On

select
	s.language_id,
	s.language_name,
	sa.agent_id

from uc_language s
	left join uc_agent_language sa on (sa.language_id = s.language_id and sa.agent_id = @agent_id)

where s.is_deleted = 0 and 
((sa.agent_id = @agent_id) or (sa.agent_id is NULL))

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_language_select]
(
@language_id	int
)
AS
 
Set NoCount On

select
l.language_id,
l.language_name,
l.date_created,
l.date_updated,
l.date_deleted,
l.is_deleted,
(select count(agent_id)	from uc_agent_language	where language_id = l.language_id) as agent_cnt
from uc_language l
where l.is_deleted = 0 and l.language_id = @language_id;


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_set_agent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_language_set_agent]
(
@agent_id		int,
@language_id	int,
@set			bit
)
AS
 
Set NoCount On

if(@set = 1)
	insert uc_agent_language(agent_id, language_id)
	values(@agent_id, @language_id)
else
	delete uc_agent_language
	where language_id = @language_id	and agent_id = @agent_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_get_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_language_get_list]
(
@agent_id		int
)
AS
 
Set NoCount On

select
l.language_id,
l.language_name,
l.date_created,
l.date_updated,
l.date_deleted,
l.is_deleted,
(select count(agent_id)	from uc_agent_language	where language_id = l.language_id) as agent_cnt
from uc_language l
where l.is_deleted = 0 and
((@agent_id = 0) or l.language_id in (select language_id from uc_agent_language al where al.agent_id = @agent_id))
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_get_agents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_language_get_agents]
(
@language_id	int
)
AS
 
Set NoCount On

select
		
	a.agent_id,
	a.first_name,
	a.last_name,

	sa.language_id

from uc_agent a
	left join uc_agent_language sa on (sa.agent_id = a.agent_id and sa.language_id = @language_id)

where a.is_deleted = 0
	and ((sa.language_id = @language_id) or (sa.language_id is NULL))



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_language_delete]
(
@language_id	int
)
AS
 
Set NoCount On

delete uc_agent_language
where language_id = @language_id

update uc_language
	set
	is_deleted = 1,
	date_deleted = getUtcDate()
where language_id = @language_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_queue_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_queue_list]
(
@status_id	int,
@agent_id	int
)
AS
 
Set NoCount On

declare @public_enabled	bit

select @public_enabled = a.public_enabled
from uc_agent a
where a.agent_id = @agent_id

select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.skill_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,

luis.incident_status_name,

g.group_name	as group_name,
s.skill_name    as skill_name,
l.language_name as language_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_skill s on s.skill_id = i.skill_id
	left join uc_language l on l.language_id = i.language_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
	and (i.status_id = 1)

	and ((i.agent_id = @agent_id) or (i.agent_id is NULL))
	and ((i.reserved_agent_id = @agent_id) or (i.reserved_agent_id is NULL))	-- ##-------------------------------

	and ((@public_enabled = 1) or (i.facility_id is not NULL))

-- Routing Facility Group filtration
/*
	and	(
			(f.facility_id in 
				(
				select gf.facility_id
				from uc_group g
					join uc_group_agent ga		on ga.group_id = g.group_id
					join uc_group_facility gf	on gf.group_id = g.group_id
				where g.is_deleted = 0
					and ga.agent_id = @agent_id
				)
			)
			or
			(f.facility_id is NULL)
		)
*/
-- Routing Facility Group filtration
	
-- Routing Incident Group filtration
	and	(
			(i.group_id in 
				(
				select g.group_id
				from uc_group g
					join uc_group_agent ga on ga.group_id = g.group_id
				where g.is_deleted = 0
					and ga.agent_id = @agent_id
				)
			)
			or
			(i.group_id is NULL)
		)
-- Routing Incident Group filtration

-- Routing Skill filtration
	and	(
			(i.skill_id in 
				(
				select s.skill_id
				from uc_skill s
					 join uc_agent_skill sa on sa.skill_id = s.skill_id
				where s.is_deleted = 0 and sa.agent_id = @agent_id
				)
			)
			or
			(i.skill_id is NULL)
		)
-- Routing Skill filtration

-- Routing Language filtration
	and	(
			(i.language_id in 
				(
				select l.language_id
				from uc_language l
					 join uc_agent_language sa on sa.language_id = l.language_id
				where s.is_deleted = 0 and sa.agent_id = @agent_id
				)
			)
			or
			(i.language_id is NULL)
		)
-- Routing Language filtration

order by i.agent_id desc, i.date_created

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_open_followup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_open_followup]
(
	@incident_id int,
	@agent_id int
)
AS
 
	SET NOCOUNT ON

	UPDATE uc_incident
		SET
			agent_id = @agent_id,
			date_open = getUTCDate(),
			date_updated = getUTCDate()
		WHERE incident_id = @incident_id
		AND status_id = 5 -- Follow-Up
		AND ((agent_id IS NULL) OR (agent_id = @agent_id))
		-- AND ((reserved_agent_id IS NULL) OR (reserved_agent_id = @agent_id))

	UPDATE uc_facility
		SET agent_id = @agent_id
		WHERE facility_id IN
			(
				SELECT facility_id
				FROM uc_incident
				WHERE incident_id = @incident_id
					AND status_id = 5 -- Follow-Up
			)

select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
and (i.incident_id = @incident_id)







---------------------------
-- update uc_incident set status_id		= 1 where incident_id = @incident_id
---------------------------
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_reservation_set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_reservation_set]
(
@incident_id		int,
@reserved_agent_id	int = NULL
)
AS
 
Set NoCount On



update uc_incident
	set
	reserved_agent_id	= @reserved_agent_id,
	date_updated		= getUtcDate()
									
where incident_id = @incident_id
--	and (reserved_agent_id is NULL)
--	and ((agent_id <> @reserved_agent_id) or (agent_id is null))


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_select_by_guid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_select_by_guid]
(
@incident_guid	uniqueidentifier
)
AS
 
Set NoCount On


select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name


from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id


where i.is_deleted = 0
and (i.incident_guid = @incident_guid)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_select]
(
@incident_id	int
)
AS
 
Set NoCount On


select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.skill_id,
i.language_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_skill s on s.skill_id = i.skill_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
and (i.incident_id = @incident_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_open]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_open]
(
@incident_id	int,
@agent_id		int
)
AS
 
	SET NOCOUNT ON

	UPDATE uc_incident
		SET
			agent_id = @agent_id,
			status_id = 2, -- In-Progress
			date_open = getUTCDate(),
			date_updated = getUTCDate()
		WHERE incident_id = @incident_id
			AND status_id = 1 -- New
			AND ((agent_id IS NULL) OR (agent_id = @agent_id))
			AND ((reserved_agent_id IS NULL) OR (reserved_agent_id = @agent_id))

	UPDATE uc_facility
		SET agent_id = @agent_id
		WHERE facility_id IN
			(
				SELECT facility_id
				FROM uc_incident
				WHERE incident_id = @incident_id
					AND status_id = 2 -- In-Progress
					AND ((agent_id IS NULL) OR (agent_id = @agent_id))
					AND ((reserved_agent_id IS NULL) OR (reserved_agent_id = @agent_id))
			)


select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
and (i.incident_id = @incident_id)







---------------------------
-- update uc_incident set status_id		= 1 where incident_id = @incident_id
---------------------------
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_subject_set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_incident_subject_set]
(
	@incident_id int,
	@status_id int,
	@subject nvarchar(100)
)
AS
 
	SET NOCOUNT ON

	DECLARE @agent_id int
	DECLARE @facility_id int

	SELECT
		@agent_id = agent_id,
		@facility_id = facility_id
		FROM uc_incident
		WHERE incident_id = @incident_id

	IF @status_id = 3 OR @status_id = 4 -- Cancelled or Closed
	BEGIN
		SET @agent_id = NULL
	END

	UPDATE uc_incident
		SET
			status_id = @status_id,
			subject = @subject,
			date_updated = getUtcDate()
		WHERE incident_id = @incident_id

	UPDATE uc_facility
		SET agent_id = @agent_id
		WHERE facility_id = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_status_set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_status_set]
(
	@incident_id	int,
	@status_id		int
)
AS
	SET NOCOUNT ON

	DECLARE @agent_id int
	DECLARE @facility_id int

	SELECT
		@agent_id = agent_id,
		@facility_id = facility_id
		FROM uc_incident
		WHERE incident_id = @incident_id

	IF @status_id = 3 OR @status_id = 4 -- Cancelled or Closed
	BEGIN
		SET @agent_id = NULL
	END

	UPDATE uc_incident
		SET
		status_id = @status_id,
		date_updated = getUtcDate()
	WHERE incident_id = @incident_id

	UPDATE uc_facility
		SET agent_id = @agent_id
		WHERE facility_id = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_list_get_by_status]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_list_get_by_status]
(
@status_id	int = 0,
@agent_id	int = 0
)
AS
 
Set NoCount On






select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,
s.skill_name	as skill_name,
l.language_name as language_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name


from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_skill s on s.skill_id = i.group_id
	left join uc_language l on l.language_id = i.language_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
	and ((i.status_id = @status_id) or (@status_id = 0))
	and ((i.agent_id = @agent_id) or (@agent_id = 0))	-- ##-------------------------------
	and ((i.agent_id is NULL) or (i.agent_id = @agent_id) or (@agent_id = 0))


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_status_get]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_status_get]
(
@incident_id	int
)
AS
 
Set NoCount On


select
	status_id
from uc_incident
where incident_id = @incident_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_list_get_by_contact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_list_get_by_contact]
(
@status_id	int,
@contact_id	int
)
AS
 
Set NoCount On






select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
	and ((i.status_id = @status_id) or (@status_id = 0))
	and (i.contact_id = @contact_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_followup_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_followup_list]
(
@status_id	int,
@agent_id	int
)
AS
 

Set NoCount On






select
	
i.incident_id,
i.incident_guid,
i.subject,

i.group_id,
i.facility_id,
i.contact_id,
i.agent_id,
i.status_id,

i.reserved_agent_id,
i.connect_count,

i.date_created,

i.date_open,
i.date_closed,

i.date_updated,
i.date_deleted,


luis.incident_status_name,

g.group_name	as group_name,
s.skill_name	as skill_name,
l.language_name as language_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_guid,
f.facility_name	as facility_name,

log.consumer_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g on g.group_id = i.group_id
	left join uc_skill s on s.skill_id = i.group_id
	left join uc_language l on l.language_id = i.language_id
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id
	left join uc_log log on log.incident_id = i.incident_id

where i.is_deleted = 0
	and ((i.status_id = @status_id) or (@status_id = 0))
--	and ((i.agent_id = @agent_id) or (@agent_id = 0))	-- ##-------------------------------
	and ((i.agent_id is NULL) or (i.agent_id = @agent_id) or (@agent_id = 0))


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_insert]
(
@group_id		int,
@skill_id		int,
@language_id	int,
@facility_id	int,
@contact_id		int,
@agent_id		int
)
AS
 
-- @contact_id and @agent_id are always 0 ???
Set NoCount On

declare @guid as uniqueidentifier
set		@guid = newID()

insert uc_incident (incident_guid,group_id,skill_id,language_id,facility_id,contact_id,agent_id,status_id)
values (@guid,@group_id,@skill_id,@language_id,@facility_id,@contact_id,@agent_id,1)




select SCOPE_IDENTITY() as id
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_delete]
(
	@incident_id int
)
AS
	SET NOCOUNT ON

	--DELETE uc_incident
	--WHERE incident_id = @incident_id

	UPDATE uc_incident
		SET
		is_deleted = 1,
		date_deleted = getUtcDate()
	WHERE incident_id = @incident_id

	DECLARE @agent_id int
	SELECT @agent_id = agent_id FROM uc_incident WHERE incident_id = @incident_id

	UPDATE uc_facility
		SET agent_id = NULL
		WHERE facility_id IN
			(
				SELECT facility_id
				FROM uc_incident
				WHERE incident_id = @incident_id
					AND agent_id = @agent_id
			)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_connect_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_incident_connect_update]
(
	@incident_id int
)
AS
 
Set NoCount On



update uc_incident
	set
	connect_count	= connect_count + 1,
	date_updated	= getUtcDate()
									
where incident_id = @incident_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_update]
(
	@incident_id int,
	@contact_id int,
	@agent_id int,
	@status_id int,
	@subject nvarchar(100)
)
AS
	SET NOCOUNT ON

	UPDATE uc_incident
		SET
			contact_id = @contact_id,
			agent_id = @agent_id,
			status_id = @status_id,
			subject = @subject,
			date_updated = getUtcDate(),
			date_closed =
				CASE
					WHEN @status_id = 4 THEN getUtcDate() -- Close
					ELSE NULL
				END 
		WHERE incident_id = @incident_id

	UPDATE uc_facility
		SET agent_id =
			CASE
				WHEN @status_id = 2 OR @status_id = 5 THEN @agent_id -- InProcess FollowUp
				ELSE NULL
			END
		WHERE facility_id IN
			(
				SELECT facility_id
				FROM uc_incident
				WHERE incident_id = @incident_id
			)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_report_incident]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [usp_report_incident]
(
@date_start	datetime,
@date_end	datetime
)
AS
 
Set NoCount On



select

	
i.incident_id,
i.subject,


i.date_created,
i.date_open,
i.date_closed,
i.date_updated,
i.date_deleted,

luis.incident_status_name,

g.group_name	as group_name,

a.first_name	as agent_first_name,
a.last_name		as agent_last_name,

c.first_name	as contact_first_name,
c.last_name		as contact_last_name,

f.facility_name	as facility_name

from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g		on g.group_id = i.group_id
	left join uc_agent a		on a.agent_id = i.agent_id
	left join uc_contact c		on c.contact_id = i.contact_id
	left join uc_facility f	on f.facility_id = i.facility_id

where i.is_deleted = 0
and i.date_created between @date_start and @date_end
--and (i.date_created >= @date_start and i.date_created <= @date_end)


order by i.incident_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_report_survey_average]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [usp_report_survey_average]
(
@date_start	datetime,
@date_end	datetime
)
AS
 
Set NoCount On





/*
select
	i.incident_id,
	s.survey_id,
	q.question_id,
	sr.survey_response_id,

---------------------------

	i.date_open,
	i.date_closed,

	luis.incident_status_name,

	g.group_name	as group_name,

	a.first_name	as agent_first_name,
	a.last_name		as agent_last_name,

	c.first_name	as contact_first_name,
	c.last_name		as contact_last_name,

	f.facility_name	as facility_name,

	sr.date_created	as date_survey_created,

------------------------------

	s.survey_name,
	q.question_text,
	sr1.response



from uc_incident i

	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g		on g.group_id = i.group_id
	left join uc_agent a		on a.agent_id = i.agent_id
	left join uc_contact c		on c.contact_id = i.contact_id
	left join uc_facility f	on f.facility_id = i.facility_id


	join uc_survey_response sr	on sr.incident_id = i.incident_id
	join uc_survey s			on s.survey_id = sr.survey_id
	join uc_survey_question sq	on sq.survey_id = s.survey_id
	join uc_question q			on q.question_id = sq.question_id

	left join uc_survey_response sr1
		on sr1.incident_id = i.incident_id
			and sr1.survey_id = s.survey_id
			and sr1.question_id = q.question_id

where i.is_deleted = 0
	and i.date_created between @date_start and @date_end


order by 
	s.survey_id,
	q.question_id,
	sr.survey_response_id


--
*/


select
		
	sr.survey_response_id,
	i.incident_id,
	i.subject,


	i.date_open,
	i.date_closed,


	luis.incident_status_name,

	g.group_name	as group_name,

	a.first_name	as agent_first_name,
	a.last_name		as agent_last_name,

	c.first_name	as contact_first_name,
	c.last_name		as contact_last_name,

	f.facility_name	as facility_name,



	s.survey_name,
	q.question_text,

	--sr.response,
	case when ((q.type_id = 1) and (sr.response is not null)) then '''' else sr.response end as response,

	sr.date_created	as date_survey_created




from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g		on g.group_id = i.group_id
	left join uc_agent a		on a.agent_id = i.agent_id
	left join uc_contact c		on c.contact_id = i.contact_id
	left join uc_facility f	on f.facility_id = i.facility_id

	join uc_survey_response sr	on sr.incident_id = i.incident_id
	join uc_question q			on q.question_id = sr.question_id
	join uc_survey s			on s.survey_id = sr.survey_id



where i.is_deleted = 0
--	and q.type_id in (2,3)
	and i.date_created between @date_start and @date_end


order by i.incident_id
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_report_survey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  Procedure [usp_report_survey]
(
@date_start	datetime,
@date_end	datetime
)
AS
 
Set NoCount On






select
		
	sr.survey_response_id,
	i.incident_id,
	i.subject,


	i.date_open,
	i.date_closed,


	luis.incident_status_name,

	g.group_name	as group_name,

	a.first_name	as agent_first_name,
	a.last_name		as agent_last_name,

	c.first_name	as contact_first_name,
	c.last_name		as contact_last_name,

	f.facility_name	as facility_name,



	s.survey_name,
	q.question_text,
	sr.response,
	sr.date_created	as date_survey_created




from uc_incident i
	join lu_incident_status luis on luis.incident_status_id = i.status_id

	left join uc_group g		on g.group_id = i.group_id
	left join uc_agent a		on a.agent_id = i.agent_id
	left join uc_contact c		on c.contact_id = i.contact_id
	left join uc_facility f	on f.facility_id = i.facility_id

	join uc_survey_response sr	on sr.incident_id = i.incident_id
	join uc_question q			on q.question_id = sr.question_id
	join uc_survey s			on s.survey_id = sr.survey_id



where i.is_deleted = 0
and sr.response is not NULL
and i.date_created between @date_start and @date_end



order by i.incident_id
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[intsp_delete_all_deleted]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [intsp_delete_all_deleted]
AS
 
Set NoCount On



--   [dbo].[uc_agent]
--   [dbo].[uc_call]
--   [dbo].[uc_chat]
--   [dbo].[uc_contact]
--   [dbo].[uc_contact_listing]
--   [dbo].[uc_contact_state]
--   [dbo].[uc_exception]
--   [dbo].[uc_facility]
--   [dbo].[uc_group]
--   [dbo].[uc_group_agent]
--   [dbo].[uc_group_facility]
--   [dbo].[uc_incident]
--   [dbo].[uc_incident_note]
--   [dbo].[uc_incident_state]
--   [dbo].[uc_incident_transfer]
--   [dbo].[uc_pool]
--   [dbo].[uc_question]
--   [dbo].[uc_settings]
--   [dbo].[uc_survey]
--   [dbo].[uc_survey_question]
--   [dbo].[uc_survey_response]
--   [dbo].[uc_user]






-------------------------------------------------------------------------------

delete uc_group_agent
where agent_id in
(select agent_id from uc_agent where is_deleted = 1)
-------------------------------------------------------------------------------
delete uc_group_facility
where facility_id in
(select facility_id from uc_facility where is_deleted = 1)
-------------------------------------------------------------------------------
delete uc_group_agent
where group_id in
(select group_id from uc_group where is_deleted = 1)
-------------------------------------------------------------------------------
delete uc_group_facility
where group_id in
(select group_id from uc_group where is_deleted = 1)

-------------------------------------------------------------------------------







/*

select
*
from uc_incident i
	left join uc_agent a on a.agent_id = i.agent_id
	left join uc_contact c on c.contact_id = i.contact_id
	left join uc_facility f on f.facility_id = i.facility_id

where i.is_deleted = 0
and (i.incident_id = @incident_id)

*/



select *
from uc_contact c
where c.is_deleted = 1
and not exists(select * from uc_incident i where i.is_deleted = 0)



select *
from uc_agent a
where a.is_deleted = 1
and not exists(select * from uc_incident i where i.is_deleted = 0)



select *
from uc_facility f
where f.is_deleted = 1
and not exists(select * from uc_incident i where i.is_deleted = 0)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_transfer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_transfer]
(
	@incident_id int,
	@status_id int,
	@user_id int,
	@from_agent_id int,
	@to_agent_id int
)
AS
	SET NOCOUNT ON

	INSERT uc_incident_transfer ([incident_id],[user_id],[from_agent_id],[to_agent_id])
	VALUES (@incident_id,@user_id,@from_agent_id,@to_agent_id)

	UPDATE uc_incident
		SET
		[status_id] = @status_id,
		[agent_id] = @to_agent_id,
		[reserved_agent_id] = NULL,
		[date_updated] = getUtcDate()
	WHERE incident_id = @incident_id

	UPDATE uc_facility
		SET agent_id =
			CASE
				WHEN @status_id = 2 OR @status_id = 5 THEN @to_agent_id -- InProcess FollowUp
				ELSE NULL
			END
		WHERE facility_id IN
			(
				SELECT facility_id
				FROM uc_incident
				WHERE incident_id = @incident_id
			)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_state_set_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_state_set_1]
(
@incident_id		int,
@period_to_update	int
)
AS
 
Set NoCount On



update uc_incident_state
	set
	period_to_update_1	= @period_to_update,
	date_accessed_1		= getUtcDate()

where incident_id = @incident_id






select
	i.incident_id,
	i.status_id,
	
	ins.is_active,
	ins.state,
	ins.date_updated,

	ins.period_to_update_0,
	ins.date_accessed_0,
	ins.period_to_update_1,
	ins.date_accessed_1


from uc_incident i
	left join uc_incident_state ins on ins.incident_id = i.incident_id
where i.incident_id = @incident_id



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_state_set_0]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_incident_state_set_0]
(
@incident_id		int,
@period_to_update	int
)
AS
 
Set NoCount On



update uc_incident_state
	set
	period_to_update_0	= @period_to_update,
	date_accessed_0		= getUtcDate()

where incident_id = @incident_id





select
	i.incident_id,
	i.status_id,
	
	ins.is_active,
	ins.state,
	ins.date_updated,

	ins.period_to_update_0,
	ins.date_accessed_0,
	ins.period_to_update_1,
	ins.date_accessed_1


from uc_incident i
	left join uc_incident_state ins on ins.incident_id = i.incident_id
where i.incident_id = @incident_id



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_state_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_incident_state_select]
(
@incident_id	int
)
AS
 
Set NoCount On



select
	
	i.incident_id,
	i.status_id,
	
	ins.is_active,
	ins.state,
	ins.date_updated,

	ins.period_to_update_0,
	ins.date_accessed_0,
	ins.period_to_update_1,
	ins.date_accessed_1


from uc_incident i
	left join uc_incident_state ins on ins.incident_id = i.incident_id

	
where i.incident_id = @incident_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_select_by_guid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_select_by_guid]
(
@facility_guid	uniqueidentifier
)
AS
 
Set NoCount On



select

	f.facility_id,
	f.active,
	f.facility_guid,
	f.user_id,
	f.facility_name,
	f.address,
	f.phone,
	f.ip_address,
	f.web_referrer,

	f.survey_id,

	f.status,
	f.status_stamp,
	f.agent_id,
	a.first_name as agent_first_name,
	a.last_name as agent_last_name,

	f.date_created,
	f.date_updated,
	f.date_deleted,

	s.survey_name,
	u.username,
	u.first_name,
	u.last_name,

	(select count(group_id)	from uc_group_facility	where facility_id = f.facility_id)	as group_cnt

from uc_facility f
	left join uc_survey s	on s.survey_id = f.survey_id
	left join uc_user u		on u.user_id = f.user_id
	left join uc_agent a		on a.agent_id = f.agent_id

where f.is_deleted = 0
	and f.facility_guid = @facility_guid
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_select_by_user]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_select_by_user]
(
@user_id int
)
AS
 
Set NoCount On



select

	f.facility_id,
	f.active,
	f.facility_guid,
	f.user_id,
	f.facility_name,
	f.address,
	f.phone,
	f.ip_address,
	f.web_referrer,

	f.survey_id,

	f.status,
	f.status_stamp,
	f.agent_id,
	a.first_name as agent_first_name,
	a.last_name as agent_last_name,

	f.date_created,
	f.date_updated,
	f.date_deleted,

	s.survey_name,
	u.username,
	u.first_name,
	u.last_name,

	(select count(group_id)	from uc_group_facility	where facility_id = f.facility_id)	as group_cnt

from uc_facility f
	left join uc_survey s	on s.survey_id = f.survey_id
	left join uc_user u		on u.user_id = f.user_id
	left join uc_agent a		on a.agent_id = f.agent_id

where f.is_deleted = 0
	and (f.user_id = @user_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_get_groups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_facility_get_groups]
(
@facility_id	int
)
AS
 
Set NoCount On



select
		
	g.group_id,
	g.group_name,
	gf.facility_id

from uc_group g
	left join uc_group_facility gf on (gf.group_id = g.group_id and gf.facility_id = @facility_id)

where g.is_deleted = 0
	and ((gf.facility_id = @facility_id) or (gf.facility_id is NULL))




--
'
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_get_by_facility]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_group_get_by_facility]
	( @facility_id INT
	)
AS
	SELECT g.[group_id]
		, g.[group_name]
		, gf.[facility_id]
	FROM [uc_group] g
		, [uc_group_facility] gf
	WHERE g.[is_deleted] = 0
		AND gf.[group_id] = g.[group_id]
		AND gf.[facility_id] = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_list_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_list_get_all]
(
@stamp_max_ms int
)
AS
 
Set NoCount On




select

	f.facility_id,
	f.active,
	f.facility_guid,
	f.user_id,
	f.facility_name,
	f.address,
	f.phone,
	f.ip_address,
	f.web_referrer,

	f.survey_id,

	( case when datediff(ms,status_stamp,getutcdate())<@stamp_max_ms then f.status else null end ) as status,
	f.status_stamp,
	f.agent_id,
	a.first_name as agent_first_name,
	a.last_name as agent_last_name,

	f.date_created,
	f.date_updated,
	f.date_deleted,

	s.survey_name,
	u.username,
	u.first_name,
	u.last_name,

	(select count(group_id)	from uc_group_facility	where facility_id = f.facility_id)	as group_cnt

from uc_facility f
	left join uc_survey s	on s.survey_id = f.survey_id
	left join uc_user u		on u.user_id = f.user_id
	left join uc_agent a		on a.agent_id = f.agent_id

where f.is_deleted = 0
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_list_get_by_agent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_list_get_by_agent]
(
@stamp_max_ms int,
@agent_id	int
)
AS
 
Set NoCount On




select

	f.facility_id,
	f.active,
	f.facility_guid,
	f.user_id,
	f.facility_name,
	f.address,
	f.phone,
	f.ip_address,
	f.web_referrer,

	f.survey_id,

	( case when datediff(ms,status_stamp,getutcdate())<@stamp_max_ms then f.status else null end ) as status,
	f.status_stamp,
	f.agent_id,
	a.first_name as agent_first_name,
	a.last_name as agent_last_name,

	f.date_created,
	f.date_updated,
	f.date_deleted,

	s.survey_name,
	u.username,
	u.first_name,
	u.last_name,

	(select count(group_id)	from uc_group_facility	where facility_id = f.facility_id)	as group_cnt

from uc_facility f
	left join uc_survey s	on s.survey_id = f.survey_id
	left join uc_user u		on u.user_id = f.user_id
	left join uc_agent a		on a.agent_id = f.agent_id


where f.is_deleted = 0
	and (
			(@agent_id = 0)
			or
			(f.facility_id in 
				(
					select gf.facility_id
					from uc_group g
						join uc_group_agent ga		on ga.group_id = g.group_id
						join uc_group_facility gf	on gf.group_id = g.group_id
					where g.is_deleted = 0
						and ga.agent_id = @agent_id
				)
			)
		)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_select]
(
@facility_id	int
)
AS
 
Set NoCount On



select

	f.facility_id,
	f.active,
	f.facility_guid,
	f.user_id,
	f.facility_name,
	f.address,
	f.phone,
	f.ip_address,
	f.web_referrer,

	f.survey_id,

	f.status,
	f.status_stamp,
	f.agent_id,
	a.first_name as agent_first_name,
	a.last_name as agent_last_name,

	f.date_created,
	f.date_updated,
	f.date_deleted,

	s.survey_name,
	u.username,
	u.first_name,
	u.last_name,

	(select count(group_id)	from uc_group_facility	where facility_id = f.facility_id)	as group_cnt

from uc_facility f
	left join uc_survey s	on s.survey_id = f.survey_id
	left join uc_user u		on u.user_id = f.user_id
	left join uc_agent a		on a.agent_id = f.agent_id


where f.is_deleted = 0
	and f.facility_id = @facility_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_group_select]
(
@group_id	int
)
AS
 
Set NoCount On


select
	
g.group_id,
g.group_name,
g.date_created,
g.date_updated,
g.date_deleted,
g.is_deleted,

(select count(agent_id)		from uc_group_agent	where group_id = g.group_id)	as agent_cnt,
(select count(facility_id)	from uc_group_facility	where group_id = g.group_id)	as facility_cnt

from uc_group g


where g.is_deleted = 0
	and (g.group_id = @group_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_set_facility]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
create Procedure [usp_group_set_facility]
(
@group_id		int,
@facility_id		int,
@set			bit
)
AS
 
Set NoCount On


delete uc_group_facility
where group_id = @group_id
	and facility_id = @facility_id


if(@set = 1)
	insert uc_group_facility(group_id, facility_id)
	values(@group_id, @facility_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_get_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_group_get_list]
(
@agent_id		int,
@facility_id	int
)
AS
 
Set NoCount On


select
	
g.group_id,
g.group_name,
g.date_created,
g.date_updated,
g.date_deleted,
g.is_deleted,

(select count(agent_id)		from uc_group_agent	where group_id = g.group_id)	as agent_cnt,
(select count(facility_id)	from uc_group_facility	where group_id = g.group_id)	as facility_cnt


from uc_group g
	
where g.is_deleted		= 0

	and
	(
	(@agent_id = 0) or g.group_id in 
	(select group_id from uc_group_agent ga where ga.agent_id = @agent_id)
	)

	and
	(
	(@facility_id = 0) or g.group_id in 
	(select group_id from uc_group_facility gf where gf.facility_id = @facility_id)
	)



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_get_facilities]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_group_get_facilities]
(
@group_id	int
)
AS
 
Set NoCount On


select

	f.facility_id,
	f.active,
	f.facility_name,

	gf.group_id

from uc_facility f
	left join uc_group_facility gf on (gf.facility_id = f.facility_id and gf.group_id = @group_id)

where f.is_deleted = 0
	and ((gf.group_id = @group_id) or (gf.group_id is NULL))



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_delete]
(
@facility_id	int
)
AS
 
Set NoCount On



--delete uc_facility
--where facility_id = @facility_id



delete uc_group_facility
where facility_id = @facility_id


update uc_facility
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where facility_id = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_set_status]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_set_status]
	( @facility_id INT
	, @status NVARCHAR(16)
	, @stamp_max_ms INT
	, @command NVARCHAR(128) OUT
	, @agent_id INT OUT
	)
AS
	DECLARE @stamp DATETIME
	SET @stamp = GetUtcDate()

	SELECT
		@agent_id = [agent_id],
		@command =
			CASE
				WHEN DateDiff( ms, [command_stamp], @stamp ) < @stamp_max_ms THEN [command]
				ELSE NULL
			END
		FROM [uc_facility]
		WHERE [facility_id] = @facility_id

	UPDATE [uc_facility]
		SET [status] = @status
		, [status_stamp] = @stamp
		, [command] = NULL
		WHERE [facility_id] = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_set_command]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_set_command]
	( @facility_id int
	, @agent_id int
	, @command nvarchar(128)
	)
AS
	UPDATE [uc_facility]
		SET [command] = @command
		, [command_stamp] = GetUtcDate()
		, [agent_id] = @agent_id
		WHERE [facility_id] = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_group_delete]
(
@group_id	int
)
AS
 
Set NoCount On



delete uc_group_agent
where group_id = @group_id

delete uc_group_facility
where group_id = @group_id




update uc_group
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where group_id = @group_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_get_agents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_group_get_agents]
(
@group_id	int
)
AS
 
Set NoCount On


select
		
	a.agent_id,
	a.first_name,
	a.last_name,

	ga.group_id

from uc_agent a
	left join uc_group_agent ga on (ga.agent_id = a.agent_id and ga.group_id = @group_id)

where a.is_deleted = 0
	and ((ga.group_id = @group_id) or (ga.group_id is NULL))



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_set_agent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_group_set_agent]
(
@group_id		int,
@agent_id		int,
@set			bit
)
AS
 
Set NoCount On


delete uc_group_agent
where group_id = @group_id	and agent_id = @agent_id


if(@set = 1)
	insert uc_group_agent(group_id, agent_id)
	values(@group_id, @agent_id)

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_get_groups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_agent_get_groups]
(
@agent_id	int
)
AS
 
Set NoCount On



select
		
	g.group_id,
	g.group_name,

	ga.agent_id

from uc_group g
	left join uc_group_agent ga on (ga.group_id = g.group_id and ga.agent_id = @agent_id)

where g.is_deleted = 0
	and ((ga.agent_id = @agent_id) or (ga.agent_id is NULL))




--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_select_by_user]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_select_by_user]
(
@user_id	int
)
AS
 
Set NoCount On


select
	
	a.agent_id,
	a.agent_guid,
	a.user_id,
	a.first_name,
	a.last_name,
	a.email,
	a.phone,

	a.public_enabled,

	a.date_created,
	a.date_updated,
	a.date_deleted,

	(select count(group_id)	from uc_group_agent	where agent_id = a.agent_id)	as group_cnt

from uc_agent a

where a.is_deleted = 0
	and (a.user_id = @user_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_select_by_email]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_select_by_email]
(
	@email nvarchar(50)
)
AS
 
Set NoCount On

select
	
	a.agent_id,
	a.agent_guid,
	a.user_id,
	a.first_name,
	a.last_name,
	a.email,
	a.phone,

	a.public_enabled,

	a.date_created,
	a.date_updated,
	a.date_deleted,

	(select count(group_id)	from uc_group_agent	where agent_id = a.agent_id)	as group_cnt

from uc_agent a

where a.is_deleted = 0
	and (a.email = @email)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_list_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_list_get_all]
AS
 
Set NoCount On




select
	
	a.agent_id,
	a.agent_guid,
	a.user_id,
	a.first_name,
	a.last_name,
	a.email,
	a.phone,

	a.public_enabled,

	a.date_created,
	a.date_updated,
	a.date_deleted,

	(select count(group_id)	from uc_group_agent	where agent_id = a.agent_id)	as group_cnt

from uc_agent a

where a.is_deleted = 0
--	and (a.agent_id = @agent_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_delete]
(
@agent_id	int
)
AS
 
Set NoCount On

delete uc_pool
where agent_id = @agent_id

delete uc_group_agent
where agent_id = @agent_id

--delete uc_agent
--where agent_id = @agent_id

update uc_agent
	set
	is_deleted = 1,
	date_deleted = getUtcDate()
where agent_id = @agent_id

update uc_user
	set
	is_deleted = 1,
	date_deleted = getUtcDate()
where user_id in (select user_id from uc_agent where agent_id = @agent_id)

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_response_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_survey_response_insert]
(
@incident_id	int,
@survey_id		int,
@question_id	int,
@response		nvarchar(1000)
)
AS
 
Set NoCount On


insert uc_survey_response (incident_id, survey_id, question_id, response)
values (@incident_id, @survey_id, @question_id, @response)


select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_state_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_incident_state_update]
(
@incident_id	int,
@is_active		bit,
@state			char(3)
)
AS
 
Set NoCount On



update uc_incident_state
	set

--incident_id		= @incident_id,
is_active		= @is_active,
state			= @state,
date_updated	= getUtcDate()
									
where incident_id = @incident_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_state_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_incident_state_insert]
(
@incident_id		int,
@is_active		bit,
@state			char(3)
)
AS

 
Set NoCount On


delete uc_incident_state
where incident_id = @incident_id


insert uc_incident_state (incident_id, is_active, state)
values (@incident_id, @is_active, @state)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_state_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_incident_state_delete]
(
@incident_id	int
)
AS
 
Set NoCount On


delete uc_incident_state
where incident_id = @incident_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_note_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_incident_note_select]
(
@note_id	int
)
AS
 
Set NoCount On


select

inote.[note_id],
inote.[incident_id],
inote.[note],
inote.[user_id],
inote.[date_created],
inote.[date_deleted],
inote.[is_deleted],

u.first_name,
u.last_name

from uc_incident_note inote
	join uc_user u on u.user_id = inote.user_id

where inote.is_deleted = 0
	and (inote.note_id = @note_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_note_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_incident_note_delete]
(
@note_id	int
)
AS
 
Set NoCount On



update uc_incident_note
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where note_id = @note_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_note_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
create Procedure [usp_incident_note_insert]
(
@incident_id	int,
@user_id		int,
@note			ntext
)
AS
 
Set NoCount On


insert uc_incident_note ([incident_id], [user_id], [note])
values (@incident_id, @user_id, @note)



select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_incident_note_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_incident_note_get_all]
(
@incident_id	int
)
AS
 
Set NoCount On


select

inote.[note_id],
inote.[incident_id],
inote.[note],
inote.[user_id],
inote.[date_created],
inote.[date_deleted],
inote.[is_deleted],

u.first_name,
u.last_name

from uc_incident_note inote
	join uc_user u on u.user_id = inote.user_id



where inote.is_deleted = 0
	and ((inote.incident_id = @incident_id) or (@incident_id = 0))

--	and (inote.incident_id in (select incident_id from uc_incident where contact_id = @contact_id) )


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_set_available]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_pool_set_available]
(
@agent_id		int,
@is_available	bit
)
AS
 
Set NoCount On


update uc_pool
	set
	is_available	= @is_available,

	is_busy			= 0,
	incident_id		= NULL,

	date_accessed	= getUtcDate()


where agent_id = @agent_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_pool_select]
(
@agent_id	int
)
AS
 
Set NoCount On




update uc_pool
	set
	date_accessed	= getUtcDate()
where agent_id = @agent_id


select

	p.agent_id,
	p.is_available,
	p.is_busy,
	p.last_call_time,
	p.incident_id,
	p.date_created,
	p.date_accessed,
	p.date_reserved,

	a.first_name	as agent_first_name,
	a.last_name		as agent_last_name

from uc_pool p
	join uc_agent a on a.agent_id = p.agent_id
where p.agent_id = @agent_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_pool_insert]
(
@agent_id		int
)
AS
 
Set NoCount On


insert uc_pool (agent_id)
values (@agent_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_pool_get_all]
AS
 
Set NoCount On


select

	p.agent_id,
	p.is_available,
	p.is_busy,
	p.last_call_time,
	p.incident_id,
	p.date_created,
	p.date_accessed,
	p.date_reserved,

	a.first_name	as agent_first_name,
	a.last_name		as agent_last_name

from uc_pool p
	join uc_agent a on a.agent_id = p.agent_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_pool_delete]
(
@agent_id		int
)
AS
 
Set NoCount On


delete uc_pool
where agent_id = @agent_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_set_session]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_pool_set_session]
(
@agent_id		int,
@incident_id	int
)
AS
 
Set NoCount On


update uc_pool
	set
	--last_incident_id	= @incident_id,
	last_call_time		= getUtcDate(),
	date_accessed		= getUtcDate()

where agent_id = @agent_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_set_incident]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_pool_set_incident]
(
@agent_id		int,
@incident_id	int
)
AS
 
Set NoCount On


update uc_pool
	set
	incident_id		= @incident_id,
	date_reserved	= getUtcDate(),
	date_accessed	= getUtcDate()

where agent_id = @agent_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_pool_set_busy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_pool_set_busy]
(
@agent_id		int,
@is_busy	bit
)
AS
 
Set NoCount On


update uc_pool
	set
	is_busy			= @is_busy,
	date_accessed	= getUtcDate()


where agent_id = @agent_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_delete]
(
@incident_id int
)
AS
 
Set NoCount On

delete uc_log
where incident_id = @incident_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_select]
(
@incident_id int
)
AS
 
Set NoCount On

select

*
	
from uc_log
where incident_id = @incident_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_insert]
(
@incident_id						int,
@consumer_name						nvarchar(50),	
@transaction_value					nvarchar(50),	
@transaction_completion				bit,
@issue_found						nvarchar(100),	
@issue_resolved						nvarchar(100),	
@kiosk_malfunction					bit,
@kiosk_status_after_transaction		nvarchar(50),
@kiosk_id							nvarchar(50),
@kiosk_name							nvarchar(50),
@kiosk_location						nvarchar(50),	
@device_in_database					bit,
@engineering_work_order_opened		bit,
@device_value						int,
@device_type						nvarchar(50),	
@device_make						nvarchar(50),
@device_model						nvarchar(50),
@audio								varbinary(MAX),
@driver_license						varbinary(MAX),
@id_card							varbinary(MAX),
@inspector_bin						varbinary(MAX),
@transaction_status_id				int,
@subject_notes						nvarchar(100),
@screen_user_help					nvarchar(200),
@server nvarchar(100)
)
AS
 
Set NoCount On
  

insert uc_log (incident_id,
			consumer_name,
			transaction_value,
			transaction_completion,
			issue_found,
			issue_resolved,
			kiosk_malfunction,
			kiosk_status_after_transaction,
			device_in_database,
			engineering_work_order_opened,
			device_value,
			device_type,
			kiosk_location,
			audio,
			driver_license,
			id_card,inspector_bin,
			device_make,
			device_model,
			kiosk_id,
			kiosk_name,
			transaction_status_id,
			subject_notes,
			screen_user_help,
			server)
values (@incident_id,
		@consumer_name,
		@transaction_value,
		@transaction_completion,
		@issue_found,
		@issue_resolved,
		@kiosk_malfunction,
		@kiosk_status_after_transaction,
		@device_in_database,
		@engineering_work_order_opened,
		@device_value,@device_type,
		@kiosk_location,
		@audio,
		@driver_license,
		@id_card,
		@inspector_bin,
		@device_make,
		@device_model,
		@kiosk_id,
		@kiosk_name,
		@transaction_status_id,
		@subject_notes,
		@screen_user_help,
		@server)

select SCOPE_IDENTITY() as id
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_update_agent_info]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_update_agent_info]
(
@incident_id						int,
--@issue_found						nvarchar(100),	
--@issue_resolved						nvarchar(100),
@subject_notes					    nvarchar(100)
--@kiosk_malfunction					bit,
--@kiosk_status_after_transaction		nvarchar(50),
--@device_in_database					bit,
--@engineering_work_order_opened		bit,
--@transaction_status_id				int,
--@customer_satisfaction				nvarchar(100)
)
AS
 
Set NoCount On

update uc_log
set

--issue_found						= @issue_found,					
--issue_resolved					= @issue_resolved,	
subject_notes					= @subject_notes
--kiosk_malfunction				= @kiosk_malfunction,			
--kiosk_status_after_transaction	= @kiosk_status_after_transaction,
--device_in_database				= @device_in_database,			
--engineering_work_order_opened	= @engineering_work_order_opened,
--transaction_status_id			= @transaction_status_id,
--customer_satisfaction			= @customer_satisfaction
									
where incident_id = @incident_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_list_get_by_role]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_list_get_by_role]
(
@user_role_id	int = 0
)
AS
 
Set NoCount On


select

	u.user_id,
	u.user_guid,
	u.first_name,
	u.last_name,
	u.username,
	u.password,
	u.password_salt,
	u.user_role_id,
	u.time_zone,
	
	u.logins,
	u.login_attempts,
	u.is_locked_out,

	u.date_last_login,
	u.date_created,
	u.date_updated,
	u.date_deleted,

	lumr.user_role_name

from uc_user u
	join lu_user_role lumr on lumr.user_role_id = u.user_role_id


where is_deleted = 0
	and ((@user_role_id = 0) or (u.user_role_id = @user_role_id))
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_select]
(
@user_id	int
)
AS
 
Set NoCount On


select

	u.user_id,
	u.user_guid,
	u.first_name,
	u.last_name,
	u.username,
	u.password,
	u.password_salt,
	u.user_role_id,
	u.time_zone,
	
	u.logins,
	u.login_attempts,
	u.is_locked_out,

	u.date_last_login,
	u.date_created,
	u.date_updated,
	u.date_deleted,

	lumr.user_role_name

from uc_user u
	join lu_user_role lumr on lumr.user_role_id = u.user_role_id




where is_deleted = 0
	and (user_id = @user_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_select_by_guid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_select_by_guid]
(
@user_guid	uniqueidentifier
)
AS
 
Set NoCount On


select

	u.user_id,
	u.user_guid,
	u.first_name,
	u.last_name,
	u.username,
	u.password,
	u.password_salt,
	u.user_role_id,
	u.time_zone,
	
	u.logins,
	u.login_attempts,
	u.is_locked_out,

	u.date_last_login,
	u.date_created,
	u.date_updated,
	u.date_deleted,

	lumr.user_role_name

from uc_user u
	join lu_user_role lumr on lumr.user_role_id = u.user_role_id


where is_deleted = 0
	and (user_guid = @user_guid)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_get_by_username]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_get_by_username]
(
@username	nvarchar(50)
)
AS
 
Set NoCount On


select

	u.user_id,
	u.user_guid,
	u.first_name,
	u.last_name,
	u.username,
	u.password,
	u.password_salt,
	u.user_role_id,
	u.time_zone,
	
	u.logins,
	u.login_attempts,
	u.is_locked_out,

	u.date_last_login,
	u.date_created,
	u.date_updated,
	u.date_deleted,

	lumr.user_role_name

from uc_user u
	join lu_user_role lumr on lumr.user_role_id = u.user_role_id

where is_deleted = 0
	and (u.username = @username)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usplu_get_user_roles]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usplu_get_user_roles]
AS
 
Set NoCount On



select
	user_role_id,
	user_role_name
from lu_user_role
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usplu_get_question_types]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usplu_get_question_types]
AS
 
Set NoCount On



select
	question_type_id,
	question_type_name
from lu_question_type
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_question_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
CREATE Procedure [usp_question_select]
(
@question_id	int
)
AS
 
Set NoCount On



select

q.question_id,
q.question_text,
q.type_id,
q.date_created,
q.date_updated,
q.date_deleted,

luqt.question_type_name


from uc_question q
	join lu_question_type luqt	on luqt.question_type_id = q.type_id


where q.is_deleted = 0
	and (q.question_id = @question_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_question_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_question_get_all]
AS
 
Set NoCount On

select
	
q.question_id,
q.question_text,
q.type_id,
q.date_created,
q.date_updated,
q.date_deleted,

luqt.question_type_name


from uc_question q
	join lu_question_type luqt	on luqt.question_type_id = q.type_id


where q.is_deleted = 0


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_get_questions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_survey_get_questions]
(
@survey_id	int
)
AS
 
Set NoCount On


select

	q.question_id,
--	q.active,
	q.question_text,

	luqt.question_type_name,
	sq.survey_id
	

from uc_question q
	join lu_question_type luqt	on luqt.question_type_id = q.type_id
	left join uc_survey_question sq on (sq.question_id = q.question_id and sq.survey_id = @survey_id)

where q.is_deleted = 0
	and ((sq.survey_id = @survey_id) or (sq.survey_id is NULL))



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_question_select_by_survey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_question_select_by_survey]
(
@survey_id	int
)
AS
 
Set NoCount On

select
	
q.question_id,
q.question_text,
q.type_id,
q.date_created,
q.date_updated,
q.date_deleted,

luqt.question_type_name


from uc_question q
	join lu_question_type luqt	on luqt.question_type_id = q.type_id
	join uc_survey_question sq	on sq.question_id = q.question_id

where q.is_deleted = 0
	and (sq.survey_id = @survey_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usplu_get_incident_statuses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usplu_get_incident_statuses]
AS
 
Set NoCount On



select
	incident_status_id,
	incident_status_name
from lu_incident_status

--where incident_status_id <> 1
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_chat_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
CREATE Procedure [usp_chat_delete]
(
@chat_id	int
)
AS
 
Set NoCount On




update uc_chat
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where chat_id = @chat_id
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_chat_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
create Procedure [usp_chat_insert]
(
@chat_session	nvarchar(50),
@chat_sender	nvarchar(50),
@chat_message	ntext
)
AS
 
Set NoCount On


insert uc_chat (chat_session, chat_sender, chat_message)
values (@chat_session, @chat_sender, @chat_message)


select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_chat_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
create Procedure [usp_chat_update]
(
@chat_id		int,
@chat_session	nvarchar(50),
@chat_sender	nvarchar(50),
@chat_message	ntext
)
AS
 
Set NoCount On



update uc_chat
	set

	chat_session	= @chat_session,
	chat_sender		= @chat_sender,
	chat_message	= @chat_message

	--date_updated	= getUtcDate()


									
where chat_id = @chat_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_chat_select_by_session]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
CREATE Procedure [usp_chat_select_by_session]
(
@chat_session	nvarchar(50),
@chat_rows		int = 0
)
AS
 
Set NoCount On

SET ROWCOUNT @chat_rows


select
	
	chat_id,
	chat_session,
	chat_sender,
	chat_message,
	chat_datetime

from uc_chat c
where c.is_deleted = 0
	and (c.chat_session = @chat_session)

order by chat_id desc

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_chat_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
CREATE Procedure [usp_chat_select]
(
@chat_id	int
)
AS
 
Set NoCount On


select
	
	chat_id,
	chat_session,
	chat_sender,
	chat_message,
	chat_datetime

from uc_chat c
where c.is_deleted = 0
	and (c.chat_id = @chat_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_exception_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_exception_delete]
(
@ex_id	int
)
AS
 
Set NoCount On



update uc_exception
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where ex_id = @ex_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_exception_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_exception_insert]
(
@parent_ex_id	int,
@ex_message		nvarchar(500),
@ex_stacktrace	nvarchar(1000),
@application	nvarchar(50),
@username		nvarchar(50),
@page_url		nvarchar(250)
)
AS
 
Set NoCount On




declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_exception (parent_ex_id, ex_message,ex_stacktrace,application,username,page_url)
values (@parent_ex_id, @ex_message,@ex_stacktrace,@application,@username,@page_url)


select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_exception_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_exception_select]
(
@ex_id	int
)
AS
 
Set NoCount On



select

	e.ex_id,
	e.parent_ex_id,
	e.ex_message,
	e.ex_stacktrace,
	e.username,
	e.page_url,
	e.date_created,
	e.date_deleted,
	e.is_deleted

from uc_exception e
where is_deleted = 0
	and ex_id = @ex_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_exception_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_exception_get_all]
AS
 
Set NoCount On




select

	e.ex_id,
	e.parent_ex_id,
	e.ex_message,
	e.ex_stacktrace,
	e.username,
	e.page_url,
	e.date_created,
	e.date_deleted,
	e.is_deleted

from uc_exception e
where is_deleted = 0
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
create Procedure [usp_group_update]
(
@group_id		int,
@group_name		nvarchar(50)
)
AS
 
Set NoCount On



update uc_group
	set

group_name			= @group_name,
date_updated		= getUtcDate()
									
where group_id = @group_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_group_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
create Procedure [usp_group_insert]
(
@group_name	nvarchar(50)
)
AS
 
Set NoCount On




declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_group (group_guid, group_name)
values (@guid, @group_name)



select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_language_update]
(
@language_id		int,
@language_name		nvarchar(50)
)
AS
 
Set NoCount On

update uc_language
set
language_name = @language_name,
date_updated = getUtcDate()
where language_id = @language_id

select SCOPE_IDENTITY() as id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_language_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_language_insert]
(
@language_name	nvarchar(50)
)
AS
 
Set NoCount On

insert uc_language (language_name) values (@language_name)

select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_survey_insert]
(
@survey_name	nvarchar(50)
)
AS
 
Set NoCount On




declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_survey (survey_guid, survey_name)
values (@guid, @survey_name)



select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_survey_delete]
(
@survey_id	int
)
AS
 
Set NoCount On


update uc_survey
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where survey_id = @survey_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_survey_update]
(
@survey_id		int,
@survey_name	nvarchar(50)
)
AS
 
Set NoCount On



update uc_survey
	set

survey_name			= @survey_name,
date_updated		= getUtcDate()
									
where survey_id = @survey_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_survey_get_all]
AS
 
Set NoCount On


select
	
s.survey_id,
s.survey_name,
s.date_created,
s.date_updated,
s.date_deleted,
s.is_deleted,

(select count(*) from uc_survey_question sq where sq.survey_id = s.survey_id) as question_cnt

from uc_survey s

where s.is_deleted = 0


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_survey_select]
(
@survey_id	int
)
AS
 
Set NoCount On


select
	
s.survey_id,
s.survey_name,
s.date_created,
s.date_updated,
s.date_deleted,
s.is_deleted,

(select count(*) from uc_survey_question sq where sq.survey_id = s.survey_id) as question_cnt

from uc_survey s

where s.is_deleted = 0
	and (s.survey_id = @survey_id)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_get_skills]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_get_skills]
(
@agent_id	int
)
AS
 
Set NoCount On

select
	s.skill_id,
	s.skill_name,
	sa.agent_id

from uc_skill s
	left join uc_agent_skill sa on (sa.skill_id = s.skill_id and sa.agent_id = @agent_id)

where s.is_deleted = 0 and 
((sa.agent_id = @agent_id) or (sa.agent_id is NULL))

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_skill_update]
(
@skill_id		int,
@skill_name		nvarchar(50)
)
AS
 
Set NoCount On

update uc_skill
set
skill_name = @skill_name,
date_updated = getUtcDate()
where skill_id = @skill_id

select SCOPE_IDENTITY() as id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_skill_insert]
(
@skill_name	nvarchar(50)
)
AS
 
Set NoCount On

insert uc_skill (skill_name) values (@skill_name)

select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_skill_select]
(
@skill_id	int
)
AS
 
Set NoCount On

select
s.skill_id,
s.skill_name,
s.date_created,
s.date_updated,
s.date_deleted,
s.is_deleted,
(select count(agent_id)	from uc_agent_skill	where skill_id = s.skill_id) as agent_cnt
from uc_skill s
where s.is_deleted = 0 and skill_id = @skill_id;
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_get_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_skill_get_list]
(
@agent_id		int
)
AS
 
Set NoCount On

select
s.skill_id,
s.skill_name,
s.date_created,
s.date_updated,
s.date_deleted,
s.is_deleted,
(select count(agent_id)	from uc_agent_skill	where skill_id = s.skill_id) as agent_cnt
from uc_skill s
where s.is_deleted = 0 and 
((@agent_id = 0) or 
s.skill_id in (select skill_id from uc_agent_skill al where al.agent_id = @agent_id))

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_skill_delete]
(
@skill_id	int
)
AS
 
Set NoCount On

delete uc_agent_skill
where skill_id = @skill_id

update uc_skill
	set
	is_deleted = 1,
	date_deleted = getUtcDate()
where skill_id = @skill_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_settings_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_settings_list]
(
@category		nvarchar(50)
)
AS
 
Set NoCount On




select
	
	[category],
	[name],
	[value],
	[tooltip]

from uc_settings
where category = @category
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_settings_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_settings_select]
(
@name		nvarchar(50),
@category	varchar(50)
)
AS

 
Set NoCount On




select
	
	[category],
	[name],
	[value],
	[tooltip]

from uc_settings
where [name] = @name
	and [category] = @category


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_settings_set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_settings_set]
(
@name		varchar(50),
@category	varchar(50),
@value		nvarchar(512)
)
AS
 
Set NoCount On

--if(not exists(select [value] from uc_settings where [name] = @name))
--	begin
--		insert uc_settings ([name], [category], [value])
--		values (@name, @category, @value)
--	end
--else
--	begin
--		update uc_settings
--			set
--			[value] = @value
--		where [name] = @name
--	end


	update uc_settings
		set
		[value] = @value
	where [name] = @name and [category] = @category

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_question_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
CREATE Procedure [usp_question_update]
(
@question_id		int,
@type_id			int,
@question_text		nvarchar(200)
)
AS
 
Set NoCount On




update uc_question
	set


		type_id			= @type_id,
		question_text	= @question_text,
		date_updated	= getUtcDate()

		

where question_id = @question_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_question_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
CREATE Procedure [usp_question_insert]
(
@type_id		int,
@question_text	nvarchar(200)
)
AS
 
Set NoCount On


insert uc_question (question_text,type_id)
values (@question_text,@type_id)

select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_question_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
CREATE Procedure [usp_question_delete]
(
@question_id	int
)
AS
 
Set NoCount On





delete uc_survey_question
where question_id = @question_id




update uc_question
	set

	is_deleted = 1,
	date_deleted = getUtcDate()

where question_id = @question_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_delete]
(
@user_id	int
)
AS
 
Set NoCount On

--delete uc_user
--where user_id = @user_id

update uc_agent
	set
	is_deleted = 1,
	date_deleted = getUtcDate()
where user_id = @user_id

update uc_user
	set
	is_deleted = 1,
	date_deleted = getUtcDate()
where user_id = @user_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_login]
(
@username	nvarchar(50),
@success	bit
)
AS
 
Set NoCount On



if(@success = 1)
	update uc_user
		set
		logins			= logins + 1,
		login_attempts	= 0,
		date_last_login	= getUtcDate()
	where username = @username

else
	update uc_user
		set
		login_attempts	= login_attempts + 1
	where username = @username


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_info_set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_user_info_set]
(
@user_id	int,
@first_name	nvarchar(50),
@last_name	nvarchar(50)
)
AS
 
Set NoCount On


update uc_user
	set
	first_name	= @first_name,
	last_name	= @last_name,

	date_updated	= getUtcDate()

where [user_id] = @user_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_insert]
(
@first_name	nvarchar(50),
@last_name	nvarchar(50),
@username	nvarchar(50),
@password	nvarchar(50),
@password_salt	nvarchar(50),
@user_role_id	int,
@time_zone		varchar(100)
)
AS
 
SET NOCOUNT ON

INSERT uc_user (user_guid,first_name,last_name,username,password,password_salt,user_role_id,time_zone)
VALUES (NewID(),@first_name,@last_name,@username,@password,@password_salt,@user_role_id,@time_zone)

DECLARE @user_id INT
select @user_id = SCOPE_IDENTITY()

IF @user_role_id = 2 -- Agent
BEGIN
	INSERT uc_agent (agent_guid,user_id,first_name,last_name,email,phone,public_enabled)
	VALUES (NewID(),@user_id,@first_name,@last_name,'''','''',1)
END

select @user_id as id
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_user_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_user_update]
(
@user_id	int,
@first_name	nvarchar(50),
@last_name	nvarchar(50),
@username	nvarchar(50),
@password	nvarchar(50),
@password_salt	nvarchar(50),
@user_role_id	int,
@time_zone		varchar(100)
)
AS
 
Set NoCount On


update uc_user
	set
	first_name	= @first_name,
	last_name	= @last_name,

--	username	= @username,

	password	= @password,
	password_salt	= @password_salt,
	user_role_id	= @user_role_id,
	time_zone		= @time_zone,
	date_updated	= getUtcDate()

where user_id = @user_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_insert]
(
@active				bit,
@user_id			int,
@survey_id			int,
@facility_name		nvarchar(100),
@address			nvarchar(100),
@phone				nvarchar(50),
@ip_address			nvarchar(16),
@web_referrer		nvarchar(100)
)
AS
 
Set NoCount On




declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_facility (facility_guid,active,user_id,survey_id,facility_name,address,phone,ip_address,web_referrer)
values (@guid,@active,@user_id,@survey_id,@facility_name,@address,@phone,@ip_address,@web_referrer)


select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_facility_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_facility_update]
(
@facility_id		int,
@active				bit,
@user_id			int,
@survey_id			int,
@facility_name		nvarchar(100),
@address			nvarchar(100),
@phone				nvarchar(50),
@ip_address			nvarchar(16),
@web_referrer		nvarchar(100)
)
AS
 
Set NoCount On



update uc_facility
	set

		facility_name	= @facility_name,
		user_id			= @user_id,
		survey_id		= @survey_id,
		address			= @address,
		phone			= @phone,
		active			= @active,
		ip_address		= @ip_address,
		web_referrer	= @web_referrer,

		date_updated	= getUtcDate()

where facility_id = @facility_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_get_all]
AS
 
Set NoCount On


select

	c.contact_id,
	c.contact_guid,
	c.user_id,
	c.first_name,
	c.last_name,
	c.email,
	c.phone,
	c.memo,

	c.date_created,
	c.date_updated,
	c.date_deleted

from uc_contact c

where is_deleted = 0
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_delete]
(
@contact_id	int
)
AS
 
Set NoCount On



--delete uc_contact
--where contact_id = @contact_id

update uc_contact
	set
	is_deleted = 1,
	date_deleted = getUtcDate()

where contact_id = @contact_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_search]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_search]
(
@first_name		nvarchar(50),
@last_name		nvarchar(50),
@email			nvarchar(50),
@phone			nvarchar(50)
)
AS
 
Set NoCount On



select

	c.contact_id,
	c.contact_guid,
	c.user_id,
	c.first_name,
	c.last_name,
	c.email,
	c.phone,
	c.memo,

	c.date_created,
	c.date_updated,
	c.date_deleted

from uc_contact c
where is_deleted = 0
--	and contact_id	= @contact_id
	and first_name	= @first_name
	and last_name	= @last_name
	and email		= @email
	and phone		= @phone
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_select_by_user]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_select_by_user]
(
@user_id	int
)
AS
 
Set NoCount On





select

	c.contact_id,
	c.contact_guid,
	c.user_id,
	c.first_name,
	c.last_name,
	c.email,
	c.phone,
	c.memo,

	c.date_created,
	c.date_updated,
	c.date_deleted

from uc_contact c
where c.is_deleted = 0
	and (c.user_id = @user_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_select_by_guid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_select_by_guid]
(
@contact_guid	uniqueidentifier
)
AS
 
Set NoCount On



select

	c.contact_id,
	c.contact_guid,
	c.user_id,
	c.first_name,
	c.last_name,
	c.email,
	c.phone,
	c.memo,

	c.date_created,
	c.date_updated,
	c.date_deleted

from uc_contact c
where is_deleted = 0
	and contact_guid = @contact_guid
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_select]
(
@contact_id	int
)
AS
 
Set NoCount On



select

	c.contact_id,
	c.contact_guid,
	c.user_id,
	c.first_name,
	c.last_name,
	c.email,
	c.phone,
	c.memo,

	c.date_created,
	c.date_updated,
	c.date_deleted

from uc_contact c
where is_deleted = 0
	and contact_id = @contact_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_list_get_by_phone]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_list_get_by_phone]
(
@phone	nvarchar(50)
)
AS
 
Set NoCount On



select

	c.contact_id,
	c.contact_guid,
	c.user_id,
	c.first_name,
	c.last_name,
	c.email,
	c.phone,

	c.date_created,
	c.date_updated,
	c.date_deleted

from uc_contact c
where is_deleted = 0
	and phone = @phone
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_update]
(
@contact_id		int,
@user_id		int,
@first_name		nvarchar(50),
@last_name		nvarchar(50),
@email			nvarchar(50),
@phone			nvarchar(50),
@memo			nvarchar(50)
)
AS
 
Set NoCount On



update uc_contact
	set
		--user_id	= @user_id,
		first_name	= @first_name,
		last_name	= @last_name,
		email		= @email,
		phone		= @phone,
		memo		= @memo,
		date_updated= getUtcDate()

where contact_id = @contact_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_insert]
(
--@contact_id	int
@user_id		int,
@first_name		nvarchar(50),
@last_name		nvarchar(50),
@email			nvarchar(50),
@phone			nvarchar(50),
@memo			nvarchar(50)
)
AS
 
Set NoCount On






declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_contact (user_id,contact_guid,first_name,last_name,email,phone,memo)
values (@user_id,@guid,@first_name,@last_name,@email,@phone,@memo)


select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_listing_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_listing_select]
(
@contact_id			int,
@lst_contact_id		int
)
AS
 
Set NoCount On




select

	@contact_id		as contact_id,
	@lst_contact_id	as lst_contact_id,

--	cl.contact_id,
--	cl.lst_contact_id,


	c.contact_guid,
	c.first_name,
	c.last_name,

	cs.is_available,
	cs.is_busy,
	cs.state,

	cs.call_id,
	
	IsNull(cl.lst_nickname, '''') as lst_nickname,
	case when (cl.lst_nickname is NULL) then 0 else 1 end as contact_listed


from uc_contact c
	left join uc_contact_state cs	on (cs.contact_id = c.contact_id) and (cs.call_id = @contact_id)
	left join uc_contact_listing cl	on (cl.lst_contact_id = c.contact_id) and (cl.contact_id = @contact_id)
where c.is_deleted = 0
	and c.contact_id		= @lst_contact_id
	and ((cl.lst_contact_id = @lst_contact_id) or (cl.lst_contact_id is NULL))


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_search_listing]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_search_listing]
(
@contact_id		int,
@search_words	nvarchar(250)
)
AS
 
Set NoCount On


select

	cl.contact_id,
	c.contact_id	as lst_contact_id,

	c.contact_guid,
	c.first_name,
	c.last_name,

	cs.is_available,
	cs.is_busy,
	cs.state,

	call.call_id,
	
	IsNull(cl.lst_nickname, '''') as lst_nickname,
	case when (cl.lst_nickname is NULL) then 0 else 1 end as contact_listed

from uc_contact c
	left join uc_contact_state cs	on (cs.contact_id		= c.contact_id)	-- and (cs.call_id = @contact_id)
	left join uc_call call			on (call.call_id		= cs.call_id)	and (call.to_contact_id = @contact_id)
	left join uc_contact_listing cl	on (cl.lst_contact_id	= c.contact_id)	and (cl.contact_id = @contact_id)

where c.is_deleted = 0
	and @search_words is not NULL
	and 
	(
		c.first_name like ''%''+@search_words+''%''
	or
		c.last_name like ''%''+@search_words+''%''
	)

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_select_by_status]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_call_select_by_status]
(
@status_id		int
)
AS
 
Set NoCount On



select
	call.call_id,
	call.call_guid,
	call.status_id,
	call.from_contact_id,
	call.to_contact_id,

	call.date_created,
	call.date_open,
	call.date_closed,
	call.date_updated,
	call.date_deleted,

	uc_to.first_name	as to_first_name,
	uc_to.last_name		as to_last_name,

	uc_from.first_name	as from_first_name,
	uc_from.last_name	as from_last_name


/*
from uc_contact_state cs
	join uc_call call on call.call_id = cs.call_id
	join uc_contact uc_to	on uc_to.contact_id = call.to_contact_id
	join uc_contact uc_from	on uc_from.contact_id = call.from_contact_id

where call.status_id = @status_id
	and call.is_deleted = 0
*/


from uc_call call
	join uc_contact uc_to	on uc_to.contact_id = call.to_contact_id
	join uc_contact uc_from	on uc_from.contact_id = call.from_contact_id

where call.status_id = @status_id
	and call.is_deleted = 0

--








--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_select_by_contact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_call_select_by_contact]
(
@contact_id		int
)
AS
 
Set NoCount On



select
	call.call_id,
	call.call_guid,
	call.status_id,
	call.from_contact_id,
	call.to_contact_id,

	call.date_created,
	call.date_open,
	call.date_closed,
	call.date_updated,
	call.date_deleted,

	uc_to.first_name	as to_first_name,
	uc_to.last_name		as to_last_name,

	uc_from.first_name	as from_first_name,
	uc_from.last_name	as from_last_name


from uc_contact_state cs
	join uc_call call on call.call_id = cs.call_id
	join uc_contact uc_to	on uc_to.contact_id = call.to_contact_id
	join uc_contact uc_from	on uc_from.contact_id = call.from_contact_id


where cs.contact_id = @contact_id
	and call.is_deleted = 0

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_get_by_contact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_call_get_by_contact]
(
@contact_id		int
)
AS
 
Set NoCount On




select

	cl.contact_id,
	c.contact_id	as lst_contact_id,

	c.contact_guid,
	c.first_name,
	c.last_name,

	call.call_id,
	
	IsNull(cl.lst_nickname, '''') as lst_nickname,
	case when (cl.lst_nickname is NULL) then 0 else 1 end as contact_listed

from uc_contact c
	left join uc_contact_state cs	on (cs.contact_id		= c.contact_id)	-- and (cs.call_id = @contact_id)
	
	left join uc_call call			on (call.call_id		= cs.call_id)	
		and ((call.from_contact_id = @contact_id) or (call.to_contact_id = @contact_id))

	left join uc_contact_listing cl	on (cl.lst_contact_id	= c.contact_id)	and (cl.contact_id = @contact_id)

where c.is_deleted = 0
	and (call.from_contact_id = @contact_id or call.to_contact_id = @contact_id)
	and call.status_id in (1,2)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_call_select]
(
@call_id		int
)
AS
 
Set NoCount On






update uc_call
	set
	date_updated	= getUtcDate()
where call_id = @call_id






select
	call.call_id,
	call.call_guid,
	call.status_id,
	call.from_contact_id,
	call.to_contact_id,

	call.date_created,
	call.date_open,
	call.date_closed,
	call.date_updated,
	call.date_deleted,

	uc_to.first_name	as to_first_name,
	uc_to.last_name		as to_last_name,

	uc_from.first_name	as from_first_name,
	uc_from.last_name	as from_last_name


from uc_call call
	join uc_contact uc_to	on uc_to.contact_id = call.to_contact_id
	join uc_contact uc_from	on uc_from.contact_id = call.from_contact_id

where call.call_id = @call_id
	and call.is_deleted = 0

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_listing_incoming]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_listing_incoming]
(
@contact_id		int
)
AS
 
Set NoCount On




select

	cl.contact_id,
	c.contact_id	as lst_contact_id,

	c.contact_guid,
	c.first_name,
	c.last_name,

	cs.is_available,
	cs.is_busy,
	cs.state,

	call.call_id,
	
	IsNull(cl.lst_nickname, '''') as lst_nickname,
	case when (cl.lst_nickname is NULL) then 0 else 1 end as contact_listed

from uc_contact c
	left join uc_contact_state cs	on (cs.contact_id		= c.contact_id)	-- and (cs.call_id = @contact_id)
	left join uc_call call			on (call.call_id		= cs.call_id)	and (call.to_contact_id = @contact_id)
	left join uc_contact_listing cl	on (cl.lst_contact_id	= c.contact_id)	and (cl.contact_id = @contact_id)
where c.is_deleted = 0
	and call.to_contact_id = @contact_id
	and call.status_id in (1,2)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_listing_current]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_contact_listing_current]
(
@contact_id		int
)
AS
 
Set NoCount On




select

	cl.contact_id,
	c.contact_id	as lst_contact_id,

	c.contact_guid,
	c.first_name,
	c.last_name,

	cs.is_available,
	cs.is_busy,
	cs.state,

	call.call_id,
	
	IsNull(cl.lst_nickname, '''') as lst_nickname,
	case when (cl.lst_nickname is NULL) then 0 else 1 end as contact_listed

from uc_contact c
	join uc_contact_state cs	on (cs.contact_id		= c.contact_id)
	join uc_call call			on (call.call_id		= cs.call_id)	and (call.from_contact_id = @contact_id)
	left join uc_contact_listing cl	on (cl.lst_contact_id	= c.contact_id)	and (cl.contact_id = @contact_id)
where c.is_deleted = 0
	and call.from_contact_id = @contact_id
	and call.status_id in (1,2)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_get_listing]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_get_listing]
(
@contact_id	int
)
AS
 
Set NoCount On


select

	cl.contact_id,
	c.contact_id	as lst_contact_id,

	c.contact_guid,
	c.first_name,
	c.last_name,

	cs.is_available,
	cs.is_busy,
	cs.state,

	call.call_id,
	
	IsNull(cl.lst_nickname, '''') as lst_nickname,
	case when (cl.lst_nickname is NULL) then 0 else 1 end as contact_listed

from uc_contact c
	left join uc_contact_state cs	on (cs.contact_id		= c.contact_id)-- and (cs.call_id = @contact_id)
	left join uc_call call			on (call.call_id		= cs.call_id) and (call.to_contact_id = @contact_id)
	left join uc_contact_listing cl	on cl.lst_contact_id	= c.contact_id
where c.is_deleted = 0
	and cl.contact_id = @contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_state_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_contact_state_get_all]
AS
 
Set NoCount On




declare @call_cnt int
set @call_cnt = 0

select
	
	c.contact_id,
	
	cs.is_available,
	cs.is_busy,
	cs.state,
	cs.call_id,
	cs.date_accessed,

	@call_cnt as call_count

from uc_contact c
	join uc_contact_state cs on cs.contact_id = c.contact_id

	
--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_state_select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_contact_state_select]
(
@contact_id	int
)
AS
 
Set NoCount On











update uc_contact_state
	set
	date_accessed	= getUtcDate()
where contact_id = @contact_id







declare @call_cnt int

select
@call_cnt = count(c.contact_id)
from uc_contact c
	join uc_contact_state cs	on cs.contact_id		= c.contact_id
	join uc_call call			on call.call_id			= cs.call_id
where c.is_deleted = 0
	and call.to_contact_id = @contact_id
	and call.status_id = 1


select
	
	c.contact_id,
--	c.status_id,
	
	cs.is_available,
	cs.is_busy,
	cs.state,
	cs.call_id,
	cs.date_accessed,

--	(select count(*) from uc_contact_state where uc_contact_state.call_id = @contact_id) as call_count
	@call_cnt as call_count

from uc_contact c
	join uc_contact_state cs on cs.contact_id = c.contact_id

	
where c.contact_id = @contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_get_all]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_call_get_all]
(
@from_contact_id	int,
@to_contact_id		int,
@status_id			int
)
AS
 
Set NoCount On



select
	call.call_id,
	call.call_guid,
	call.status_id,
	call.from_contact_id,
	call.to_contact_id,

	call.date_created,
	call.date_open,
	call.date_closed,
	call.date_updated,
	call.date_deleted,

	uc_to.first_name	as to_first_name,
	uc_to.last_name		as to_last_name,

	uc_from.first_name	as from_first_name,
	uc_from.last_name	as from_last_name



from uc_call call
	join uc_contact uc_to	on uc_to.contact_id = call.to_contact_id
	join uc_contact uc_from	on uc_from.contact_id = call.from_contact_id


where call.is_deleted = 0
	and ((call.from_contact_id	= @from_contact_id)	or (@from_contact_id	= 0))
	and ((call.to_contact_id	= @to_contact_id)	or (@to_contact_id		= 0))
	and ((call.status_id		= @status_id)		or (@status_id = 0))


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_get_agents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_skill_get_agents]
(
@skill_id	int
)
AS
 
Set NoCount On

select
		
	a.agent_id,
	a.first_name,
	a.last_name,

	sa.skill_id

from uc_agent a
	left join uc_agent_skill sa on (sa.agent_id = a.agent_id and sa.skill_id = @skill_id)

where a.is_deleted = 0
	and ((sa.skill_id = @skill_id) or (sa.skill_id is NULL))



--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_insert]
(
@user_id		int,
@first_name		nvarchar(50),
@last_name		nvarchar(50),
@email			nvarchar(50),
@phone			nvarchar(50),
@public_enabled	bit
)
AS
 
Set NoCount On




declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_agent (agent_guid,user_id,first_name,last_name,email,phone,public_enabled)
values (@guid,@user_id,@first_name,@last_name,@email,@phone,@public_enabled)


select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_agent_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_agent_update]
(
@agent_id		int,
@user_id		int,
@first_name		nvarchar(50),
@last_name		nvarchar(50),
@email			nvarchar(50),
@phone			nvarchar(50),
@public_enabled	bit
)
AS
 
Set NoCount On



update uc_agent
	set

		--user_id		= @user_id,
		first_name		= @first_name,
		last_name		= @last_name,
		email			= @email,
		phone			= @phone,
		public_enabled	= @public_enabled,
		date_updated	= getUtcDate()

where agent_id = @agent_id
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_survey_set_question]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_survey_set_question]
(
@survey_id		int,
@question_id	int,
@set			bit
)
AS
 
Set NoCount On


delete uc_survey_question
where survey_id = @survey_id
	and question_id = @question_id


if(@set = 1)
	insert uc_survey_question(survey_id, question_id)
	values(@survey_id, @question_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_state_set_busy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_contact_state_set_busy]
(
@contact_id			int,
@is_busy			bit,
@call_id			int
)
AS
 
Set NoCount On



update uc_contact_state
	set

	contact_id		= @contact_id,
	is_busy			= @is_busy,
	call_id			= @call_id,
	date_accessed	= getUtcDate()
									
where contact_id = @contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_state_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_contact_state_delete]
(
@contact_id	int
)
AS
 
Set NoCount On


delete uc_contact_state
where contact_id = @contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_state_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_contact_state_insert]
(
@contact_id		int,
@is_available	bit,
@state			char(3)
)
AS

 
Set NoCount On


delete uc_contact_state
where contact_id = @contact_id


insert uc_contact_state (contact_id, is_available, is_busy, state)
values (@contact_id, @is_available, 0, @state)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[_usp_contact_state_set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [_usp_contact_state_set]
(
@contact_id		int
)
AS
 
Set NoCount On


update uc_contact_state
	set
		date_accessed	= getUtcDate()

where contact_id = @contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_state_update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
CREATE Procedure [usp_contact_state_update]
(
@contact_id			int,
@is_available		bit,
@state				char(3),
@call_id			int
)
AS
 
Set NoCount On



update uc_contact_state
	set

	contact_id		= @contact_id,
	is_available	= @is_available,
	state			= @state,
	call_id			= @call_id,
	date_accessed	= getUtcDate()
									
where contact_id = @contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_listing_delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
create Procedure [usp_contact_listing_delete]
(
@contact_id			int,
@lst_contact_id		int
)
AS

 
Set NoCount On


delete uc_contact_listing
where contact_id = @contact_id
	and lst_contact_id = @lst_contact_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_contact_listing_add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------
create Procedure [usp_contact_listing_add]
(
@contact_id			int,
@lst_contact_id		int,
@lst_nickname			nvarchar(50)
)
AS

 
Set NoCount On


delete uc_contact_listing
where contact_id = @contact_id
	and lst_contact_id = @lst_contact_id


insert uc_contact_listing (contact_id, lst_contact_id, lst_nickname)
values (@contact_id, @lst_contact_id, @lst_nickname)


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_open]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_call_open]
(
@call_id		int
)
AS
 
Set NoCount On


update uc_call
	set

	status_id		= 2,	-- Open
	date_open		= getUtcDate(),
	date_updated	= getUtcDate()

where call_id = @call_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_call_insert]
(
@call_guid			uniqueidentifier,	-- to delete
@from_contact_id	int,
@to_contact_id		int
)
AS
 
Set NoCount On


declare @guid as uniqueidentifier
set		@guid = newID()


insert uc_call (call_guid, from_contact_id, to_contact_id, status_id)
values (@guid, @from_contact_id, @to_contact_id, 1)



select SCOPE_IDENTITY() as id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_close]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------
--------------------------------------------------
--------------------------------------------------
CREATE Procedure [usp_call_close]
(
@call_id		int
)
AS
 
Set NoCount On


update uc_call
	set

	status_id = 4,	-- Closed
	date_closed = getUtcDate(),
	date_updated = getUtcDate()


where call_id = @call_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_call_cancel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create Procedure [usp_call_cancel]
(
@call_id		int
)
AS
 
Set NoCount On


update uc_call
	set

	status_id = 3,	-- Canceled
	date_closed = getUtcDate(),
	date_updated = getUtcDate()


where call_id = @call_id


--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_skill_set_agent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_skill_set_agent]
(
@agent_id		int,
@skill_id		int,
@set			bit
)
AS
 
Set NoCount On

if(@set = 1)
	insert uc_agent_skill(agent_id, skill_id)
	values(@agent_id, @skill_id)
else
	delete uc_agent_skill
	where skill_id = @skill_id	and agent_id = @agent_id

--
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_update_audio]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_update_audio]
(
	@incident_id INT,
	@audio_source INT,
	@audio_complete BIT OUT
)
AS
	SET NOCOUNT ON

	SET @audio_complete = 0

	IF @audio_source = 1
	BEGIN
		UPDATE [uc_log]
		SET [audio_callcenter] = 1
		WHERE [incident_id] = @incident_id
		
		SELECT @audio_complete = [audio_facility]
		FROM [uc_log]
		WHERE [incident_id] = @incident_id
	END
	ELSE IF @audio_source = 2
	BEGIN
		UPDATE [uc_log]
		SET [audio_facility] = 1
		WHERE [incident_id] = @incident_id

		SELECT @audio_complete = [audio_callcenter]
		FROM [uc_log]
		WHERE [incident_id] = @incident_id
	END
	ELSE IF @audio_source = 3
	BEGIN
		UPDATE [uc_log]
		SET [audio_merged] = 1
		WHERE [incident_id] = @incident_id
	END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[usp_log_get_audio_link]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [usp_log_get_audio_link]
(
	@incident_id INT,
	@audio_link NVARCHAR(100) OUT
)
AS
	SET NOCOUNT ON

	DECLARE @a INT

	SELECT @a =
		CASE
			WHEN [audio_merged] = 1 THEN 1
			WHEN [audio_callcenter] = 1 THEN 2
			WHEN [audio_facility] = 1 THEN 3
			ELSE 0
		END 
	FROM [uc_log]
	WHERE [incident_id] = @incident_id

	IF @a = 0
	BEGIN
		SET @audio_link = ''''
		RETURN
	END

	SET @audio_link = ''http://webdemo.ucentrik.com/AudioRecords/''

	IF @a = 2
		SET @audio_link = @audio_link + ''callcenter''
	ELSE IF @a = 3
		SET @audio_link = @audio_link + ''facility''

	SET @audio_link = @audio_link + LTRIM(STR(@incident_id)) + ''.mp3''
' 
END
