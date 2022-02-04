# CSharpSolutionCodingTest
Contains a CSHARP solution for the DU SDET Test.

This repo contains a console application, a class library for the engine and some unit tests.

## How to run the console application from command line
1. Set project to Release mode then from Build, Click Publish to folder.
2. type the example input command: dotnet Communicator.dll "Alpha,Bravo<BR>Bravo,Alpha, SAT1<BR>SAT1,Bravo , Charlie<BR>Charlie, SAT1<BR>Delta  ,Zulu<BR> Zulu,Delta, SAT2<BR>SAT2,  Zulu" 

Output : 3 

## How to run tests from the command line:

   dotnet test Communicator.Tests.dll

## Assumptions :
Lowercase SAT would be rejected <BR>
Can have as many duplicate Team names in input but would still be grouped distictly<BR>
Teams can talk over any number of Satalites.<BR>
Team names can not be 0 chars long<BR>
Team names can't have spaces in them<BR>
