using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebclientDownloader
{
    class Program
    {
        static int percentage = 0;
        static async Task Main(string[] args)
        {
            Uri fileUr = new Uri("https://www.postnl.nl/klantenservice/bestellen-en-downloaden/besloten-locatiewijzer/postbusgegevens_tcm10-17413.xls?version=2944");

            var username = "jorik@intrapost.nl";
            var password = "PostNL2014";

            /*using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(username, password);
                //String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                //client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";

                client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                client.DownloadDataCompleted += WebClientDownloadCompleted;

                client.DownloadFileAsync(ur, @"C:\Users\Mark\Desktop\postbussen\postbusgegevens.xls");
            }

            while (true)
            {
                Thread.Sleep(1000);
            }*/

            Uri ur = new Uri("https://www.postnl.nl/Images/postbusgegevens_tcm10-17413.xls");

            HttpClient client = new HttpClient();

            var content = new StringContent($"username={username}&password={password}&submit=submit");
            var response = await client.PostAsync(ur, content);
            await response.Content.LoadIntoBufferAsync();
            var bytes = await response.Content.ReadAsByteArrayAsync();
            int trol = 0;
            
            //using (WebClient client = new WebClient())
            //{
            //    client.Credentials = new NetworkCredential(username, password);
            //
            //    string postData = $"username={username}&password={password}&submit=submit";
            //    string response = client.UploadString(ur, postData);
            //
            //    //string postData
            //    client.DownloadProgressChanged += Client_DownloadProgressChanged;
            //    client.DownloadFile(ur, @"C:\Users\Mark\Desktop\postbussen\postbusgegevens.xls");
            //
            //    //var webClient = new WebClient
            //    //{
            //    //    Credentials = new NetworkCredential(username, password),
            //    //};
            //    //
            //    //string reply = webClient.DownloadString(ur);
            //    //
            //    //Console.WriteLine(reply);
            //    //Console.ReadLine();
            //    //
            //    //client.UseDefaultCredentials = true;
            //    //client.Credentials = new NetworkCredential(username, password);
            //    //String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
            //    //client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
            //
            //    //string postData = $"username={username}&password={password}&submit=submit";
            //    //string response = client.UploadString(ur, postData);
            //
            //
            //}
            //string postData = $"username={username}&password={password}&submit=submit";
            //string response = http.UploadString("https://www.postnl.nl/klantenservice/bestellen-en-downloaden/besloten-locatiewijzer/", postData);

            //CookieContainer cookieJar = new CookieContainer();
            //CookieAwareWebClient http = new CookieAwareWebClient(cookieJar);
            //
            //string postData = $"name={username}&password={password}&submit=submit";
            //string response = http.UploadString(ur, postData);
            //
            //// validate your login! 
            //
            //http.DownloadFile("https://www.postnl.nl/Images/postbusgegevens_tcm10-17413.xls?version=2944", @"C:\Users\Mark\Desktop\postbussen\postbusgegevens.xls");

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Download status: {0}%.", e.ProgressPercentage);

            percentage = e.ProgressPercentage;
            //// updating the UI
            //Dispatcher.Invoke(() => {
            //    progressBar.Value = e.ProgressPercentage;
            //});
        }

        static void WebClientDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Console.WriteLine("Download finished!");
        }

        public class CookieAwareWebClient : WebClient
        {
            public CookieContainer CookieContainer { get; set; }
            public Uri Uri { get; set; }

            public CookieAwareWebClient()
                : this(new CookieContainer())
            {
            }

            public CookieAwareWebClient(CookieContainer cookies)
            {
                this.CookieContainer = cookies;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = this.CookieContainer;
                }
                HttpWebRequest httpRequest = (HttpWebRequest)request;
                httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                return httpRequest;
            }

            protected override WebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];

                if (setCookieHeader != null)
                {
                    //do something if needed to parse out the cookie.
                    if (setCookieHeader != null)
                    {
                        Cookie cookie = new Cookie(); //create cookie
                        this.CookieContainer.Add(cookie);
                    }
                }
                return response;
            }
        }
    }
}
