/****** Object:  Table [dbo].[uc_group]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_group] ON
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'f971eeb7-22d3-429b-8d8c-0244fabdf8a0', N'DCF_MOD_QAQC', NULL, 0, CAST(0x00009F7400D04740 AS DateTime), CAST(0x00009F7400D05567 AS DateTime), NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, N'36518fd2-eaab-4aae-afd4-43a1c39d859f', N'DCF_MOD_Tier2 ', NULL, 0, CAST(0x00009F7400D05916 AS DateTime), CAST(0x00009F7400D05A14 AS DateTime), NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, N'96b9db6f-7217-4e56-98fe-46d3a64a6e27', N'DCF_MOD_Tier2_French ', NULL, 0, CAST(0x00009F7400D065DD AS DateTime), CAST(0x00009F7400D066C4 AS DateTime), NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (4, N'c465dd4b-2124-4e40-9c8e-0cbaf8f6808b', N'DCF_MOD_Tier3 ', NULL, 0, CAST(0x00009F7400D06E99 AS DateTime), CAST(0x00009F7400D06FC8 AS DateTime), NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (5, N'd3491bb9-4af6-4ea0-bbe5-69795271571c', N'DCF_MOD_Tier3_French ', NULL, 0, CAST(0x00009F7400D077C7 AS DateTime), CAST(0x00009F7400D07947 AS DateTime), NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (6, N'19589f36-d196-487a-ab73-dd77269ab9dd', N'DCF_MOD_Training ', NULL, 0, CAST(0x00009F7400D0820E AS DateTime), CAST(0x00009F7400D082E5 AS DateTime), NULL, 0)
INSERT [dbo].[uc_group] ([group_id], [group_guid], [group_name], [description], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (7, N'4a996a86-3623-4459-b1d4-861f56743423', N'DCF_MOD_Training_French ', NULL, 0, CAST(0x00009F7400D08C84 AS DateTime), CAST(0x00009F7400D08DC3 AS DateTime), NULL, 0)
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
INSERT [dbo].[uc_language] ([language_id], [language_name]) VALUES (2, N'German')
INSERT [dbo].[uc_language] ([language_id], [language_name]) VALUES (3, N'Russian')
INSERT [dbo].[uc_language] ([language_id], [language_name]) VALUES (4, N'Ukrainian')
SET IDENTITY_INSERT [dbo].[uc_language] OFF
/****** Object:  Table [dbo].[uc_survey]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_survey] ON
INSERT [dbo].[uc_survey] ([survey_id], [survey_guid], [survey_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'6e848f07-6208-4c3d-823a-70cc46845b51', N'CSS', CAST(0x00009D45010C5259 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_survey] OFF
/****** Object:  Table [dbo].[uc_skill]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_skill] ON
INSERT [dbo].[uc_skill] ([skill_id], [skill_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'ASP.NET', CAST(0x000007D200000000 AS DateTime), CAST(0x00009F1D00CD26D8 AS DateTime), NULL, 0)
INSERT [dbo].[uc_skill] ([skill_id], [skill_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, N'PHP', CAST(0x000007D200000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[uc_skill] ([skill_id], [skill_name], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, N'COM', CAST(0x000007D200000000 AS DateTime), NULL, NULL, 0)
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
INSERT [dbo].[uc_settings] ([name], [category], [value], [tooltip]) VALUES (N'Server', N'CTX_SERVER', N'184.173.150.210:85:447:85', N'IP_address:TCP_Port:SSL_Port:HTTP_Port')
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
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'AAA', 2, CAST(0x00009D45010F2615 AS DateTime), CAST(0x00009D4501107393 AS DateTime), CAST(0x00009D450111544E AS DateTime), 1)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (2, N'TEST1', 2, CAST(0x00009D45011B517A AS DateTime), CAST(0x00009D45011B60FD AS DateTime), CAST(0x00009D45011D25C2 AS DateTime), 1)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (3, N'dfghdfg', 1, CAST(0x00009D45011D20DE AS DateTime), NULL, CAST(0x00009D45011D26DB AS DateTime), 1)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (4, N'dg', 1, CAST(0x00009D45011D2C5E AS DateTime), NULL, CAST(0x00009D45011D2E6B AS DateTime), 1)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (5, N'Comments', 1, CAST(0x00009D45011D40BB AS DateTime), NULL, NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (6, N'Overall experience', 3, CAST(0x00009D45011D4F11 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (7, N'Would you reccomend that to friend?', 2, CAST(0x00009D45011D6652 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (8, N'_TEST QUESTION #1', 1, CAST(0x00009D4F014155F8 AS DateTime), CAST(0x00009D4F01460354 AS DateTime), NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (9, N'_TEST QUESTION #2', 2, CAST(0x00009D4F01415D12 AS DateTime), CAST(0x00009D4F01460AB9 AS DateTime), NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (10, N'_TEST QUESTION #3', 3, CAST(0x00009D4F014164AC AS DateTime), CAST(0x00009D4F01461164 AS DateTime), NULL, 0)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (11, N'qwerty', 1, CAST(0x00009D5E013828B2 AS DateTime), NULL, CAST(0x00009D5E01382C7C AS DateTime), 1)
INSERT [dbo].[uc_question] ([question_id], [question_text], [type_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (12, N'11111', 2, CAST(0x00009E2B013BE252 AS DateTime), NULL, CAST(0x00009E2B013BE62F AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[uc_question] OFF
/****** Object:  Table [dbo].[uc_user]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_user] ON
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (1, N'de3d7627-b1df-42af-b887-c7daa25b93ea', N'Top', N'Administrator', N'administrator', N'Vrdw2WXDNZcRWWGOQjCgDQ==', N'', 1, N'Eastern Standard Time', 31, 0, CAST(0x00009F1E00B7CD31 AS DateTime), CAST(0x00009D4501094DDF AS DateTime), CAST(0x00009DDB012A1205 AS DateTime), NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (2, N'dcaef347-0b5b-45a3-b700-76760d167031', N'Andrew', N'Dallas', N'agent', N'Pg+U81hnUoKNSFbzEIUrgg==', N'', 2, N'Eastern Standard Time', 1222, 0, CAST(0x00009F2000978EF2 AS DateTime), CAST(0x00009D450109831A AS DateTime), CAST(0x00009F1200702A58 AS DateTime), NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (4, N'ca1258cb-0f74-4284-a8cb-8a41e8ec278e', N'Demo', N'Kiosk', N'kiosk', N'ktP1OTwCkKn5tV9Hjje3lA==', N'', 3, N'Eastern Standard Time', 656390, 0, CAST(0x00009F20008EA039 AS DateTime), CAST(0x00009D450109BD38 AS DateTime), CAST(0x00009DDB012D62BF AS DateTime), NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (6, N'58ebcab5-7d52-483b-94ba-ecedaff927c6', N'Admin', N'Admin', N'admin', N'hX1V04AhuZMB8A1MpX1uuQ==', N'', 1, N'Eastern Standard Time', 552, 0, CAST(0x00009F2000924631 AS DateTime), CAST(0x00009D45010AF703 AS DateTime), CAST(0x00009E470166AE66 AS DateTime), NULL, 0, 0)
INSERT [dbo].[uc_user] ([user_id], [user_guid], [first_name], [last_name], [username], [password], [password_salt], [user_role_id], [time_zone], [logins], [login_attempts], [date_last_login], [date_created], [date_updated], [date_deleted], [is_locked_out], [is_deleted]) VALUES (7, N'23d80749-9317-4474-909f-af4ff7aaa4fe', N'Super', N'Demo', N'super', N'Zkc1ndiMZvnfxWW5wNRPOQ==', N'', 5, N'Eastern Standard Time', 53, 0, CAST(0x00009F4300B92EC3 AS DateTime), CAST(0x00009F2500D3A555 AS DateTime), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[uc_user] OFF
/****** Object:  Table [dbo].[uc_survey_question]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_survey_question] ([survey_id], [question_id]) VALUES (1, 5)
INSERT [dbo].[uc_survey_question] ([survey_id], [question_id]) VALUES (1, 6)
INSERT [dbo].[uc_survey_question] ([survey_id], [question_id]) VALUES (1, 7)
/****** Object:  Table [dbo].[uc_agent]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_agent] ON
INSERT [dbo].[uc_agent] ([agent_id], [agent_guid], [user_id], [first_name], [last_name], [email], [phone], [public_enabled], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, N'9180840e-2cb7-45f0-83ff-0ce9fc311c4a', 2, N'Andrew', N'Dallas', N'noname@nomail.com', N'416-504-0000', 1, CAST(0x00009D45010A8701 AS DateTime), CAST(0x00009E160154ED27 AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_agent] OFF
/****** Object:  Table [dbo].[uc_facility]    Script Date: 07/14/2011 12:19:41 ******/
SET IDENTITY_INSERT [dbo].[uc_facility] ON
INSERT [dbo].[uc_facility] ([facility_id], [active], [facility_guid], [ip_address], [user_id], [facility_name], [address], [phone], [survey_id], [date_created], [date_updated], [date_deleted], [is_deleted]) VALUES (1, 1, N'c37915be-85eb-4768-8ec7-724219d898b2', NULL, 4, N'Demo Kiosk', N'345 Adelaide', N'416-504-0000', 1, CAST(0x00009D45010A4AED AS DateTime), CAST(0x00009E30013BC0DD AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[uc_facility] OFF
SET IDENTITY_INSERT [dbo].[uc_incident] OFF
/****** Object:  Table [dbo].[uc_group_facility]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (1, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (2, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (3, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (4, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (5, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (6, 1)
INSERT [dbo].[uc_group_facility] ([group_id], [facility_id]) VALUES (7, 1)
/****** Object:  Table [dbo].[uc_group_agent]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (1, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (2, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (3, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (4, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (5, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (6, 1)
INSERT [dbo].[uc_group_agent] ([group_id], [agent_id]) VALUES (7, 1)
/****** Object:  Table [dbo].[uc_call]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_agent_skill]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_agent_skill] ([agent_id], [skill_id]) VALUES (1, 1)
INSERT [dbo].[uc_agent_skill] ([agent_id], [skill_id]) VALUES (1, 3)
INSERT [dbo].[uc_agent_skill] ([agent_id], [skill_id]) VALUES (1, 2)
/****** Object:  Table [dbo].[uc_agent_language]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (1, 1)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (1, 2)
INSERT [dbo].[uc_agent_language] ([agent_id], [language_id]) VALUES (1, 3)
/****** Object:  Table [dbo].[uc_contact_state]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_contact_listing]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_survey_response]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_incident_transfer]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_incident_note]    Script Date: 07/14/2011 12:19:41 ******/
/****** Object:  Table [dbo].[uc_pool]    Script Date: 07/14/2011 12:19:41 ******/
INSERT [dbo].[uc_pool] ([agent_id], [is_available], [is_busy], [last_call_time], [incident_id], [date_created], [date_accessed], [date_reserved]) VALUES (1, 0, 0, CAST(0x00009F2000981BD7 AS DateTime), NULL, CAST(0x00009F20008EB9B1 AS DateTime), CAST(0x00009F2000993F9D AS DateTime), CAST(0x00009F2000981BCA AS DateTime))
/****** Object:  Table [dbo].[uc_log]    Script Date: 07/14/2011 12:19:41 ******/
