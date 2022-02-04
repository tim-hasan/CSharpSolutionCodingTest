# CSharpSolutionCodingTest
Contains a CSHARP solution for the DU SDET Test

## How to run
1. Set project to Release mode then from Build, Click Publish to folder.
2. type the command:

dotnet Communicator.dll "Alpha,Bravo/nBravo,Alpha, SAT1/nSAT1,Bravo , Charlie/nCharlie, SAT1/nDelta  ,Zulu/n Zulu,Delta, SAT2/nSAT2,  Zulu" 

Expect output will be 3 for this command.

Can take other commands.

## How to run tests from the command line:

   dotnet test Communicator.Tests.dll

##Assumptions :
Lowercase SAT would be rejected <BR>
Can have as many duplicate Team names in input but would still be grouped distictly<BR>
Teams can talk over any number of Satalites.<BR>
Team names can not be 0 chars long<BR>
Team names can't have spaces in them<BR>
