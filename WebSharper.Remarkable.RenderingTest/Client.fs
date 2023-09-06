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
namespace WebSharper.Remarkable.RenderingTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.Remarkable

[<JavaScript>]
module Client =
    open WebSharper.UI.Client
    open WebSharper.UI.Templating
    open WebSharper.UI
    open WebSharper.UI.Html

    [<SPAEntryPoint>]
    let Main () =
        let remarkableConfig = new WebSharper.Remarkable.Options()
        remarkableConfig.Html <- false
        remarkableConfig.XhtmlOut <- false
        remarkableConfig.Breaks <- false
        remarkableConfig.LangPrefix <- "language-"
        remarkableConfig.LinkTarget <- ""
        remarkableConfig.Typographer <- false
        remarkableConfig.Quotes <- "'����'"

        let md = new Remarkable.Remarkable(remarkableConfig)
        
        let rvInput = Var.Create ""
        div [] [
            h1 [] [text "WebSharper.Remarkable extension sample page"]
            p [] [text "Type markdown text here:"]
            Doc.InputArea [attr.``class`` "input"; attr.rows "20"] rvInput
            hr [] []
            h4 [] [text "Result"]
            div [attr.``class`` "output"] [rvInput.View.Doc(md.Render >> Doc.Verbatim)]
        ]
        |> Doc.RunById "main"
        

        
