namespace WebSharper.Remarkable.Extension

open WebSharper
open WebSharper.InterfaceGenerator

module Definition =

    let Options =
        Pattern.Config "Options"{
            Required = []
            Optional =
            [
                "html", T<bool>
                "xhtmlOut", T<bool>
                "breaks", T<bool>
                "langPrefix", T<string>
                "linkify", T<bool>
                "linkTarget", T<string>

                "typographer", T<string>
                "quotes", T<string>
                "highlight", T<string*string> ^-> T<string>
                "maxNesting", T<int>
            ]
        }
        
    let Remarkable = 
        Class "Remarkable"
        |+> Static [
            Constructor (T<unit> + Options + T<string>)
        ]
        |+> Instance [
            "set" => Options ^-> T<unit>
        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.Remarkable.Resources" [
                Resource "Js" "https://cdn.jsdelivr.net/remarkable/1.7.1/remarkable.min.js"
                |> AssemblyWide
            ]
            Namespace "WebSharper.Remarkable" [
                Options
                Remarkable
            ]
        ]


[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
