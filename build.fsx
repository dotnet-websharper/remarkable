#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.Remarkable")
        .VersionFrom("WebSharper", versionSpec = "(,4.0)")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun f -> f.Net40)

let main =
    bt.WebSharper.Extension("WebSharper.Remarkable")
        .SourcesFromProject()
        .Embed([])
        .References(fun r -> [])

let tests =
    bt.WebSharper.SiteletWebsite("WebSharper.Remarkable.Tests")
        .SourcesFromProject()
        .Embed([])
        .References(fun r ->
            [
                r.Project(main)
                r.NuGet("WebSharper.Testing").Version("(,4.0)").Reference()
                r.NuGet("WebSharper.UI.Next").Version("(,4.0)").Reference()
            ])

bt.Solution [
    main
    tests

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper bindings for Remarkable"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/https://github.com/intellifactory/websharper.remarkable"
                Description = "WebSharper Extension for remarkable 1.7.1"
                RequiresLicenseAcceptance = true })
        .Add(main)
]
|> bt.Dispatch
