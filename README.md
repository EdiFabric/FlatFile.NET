# EdiFabric C# .NET Examples for Flat and CSV Files

## 1. Overview
EdiFabric is a software development kit for .NET Framework and .NET Core, which makes it straightforward to parse, generate, validate, acknowledge, split, customize, or in other words, to programmatically manipulate EDI files. It is written in C# and is distributed as a set of NuGet packages and C# files.  

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
- Visual Studio, compatible with the supported .NET versions.  
- Minimum .NET Framework 4.5 or .NET Core 3.1. All projects target .NET Framework 4.5, however, the Target Framework from each project's properties can be changed to .NET Core 3.1.  
- EdiFabric trial DLLs and serial number.

## 3. Serial Key and EdiFabric trial DLLs
[Download the serial key](https://sowl.co/oApEt).
The serial key is included in the file serial.key in folder edifabric-trial. Ensure it is there and that the file is not empty. The serial key is loaded in the file SerialKey.cs in project EdiFabric.Examples.FlatFile.Common. Open the file and ensure that the serialKeyPath is correct.
If the serial key is invalid or the file is missing, contact us at https://support.edifabric.com/hc/en-us/requests/new for assistance.  
The trial DLLs are in folders net45 (for .NET Framework 4.5+) and netcoreapp3.1 (for .NET Core 3.1+).

## 4. Setup
Rebuild the solution. If there are any build errors, contact us at https://support.edifabric.com/hc/en-us/requests/new for assistance.  

## 5. Getting started
To get started, set project EdiFabric.Examples.FlatFile.Read as the startup project, open ReadCSVFile.cs and run it.  

## 6. Examples by feature
Explore the different features of EdiFabric, such as translating from flat file file (Read) and generating flat file file (Write).  

## 7. Trial use
The trial assemblies are valid for 14 days and are subject to EdiFabric's license terms available at https://www.edifabric.com/files/eula.pdf. Upon expiry, the trial packages will begin throwing exceptions.   
To continue using the trial and the examples, you'll need to either request a trial extension or replace the trial packages, together with all references to the trial packages, with the full version of EdiFabric.   

## 8. Warranty
*The source code in these example projects is strictly for demonstrational purposes and is provided "AS IS" without warranty of any kind, whether expressed or implied, including but not limited to the
implied warranties of merchantability and/or fitness for a particular purpose.*  

## 9. Additional information

[Install EdiFabric](https://support.edifabric.com/hc/en-us/articles/360016808578-Install-EdiFabric)

[Trial and Examples](https://support.edifabric.com/hc/en-us/articles/360000280532-Trial-and-Examples)

[EdiFabric Tutorial](https://support.edifabric.com/hc/en-us/articles/360000291511-Tutorial-EDI-NET-Tools-Basics)

[Knowledge Base](https://support.edifabric.com)

[Support](https://support.edifabric.com/hc/en-us/requests/new)

Last updated on November 22, 2022
### 2022 © EdiFabric
