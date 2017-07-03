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
        let RemarkableConfig = new Options()
        RemarkableConfig.Html <- true //true -> enable html tags in text
        RemarkableConfig.XhtmlOut <- false //true -> produce xhtml output
        RemarkableConfig.Breaks <- false //true -> newlines in paragraphs are rendered as <br>
        RemarkableConfig.LangPrefix <- "language-" //css class language prefix for fenced code blocks
        RemarkableConfig.Linkify <- true //true -> autoconvert link-like texts to links
        RemarkableConfig.LinkTarget <- "" //target to open link in

        RemarkableConfig.Typographer <- false //true -> do typographic repalacements
        RemarkableConfig.Quotes <- "'“”‘’'"

        
        let Md = new Remarkable(RemarkableConfig)

 //       .Set method takes an option and returns with unit
 //       RemarkableConfig.Html <- false
 //       Md.Set(RemarkableConfig)


        let rvInput = Var.Create ""

        div [
            h1 [text "WebSharper.Remarkable extension sample page"]
            p [text "Type markdown text here:"]
            Doc.InputArea [attr.``class`` "input"; attr.rows "20"] rvInput
            hr[]
            h4 [text "Result"]
            divAttr[attr.``class`` "output"][rvInput.View.Doc(Md.Render >> Doc.Verbatim)]
        ]
        |> Doc.RunById "body"

        
