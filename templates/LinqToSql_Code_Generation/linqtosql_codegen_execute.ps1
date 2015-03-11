#
#	Copyright �2002-2015 Daniel Bullington (dpbullington@gmail.com)
#	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
#

cls
$root = [System.Environment]::CurrentDirectory

$src_dir = "..\..\src"
$build_flavor_dir = "Debug"
$template_dir = "."

$textmetal_exe = "$src_dir\TextMetal.ConsoleTool\bin\$build_flavor_dir\TextMetal.exe"

$template_file = "$template_dir\master_template.xml"
$source_file = "Server=(local);User ID=textmetal_sample_mssql_lcl_login;PWD=LrJGmP6UfW8TEp7x3wWhECUYULE6zzMcWQ03R6UxeB4xzVmnq5S4Lx0vApegZVH;Database=textmetal_sample"
$base_dir = ".\output"
$source_strategy = "TextMetal.Framework.Source.DatabaseSchema.Sql.SqlSchemaSourceStrategy, TextMetal.Framework"
$strict = $true
$property_connection_type = "System.Data.SqlClient.SqlConnection, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
$property_data_source_tag = "net.sqlserver"
$property_module_name = "TextMetal.Sample.DomainModel"
$property_clr_namespace = "TextMetal.Sample.DomainModel"
$property_model_clr_super_type = "ModelObject"

$lib_dir = "..\..\lib"

$base_src_dir = "$base_dir\src"
$base_lib_dir = "$base_dir\lib"

$sn_exe = "C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\sn.exe"
$snk_file = "$base_src_dir\$property_module_name.snk"

$sql_metal_exe = "C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\SqlMetal.exe"

$l2s_dir = "$base_src_dir\$property_module_name\L2S"
$l2s_clr_namespace = "$property_clr_namespace.L2S"
$l2s_data_context_name = "TextMetalDataContext"
$l2s_dbml_file = "$l2s_dir\$l2s_data_context_name.dbml"
$l2s_designer_cs_file = "$l2s_dir\$l2s_data_context_name.designer.cs"

echo "The operation is starting..."

if ((Test-Path -Path $base_dir))
{
	Remove-Item $base_dir -recurse

	if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
	{ echo "An error occurred during the operation."; return; }
}

New-Item -ItemType directory -Path $base_dir

if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
{ echo "An error occurred during the operation."; return; }

$argz = @("-templatefile:$template_file",
	"-sourcefile:$source_file",
	"-basedir:$base_src_dir",
	"-sourcestrategy:$source_strategy",
	"-strict:$strict",
	"-property:ConnectionType=$property_connection_type",
	"-property:DataSourceTag=$property_data_source_tag",
	"-property:ModuleName=$property_module_name",
	"-property:ClrNamespace=$property_clr_namespace",
	"-property:ModelClrSuperType=$property_model_clr_super_type",
	"-property:LinqToSqlDataContextRootNamespace=$l2s_clr_namespace",
	"-property:LinqToSqlTargetDataContextName=$l2s_data_context_name")

&"$textmetal_exe" $argz

if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
{ echo "An error occurred during the operation."; return; }

$argz = @("-k",
	"$snk_file")

&"$sn_exe" $argz

if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
{ echo "An error occurred during the operation."; return; }


New-Item -ItemType directory -Path $base_lib_dir
New-Item -ItemType directory -Path "$base_lib_dir\TextMetal"
New-Item -ItemType directory -Path "$base_lib_dir\IronRuby"
New-Item -ItemType directory -Path "$base_lib_dir\Sqlite"
New-Item -ItemType directory -Path "$base_lib_dir\Sqlite\x64"
New-Item -ItemType directory -Path "$base_lib_dir\Sqlite\x86"

Copy-Item "$lib_dir\IronRuby\*.*" "$base_lib_dir\IronRuby\."
Copy-Item "$lib_dir\SQLite\x64\*.*" "$base_lib_dir\SQLite\x64\."
Copy-Item "$lib_dir\SQLite\x86\*.*" "$base_lib_dir\SQLite\x86\."

Copy-Item "$src_dir\TextMetal.Common.Core\bin\$build_flavor_dir\TextMetal.Common.Core.dll" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Core\bin\$build_flavor_dir\TextMetal.Common.Core.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Core\bin\$build_flavor_dir\TextMetal.Common.Core.pdb" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Data\bin\$build_flavor_dir\TextMetal.Common.Data.dll" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Data\bin\$build_flavor_dir\TextMetal.Common.Data.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Data\bin\$build_flavor_dir\TextMetal.Common.Data.pdb" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Solder\bin\$build_flavor_dir\TextMetal.Common.Solder.dll" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Solder\bin\$build_flavor_dir\TextMetal.Common.Solder.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Common.Solder\bin\$build_flavor_dir\TextMetal.Common.Solder.pdb" "$base_lib_dir\TextMetal\."

Copy-Item "$src_dir\TextMetal.Imports\bin\$build_flavor_dir\TextMetal.Imports.dll" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports\bin\$build_flavor_dir\TextMetal.Imports.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports\bin\$build_flavor_dir\TextMetal.Imports.pdb" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports.nunit.console.exe\bin\$build_flavor_dir\TextMetal.Imports.nunit.console.exe" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports.nunit.console.exe\bin\$build_flavor_dir\TextMetal.Imports.nunit.console.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports.nunit.console.exe\bin\$build_flavor_dir\TextMetal.Imports.nunit.console.pdb" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports.nunit.gui.exe\bin\$build_flavor_dir\TextMetal.Imports.nunit.gui.exe" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports.nunit.gui.exe\bin\$build_flavor_dir\TextMetal.Imports.nunit.gui.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.Imports.nunit.gui.exe\bin\$build_flavor_dir\TextMetal.Imports.nunit.gui.pdb" "$base_lib_dir\TextMetal\."

Copy-Item "$src_dir\TextMetal.TestFramework\bin\$build_flavor_dir\TextMetal.TestFramework.dll" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.TestFramework\bin\$build_flavor_dir\TextMetal.TestFramework.xml" "$base_lib_dir\TextMetal\."
Copy-Item "$src_dir\TextMetal.TestFramework\bin\$build_flavor_dir\TextMetal.TestFramework.pdb" "$base_lib_dir\TextMetal\."


New-Item -ItemType directory -Path "$l2s_dir"

$argz = @("/views",
	"/sprocs",
	"/language:C#",
	"/pluralize",
	"/namespace:$l2s_clr_namespace",
	"/context:$l2s_data_context_name",
	"/dbml:$l2s_dbml_file",
	"/conn:$source_file")

&"$sql_metal_exe" $argz > "$base_dir\SqlMetal_LOG.txt"

if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
{ echo "An error occurred during the operation."; return; }




$xd = New-Object System.Xml.XmlDocument
$xd.Load($l2s_dbml_file)
$xa_list = $xd.SelectNodes("//@CanBeNull")

if ($xa_list -ne $null)
{
	$xa_list.Count

	foreach ($xa_item in $xa_list)
	{
		$xa_item.Value = "true"
	}
}
else
{
	echo "Warning: no XPATH results."
}

$xd.Save($l2s_dbml_file)




$argz = @("/language:C#",
	"/code:$l2s_designer_cs_file",
	"$l2s_dbml_file")

&"$sql_metal_exe" $argz >> "$base_dir\SqlMetal_LOG.txt"

if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
{ echo "An error occurred during the operation."; return; }

echo "The operation completed successfully."