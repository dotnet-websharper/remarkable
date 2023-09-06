// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
namespace WebSharper.Remarkable.Extension

open WebSharper
open WebSharper.InterfaceGenerator

module Definition =
    let Remarkable = 
        Class "Remarkable"
        |> Import "Remarkable" "remarkable"
    let Utils =
        Class "Utils"
        |> Import "utils" "remarkable"

    let Ruler =
        Class "Ruler"
        |> WithSourceName "ruler"
        |+> Instance [
            "enable" => (!| T<string> * !? T<bool>) ^-> T<unit>
            "disable" => !| T<string> ^-> T<unit>
        ]

    let WithRuler cl = cl |+> Instance [ "ruler" =? Ruler ]
    let ParserBlock =
        Class "ParserBlock" 
        |> WithRuler
    let ParserCore =
        Class "ParserCore"
        |> WithRuler
    let ParserInline =
        Class "ParserInline"
        |> WithRuler
    


    Utils
        |+> Instance [
            "isValidEntityCode" => T<char> ^-> T<bool>
            "fromCodePoint" => T<char> ^-> T<string>
            "replaceEntities" => T<string> ^-> T<string>
        ]
        |> ignore
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
            Constructor (T<unit> + Options + T<string> + (T<string> * Options))
        ]
        |+> Instance [
            "set" => Options ^-> T<unit>
            "use" => (Plugin * Options) ^-> Remarkable
            "configure" => !| T<obj>^-> T<unit>
            "parse" => (T<string> * T<obj>) ^-> T<string[]>
            "render" => (T<string> * !? T<obj>) ^-> T<string>
            "parseInline" => (T<string> * T<obj>) ^-> T<string[]>
            "renderInline" => (T<string> * !? T<obj>) ^-> T<string>

            "inline" =? ParserInline
            "block" =? ParserBlock
            "core" =? ParserCore
        ]|> ignore

 
 (*   StateCore
        |+> Static [
            Constructor (Remarkable * T<string> * T<obj>)
        ] |> ignore *)

    let Assembly =
        Assembly [
            Namespace "WebSharper.Remarkable.Resources" [
                //Resource "Js" "https://cdn.jsdelivr.net/remarkable/1.7.1/remarkable.min.js"
                //|> AssemblyWide
            ]
            Namespace "WebSharper.Remarkable.Bindings" [
            ]
            Namespace "WebSharper.Remarkable" [
                ParserBlock
                ParserCore
                ParserInline
                Ruler
                Utils
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
