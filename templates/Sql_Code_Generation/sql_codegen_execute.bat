@echo off

REM
REM	Copyright �2002-2014 Daniel Bullington (dpbullington@gmail.com)
REM	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
REM

set TEXTMETAL_EXE=..\..\src\TextMetal.HostImpl.ConsoleTool\bin\Debug\TextMetal.exe

SET SRC_DIR=..\..\src
SET BUILD_FLAVOR_DIR=Debug
SET BUILD_TOOL_CFG=Debug

set PACKAGE_DIR=.\output
set PACKAGE_DIR_EXISTS=%PACKAGE_DIR%\nul

set ADO_NET_CONNECTION_STRING=Server=(local);User ID=textmetal_mssql_dev_login;Password=LrJGmP6UfW8TEp7x3wWhECUYULE6zzMcWQ03R6UxeB4xzVmnq5S4Lx0vApegZVH;Database=textmetal_ods_dev
set HISTORY_SCHEMA_NAME=history
set OBFUSCATION_SCHEMA_NAME=ObfuConf
set OBFUSCATION_DESTINATION_DATABASE_NAME=Ox_textmetal_ods_dev
set OBFUSCATION_CONFIG_FILE_PATH=textmetal_ods_dev_obfu_cfg.json

:pkgDir

IF NOT EXIST %PACKAGE_DIR_EXISTS% GOTO noPkgDir
goto delPkgDir

:noPkgDir
@echo Creating output directory...
mkdir "%PACKAGE_DIR%"
IF %ERRORLEVEL% NEQ 0 goto pkgError
goto pkgBuild

:delPkgDir
@echo Cleaning output directory...
del "%PACKAGE_DIR%\*.*" /Q /S
rem IF %ERRORLEVEL% NEQ 0 goto pkgError
goto pkgBuild


:pkgBuild

copy "%SRC_DIR%\TextMetal.Common.SqlServerClr\bin\%BUILD_FLAVOR_DIR%\TextMetal.Common.SqlServerClr.dll" "%PACKAGE_DIR%\."
IF %ERRORLEVEL% NEQ 0 goto pkgError

powershell -command "'0x' + [System.BitConverter]::ToString([System.IO.File]::ReadAllBytes('..\..\src\TextMetal.Common.SqlServerClr\bin\Debug\TextMetal.Common.SqlServerClr.dll')).Replace('-', '')" > "%PACKAGE_DIR%\TextMetal.Common.SqlServerClr.dll.txt"
IF %ERRORLEVEL% NEQ 0 goto pkgError

echo *** sql_codegen_execute ***
"%TEXTMETAL_EXE%" ^
	-templatefile:"master_template.xml" ^
	-sourcefile:"%ADO_NET_CONNECTION_STRING%" ^
	-basedir:"%PACKAGE_DIR%" ^
	-sourcestrategy:"TextMetal.Framework.SourceModel.DatabaseSchema.Sql.SqlSchemaSourceStrategy, TextMetal.Framework.SourceModel" ^
	-strict:"true" ^
	-property:"HistorySchemaName=%HISTORY_SCHEMA_NAME%" ^
	-property:"ObfuscationSchemaName=%OBFUSCATION_SCHEMA_NAME%" ^
	-property:"ObfuscationDestinationDatabaseName=%OBFUSCATION_DESTINATION_DATABASE_NAME%" ^
	-property:"ObfuscationConfigFilePath=%OBFUSCATION_CONFIG_FILE_PATH%" ^
	-property:"ConnectionType=System.Data.SqlClient.SqlConnection, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" ^
	-property:"DataSourceTag=net.sqlserver"
IF %ERRORLEVEL% NEQ 0 goto pkgError


goto pkgSuccess


:pkgError
echo An error occured.
pause > nul
goto :eof

:pkgSuccess
echo Completed successfully.
goto :eof
