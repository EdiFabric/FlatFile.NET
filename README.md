# EdiFabric C# .NET Examples for Flat and CSV Files

## 1. Overview
EdiFabric is a software development kit for .NET Framework and .NET Core, which makes it straightforward to parse, generate, validate, acknowledge, split, customize, or in other words, to programmatically manipulate EDI files. It is written in C# and is distributed as a DLL file and a NuGet package.  

It currently supports all message types for the X12, EDIFACT, HL7, and NCPDP EDI standards, the German automotive standard VDA, as well as custom formatted flat files (delimited, positional, or a mixture of both).  

> NOTE: EdiFabric does not provide any communication components (AS2 or SFTP, for example), has no dashboard or UI, and is not a full end-to-end EDI solution.
The best option to get the gist of what EdiFabric is, and can do, is to play around with the trial and examples.  

The examples are organized into different projects in two logical categories: by product feature and by message type.   

```C#
Stream ediStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\Files\Flat_PO.txt");

using (StreamReader streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
    using (var csvReader = new FlatReader(streamReader, typeof(FlatPO)))
    {
        var result = csvReader.ReadToEnd() as FlatPO;
    }
```

## 2. Requirements
- Visual Studio, compatible with the supported .NET versions. [Download Visual Studio](https://visualstudio.microsoft.com/downloads/).
- Minimum .NET Framework 4.8 or .NET 6. Downgrade to .NET Framework 4.5 is possible by changing the target framework for each project.  

## 3. Serial Key and EdiFabric DLLs
All projects reference EdiFabric EDI Tools as NuGet packages from nuget.org. If you wish to install EdiFabric EDI Tools as DLLs, download the trial DLLs from [here](https://support.edifabric.com/hc/en-us/articles/360000280532-Free-code-to-master-you-EDI-files).  

## 4. Setup
Rebuild the solution with Package Restore enabled. If there are any build errors, manually install the missing packages from [here](https://www.nuget.org/packages?q=edifabric).  

## 5. Getting started
To get started, set project EdiFabric.Examples.FlatFile.Read as the startup project, open ReadCSVFile.cs and run it.  

## 6. Examples by feature
Explore the different features of EdiFabric, such as translating from flat file file (Read) and generating flat file file (Write).   

## 7. Trial use
The trial serial key is valid for 14 days, and using the product with a trial license is subject to EdiFabric's license terms available at https://www.edifabric.com/files/eula.pdf. Upon expiry, the product will begin throwing exceptions. To continue using the trial and the examples, you'll need to request a trial extension.   

## 8. Warranty
*The source code in these example projects is strictly for demonstrational purposes and is provided "AS IS" without warranty of any kind, whether expressed or implied, including but not limited to the
implied warranties of merchantability and/or fitness for a particular purpose.*  

## 9. Additional information

[Install EdiFabric](https://support.edifabric.com/hc/en-us/articles/360016808578-Install-EdiFabric)

[Trial and Examples](https://support.edifabric.com/hc/en-us/articles/360000280532-Trial-and-Examples)

[EdiFabric EDI to CSV](https://support.edifabric.com/hc/en-us/articles/360012781291-EDI-to-CSV)

[Knowledge Base](https://support.edifabric.com)

[Support](https://support.edifabric.com/hc/en-us/requests/new)

Last updated on June 20, 2023
### 2023 © EdiFabric
