# EdiFabric C# .NET Examples for Flat Files and CSV

C# examples for EdiFabric, the .NET flat file and CSV parser: read, write and validate delimited, positional and mixed flat files, and convert them to JSON. Install EdiFabric from NuGet with `dotnet add package EdiFabric`; it targets .NET 6, 8, 9, 10 and .NET Framework 4.8, and runs without an account on the demo serial key.

**EdiFabric 11.2.0** is a .NET SDK that parses, generates, validates, and splits EDI files. These examples cover custom **flat files**: delimited, positional, or a mixture of both, including CSV.

EdiFabric does not include communication components (AS2 or SFTP), a dashboard, or a UI. It is a library you call from your own application.

The .NET 6 projects compile the same sources as the .NET Framework 4.8 projects. Both solutions reference [EdiFabric 11.2.0](https://www.nuget.org/packages/EdiFabric) from NuGet. The examples target .NET 6 for backward compatibility. EdiFabric 11.2.0 also ships targets for .NET 8, .NET 9, and .NET 10. To evaluate one of those, change `TargetFramework` in the project file and rebuild.

| Path | Purpose |
| --- | --- |
| `NET 6/EdiFabric.Examples.FlatFile.sln` | .NET 6 solution |
| `NET Framework 4.8/EdiFabric.Examples.FlatFile.sln` | .NET Framework 4.8 solution |
| `NET Framework 4.8/EdiFabric.Examples.FlatFile.Common/Config.cs` | Serial key shared by every example |
| `NET Framework 4.8/EdiFabric.Examples.FlatFile.Common/` | Flat-file models (`FlatPO`, markers, and purchase order) |
| `NET Framework 4.8/EdiFabric.Examples.FlatFile.Read/ReadCSVFile.cs` | Read the sample files |
| `Files/` | Sample flat and CSV files |

## Requirements

- Visual Studio 2022, or the .NET SDK. [Download Visual Studio](https://visualstudio.microsoft.com/downloads/).
- .NET 6 for `NET 6/EdiFabric.Examples.FlatFile.sln`. The projects set `<TargetFramework>net6.0</TargetFramework>` so they stay compatible with existing .NET 6 apps. EdiFabric 11.2.0 also provides `net8.0`, `net9.0`, and `net10.0`. To evaluate a later version, change that property (for example to `net8.0`) and rebuild.
- .NET Framework 4.8 for `NET Framework 4.8/EdiFabric.Examples.FlatFile.sln`.

1. [Sign up free for **Community**](https://www.edifabric.com/pricing.html) to get an evaluation serial key. Community never expires, requires no credit card, and is for non-production use. The first 14 days after you subscribe have unlimited operations, then the quota is 250 per day. To extend the unlimited period, ask through the [support portal](https://support.edifabric.com/hc/en-us/requests/new) or at [support@edifabric.com](mailto:support@edifabric.com). After signup, retrieve your serial from [Your Account](https://www.edifabric.com/docs/getting-started/your-account.html).
2. Paste that serial into `TrialSerialKey` in `NET Framework 4.8/EdiFabric.Examples.FlatFile.Common/Config.cs`. The .NET 6 projects link this file, so one edit covers both solutions.

NuGet restore pulls **EdiFabric 11.2.0**. The flat-file models are C# classes in `EdiFabric.Examples.FlatFile.Common`, not a template NuGet package.

## Getting started

**Sign up free for Community** at [edifabric.com/pricing](https://www.edifabric.com/pricing.html) and put your serial in `Config.TrialSerialKey`. Then open a solution, set **EdiFabric.Examples.FlatFile.Read** as the startup project, and run it.

From the command line:

```bash
cd "NET 6/EdiFabric.Examples.FlatFile.Read"
dotnet run
```

The project reads `Files/Flat_PO.txt`, `Files/Flat_Markers.txt`, `Files/Flat_Multiple.txt`, and `Files/CSV_PO.txt` with `FlatReader`. A factory maps the start of each record to a model in `EdiFabric.Examples.FlatFile.Common`: `PO`, `Markers`, or `PurchaseOrder`.

To translate your own file, change the path in `EdiFabric.Examples.FlatFile.Read/ReadCSVFile.cs`.

## Usage

Every example calls `License.EnsureToken` before it reads or writes. Since EdiFabric 11.2.0 that's the one licensing call on every plan, in place of `License.SetSerial`. See [Licensing](#licensing).

```csharp
using EdiFabric.Core.Model.Edi;
using EdiFabric.Framework.Readers;

License.EnsureToken(serial, seconds: 3600);   // every plan: license the process (see Licensing)

var ediStream = File.OpenRead(@"Files\Flat_PO.txt");
var items = new List<IEdiItem>();

using (var streamReader = new StreamReader(ediStream, Encoding.UTF8, true, 1024))
using (var flatReader = new FlatReader(streamReader, FlatFactory))
{
    while (flatReader.Read())
        items.Add(flatReader.Item);
}
```

`FlatFactory` looks at the first two characters. `PO` loads `FlatPO`, `H,` loads the markers model, and `LI` loads the purchase-order model, all from assembly `EdiFabric.Examples.FlatFile.Common`. **Read** also shows an async read and a split read (`FlatReaderSettings.Split`).

### Writing a flat file

**Write** builds a purchase order with `POBuilder` and writes it with `FlatWriter`. The same project writes asynchronously.

```csharp
using (var stream = new MemoryStream())
using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
using (var flatWriter = new FlatWriter(writer, null))
{
    flatWriter.Write(POBuilder.BuildFlatPO());
}
```

## Examples by feature

| Project | What it shows |
| --- | --- |
| `EdiFabric.Examples.FlatFile.Read` | Read a positional purchase order, a file with markers, mixed messages, a CSV purchase order, an async read, and a split read |
| `EdiFabric.Examples.FlatFile.Write` | Write a flat purchase order, and write it asynchronously |
| `EdiFabric.Examples.FlatFile.Common` | The C# models and `POBuilder` |

For another layout, add a C# model to `EdiFabric.Examples.FlatFile.Common` and return it from `FlatFactory`. See [EDI templates](#edi-templates).

## Licensing

> [!NOTE]
> Sign up free for the [Community plan](https://www.edifabric.com/pricing.html)
> to get an evaluation serial key. Community never expires, requires no credit
> card, and is for non-production evaluation, learning, and prototyping
> (unlimited operations for the first 14 days after you subscribe, then 250 per day;
> to extend the unlimited period, ask through the [support portal](https://support.edifabric.com/hc/en-us/requests/new)
> or at [support@edifabric.com](mailto:support@edifabric.com)). After signup, copy your serial from
> [Your Account](https://www.edifabric.com/docs/getting-started/your-account.html)
> into `Config.TrialSerialKey`.
>
> One operation is one parse, generate, validate, or acknowledge call. The 250-a-day
> quota is shared across ediFabric .NET, Native, and Cloud. If you hit it, calls
> throw `LicenseException` with [error 639](#error-codes). Upgrade at
> [edifabric.com/pricing](https://www.edifabric.com/pricing.html) to continue.
>
> Use of the product is subject to the [EULA](https://www.edifabric.com/files/eula.pdf).

**Use `License.EnsureToken` on every plan.** Since EdiFabric 11.2.0 it's the one licensing call for Community, Developer, Enterprise and Perpetual, in place of `License.SetSerial`. Call it once at startup with your serial and the number of seconds a token must still be valid, and it keeps the process licensed from then on.

| Plan | What `License.EnsureToken` does |
| --- | --- |
| Community and the demo serial | Checks the serial online on every operation, as `License.SetSerial` does |
| Developer, Enterprise and Perpetual | Gets a token, caches it on disk and refreshes it before it expires, so operations are checked locally |

The token cache is `%LOCALAPPDATA%\EdiFabric\tokens` on Windows, `~/Library/Caches/EdiFabric/tokens` on macOS, and `$XDG_CACHE_HOME/edifabric/tokens` (or `~/.cache/edifabric/tokens`) on Linux, so every process on the machine reuses the token. Set `EDIFABRIC_TOKEN_CACHE` to another folder, or to `none` to turn the cache off. When the license server can't be reached, a cached token that's still valid keeps working; without one, calls throw `LicenseException` with [error 640](#error-codes).

```csharp
// Every plan (recommended): license the process; tokens are refreshed when they expire within N seconds
License.EnsureToken(serial, seconds: 3600);

// Enterprise and Perpetual, when your hosts manage tokens themselves: set an offline token
License.SetToken(token);
```

The examples call `License.EnsureToken(Config.TrialSerialKey, 3600)`. `License.SetSerial` still works, but it checks the serial online on every operation, on every plan. `TokenFileCache.Set()` in `EdiFabric.Examples.FlatFile.Common` is the manual `GetToken` / `SetToken` cache, for Enterprise and Perpetual hosts that fetch and store offline tokens themselves.

Self-service offline tokens last 30 days, so refresh them before they expire. If your hosts can't refresh a token, Enterprise and Perpetual can request a 1-year token, and Perpetual gets a new one free every year, if approved. Long-lived tokens are issued after the trial or evaluation period to registered companies using professional email addresses, and are non-refundable once issued. See [how to request one](https://www.edifabric.com/docs/faq/pricing-and-licensing-faqs.html#long-lived-tokens). Treat every token as a secret, and keep it out of source control.

## Error codes

License failures throw `LicenseException`. `ErrorCode` is the number below, and `Message` is the text.

**Error 639** means the Community daily quota was exceeded. Upgrade your plan at [edifabric.com/pricing](https://www.edifabric.com/pricing.html) if you wish to continue.

**Error 640** means the license server can't be reached and no valid token is cached. Check the internet connection, firewall and proxy settings. A cached token that's still valid keeps working, so this happens only before the first token, or after a token expired.

| Code | Message |
| --- | --- |
| 1 | The suggested output buffer size is too small |
| 501 | Unexpected error occured. Contact support@edifabric.com for assistance |
| 611 | The input buffer is either null or its size is nill |
| 612 | The logger failed to log |
| 613 | The map configuration file is invalid |
| 614 | The output capacity must be positive |
| 615 | Models map must be set before parsing or splitting |
| 616 | Mode must be any of: 1 - Parse, 2 - Parse and Validate, 3 - Parse and Validate and Acknowledge |
| 617 | Parser failed. Contact support@edifabric.com and include a sample project/file to reproduce the issue |
| 618 | Validation failed. Contact support@edifabric.com and include a sample project/file to reproduce the issue |
| 619 | Validation serializer failed. Contact support@edifabric.com and include a sample project/file to reproduce the issue |
| 620 | The token is invalid. Contact support@edifabric.com for assistance |
| 621 | The configuration file is invalid |
| 622 | The split segment ID must not be blank |
| 623 | Call start_split before splitting |
| 624 | The result can't be retrieved. Contact support@edifabric.com and include a sample project/file to reproduce the issue |
| 625 | Result buffer size mismatched |
| 626 | Call start_merge before merging |
| 627 | The output buffer is either null or its size is nill |
| 628 | The serial number is missing or incorrect. GetToken doesn't work with developer license. Contact support@edifabric.com for assistance |
| 629 | License was not installed. Contact support@edifabric.com for assistance |
| 630 | No license to use this version. Contact support@edifabric.com for assistance |
| 631 | The token has expired. Get and set a new token to continue. Contact support@edifabric.com for assistance |
| 632 | The token is missing. Set token to continue. Contact support@edifabric.com for assistance |
| 633 | Reached the maximum number of licenses. Set token to continue. Contact support@edifabric.com for assistance |
| 634 | Environment not recognized for licensing or reached the maximum number of licenses. Contact support@edifabric.com for assistance |
| 635 | Serial or token not found. Either set token or serial to continue. Contact support@edifabric.com for assistance |
| 636 | The rate to get serials was exceeded for your license. Wait for 60 seconds and try again or upgrade your license. Contact support@edifabric.com for assistance |
| 637 | Invalid JSON. Enable logging for additional details |
| 638 | The operation is not supported by your license |
| 639 | Your license has reached its daily call limit. Upgrade your plan at edifabric.com to continue using the product. |
| 640 | The license server can't be reached and no valid token is cached. Check the internet connection, firewall and proxy settings, and try again. Contact support@edifabric.com if this continues |

## EDI templates

Custom flat files are plain C# classes. These examples already include them in `EdiFabric.Examples.FlatFile.Common`.

Standard EDI formats, such as X12, EDIFACT and HL7, use C# templates from the [EDI spec library](https://www.edifabric.com/specs/index.html). The templates are the same on every plan, Community included. Open a transaction and, under **Download**, select **C# template**: the ZIP has the transaction class and a Common folder with the segments, composites and codes it needs. Downloads need a free sign-in, as the Community plan is enough, and accepting the spec licence once; every plan includes 50 spec downloads a day. The specs the ediFabric examples use are a free sample that downloads without signing in. To change a template for a trading partner, select **Customize in Spec Builder** and download the C# of your spec from the [EDI Spec Builder](https://www.edifabric.com/spec-builder/index.html), which you use signed in to your free account. How to add the files to a class library is in [EDI templates](https://www.edifabric.com/docs/edifabric-net/edi-templates.html).

- [EDI to CSV](https://www.edifabric.com/docs/edifabric-net/edi-to-csv.html)
- [EDI spec library](https://www.edifabric.com/specs/index.html) (browse without registration; sign in free to download)
- [EDI Spec Builder](https://www.edifabric.com/spec-builder/index.html)

## Warranty

The source code in these example projects is strictly for demonstrational purposes and is provided "AS IS" without warranty of any kind, whether expressed or implied, including but not limited to the implied warranties of merchantability and/or fitness for a particular purpose.

## Links

- [Install EdiFabric](https://www.edifabric.com/docs/edifabric-net/install.html)
- [Tutorial](https://www.edifabric.com/docs/edifabric-net/edi-tools-for-net-tutorial-part-1.html)
- [EDI to CSV](https://www.edifabric.com/docs/edifabric-net/edi-to-csv.html)
- [Knowledge base](https://www.edifabric.com/docs/index.html)
- [Community plan (free signup)](https://www.edifabric.com/pricing.html)
- [Your Account](https://www.edifabric.com/docs/getting-started/your-account.html)
- [Support](https://www.edifabric.com/docs/index.html)
- Support: support@edifabric.com

### 2026 © EdiFabric
