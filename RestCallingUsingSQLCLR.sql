--Alter the database(use your database instead of master) to set the trustworthy to ON, 
-- this is not recommended procedure, It is better to instead sign the assembly with a certificate.
ALTER DATABASE master SET TRUSTWORTHY ON

CREATE ASSEMBLY SPAssembly
FROM 'D:\StoredProcedures.dll'
WITH PERMISSION_SET = UNSAFE;



--Create procedure to the methods in the .cs file 
CREATE PROCEDURE [dbo].[SampleWSGet]
      @weburl [nvarchar](4000),
      @returnval [nvarchar](2000) OUTPUT


WITH EXECUTE AS CALLER
AS
--Makes sure that you give assemblyName.className
EXTERNAL NAME SPAssembly.[SampleCLR.StoredProcedures].SampleWSGet

GO


CREATE PROCEDURE [dbo].[SampleWSPost]
      @weburl [nvarchar](4000),
      @returnval [nvarchar](2000) OUTPUT

WITH EXECUTE AS CALLER
AS
--Makes sure that you give assemblyName.className
EXTERNAL NAME [SPAssembly].[SampleCLR.StoredProcedures].[SampleWSPost]



---Enable CLR, if its not enabled --------------

EXEC sp_configure 'clr enabled', 1
 go
 RECONFIGURE
 go
EXEC sp_configure 'clr enabled'
 go


------Execute the procedure ----------

Declare @Response NVARCHAR(2000)
EXECUTE SampleWSGet 'https://jsonplaceholder.typicode.com/posts/1',@Response OUT
SELECT @Response

