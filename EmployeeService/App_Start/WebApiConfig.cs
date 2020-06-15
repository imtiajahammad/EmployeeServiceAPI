using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiContrib.Formatting.Jsonp;

namespace EmployeeService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ///Indent Xml Data
            ///
            /*
            config.Formatters.XmlFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            */




            ///returning raw data indebted 
            ///
            /*
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            */


            ///returning raw data in Camel Case instead of Pascal Case
            ///
            /*
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            */


            ///If you want to only send json format, ignoring whatever accept type in the request header, you need to use this.
            ///            
            /*config.Formatters.Remove(config.Formatters.XmlFormatter);*/



            ///If you want to only send xml format, ignoring whatever accept type in the request header, you need to use this.
            ///
            /*
            config.Formatters.Remove(config.Formatters.JsonFormatter);
            */


            /// How to  return JSON instead of XML from asp.net web api service when a request is made from the browser
            /// approach 1
            /*config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));*/



            /// How to  return JSON instead of XML from asp.net web api service when a request is made from the browser
            /// approach 2
            /*config.Formatters.Add(new CustomJsonFormatter());*/



            /// How to  return csv instead of XML from asp.net web api service when a request is made from the browser
            /// http://www.tugberkugurlu.com/archive/creating-custom-csvmediatypeformatter-in-asp-net-web-api-for-comma-separated-values-csv-format



            ///to api being called from different domain in jsonp way
            /// to use this jsonp way, i need to change the dataType of ajax api call
            /*var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);*/


            ///to api being called from different domain in cors way
            ///you can also use cors for specific controller OR for specific action method in a controller
            /*EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:50883,http://pragimtech.com,*","Content-Type,*","GET,POST,*");*/
            /*EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:50883","*","*");
            config.EnableCors(cors);*/
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            /// to redirect uri with http to uri with https 
            /// class RequireHttpsAttribute is written only for this purpose
            /// also you can do this work without putting it in here, and put this inFrontOf controller/acition
            ///config.Filters.Add(new RequireHttpsAttribute());


        }
    }
    ///this whole class CustomJsonFormatter is to implement-
    /// How to  return JSON instead of XML from asp.net web api service when a request is made from the browser
    /// approach 2
    /*public class CustomJsonFormatter : JsonMediaTypeFormatter
    {
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }*/
}
