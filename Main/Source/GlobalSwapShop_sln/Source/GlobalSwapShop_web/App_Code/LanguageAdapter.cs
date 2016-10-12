using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;



/// <summary>
/// Summary description for LanguageAdapter
/// </summary>
public class LanguageAdapter
{
	public LanguageAdapter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void setPageLanguage(Page page, string language)
    {
        //object strObj = HttpContext.Current.Session["GSS_LANGUAGE"];

        //string language = "en-us";

        //string language = list.SelectedValue.ToLowerInvariant().Trim();

        //if (strObj != null)
        //{
        //    language = strObj.ToString().ToLowerInvariant().Trim();
        //}
        //else
        //{
        //    string[] languages = HttpContext.Current.Request.UserLanguages;

        //    if (languages != null && languages.Length != 0)
        //    {
        //        language = languages[0].ToLowerInvariant().Trim();
        //    }
        //}

        page.UICulture = language;
        page.Culture = language;

        Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(language);
        Thread.CurrentThread.CurrentUICulture = new
            CultureInfo(language);
    }
}