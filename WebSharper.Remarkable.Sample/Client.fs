namespace WebSharper.Remarkable.RenderingTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.Remarkable
open WebSharper.UI.Next.Client
open WebSharper.UI.Next
open WebSharper.UI.Next.Html

[<JavaScript>]
module Client =
    [<SPAEntryPoint>]
    let Main () =
        //basic example: how to configure Remarkable
        let remarkableConfig = new WebSharper.Remarkable.Options()
        remarkableConfig.Html <- true //true -> enable html tags in text
        remarkableConfig.XhtmlOut <- false //true -> produce xhtml output
        remarkableConfig.Breaks <- false //true -> newlines in paragraphs are rendered as <br>
        remarkableConfig.LangPrefix <- "language-" //css class language prefix for fenced code blocks
        remarkableConfig.Linkify <- true //true -> autoconvert link-like texts to links
        remarkableConfig.LinkTarget <- "" //target to open link in
        remarkableConfig.Typographer <- false //true -> do typographic repalacements
        remarkableConfig.Quotes <- "'“”‘’'"

        
        let md = new Remarkable.Remarkable(remarkableConfig)

        let rvInput = Var.Create ""

        div [
            h1 [text "WebSharper.Remarkable extension sample page"]
            p [text "Type markdown text here:"]
            Doc.InputArea [attr.``class`` "input"; attr.rows "20"] rvInput
            hr[]
            h4 [text "Result"]
            divAttr[attr.``class`` "output"][rvInput.View.Doc(md.Render >> text)]
        ]
        |> Doc.RunById "body"
        

        
