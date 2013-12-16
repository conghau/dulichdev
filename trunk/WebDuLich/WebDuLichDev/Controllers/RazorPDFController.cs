using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using zingme_sdk;
using DuLichDLL.BAL;
using WebDuLichDev.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WebDuLichDev.WebUtility;
using System.Web.Mvc.Html;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;
using System.Web.UI;
namespace WebDuLichDev.Controllers
{

    public class RazorPDFController : Controller
    {
        public ActionResult Pdf(long ID)
        {
            ViewBag.CityId = ID;

            DL_CityBAL dlCityBal = new DL_CityBAL();
            var city = dlCityBal.GetByID(ID);
            ViewBag.Title = city.CityName;


            DL_PlaceBAL dlPlaceBal = new DL_PlaceBAL();
            DL_NicePlaceInfoDetailBAL dlNicePlaceInfoDetailBal = new DL_NicePlaceInfoDetailBAL();
            DL_ImagePlaceBAL dlImagePlaceBal = new DL_ImagePlaceBAL();
            var dlPlace = dlPlaceBal.GetListNicePlaceByCity(ID);



            var tmp = new vm_NicePlace();
            tmp.dlPlace = dlPlaceBal.GetByID(ID);
            tmp.dlNicePlaceInfoDetail = dlNicePlaceInfoDetailBal.GetByPlaceId(tmp.dlPlace.ID);
            tmp.listImagePlace = dlImagePlaceBal.GetByDLPlaceID(tmp.dlPlace.ID);

            return View(tmp);

            //var resultpdf = new PdfResult(tmp, "PDF");

            //return new RazorPDF.PdfResult(tmp, "PDF");
            // }

            //Document document = new Document();
            //document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            //MemoryStream stream = new MemoryStream();

            //try
            //{
            //    Font TimeNewRoman = new Font(Font.TIMES_ROMAN, 16f);
            //    String fontFile = Path.Combine(Server.MapPath("~/Content/Fonts/"), "ARIALUNI.TTF");
            //    BaseFont baseFont = BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //    Font font = new Font(baseFont, 16);
            //    Font courier = new Font(Font.COURIER, 9f);
            //    Font font_big = new Font(baseFont, 22);
            //    PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
            //    pdfWriter.CloseStream = false;

            //    PdfPTable table = new PdfPTable(2);

            //    table.TotalWidth = 800f;

            //    table.LockedWidth = true;
            //    Phrase tieude = new Phrase(" Thông tin cơ bản ", font_big);

            //    PdfPCell header = new PdfPCell(tieude);
            //    PdfPTable table_small = new PdfPTable(1);

            //    Phrase diachi = new Phrase(@Resources.Language.Address + ": " + tmp.dlPlace.Address, font);
            //    Phrase ten = new Phrase(@Resources.Language.PlaceName + ": " + tmp.dlPlace.Name, font);
            //    table_small.AddCell(diachi);
            //    table_small.AddCell(ten);
            //    SelectListItem[] citylist = WebDuLichData.ListCity.ToArray();
            //    string valuefind = tmp.dlPlace.DL_CityId.ToString();
            //    SelectListItem city_pdf = citylist.FirstOrDefault(i => i.Value == valuefind)
            //?? citylist[0];

            //    var city_pdf_text = city_pdf.Text;
            //    Phrase tpho = new Phrase(@Resources.Language.CityName + ": " + city_pdf_text, font);

            //    table_small.AddCell(tpho);

            //    header.Colspan = 2;
            //    header.HorizontalAlignment = 1;
            //    table.AddCell(header);

            //    table.AddCell(table_small);
            //    var url = Path.Combine(Server.MapPath("~/Data/Avatar/Place/"), tmp.dlPlace.Avatar);
            //    document.Open();
            //    //document.AddTitle(tmp.dlPlace.Name); //Add Name Header
            //    //document.AddHeader("Header", tmp.dlPlace.Name);
            //    //document.Add(new Paragraph("Hello World"));
            //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(url);
            //    //image.ScalePercent(10f);
            //    image.ScaleAbsoluteHeight(300f);
            //    image.ScaleAbsoluteWidth(300f);
            //    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE | Image.TEXTWRAP;
            //    table.AddCell(image);




            //    document.Add(table);
            //    PdfPTable table_page2 = new PdfPTable(2);

            //    table_page2.TotalWidth = 800f;

            //    table_page2.LockedWidth = true;
            //    Phrase tieude_page2 = new Phrase(" Thông tin chi tiết ", font_big);

            //    PdfPCell header_page2 = new PdfPCell(tieude_page2);

            //    header.Colspan = 2;
            //    header.HorizontalAlignment = 1;
            //    table_page2.AddCell(header);
            //    string info = HttpUtility.HtmlDecode(tmp.dlNicePlaceInfoDetail.Info);

            //    StringWriter sw = new StringWriter();
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    StringReader sr = new StringReader(info);
            //    HTMLWorker htmlparser = new HTMLWorker(document);
            //    htmlparser.Parse(sr);
            //    //var abc = MvcHtmlString.Create(tmp.dlNicePlaceInfoDetail.Info).ToString();

            //    //htmlStr.AppendLine(info);

            //    //Paragraph abc_new= new Paragraph(abc, font);
            //    Phrase gioithieu = new Phrase(@Resources.Language.Introduce, font);
            //    table_page2.AddCell(gioithieu);
            //    table_page2.AddCell("abc");
            //    document.Add(table_page2);

            //    //document.Add(image);//Add Image Avatar

            //    //document.Add(new Phrase("Địa chỉ: " + tmp.dlPlace.Address, font));

            //    //document.Add(new Phrase("Thành Phố: " + city_pdf_text, font));

            //}
            //catch (DocumentException de)
            //{
            //    Console.Error.WriteLine(de.Message);
            //}
            //catch (IOException ioe)
            //{
            //    Console.Error.WriteLine(ioe.Message);
            //}

            //document.Close();

            //stream.Flush(); //Always catches me out
            //stream.Position = 0; //Not sure if this is required

            //return File(stream, "application/pdf", "DownloadName.pdf");
            //    //return View();

        }
        
        public ActionResult Pdf_Post()
        {
            var client = new WebClient();
            string contents = client.DownloadString("http://localhost:62688/RazorPDF/pdf/54");
           
            string url="http://localhost:62688/RazorPDF/pdf/54";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();




            PDFFactory.GeneratePDF(result, "pdftest");
          
            return View();

        }
    }
}
    //public class ZingController : IAuthenticationClient
    //{
    //    public static string code;
    //    public static string access_token;
    //    private string clientId;
    //    private string clientSecret;
    //    private string scope;
    //    public ZingController(string clientId, string clientSecret, string scope)
    //    {
    //        this.clientId = clientId;
    //        this.clientSecret = clientSecret;
    //        this.scope = scope;
    //    }
 
    //    public string ProviderName
    //    {
    //        get { return "ZingMe"; }
    //    }
    //    public void RequestAuthentication(HttpContextBase context, Uri returnUrl)
    //    {
    //        //string url = HttpUtility.UrlEncode(returnUrl.ToString());
    //        var random = new Random();
    //        long number_ran = random.Next(1, 100000);
    //        string state = number_ran.ToString();
    //        ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
    //        string url_old = "http://localhost:62688";
    //        Uri uri_old = new Uri(url_old);
          
    //        string uri_new = uri_old.ToString();
    //        String url = oauth.getAuthorizedUrl(uri_new, "14103");

    //        context.Response.Redirect(url);
    //    }

    //    public AuthenticationResult VerifyAuthentication(HttpContextBase context)
    //    {
    //        code = context.Request.QueryString["code"];
    //        string signedRequestParam = context.Request.Params["signed_request"];
    //        //NameValueCollection pColl = context.Request.Params;
    //        //pColl.GetValue("signed_request");
    //        //pColl.GetKey(10);
    //        int expires = 0;       
           
    //        ZME_Authentication oauth = new ZME_Authentication(WebDuLichDev.RegisterAuthZing.config());
    //        access_token = oauth.getAccessTokenFromCode(code, out expires);
    //        ZME_Me me = new ZME_Me(WebDuLichDev.RegisterAuthZing.config());
    //        string id = "id";
    //        string username = "username";
    //        string gender = "gender";
    //        string dob = "dob";
    //        var user_data_id = me.getInfo(access_token,id);
    //        var user_data_username = me.getInfo(access_token, username);
    //        //ZME_User user = new ZME_User(WebDuLichDev.RegisterAuthZing.config());
    //        //user.getInfo(
    //        //Hashtable hashtable = new Hashtable();
    //        //hashtable = username_data;
    //        //foreach (DictionaryEntry entry in hashtable)
    //        //{
    //        //    Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
    //        //}

    //        //From this we need to remove code portion
    //        //rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", "");
    //        string rawUrl = context.Request.Url.ToString();
    //        //From this we need to remove code portion
    //        //rawUrl = Regex.Replace(rawUrl, "&code=[^&]*", "");

    //        //IDictionary<string, string> userData = GetUserData(code, rawUrl);

    //        //IDictionary<string, string> userData = username_data;
    //        string id_data = (string)user_data_id[id];
    //        string username_data = (string)user_data_username[username];
    //        if (id_data == null)
    //            return new AuthenticationResult(false, ProviderName, null, null, null);

           
    //        //userData.Remove("id");
    //        //userData.Remove("email");

    //        AuthenticationResult result = new AuthenticationResult(true, ProviderName, id_data, username_data, null);
    //        return result;
    //    }
    //    //private IDictionary<string, string> GetUserData(string accessCode, string redirectURI)
    //    //{
    //    //    string token = QueryAccessToken(redirectURI, accessCode);
    //    //    if (token == null || token == "")
    //    //    {
    //    //        return null;
    //    //    }
    //    //    var userData = GetUserData(token);
    //    //    return userData;
    //    //}
    //    //private IDictionary<string, string> GetUserData(string accessToken)
    //    //{
    //    //    ExtendedMicrosoftClientUserData graph;
    //    //    var request =
    //    //        WebRequest.Create(
    //    //            "https://apis.live.net/v5.0/me?access_token=" + EscapeUriDataStringRfc3986(accessToken));
    //    //    using (var response = request.GetResponse())
    //    //    {
    //    //        using (var responseStream = response.GetResponseStream())
    //    //        {
    //    //            using (StreamReader sr = new StreamReader(responseStream))
    //    //            {
    //    //                string data = sr.ReadToEnd();
    //    //                graph = JsonConvert.DeserializeObject<ExtendedMicrosoftClientUserData>(data);
    //    //            }
    //    //        }
    //    //    }

    //    //    var userData = new Dictionary<string, string>();
    //    //    userData.Add("id", graph.Id);
    //    //    userData.Add("username", graph.Name);
    //    //    userData.Add("name", graph.Name);
    //    //    userData.Add("link", graph.Link == null ? null : graph.Link.AbsoluteUri);
    //    //    userData.Add("gender", graph.Gender);
    //    //    userData.Add("firstname", graph.FirstName);
    //    //    userData.Add("lastname", graph.LastName);
    //    //    userData.Add("email", graph.Emails.Preferred);
    //    //    return userData;
    //    //}

    //    //private string QueryAccessToken(string returnUrl, string authorizationCode)
    //    //{
    //    //    var entity =
    //    //        CreateQueryString(
    //    //            new Dictionary<string, string> {
    //    //                { "client_id", this.clientId },
    //    //                { "redirect_uri", returnUrl },
    //    //                { "client_secret", this.clientSecret},
    //    //                { "code", authorizationCode },
    //    //                { "grant_type", "authorization_code" },
    //    //            });

    //    //    WebRequest tokenRequest = WebRequest.Create(tokenUrl);
    //    //    tokenRequest.ContentType = "application/x-www-form-urlencoded";
    //    //    tokenRequest.ContentLength = entity.Length;
    //    //    tokenRequest.Method = "POST";

    //    //    using (Stream requestStream = tokenRequest.GetRequestStream())
    //    //    {
    //    //        var writer = new StreamWriter(requestStream);
    //    //        writer.Write(entity);
    //    //        writer.Flush();
    //    //    }

    //    //    HttpWebResponse tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
    //    //    if (tokenResponse.StatusCode == HttpStatusCode.OK)
    //    //    {
    //    //        using (Stream responseStream = tokenResponse.GetResponseStream())
    //    //        {
    //    //            using (StreamReader sr = new StreamReader(responseStream))
    //    //            {
    //    //                string data = sr.ReadToEnd();
    //    //                var tokenData = JsonConvert.DeserializeObject<OAuth2AccessTokenData>(data);
    //    //                if (tokenData != null)
    //    //                {
    //    //                    return tokenData.AccessToken;
    //    //                }
    //    //            }
    //    //        }
    //    //    }

    //    //    return null;
    //    //}
    //    //private static readonly string[] UriRfc3986CharsToEscape = new[] { "!", "*", "'", "(", ")" };

    //    //private static string EscapeUriDataStringRfc3986(string value)
    //    //{
    //    //    StringBuilder escaped = new StringBuilder(Uri.EscapeDataString(value));

    //    //    // Upgrade the escaping to RFC 3986, if necessary.
    //    //    for (int i = 0; i < UriRfc3986CharsToEscape.Length; i++)
    //    //    {
    //    //        escaped.Replace(UriRfc3986CharsToEscape[i], Uri.HexEscape(UriRfc3986CharsToEscape[i][0]));
    //    //    }

    //    //    // Return the fully-RFC3986-escaped string.
    //    //    return escaped.ToString();
    //    //}

    //    //private static string CreateQueryString(IEnumerable<KeyValuePair<string, string>> args)
    //    //{
    //    //    if (!args.Any())
    //    //    {
    //    //        return string.Empty;
    //    //    }
    //    //    StringBuilder sb = new StringBuilder(args.Count() * 10);

    //    //    foreach (var p in args)
    //    //    {
    //    //        sb.Append(EscapeUriDataStringRfc3986(p.Key));
    //    //        sb.Append('=');
    //    //        sb.Append(EscapeUriDataStringRfc3986(p.Value));
    //    //        sb.Append('&');
    //    //    }
    //    //    sb.Length--; // remove trailing &

    //    //    return sb.ToString();
    //    //}
    //    protected class ExtendedMicrosoftClientUserData
    //    {
    //        public string FirstName { get; set; }
    //        public string Gender { get; set; }
    //        public string Id { get; set; }
    //        public string LastName { get; set; }
    //        public Uri Link { get; set; }
    //        public string Name { get; set; }
    //        public Emails Emails { get; set; }
    //    }

    //    protected class Emails
    //    {
    //        public string Preferred { get; set; }
    //        public string Account { get; set; }
    //        public string Personal { get; set; }
    //        public string Business { get; set; }
    //    }
 
    //}

    
