using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Ref.HTML
{
   public class HTMLPages
    {
        public static string ErrorLoadingPage(string urlNotLoaded)
        {
            string pageText =
            "<!DOCTYPE html>" +
            "<html>" +
            "<head>" +
            "<title> Server Not Found</title>" +
            "</head>"+
            "<body>" +
            "<br>" +
            "<pre>" +
            "<h1 style='font-family:arial;'>  This site can't be reached !</h1>" +
            "<p style='font-size:18px; font-family:arial;'>         Please make sure that:  " + urlNotLoaded + "</p>" +
            "<p style='font-size:18px; font-family:arial;'>         is exist and safe and meets the Islamic Values.</p>" +
            "<hr>"+
            "<h3 style='font-family:arial;'>        You can also try to:</h3>" +
            "<p style='font-size:16px; font-family:arial;'>             -Try again later.</p>" +
            "<p style='font-size:16px; font-family:arial;'>             -Check network connection.</p>" +
            "<p style='font-size:16px; font-family:arial;'>             -Check the DNS and Firewall permission.</p>" +
            "</pre>" +
            "</body>" +
            "</html>";
           
            return pageText;
        }
        public static string HaramLoadingPage(string urlNotLoaded)
        {
            string pageText =
            "<!DOCTYPE html>" +
            "<html>" +
            "<head>" +
            "<title> Server Not Found</title>" +
            "</head>" +
            "<body>" +
            "<br>" +
            "<pre>" +
            "<h1 style='font-family:arial;'>  This site can't be reached !</h1>" +
            "<p style='font-size:18px; font-family:arial;'>         Please make sure that:  " + urlNotLoaded + "</p>" +
            "<p style='font-size:18px; font-family:arial;'>         is exist and safe and meets the Islamic Values.</p>" +
            "<hr>" +
            "<h3 style='font-family:arial;'>        You can also try to:</h3>" +
            "<p style='font-size:16px; font-family:arial;'>             -Try again later.</p>" +
            "<p style='font-size:16px; font-family:arial;'>             -Check network connection.</p>" +
            "<p style='font-size:16px; font-family:arial;'>             -Check the DNS and Firewall permission.</p>" +
            "</pre>" +
            "</body>" +
            "</html>";

            return pageText;
        }

    }
}
