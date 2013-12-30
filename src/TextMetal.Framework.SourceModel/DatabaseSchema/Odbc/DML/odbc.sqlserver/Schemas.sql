﻿/*
	Copyright ©2002-2014 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

-- schemas
select
	cast(null as int) as ObjectId,
    sys_s.name as SchemaName	
from
    sys.schemas sys_s
order by
	sys_s.name asc