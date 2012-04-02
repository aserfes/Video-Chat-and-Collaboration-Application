/****** Object:  Table [dbo].[uc_group]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_group] ON
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, NEWID(), N'Support', NULL, 0, GETUTCDATE(), NULL, NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, NEWID(), N'Training', NULL, 0, GETUTCDATE(), NULL, NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, NEWID(), N'Demo', NULL, 0, GETUTCDATE(), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_group] OFF
/****** Object:  Table [dbo].[lu_user_role]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[lu_user_role] ([user_role_id], [user_role_name]) VALUES (1, N'Administrator')
INSERT [dbo].[lu_user_role] ([user_role_id], [user_role_name]) VALUES (2, N'Agent')
INSERT [dbo].[lu_user_role] ([user_role_id], [user_role_name]) VALUES (3, N'Manager')
INSERT [dbo].[lu_user_role] ([user_role_id], [user_role_name]) VALUES (4, N'User')
INSERT [dbo].[lu_user_role] ([user_role_id], [user_role_name]) VALUES (5, N'Supervisor')
/****** Object:  Table [dbo].[lu_question_type]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[lu_question_type] ([question_type_id], [question_type_name]) VALUES (1, N'Text')
INSERT [dbo].[lu_question_type] ([question_type_id], [question_type_name]) VALUES (2, N'Yes/No')
INSERT [dbo].[lu_question_type] ([question_type_id], [question_type_name]) VALUES (3, N'Rating')
/****** Object:  Table [dbo].[lu_incident_status]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[lu_incident_status] ([incident_status_id], [incident_status_name]) VALUES (1, N'New')
INSERT [dbo].[lu_incident_status] ([incident_status_id], [incident_status_name]) VALUES (2, N'In-Progress')
INSERT [dbo].[lu_incident_status] ([incident_status_id], [incident_status_name]) VALUES (3, N'Canceled')
INSERT [dbo].[lu_incident_status] ([incident_status_id], [incident_status_name]) VALUES (4, N'Closed')
INSERT [dbo].[lu_incident_status] ([incident_status_id], [incident_status_name]) VALUES (5, N'Follow-Up')
/****** Object:  Table [dbo].[lu_call_status]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[lu_call_status] ([call_status_id], [call_status_name]) VALUES (1, N'New')
INSERT [dbo].[lu_call_status] ([call_status_id], [call_status_name]) VALUES (2, N'Open')
INSERT [dbo].[lu_call_status] ([call_status_id], [call_status_name]) VALUES (3, N'Canceled')
INSERT [dbo].[lu_call_status] ([call_status_id], [call_status_name]) VALUES (4, N'Closed')
/****** Object:  Table [dbo].[uc_language]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_language] ON
INSERT [dbo].[uc_language] ([language_id], [language_name]) VALUES (1, N'English')
INSERT [dbo].[uc_language] ([language_id], [language_name]) VALUES (2, N'French')
INSERT [dbo].[uc_language] ([language_id], [language_name]) VALUES (3, N'Spanish')
SET IDENTITY_INSERT [dbo].[uc_language] OFF
/****** Object:  Table [dbo].[uc_survey]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_survey] ON
INSERT [dbo].[uc_survey] ([survey_id], [survey_guid], [survey_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, NEWID(), N'CSS', GETUTCDATE(), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_survey] OFF
/****** Object:  Table [dbo].[uc_skill]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_skill] ON
INSERT [dbo].[uc_skill] ([skill_id], [skill_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'Support', GETUTCDATE(), GETUTCDATE(), NULL, 0)
INSERT [dbo].[uc_skill] ([skill_id], [skill_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, N'Training', GETUTCDATE(), NULL, NULL, 0)
INSERT [dbo].[uc_skill] ([skill_id], [skill_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, N'Demo', GETUTCDATE(), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_skill] OFF
/****** Object:  Table [dbo].[uc_settings]    Script Date: 10/12/2011 17:23:42 ******/
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioDeviceID', N'KIOSK', N'0', N'Index of audio device that it''s used to capture audio data. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioDeviceID', N'PLATFORM', N'0', N'Index of audio device that it''s used to capture audio data. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioOutputDeviceID', N'KIOSK', N'0', N'Index of device that plays audio data.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioOutputDeviceID', N'PLATFORM', N'0', N'Index of device that plays audio data.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioSamplesPerSec', N'KIOSK', N'1600', N'Samples per second. 8000, 16000 and 32000 are only supported. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioSamplesPerSec', N'PLATFORM', N'1600', N'Samples per second. 8000, 16000 and 32000 are only supported. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'AudioUploadTargetPageUrl', N'PLATFORM', N'http://webdemo.ucentrik.com/callcenter/dirAgent/AudioRecordReceiver.aspx', N'Platform and Kiosk use this url to send audio record file.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'DifFrameCount', N'CTX_SERVER', N'1000', N'Count of difference frames between full frames in screen data.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenDevice', N'KIOSK', N'\\.\DISPLAY1', N'Monitor device name. Parameter is optional, main OS display (\\.\DISPLAY1) is default.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenDevice', N'PLATFORM', N'\\.\DISPLAY1', N'Monitor device name. Parameter is optional, main OS display (\\.\DISPLAY1) is default.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenIDProcess', N'KIOSK', N'0', N'Have Screen Publisher to show windows only from given process and other processes started from given process. 0 - Cancel process filtering. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenIDProcess', N'PLATFORM', N'0', N'Have Screen Publisher to show windows only from given process and other processes started from given process. 0 - Cancel process filtering. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenTypePixel', N'KIOSK', N'1', N'Pixel type. 0 - 8 bit (default). 1 - 16 bit. 2 - 24 bit')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenTypePixel', N'PLATFORM', N'1', N'Pixel type. 0 - 8 bit (default). 1 - 16 bit. 2 - 24 bit')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenUIControlHeight', N'PLATFORM', N'700', N'Remote screen view resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenUIControlHeight', N'KIOSK', N'700', N'Remote screen view resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenUIControlWidth', N'PLATFORM', N'1000', N'Remote screen view resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenUIControlWidth', N'KIOSK', N'1000', N'Remote screen view resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenViewMethod', N'PLATFORM', N'0', N'Drawing mode. 0 - Scroll. 1 - Scale. 2 - Scale HalfTone. 3 - Scale ColorOnColor. 4 - Scale GdiPlus. 5 - Scale GdiPlus Default. 6 - Scale GdiPlus LowQuality. 7 - Scale GdiPlus HighQuality. 8 - Scale GdiPlus Bilinear. 9 - Scale GdiPlus Bicubic. 10 - Scale GdiPlus NearestNeighbor. 11 - Scale GdiPlus HighQualityBilinear. 12 - Scale GdiPlus HighQualityBicubic. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ScreenViewMethod', N'KIOSK', N'0', N'Drawing mode. 0 - Scroll. 1 - Scale. 2 - Scale HalfTone. 3 - Scale ColorOnColor. 4 - Scale GdiPlus. 5 - Scale GdiPlus Default. 6 - Scale GdiPlus LowQuality. 7 - Scale GdiPlus HighQuality. 8 - Scale GdiPlus Bilinear. 9 - Scale GdiPlus Bicubic. 10 - Scale GdiPlus NearestNeighbor. 11 - Scale GdiPlus HighQualityBilinear. 12 - Scale GdiPlus HighQualityBicubic. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'Server', N'CTX_SERVER', N'Ctx02.ucentrik.com:80:443:80', N'IP_address:TCP_Port:SSL_Port:HTTP_Port')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'ServerApiKey', N'CTX_SERVER', N'90add7be84444f759492953a0b4cf8c1c08f112585ea4f7b8954815ffb43dfb6fd5db88f2c95476091245d3d9da7f49b435d31a7926c472085d103b4ad4725a82f602e7915194dec95fa84ce647ce21f6ed3e972f146487d93404181fe0eeb9f007c2ac1579b4c30970616bb30416ae41bb54743a98b4197add7d54a341cca6e', N'Api-key of the CTX server')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'SpeexQuality', N'KIOSK', N'4', N'Speex quality parameter. Integer from 0 to 10. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'SpeexQuality', N'PLATFORM', N'4', N'Speex quality parameter. Integer from 0 to 10. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TheoraBitrate', N'KIOSK', N'0', N'Theora bitrate from 45000 to 2000000. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TheoraBitrate', N'PLATFORM', N'0', N'Theora bitrate from 45000 to 2000000. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TheoraKeyframe', N'KIOSK', N'5', N'Key frame frequency. 0 - Every frame is key frame. 1 - Every second frame is key frame. 2 - Every 4th frame is key frame. 3 - Every 8th frame is key frame. 4 - Every 16th frame is key frame. 5 - Every 32th frame is key frame. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TheoraKeyframe', N'PLATFORM', N'5', N'Key frame frequency. 0 - Every frame is key frame. 1 - Every second frame is key frame. 2 - Every 4th frame is key frame. 3 - Every 8th frame is key frame. 4 - Every 16th frame is key frame. 5 - Every 32th frame is key frame. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TheoraQuality', N'KIOSK', N'40', N'Theora quality parameter. Integer from 0 to 63. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TheoraQuality', N'PLATFORM', N'40', N'Theora quality parameter. Integer from 0 to 63. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'TimerSpan', N'CTX_SERVER', N'500', N'Milliseconds between screen capture operations.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoDeviceID', N'KIOSK', N'0', N'Video capture device number.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoDeviceID', N'PLATFORM', N'0', N'Video capture device number.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoHeight', N'KIOSK', N'240', N'Camera should support given resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoHeight', N'PLATFORM', N'240', N'Camera should support given resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoTimePerFrame', N'KIOSK', N'10000000', N'Time by frame. 10000000=1fps, 2000000=5fps, 666666=15fps, etc. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoTimePerFrame', N'PLATFORM', N'10000000', N'Time by frame. 10000000=1fps, 2000000=5fps, 666666=15fps, etc. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoViewMethod', N'KIOSK', N'7', N'Drawing mode. 0 - Scroll. 1 - Scale. 2 - Scale HalfTone. 3 - Scale ColorOnColor. 4 - Scale GdiPlus. 5 - Scale GdiPlus Default. 6 - Scale GdiPlus LowQuality. 7 - Scale GdiPlus HighQuality. 8 - Scale GdiPlus Bilinear. 9 - Scale GdiPlus Bicubic. 10 - Scale GdiPlus NearestNeighbor. 11 - Scale GdiPlus HighQualityBilinear. 12 - Scale GdiPlus HighQualityBicubic. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoViewMethod', N'PLATFORM', N'7', N'Drawing mode. 0 - Scroll. 1 - Scale. 2 - Scale HalfTone. 3 - Scale ColorOnColor. 4 - Scale GdiPlus. 5 - Scale GdiPlus Default. 6 - Scale GdiPlus LowQuality. 7 - Scale GdiPlus HighQuality. 8 - Scale GdiPlus Bilinear. 9 - Scale GdiPlus Bicubic. 10 - Scale GdiPlus NearestNeighbor. 11 - Scale GdiPlus HighQualityBilinear. 12 - Scale GdiPlus HighQualityBicubic. ')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoWidth', N'KIOSK', N'320', N'Camera should support given resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'VideoWidth', N'PLATFORM', N'320', N'Camera should support given resolution.')
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'UrlIndex', N'CTX_SERVER', N'http://webdemo.ucentrik.com/index/IndexServer.svc', N'Platform and Kiosk use this url to access index server.')
/****** Object:  Table [dbo].[uc_question]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_question] ON
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'Comments', 1, CAST(0x00009D45011D40BB AS DateTime), NULL, NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, N'Overall experience', 3, CAST(0x00009D45011D4F11 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, N'Would you reccomend that to friend?', 2, CAST(0x00009D45011D6652 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_question] OFF
/****** Object:  Table [dbo].[uc_user]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_user] ON
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (1, NEWID(), N'Demo', N'Kiosk', N'kiosk', N'BOSGuVCn6dbCbP2qxlkvYQ==', N'', 3, N'Eastern Standard Time', 0, 0, NULL, GETUTCDATE(), NULL, NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (2, NEWID(), N'Agent', N'One', N'Agent1', N'vZTG0ZnkOvoX9uYTyElzmA==', N'', 2, N'Eastern Standard Time', 0, 0, NULL, GETUTCDATE(), NULL, NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (3, NEWID(), N'Agent', N'Two', N'Agent2', N'7/WO3NHyzkY9Bgh8/rytPA==', N'', 2, N'Eastern Standard Time', 0, 0, NULL, GETUTCDATE(), NULL, NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (4, NEWID(), N'Agent', N'Three', N'Agent3', N'qzMfwVYMFgIampxexRcj3A==', N'', 2, N'Eastern Standard Time', 0, 0, NULL, GETUTCDATE(), NULL, NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (5, NEWID(), N'Administrator', N'One', N'Admin', N'+reiDxgKewV4w8HkwJLddwuOZOX+YNY8IZ51GPNOb8M=', N'', 1, N'Eastern Standard Time', 0, 0, NULL, GETUTCDATE(), NULL, NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (6, NEWID(), N'Supervisor', N'One', N'Super', N'o30hFr6hCz5wJZzqre+GMg==', N'', 5, N'Eastern Standard Time', 0, 0, NULL, GETUTCDATE(), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[uc_user] OFF
/****** Object:  Table [dbo].[uc_survey_question]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_survey_question] ([survey_id], [question_id]) VALUES (1, 1)
INSERT [dbo].[uc_survey_question] ([survey_id], [question_id]) VALUES (1, 2)
INSERT [dbo].[uc_survey_question] ([survey_id], [question_id]) VALUES (1, 3)
/****** Object:  Table [dbo].[uc_agent]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_agent] ON
INSERT [dbo].[uc_agent] ([agent_id], [agent_guid], [user_id], [first_name], [last_name], [email], [phone], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, NEWID(), 2, N'Agent', N'One', N'', N'', 1, GETUTCDATE(), NULL, NULL, 0)
INSERT [dbo].[uc_agent] ([agent_id], [agent_guid], [user_id], [first_name], [last_name], [email], [phone], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, NEWID(), 3, N'Agent', N'Two', N'', N'', 1, GETUTCDATE(), NULL, NULL, 0)
INSERT [dbo].[uc_agent] ([agent_id], [agent_guid], [user_id], [first_name], [last_name], [email], [phone], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, NEWID(), 4, N'Agent', N'Three', N'', N'', 1, GETUTCDATE(), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_agent] OFF
/****** Object:  Table [dbo].[uc_facility]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_facility] ON
INSERT [dbo].[uc_facility] ([facility_id], [active], [facility_guid], [ip_address], [web_referrer], [user_id], [facility_name], [address], [phone], [survey_id], [agent_id], [status], [status_stamp], [command], [command_stamp], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, 1, NEWID(), NULL, NULL, 1, N'Demo Kiosk', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, GETUTCDATE(), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_facility] OFF
/****** Object:  Table [dbo].[uc_group_facility]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (1, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (2, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (3, 1)
/****** Object:  Table [dbo].[uc_group_agent]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (1, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (2, 2)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (3, 3)
/****** Object:  Table [dbo].[uc_call]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_agent_skill]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_agent_skill] ([agent_id], [skill_id]) VALUES (1, 1)
INSERT [dbo].[uc_agent_skill] ([agent_id], [skill_id]) VALUES (2, 2)
INSERT [dbo].[uc_agent_skill] ([agent_id], [skill_id]) VALUES (3, 3)
/****** Object:  Table [dbo].[uc_agent_language]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (1, 1)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (1, 2)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (1, 3)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (2, 1)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (2, 2)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (2, 3)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (3, 1)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (3, 2)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (3, 3)
/****** Object:  Table [dbo].[uc_contact_state]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_contact_listing]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_survey_response]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_incident_transfer]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_incident_note]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_pool]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_log]    Script Date: 07/14/2011 12:19:41 ******/
