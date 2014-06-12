﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

-- DDL triggers
SELECT
	sys_o.[object_id] AS [TriggerId],
	sys_o.[name] AS [TriggerName],
	CAST(CASE WHEN sys_tr.[type] = 'TA' THEN 1
		ELSE 0 END AS [bit]) AS [IsClrTrigger],
	sys_tr.[is_disabled] AS [IsTriggerDisabled],
	sys_tr.[is_not_for_replication] AS [IsTriggerNotForReplication],
	sys_tr.[is_instead_of_trigger] AS [IsInsteadOfTrigger]
FROM
	[sys].[triggers] sys_tr
	INNER JOIN [sys].[objects] sys_o ON sys_o.[object_id] = sys_tr.[object_id]
WHERE
	sys_tr.[parent_class] = 0
ORDER BY
	sys_tr.[name] ASC