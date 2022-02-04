# CSharp solution for SDET coding Ttst
Contains a CSHARP solution for the DU SDET Test.

<img src="diagram.png" alt="drawing" width="400"/>

This repo contains a console application, a class library for the engine and some unit tests.

## How to run the console application from command line
1. After building Solution using commad: 
```
dotnet build
```
2. you need to publish the solution :
```
dotnet publish 
```
3. Alternatively from Visual Studio one can set project to Release mode then from Build, Click Publish to folder.
4. To Run the console application, type the example input command: 
Consists of the Dotnet library command, the ConsoleApplication library and then the command input. 

```
dotnet Communicator.dll "Alpha,Bravo
Bravo,Alpha, SAT1
SAT1,Bravo , Charlie
Charlie, SAT1
Delta  ,Zulu
Zulu,Delta, SAT2
SAT2,  Zulu"
```

3. The output should read out the largest number of entities in a group from the input. 
```
3
``` 

## How to run tests from the command line:

   ```
   dotnet test Communicator.Tests.dll
   ```

## Assumptions :
Lowercase SAT would be rejected <BR>
Can have as many duplicate Team names in input but would still be grouped distictly<BR>
Teams can talk over any number of Satalites.<BR>
Team names can not be 0 chars long<BR>
Team names can't have spaces in them<BR>
