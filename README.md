# RESTUsingSQLCLR
Accessing rest url's using sql clr


First, create the .cs file with your functions


Generate the .dll file using the below command in the command prompt


"csc /t:library D:\StoredProcedures.cs"(remove quotes)


To use the above command, find the csc.exe file it should be some where in the location like "C:\Program Files (x86)\Microsoft Web Tools\Packages\Microsoft.Net.Compilers.2.4.0\tools\csc.exe" always choose higher version compiler


After executing the command you will be able to see .dll in the same folder of .cs


Now, go to sql server management studio and make sure that your user have system admin permissions


Next, execute the sql file "RestCallingUsingSQLCLR"

Execute each and every sql query step by step.

