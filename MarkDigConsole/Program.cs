using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDigConsole
{
    class Program
    {


        public static string ConvertMarkdownToHTML(string markdown)

        {

            if (string.IsNullOrEmpty(markdown)) return markdown;



            MarkdownPipeline markdownPipeline = new MarkdownPipelineBuilder()

                    // GitHub Flavored Markdown Specific Extensions.

                    .UseAutoIdentifiers(AutoIdentifierOptions.GitHub)

                    .UseAutoLinks()                     // Necessary for GitHub Flavored Markdown Autolinks Extension.

                    .UseEmphasisExtras()                // Necessary for GitHub Flavored Markdown Strikethrough Extension.

                    .UsePipeTables()                    // Necessary for GitHub Flavored Markdown Tables Extension.

                    .UseTaskLists()                     // Necessary for GitHub Flavored Markdown Task List Items Extension.

                    // Other Extensions

                    .UseAdvancedExtensions()

                    .UseBootstrap()                     // Adds convenience css classes to the html markup.

                    .UseNoFollowLinks()

                    .UseSoftlineBreakAsHardlineBreak()  // Causes <BR />s on line breaks.

                    .DisableHtml()                      // Don't allow HTML inside the Markdown content.

                    // then build

                    .Build();

            return Markdown.ToHtml(markdown, markdownPipeline);

        }

        static void Main(string[] args)
        {
            // getData();
            //var stringmark = File.ReadAllText(@"C:\ClinicalInsightsSampleResponseFiles\HCCMarkDown.txt");

            var stringmark = " <h1>H </h1>  ";
            string markdown = stringmark;

            Console.WriteLine(ConvertMarkdownToHTML(markdown));

            Console.ReadKey();
        }
    }
}
