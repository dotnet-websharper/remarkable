namespace WebSharper.Remarkable.RenderingTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
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
        remarkableConfig.Linkify <- true
        remarkableConfig.LinkTarget <- ""
        remarkableConfig.Typographer <- false
        remarkableConfig.Quotes <- "'“”‘’'"

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
        

        
