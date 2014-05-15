﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

-- database
SELECT
	sys_d.[database_id] as [DatabaseId],
	sys_d.[name] as [DatabaseName]
	
	/*sys_d.[source_database_id] AS [source_database_id],
	sys_d.[owner_sid] AS [owner_sid],
	sys_d.[create_date] AS [create_date],
	sys_d.[compatibility_level] AS [compatibility_level],
	sys_d.[collation_name] AS [collation_name],
	sys_d.[user_access] AS [user_access],
	sys_d.[user_access_desc] AS [user_access_desc],
	sys_d.[is_read_only] AS [is_read_only],
	sys_d.[is_auto_close_on] AS [is_auto_close_on],
	sys_d.[is_auto_shrink_on] AS [is_auto_shrink_on],
	sys_d.[state] AS [state],
	sys_d.[state_desc] AS [state_desc],
	sys_d.[is_in_standby] AS [is_in_standby],
	sys_d.[is_cleanly_shutdown] AS [is_cleanly_shutdown],
	sys_d.[is_supplemental_logging_enabled] AS [is_supplemental_logging_enabled],
	sys_d.[snapshot_isolation_state] AS [snapshot_isolation_state],
	sys_d.[snapshot_isolation_state_desc] AS [snapshot_isolation_state_desc],
	sys_d.[is_read_committed_snapshot_on] AS [is_read_committed_snapshot_on],
	sys_d.[recovery_model] AS [recovery_model],
	sys_d.[recovery_model_desc] AS [recovery_model_desc],
	sys_d.[page_verify_option] AS [page_verify_option],
	sys_d.[page_verify_option_desc] AS [page_verify_option_desc],
	sys_d.[is_auto_create_stats_on] AS [is_auto_create_stats_on],
	sys_d.[is_auto_update_stats_on] AS [is_auto_update_stats_on],
	sys_d.[is_auto_update_stats_async_on] AS [is_auto_update_stats_async_on],
	sys_d.[is_ansi_null_default_on] AS [is_ansi_null_default_on],
	sys_d.[is_ansi_nulls_on] AS [is_ansi_nulls_on],
	sys_d.[is_ansi_padding_on] AS [is_ansi_padding_on],
	sys_d.[is_ansi_warnings_on] AS [is_ansi_warnings_on],
	sys_d.[is_arithabort_on] AS [is_arithabort_on],
	sys_d.[is_concat_null_yields_null_on] AS [is_concat_null_yields_null_on],
	sys_d.[is_numeric_roundabort_on] AS [is_numeric_roundabort_on],
	sys_d.[is_quoted_identifier_on] AS [is_quoted_identifier_on],
	sys_d.[is_recursive_triggers_on] AS [is_recursive_triggers_on],
	sys_d.[is_cursor_close_on_commit_on] AS [is_cursor_close_on_commit_on],
	sys_d.[is_local_cursor_default] AS [is_local_cursor_default],
	sys_d.[is_fulltext_enabled] AS [is_fulltext_enabled],
	sys_d.[is_trustworthy_on] AS [is_trustworthy_on],
	sys_d.[is_db_chaining_on] AS [is_db_chaining_on],
	sys_d.[is_parameterization_forced] AS [is_parameterization_forced],
	sys_d.[is_master_key_encrypted_by_server] AS [is_master_key_encrypted_by_server],
	sys_d.[is_published] AS [is_published],
	sys_d.[is_subscribed] AS [is_subscribed],
	sys_d.[is_merge_published] AS [is_merge_published],
	sys_d.[is_distributor] AS [is_distributor],
	sys_d.[is_sync_with_backup] AS [is_sync_with_backup],
	sys_d.[service_broker_guid] AS [service_broker_guid],
	sys_d.[is_broker_enabled] AS [is_broker_enabled],
	sys_d.[log_reuse_wait] AS [log_reuse_wait],
	sys_d.[log_reuse_wait_desc] AS [log_reuse_wait_desc],
	sys_d.[is_date_correlation_on] AS [is_date_correlation_on],
	sys_d.[is_cdc_enabled] AS [is_cdc_enabled],
	sys_d.[is_encrypted] AS [is_encrypted],
	sys_d.[is_honor_broker_priority_on] AS [is_honor_broker_priority_on],
	sys_d.[replica_id] AS [replica_id],
	sys_d.[group_database_id] AS [group_database_id],
	sys_d.[default_language_lcid] AS [default_language_lcid],
	sys_d.[default_language_name] AS [default_language_name],
	sys_d.[default_fulltext_language_lcid] AS [default_fulltext_language_lcid],
	sys_d.[default_fulltext_language_name] AS [default_fulltext_language_name],
	sys_d.[is_nested_triggers_on] AS [is_nested_triggers_on],
	sys_d.[is_transform_noise_words_on] AS [is_transform_noise_words_on],
	sys_d.[two_digit_year_cutoff] AS [two_digit_year_cutoff],
	sys_d.[containment] AS [containment],
	sys_d.[containment_desc] AS [containment_desc],
	sys_d.[target_recovery_time_in_seconds] AS [target_recovery_time_in_seconds]
	--sys_d.[is_federation_member] AS [is_federation_member] --AZURE ONLY*/
FROM
	[sys].[databases] sys_d