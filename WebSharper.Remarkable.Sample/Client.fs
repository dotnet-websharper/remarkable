namespace WebSharper.Remarkable.RenderingTest

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.Remarkable
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Templating
open WebSharper.UI.Next.Formlets
open WebSharper.UI.Next
open WebSharper.Html.Client

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
        
        (*let InputField =
            TextArea []
        let Btn =
            Button [Text "Submit"]
            |>! OnClick (fun button event -> Console.Log(md.Render <| InputField.Value))*)
            
        
       (* let InpField = JQuery.Of("#inp")
        let Btn = JQuery.Of("#btn").ToString
        let Res = JQuery.Of("#result").Add("<p>bdfbdf</p>")*)


        

            



        let t =
            WebSharper.UI.Next.Html.div[
 (*               WebSharper.UI.Next.Doc.TextNode "Configured in the code:"
                md.Render ("# dgsfhd") |> Doc.Verbatim
                WebSharper.UI.Next.Doc.TextNode "Using the default configuration:"
                defaultMd.Render("# This text is inside of a h1") |> Doc.Verbatim
                defaultMd.Render("***") |> Doc.Verbatim *)
                md.Render("***") |> Doc.Verbatim
                md.Render("http://google.com") |> Doc.Verbatim
                md.Render("<script>console.log(19)</script>") |> fun x -> Console.Log x; x |> Doc.Verbatim

            ]
        Console.Log <| md.Render ("# dgsfhd")
        t |> WebSharper.UI.Next.Client.Doc.RunById "main"
        

        
