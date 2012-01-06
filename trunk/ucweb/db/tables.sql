SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lu_user_role]') AND type in (N'U'))
BEGIN
CREATE TABLE [lu_user_role](
	[user_role_id] [int] NOT NULL,
	[user_role_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_user_role] PRIMARY KEY CLUSTERED 
(
	[user_role_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lu_question_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [lu_question_type](
	[question_type_id] [int] NOT NULL,
	[question_type_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_question_type] PRIMARY KEY CLUSTERED 
(
	[question_type_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lu_incident_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [lu_incident_status](
	[incident_status_id] [int] NOT NULL,
	[incident_status_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_incident_status] PRIMARY KEY CLUSTERED 
(
	[incident_status_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lu_call_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [lu_call_status](
	[call_status_id] [int] NOT NULL,
	[call_status_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_call_status] PRIMARY KEY CLUSTERED 
(
	[call_status_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_chat]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_chat](
	[chat_id] [int] IDENTITY(1,1) NOT NULL,
	[chat_session] [nvarchar](50) NOT NULL,
	[chat_sender] [nvarchar](50) NOT NULL,
	[chat_message] [ntext] NOT NULL,
	[chat_datetime] [datetime] NOT NULL CONSTRAINT [DF_uc_chat_chat_datetime]  DEFAULT (getutcdate()),
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_chat_is_deleted]  DEFAULT ((0)),
	[date_deleted] [datetime] NULL,
 CONSTRAINT [PK_uc_chat] PRIMARY KEY CLUSTERED 
(
	[chat_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_exception]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_exception](
	[ex_id] [int] IDENTITY(1,1) NOT NULL,
	[parent_ex_id] [int] NULL,
	[ex_message] [nvarchar](500) NOT NULL,
	[ex_stacktrace] [nvarchar](1000) NOT NULL,
	[application] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[page_url] [nvarchar](250) NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_ex_date_created]  DEFAULT (getutcdate()),
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_ex_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_exception] PRIMARY KEY CLUSTERED 
(
	[ex_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_group]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_group](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[group_guid] [uniqueidentifier] NOT NULL,
	[group_name] [nvarchar](50) NOT NULL,
	[description] [ntext] NULL,
	[public_enabled] [bit] NOT NULL CONSTRAINT [DF_uc_group_public_enabled]  DEFAULT ((0)),
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_group_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_group_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_group] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_language]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_language](
	[language_id] [int] IDENTITY(1,1) NOT NULL,
	[language_name] [nvarchar](50) NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_language_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_language_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_language] PRIMARY KEY CLUSTERED 
(
	[language_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_survey]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_survey](
	[survey_id] [int] IDENTITY(1,1) NOT NULL,
	[survey_guid] [uniqueidentifier] NOT NULL,
	[survey_name] [nvarchar](50) NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_survey_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_survey_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_survey] PRIMARY KEY CLUSTERED 
(
	[survey_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_skill]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_skill](
	[skill_id] [int] IDENTITY(1,1) NOT NULL,
	[skill_name] [nvarchar](50) NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_skill_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_skill_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_skill] PRIMARY KEY CLUSTERED 
(
	[skill_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[uc_settings](
	[name] [varchar](50) NOT NULL,
	[category] [varchar](50) NOT NULL,
	[value] [nvarchar](255) NOT NULL,
	[tooltip] [nvarchar](512) NULL,
 CONSTRAINT [PK_uc_settings] PRIMARY KEY CLUSTERED 
(
	[name] ASC,
	[category] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_survey_response]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_survey_response](
	[survey_response_id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[incident_id] [int] NOT NULL,
	[response] [nvarchar](1000) NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_survey_response_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_survey_response_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_survey_response] PRIMARY KEY CLUSTERED 
(
	[survey_response_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_incident_transfer]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_incident_transfer](
	[transfer_id] [int] IDENTITY(1,1) NOT NULL,
	[incident_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[from_agent_id] [int] NOT NULL,
	[to_agent_id] [int] NOT NULL,
	[date_transferred] [datetime] NOT NULL CONSTRAINT [DF_uc_incident_transfer_date_transferred]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_uc_incident_transfer] PRIMARY KEY CLUSTERED 
(
	[transfer_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_incident_state]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_incident_state](
	[incident_id] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[state] [char](3) NOT NULL,
	[date_updated] [datetime] NOT NULL CONSTRAINT [DF_uc_incident_state_date_accessed]  DEFAULT (getutcdate()),
	[period_to_update_0] [int] NULL,
	[date_accessed_0] [datetime] NULL,
	[period_to_update_1] [int] NULL,
	[date_accessed_1] [datetime] NULL,
 CONSTRAINT [PK_uc_incident_state] PRIMARY KEY CLUSTERED 
(
	[incident_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_incident_note]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_incident_note](
	[note_id] [int] IDENTITY(1,1) NOT NULL,
	[incident_id] [int] NOT NULL,
	[note] [ntext] NOT NULL,
	[user_id] [int] NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_incident_note_date_created]  DEFAULT (getutcdate()),
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_incident_note_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_incident_note] PRIMARY KEY CLUSTERED 
(
	[note_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_pool]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_pool](
	[agent_id] [int] NOT NULL,
	[is_available] [bit] NOT NULL CONSTRAINT [DF_uc_pool_is_available]  DEFAULT ((0)),
	[is_busy] [bit] NOT NULL CONSTRAINT [DF_uc_pool_is_busy]  DEFAULT ((0)),
	[last_call_time] [datetime] NULL,
	[incident_id] [int] NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_pool_date_created]  DEFAULT (getutcdate()),
	[date_accessed] [datetime] NOT NULL CONSTRAINT [DF_uc_pool_date_accessed]  DEFAULT (getutcdate()),
	[date_reserved] [datetime] NULL,
 CONSTRAINT [PK_uc_pool] PRIMARY KEY CLUSTERED 
(
	[agent_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_log]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_log](
	[incident_id] [int] NOT NULL,
	[consumer_name] [nvarchar](50) NULL,
		[customer_satisfaction] [nvarchar](100) NULL,
		[transaction_status_id] [int] NOT NULL CONSTRAINT [DF_uc_log_transaction_status_id]  DEFAULT ((0)),
	[transaction_value] [nvarchar](50) NULL,
	[transaction_completion] [bit] NULL,
		[issue_found] [nvarchar](100) NULL,
		[issue_resolved] [nvarchar](100) NULL,
		[kiosk_malfunction] [bit] NULL,
		[kiosk_status_after_transaction] [nvarchar](50) NULL,
	[kiosk_id] [nvarchar](50) NULL,
	[kiosk_name] [nvarchar](50) NULL,
	[kiosk_location] [nvarchar](50) NULL,
		[device_in_database] [bit] NULL,
		[engineering_work_order_opened] [bit] NULL,
	[device_value] [int] NULL,
	[device_type] [nvarchar](50) NULL,
	[device_make] [nvarchar](50) NULL,
	[device_model] [nvarchar](50) NULL,
	[audio] [varbinary](max) NULL,
	[driver_license] [varbinary](max) NULL,
	[id_card] [varbinary](max) NULL,
	[inspector_bin] [varbinary](max) NULL,
	[subject_notes] [nvarchar](100) NULL,
	[screen_user_help] [nvarchar](200) NULL,
	[audio_facility] [bit] NOT NULL CONSTRAINT [DF_uc_log_audio_facility] DEFAULT ((0)),
	[audio_callcenter] [bit] NOT NULL CONSTRAINT [DF_uc_log_audio_callcenter] DEFAULT ((0)),
	[audio_merged] [bit] NOT NULL CONSTRAINT [DF_uc_log_audio_merged] DEFAULT ((0)),
	[server] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_user]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_guid] [uniqueidentifier] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[password_salt] [nvarchar](50) NOT NULL,
	[user_role_id] [int] NOT NULL,
	[time_zone] [varchar](100) NOT NULL,
	[logins] [int] NOT NULL CONSTRAINT [DF_uc_user_logins]  DEFAULT ((0)),
	[login_attempts] [int] NOT NULL CONSTRAINT [DF_user_login_attempts]  DEFAULT ((0)),
	[date_last_login] [datetime] NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_user_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_locked_out] [bit] NOT NULL CONSTRAINT [DF_user_is_locked_out]  DEFAULT ((0)),
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_user_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_question]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_question](
	[question_id] [int] IDENTITY(1,1) NOT NULL,
	[question_text] [nvarchar](200) NOT NULL,
	[type_id] [int] NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_question_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_question_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_question] PRIMARY KEY CLUSTERED 
(
	[question_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_incident]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_incident](
	[incident_id] [int] IDENTITY(1,1) NOT NULL,
	[incident_guid] [uniqueidentifier] NOT NULL,
	[subject] [nvarchar](100) NULL,
	[group_id] [int] NULL,
	[skill_id] [int] NULL,
	[language_id] [int] NULL,
	[facility_id] [int] NULL,
	[contact_id] [int] NULL,
	[agent_id] [int] NULL,
	[status_id] [int] NOT NULL,
	[reserved_agent_id] [int] NULL,
	[connect_count] [int] NOT NULL CONSTRAINT [DF_uc_incident_connect_count]  DEFAULT ((0)),
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_incident_created]  DEFAULT (getutcdate()),
	[date_open] [datetime] NULL,
	[date_closed] [datetime] NULL,
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_incident_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_incident] PRIMARY KEY CLUSTERED 
(
	[incident_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_call]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_call](
	[call_id] [int] IDENTITY(1,1) NOT NULL,
	[call_guid] [uniqueidentifier] NOT NULL,
	[from_contact_id] [int] NOT NULL,
	[to_contact_id] [int] NOT NULL,
	[status_id] [int] NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_uc_call_date_created]  DEFAULT (getutcdate()),
	[date_open] [datetime] NULL,
	[date_closed] [datetime] NULL,
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_uc_call_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_uc_calls] PRIMARY KEY CLUSTERED 
(
	[call_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_group_facility]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_group_facility](
	[group_id] [int] NOT NULL,
	[facility_id] [int] NOT NULL,
 CONSTRAINT [PK_uc_group_facility] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC,
	[facility_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_group_agent]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_group_agent](
	[group_id] [int] NOT NULL,
	[agent_id] [int] NOT NULL,
 CONSTRAINT [PK_uc_group_agent] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC,
	[agent_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_agent_language]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_agent_language](
	[agent_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
 CONSTRAINT [PK_uc_agent_language] PRIMARY KEY CLUSTERED 
(
	[agent_id] ASC,
	[language_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_facility]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_facility](
	[facility_id] [int] IDENTITY(1,1) NOT NULL,
	[active] [bit] NOT NULL CONSTRAINT [DF_uc_facility_disable]  DEFAULT ((1)),
	[facility_guid] [uniqueidentifier] NOT NULL,
	[ip_address] [nvarchar](16) NULL,
	[web_referrer] [nvarchar](100) NULL,
	[user_id] [int] NULL,
	[facility_name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[survey_id] [int] NULL,
	[agent_id] [int] NULL,
	[status] [nvarchar](16) NULL,
	[status_stamp] [datetime] NULL,
	[command] [nvarchar](128) NULL,
	[command_stamp] [datetime] NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_facility_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_facility_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_facility] PRIMARY KEY CLUSTERED 
(
	[facility_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_survey_question]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_survey_question](
	[survey_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
 CONSTRAINT [PK_uc_survey_question] PRIMARY KEY CLUSTERED 
(
	[survey_id] ASC,
	[question_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_agent_skill]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_agent_skill](
	[agent_id] [int] NOT NULL,
	[skill_id] [int] NOT NULL,
 CONSTRAINT [PK_uc_agent_skill] PRIMARY KEY CLUSTERED 
(
	[agent_id] ASC,
	[skill_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_contact](
	[contact_id] [int] IDENTITY(1,1) NOT NULL,
	[contact_guid] [uniqueidentifier] NOT NULL,
	[user_id] [int] NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[memo] [nvarchar](50) NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_contact_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_contact_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_agent]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_agent](
	[agent_id] [int] IDENTITY(1,1) NOT NULL,
	[agent_guid] [uniqueidentifier] NOT NULL,
	[user_id] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[public_enabled] [bit] NOT NULL,
	[date_created] [datetime] NOT NULL CONSTRAINT [DF_agent_date_created]  DEFAULT (getutcdate()),
	[date_updated] [datetime] NULL,
	[date_deleted] [datetime] NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_agent_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_resource] PRIMARY KEY CLUSTERED 
(
	[agent_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_contact_state]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_contact_state](
	[contact_id] [int] NOT NULL,
	[is_available] [bit] NOT NULL,
	[is_busy] [bit] NULL,
	[state] [char](3) NOT NULL,
	[call_id] [int] NULL,
	[date_accessed] [datetime] NOT NULL CONSTRAINT [DF_uc_contact_state_date_accessed]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_uc_contact_state] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[uc_contact_listing]') AND type in (N'U'))
BEGIN
CREATE TABLE [uc_contact_listing](
	[contact_id] [int] NOT NULL,
	[lst_contact_id] [int] NOT NULL,
	[lst_nickname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_uc_contact_listing] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC,
	[lst_contact_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_survey_response_uc_incident]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_survey_response]'))
ALTER TABLE [dbo].[uc_survey_response]  WITH CHECK ADD  CONSTRAINT [FK_uc_survey_response_uc_incident] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_survey_response_uc_question]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_survey_response]'))
ALTER TABLE [dbo].[uc_survey_response]  WITH CHECK ADD  CONSTRAINT [FK_uc_survey_response_uc_question] FOREIGN KEY([question_id])
REFERENCES [uc_question] ([question_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_survey_response_uc_survey]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_survey_response]'))
ALTER TABLE [dbo].[uc_survey_response]  WITH CHECK ADD  CONSTRAINT [FK_uc_survey_response_uc_survey] FOREIGN KEY([survey_id])
REFERENCES [uc_survey] ([survey_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_transfer_uc_agent1]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident_transfer]'))
ALTER TABLE [dbo].[uc_incident_transfer]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_transfer_uc_agent1] FOREIGN KEY([to_agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_transfer_uc_incident]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident_transfer]'))
ALTER TABLE [dbo].[uc_incident_transfer]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_transfer_uc_incident] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_transfer_uc_incident1]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident_transfer]'))
ALTER TABLE [dbo].[uc_incident_transfer]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_transfer_uc_incident1] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_state_uc_incident]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident_state]'))
ALTER TABLE [dbo].[uc_incident_state]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_state_uc_incident] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_note_uc_incident]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident_note]'))
ALTER TABLE [dbo].[uc_incident_note]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_note_uc_incident] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_note_uc_user]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident_note]'))
ALTER TABLE [dbo].[uc_incident_note]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_note_uc_user] FOREIGN KEY([user_id])
REFERENCES [uc_user] ([user_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_pool_uc_agent]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_pool]'))
ALTER TABLE [dbo].[uc_pool]  WITH CHECK ADD  CONSTRAINT [FK_uc_pool_uc_agent] FOREIGN KEY([agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_pool_uc_incident]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_pool]'))
ALTER TABLE [dbo].[uc_pool]  WITH CHECK ADD  CONSTRAINT [FK_uc_pool_uc_incident] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_log_uc_incident]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_log]'))
ALTER TABLE [dbo].[uc_log]  WITH CHECK ADD  CONSTRAINT [FK_uc_log_uc_incident] FOREIGN KEY([incident_id])
REFERENCES [uc_incident] ([incident_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_lu_user_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_user]'))
ALTER TABLE [dbo].[uc_user]  WITH CHECK ADD  CONSTRAINT [FK_user_lu_user_role] FOREIGN KEY([user_role_id])
REFERENCES [lu_user_role] ([user_role_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_question_lu_question_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_question]'))
ALTER TABLE [dbo].[uc_question]  WITH CHECK ADD  CONSTRAINT [FK_uc_question_lu_question_type] FOREIGN KEY([type_id])
REFERENCES [lu_question_type] ([question_type_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_incident_agent]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident]'))
ALTER TABLE [dbo].[uc_incident]  WITH CHECK ADD  CONSTRAINT [FK_incident_agent] FOREIGN KEY([agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_incident_contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident]'))
ALTER TABLE [dbo].[uc_incident]  WITH CHECK ADD  CONSTRAINT [FK_incident_contact] FOREIGN KEY([contact_id])
REFERENCES [uc_contact] ([contact_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_incident_facility]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident]'))
ALTER TABLE [dbo].[uc_incident]  WITH CHECK ADD  CONSTRAINT [FK_incident_facility] FOREIGN KEY([facility_id])
REFERENCES [uc_facility] ([facility_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_incident_lu_incident_status]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident]'))
ALTER TABLE [dbo].[uc_incident]  WITH CHECK ADD  CONSTRAINT [FK_incident_lu_incident_status] FOREIGN KEY([status_id])
REFERENCES [lu_incident_status] ([incident_status_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_incident_uc_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_incident]'))
ALTER TABLE [dbo].[uc_incident]  WITH CHECK ADD  CONSTRAINT [FK_uc_incident_uc_group] FOREIGN KEY([group_id])
REFERENCES [uc_group] ([group_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_call_lu_call_status]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_call]'))
ALTER TABLE [dbo].[uc_call]  WITH CHECK ADD  CONSTRAINT [FK_uc_call_lu_call_status] FOREIGN KEY([status_id])
REFERENCES [lu_call_status] ([call_status_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_calls_uc_contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_call]'))
ALTER TABLE [dbo].[uc_call]  WITH CHECK ADD  CONSTRAINT [FK_uc_calls_uc_contact] FOREIGN KEY([from_contact_id])
REFERENCES [uc_contact] ([contact_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_calls_uc_contact1]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_call]'))
ALTER TABLE [dbo].[uc_call]  WITH CHECK ADD  CONSTRAINT [FK_uc_calls_uc_contact1] FOREIGN KEY([to_contact_id])
REFERENCES [uc_contact] ([contact_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_group_facility_uc_facility]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_group_facility]'))
ALTER TABLE [dbo].[uc_group_facility]  WITH CHECK ADD  CONSTRAINT [FK_uc_group_facility_uc_facility] FOREIGN KEY([facility_id])
REFERENCES [uc_facility] ([facility_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_group_facility_uc_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_group_facility]'))
ALTER TABLE [dbo].[uc_group_facility]  WITH CHECK ADD  CONSTRAINT [FK_uc_group_facility_uc_group] FOREIGN KEY([group_id])
REFERENCES [uc_group] ([group_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_group_agent_uc_agent]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_group_agent]'))
ALTER TABLE [dbo].[uc_group_agent]  WITH CHECK ADD  CONSTRAINT [FK_uc_group_agent_uc_agent] FOREIGN KEY([agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_group_agent_uc_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_group_agent]'))
ALTER TABLE [dbo].[uc_group_agent]  WITH CHECK ADD  CONSTRAINT [FK_uc_group_agent_uc_group] FOREIGN KEY([group_id])
REFERENCES [uc_group] ([group_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_agent_language_uc_agent]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_agent_language]'))
ALTER TABLE [dbo].[uc_agent_language]  WITH CHECK ADD  CONSTRAINT [FK_uc_agent_language_uc_agent] FOREIGN KEY([agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_agent_language_uc_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_agent_language]'))
ALTER TABLE [dbo].[uc_agent_language]  WITH CHECK ADD  CONSTRAINT [FK_uc_agent_language_uc_language] FOREIGN KEY([language_id])
REFERENCES [uc_language] ([language_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_facility_agent]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_facility]'))
ALTER TABLE [dbo].[uc_facility]  WITH CHECK ADD  CONSTRAINT [FK_facility_agent] FOREIGN KEY([agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_facility_survey]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_facility]'))
ALTER TABLE [dbo].[uc_facility]  WITH CHECK ADD  CONSTRAINT [FK_facility_survey] FOREIGN KEY([survey_id])
REFERENCES [uc_survey] ([survey_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_facility_user]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_facility]'))
ALTER TABLE [dbo].[uc_facility]  WITH CHECK ADD  CONSTRAINT [FK_facility_user] FOREIGN KEY([user_id])
REFERENCES [uc_user] ([user_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_survey_question_survey]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_survey_question]'))
ALTER TABLE [dbo].[uc_survey_question]  WITH CHECK ADD  CONSTRAINT [FK_survey_question_survey] FOREIGN KEY([survey_id])
REFERENCES [uc_survey] ([survey_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_survey_question_uc_question]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_survey_question]'))
ALTER TABLE [dbo].[uc_survey_question]  WITH CHECK ADD  CONSTRAINT [FK_uc_survey_question_uc_question] FOREIGN KEY([question_id])
REFERENCES [uc_question] ([question_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_agent_skill_uc_agent]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_agent_skill]'))
ALTER TABLE [dbo].[uc_agent_skill]  WITH CHECK ADD  CONSTRAINT [FK_uc_agent_skill_uc_agent] FOREIGN KEY([agent_id])
REFERENCES [uc_agent] ([agent_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_agent_skill_uc_skill]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_agent_skill]'))
ALTER TABLE [dbo].[uc_agent_skill]  WITH CHECK ADD  CONSTRAINT [FK_uc_agent_skill_uc_skill] FOREIGN KEY([skill_id])
REFERENCES [uc_skill] ([skill_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_contact_user]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_contact]'))
ALTER TABLE [dbo].[uc_contact]  WITH CHECK ADD  CONSTRAINT [FK_contact_user] FOREIGN KEY([user_id])
REFERENCES [uc_user] ([user_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_agent_user]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_agent]'))
ALTER TABLE [dbo].[uc_agent]  WITH CHECK ADD  CONSTRAINT [FK_agent_user] FOREIGN KEY([user_id])
REFERENCES [uc_user] ([user_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_contact_state_uc_contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_contact_state]'))
ALTER TABLE [dbo].[uc_contact_state]  WITH CHECK ADD  CONSTRAINT [FK_uc_contact_state_uc_contact] FOREIGN KEY([contact_id])
REFERENCES [uc_contact] ([contact_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_contact_listing_uc_contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_contact_listing]'))
ALTER TABLE [dbo].[uc_contact_listing]  WITH CHECK ADD  CONSTRAINT [FK_uc_contact_listing_uc_contact] FOREIGN KEY([contact_id])
REFERENCES [uc_contact] ([contact_id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_uc_contact_listing_uc_contact1]') AND parent_object_id = OBJECT_ID(N'[dbo].[uc_contact_listing]'))
ALTER TABLE [dbo].[uc_contact_listing]  WITH CHECK ADD  CONSTRAINT [FK_uc_contact_listing_uc_contact1] FOREIGN KEY([lst_contact_id])
REFERENCES [uc_contact] ([contact_id])
