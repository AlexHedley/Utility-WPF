using System;
using System.IO;
using System.Windows.Controls;

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

using File = System.IO.File;

namespace Utility_WPF.Modules.HTML.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class HtmlView : UserControl
    {
        /// <summary>
        /// Html View
        /// </summary>
        public HtmlView()
        {
            InitializeComponent();

            //PopulateWebView();
            //wbSample.Navigate("http://www.alexhedley.com");
            //var path = Path.Combine(Environment.CurrentDirectory, "Page.html");
            //wbSample.Source = new Uri(path);

            //HtmlDocument htmlDoc = webBrowser1.Document as HtmlDocument;
            //string innerText = htmlDoc.DocumentNode.Descendants("body").Single().InnerText;
            //var html = "<p>Hello from string<p>";
            //wbSample.NavigateToString(html);
        }

        //void PopulateWebView()
        //{
        //    // Xam
        //    //https://forums.xamarin.com/discussion/18467/how-to-bind-html-string-to-webview
        //    var web = new WebView();
        //    //var html = new HtmlWebViewSource
        //    //{
        //    //    Html = "your html here"
        //    //};

        //    //var url = new UrlWebViewSource
        //    //{
        //    //    Url = "your url here"
        //    //};
        //    var html = "<p>Hello<p>";
        //    //var url = new Uri("http://www.alexhedley.com/");

        //    //bool useHtml = true;
        //    //web.Source = useHtml ? html : url;
        //    _webView.NavigateToString(html);

        //    var path = Path.Combine(Environment.CurrentDirectory, "Page.html");
        //    //_webView.NavigateToLocal(path);
        //    var uri = new Uri("Page.html", UriKind.Relative);
        //    _webView.NavigateToLocalStreamUri(uri, new Resolver());
        //}

        /// <summary>
        /// Resolver
        /// </summary>
        class Resolver : IUriToStreamResolver
        {
            /// <summary>
            /// Uri To Stream
            /// </summary>
            /// <param name="uri"></param>
            /// <returns></returns>
            public Stream UriToStream(Uri uri)
            {
                //var path = Path.Combine(Environment.CurrentDirectory, "Page.html");
                //var path = Path.Combine(Environment.CurrentDirectory, uri);
                var path = Path.Combine(Environment.CurrentDirectory, uri.LocalPath.TrimStart('/'));
                var stream = File.OpenRead(path);
                return stream;
            }
        }

    }
}
