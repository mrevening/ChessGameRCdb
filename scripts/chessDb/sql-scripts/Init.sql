 IF DB_ID('$(DatabaseName)') IS NOT NULL
 BEGIN
    DROP DATABASE [$(DatabaseName)];
END
 CREATE DATABASE [$(DatabaseName)]
 GO