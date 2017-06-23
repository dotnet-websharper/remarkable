namespace WebSharper.Remarkable.RenderingTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.Remarkable

[<JavaScript>]
module Client =
    open WebSharper.UI.Next.Client
    open WebSharper.UI.Next.Templating
    open WebSharper.UI.Next

    


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
        let t =
            WebSharper.UI.Next.Html.div[
                WebSharper.UI.Next.Doc.TextNode "# Test text"
            ]
        t |> WebSharper.UI.Next.Client.Doc.RunById "main"
        

        
