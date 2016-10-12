<%@ WebHandler Language="C#" Class="imageHandler" %>

using System;
using System.Web;

public class imageHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Expires = -1;
        
        if (context.Request.QueryString["id"] != null)
        {
            byte[] buffer = (byte[])HttpRuntime.Cache[context.Request.QueryString["id"]];
            if (buffer != null)
            {
                context.Response.BinaryWrite(buffer);
                context.Response.ContentType = "image/JPEG";
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}