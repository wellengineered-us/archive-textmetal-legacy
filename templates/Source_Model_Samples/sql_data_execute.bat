@echo off

REM
REM	Copyright �2002-2014 Daniel Bullington (dpbullington@gmail.com)
REM	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
REM

set TEXTMETAL_EXE=..\..\src\TextMetal.HostImpl.ConsoleTool\bin\Debug\TextMetal.exe

echo *** sql_data_execute ***
"%TEXTMETAL_EXE%" ^
	-templatefile:"empty_template.xml" ^
	-sourcefile:"sql_data_source.xml" ^
	-basedir:".\output" ^
	-sourcestrategy:"TextMetal.Framework.SourceModel.Primative.SqlDataSourceStrategy, TextMetal.Framework.SourceModel" ^
	-strict:"true" ^
	-debug:"false" ^
	-property:"ConnectionType=System.Data.SqlClient.SqlConnection, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" ^
	-property:"ConnectionString=Server=(local);User ID=textmetal_mssql_dev_login;Password=LrJGmP6UfW8TEp7x3wWhECUYULE6zzMcWQ03R6UxeB4xzVmnq5S4Lx0vApegZVH;Database=textmetal_ods_dev" ^
IF %ERRORLEVEL% NEQ 0 goto pkgError

	
goto pkgSuccess


:pkgError
echo An error occured.
pause > nul
goto :eof

:pkgSuccess
echo Completed successfully.
goto :eof
