@echo off

REM Initialize variables
set "server_name="
set "database_name="
set "user_name="
set "password="

REM Parse command-line arguments
:parse_args
IF "%~1"=="" GOTO end_parse_args

IF /I "%~1"=="-S" (
    SET "server_name=%~2"
    SHIFT
) ELSE IF /I "%~1"=="-D" (
    SET "database_name=%~2"
    SHIFT
) ELSE IF /I "%~1"=="-U" (
    SET "user_name=%~2"
    SHIFT
)

SHIFT
GOTO parse_args
:end_parse_args

REM Check if required parameters are provided
IF "%server_name%"=="" (
    echo Error: Server name ^(-S^) is required.
    GOTO usage
)

IF "%database_name%"=="" (
    echo Error: Database name ^(-D^) is required.
    GOTO usage
)

REM If the -U parameter is provided, prompt for the password using -P
IF NOT "%user_name%"=="" (
    SET /P "password=Enter password for user %user_name%: "
)




REM Construct the sqlcmd command string variable without empty variables
set "user-name-password="

REM Add the -U option if username is not empty
if not "%user_name%"=="" set "user-name-password=-U %user_name% -P %password%"


:main_script
set "sqlScripts=Color Column Row FigureType Figure BoardConfiguration BoardConfigurationToFigure Game NotationLog"
set "sqlData=Color Column Row FigureType Figure BoardConfiguration BoardConfigurationToFigure"

sqlcmd -S %server_name% %user-name-password% -v DatabaseName="%database_name%" -i "sql-scripts/Init.sql"
for %%f in (%sqlScripts%) do (
	sqlcmd -S %server_name% %user-name-password% -d %database_name% -i "sql-scripts/%%f.sql"
)

for %%f in (%sqlData%) do (
	sqlcmd -S %server_name% %user-name-password% -d %database_name% -i "sql-data/%%f.sql"
)


GOTO :EOF




:usage
echo.
echo Usage: script_with_parameters.bat -S server_name -D database_name [-U user_name]
echo.
echo   -S     Specifies the SQL Server name.
echo   -D     Specifies the database name.
echo   -U     Specifies the user name (optional). If provided, the script will prompt for the password using -P.
echo.
GOTO :EOF