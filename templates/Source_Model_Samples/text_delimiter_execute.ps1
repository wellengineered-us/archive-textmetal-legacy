#
#	Copyright �2002-2014 Daniel Bullington (dpbullington@gmail.com)
#	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
#

cls
$root = [System.Environment]::CurrentDirectory

$src_dir = "..\..\src"
$build_flavor_dir = "Debug"
$template_dir = "."
$source_dir = "."

$textmetal_exe = "$src_dir\TextMetal.HostImpl.ConsoleTool\bin\$build_flavor_dir\TextMetal.exe"

$template_file = "$template_dir\text_delimiter_template.xml"
$source_file = "$source_dir\text_delimiter_source.txt"
$base_dir = ".\output"
$source_strategy = "TextMetal.Framework.SourceModel.Primative.TextSourceStrategy, TextMetal.Framework.SourceModel"
$strict = $true
$property_first_record_is_header = $true
$property_field_delimiter = "\\t"
$property_record_delimiter = "\\r\\n"

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
	"-basedir:$base_dir",
	"-sourcestrategy:$source_strategy",
	"-strict:$strict",
	"-property:FirstRecordIsHeader=$property_first_record_is_header",
	"-property:FieldDelimiter=$property_field_delimiter",
	"-property:RecordDelimiter=$property_record_delimiter")

&"$textmetal_exe" $argz

if (!($LastExitCode -eq $null -or $LastExitCode -eq 0))
{ echo "An error occurred during the operation."; return; }

echo "The operation completed successfully."