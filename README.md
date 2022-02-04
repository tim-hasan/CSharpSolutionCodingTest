# CSharpSolutionCodingTest
Contains a CSHARP solution for the DU SDET Test

#how To run
1. Set project to Release mode then from Build, Click Publish to folder.
2. type the command:

dotnet Communicator.dll "Alpha,Bravo                                                  
Bravo,Alpha, SAT1
SAT1,Bravo , Charlie
Charlie, SAT1
Delta  ,Zulu
 Zulu,Delta, SAT2
SAT2,  Zulu"

Expect output will be 3 for this command.

Can take other commands.

3. Can run tests from the command line too:

dotnet Communicator.Tests.dll
