namespace WebSharper.Remarkable.Extension

open WebSharper
open WebSharper.InterfaceGenerator

module Definition =
    let Remarkable = Class "Remarkable"
  //  let StateCore = Class "StateCore"


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

                "typographer", T<bool>
                "quotes", T<string>
                "highlight", T<string*string> ^-> T<string>
                "maxNesting", T<int>
            ]
        }
    let Plugin = (Remarkable * Options) ^-> T<unit>
    Remarkable
        |+> Static [
            Constructor (T<unit> + Options + T<string>)
        ]
        |+> Instance [
            "set" => Options ^-> T<unit>
            "use" => (Plugin * Options) ^-> Remarkable
//            "parse" => (T<string> * T<obj>) ^-> T<string[]>
            "render" => (T<string> * !? T<obj>) ^-> T<string>
//            "parseInline" => (T<string> * T<obj>) ^-> T<string[]>
//            "renderInline" => (T<string> * !? T<obj>) ^-> T<string>
        ]|> ignore

 
 (*   StateCore
        |+> Static [
            Constructor (Remarkable * T<string> * T<obj>)
        ] |> ignore *)

    let Assembly =
        Assembly [
            Namespace "WebSharper.Remarkable.Resources" [
                Resource "Js" "https://cdn.jsdelivr.net/remarkable/1.7.1/remarkable.min.js"
                |> AssemblyWide
            ]
            Namespace "WebSharper.Remarkable" [
                Options
                Remarkable
            //    StateCore
            ]
        ]


[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
