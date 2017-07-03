# WebSharper.Remarkable

WebSharper Extension for remarkable 1.7.1

# About the library

Remarkable is a markdown parser written in JavaScript. It is easy to use, and easily cans be configured.

The WebSharper extension works similarly to the original Remarkable.

# How to use it

You can either configure it, or just start using it with its default settings.

## The options are:
* __Html__: Enable HTML tags in source (default: false)
* __XhtmlOut__: Use ‘/’ to close single tags (for example <br/>, default: false)
* __Breaks__: Convert ‘\n’ in paragraphs into <br> (default: false)
* __LangPrefix__: CSS language prefix for fenced blocks (default: ‘language-’)
* __Linkify__: Autoconvert URL-like text to links (default: false)
* __Typographer__: Enable some language neutral-replacement (default: false)
* __Quotes__: Set doubles to '«»' for Russian, '„“' for German. (default: '“”‘’')
* __Highlight__: Highlighter function. Should return escaped HTML, or ‘’ if the source string is not changed (default: function () {return ‘’;})

### Sample:

```fsharp
//first you have to instantiate a new Options object
let RemarkableConfig = new Options()
//then you can set its fields
RemarkableConfig.Html <- false
RemarkableConfig.XhtmlOut <- false
RemarkableConfig.Breaks <- false
RemarkableConfig.Linkify <- true

//Instantiating the parser and configuring it in the constructor
Md = new Remarkable(RemarkableConfig)

//The render function will parse and then render the input string, returning a 
Md.Render(“# Hello world!”) //The .Render function will return with the “<h1>Hello world!</h1>” string
|> Doc.Verbatim
|> Doc.RunById “main”

```

## .Set

The .Set method takes an Options and returns with unit. With this method you can change the configuration on the fly, although it is not recommended. The best practice is to create multiple instances and initialize each with the needed configuration.
```fsharp
let Config = new Options()
Config.Linkify <- true

let Md = new Remarkable()

Md.Set(Config)

```
## Presets
Remarkable contains some presets. They make it easier and more convenient to configure the parser.
```fsharp

//strict commonmark mode
let MdCommonmark = new Remarkable(“commonmark”)

//enable all available rules
let MdFull = new Remarkable(“full”)

```
## Syntax highlighting

Syntax highlighting can be applied to fenced code blocks with the highlight option. For more details see the [original documentation]( https://github.com/jonschlinkert/remarkable).

## Manage rules

__TODO__

## Typographer

```fsharp

let Config = new Options()
Config.Typographer <- true
let Md = new Remarkable(Config)

// Replacements
//
// '' ? ‘’
// "" ? “”. Set '«»' for Russian, '„“' for German, empty to disable
// (c) (C) ? ©
// (tm) (TM) ? ™
// (r) (R) ? ®
// +- ? ±
// (p) (P) -> §
// ... ? … (also ?.... ? ?.., !.... ? !..)
// ???????? ? ???, !!!!! ? !!!, `,,` ? `,`
// -- ? &ndash;, --- ? &mdash;

```

## Plugins
__TODO__

# Differences to the original library

The WebSharper extension is not too different to the original library. The only noticeable change is that the configuration options are represented with the Options type, and its fields can be set as needed.
