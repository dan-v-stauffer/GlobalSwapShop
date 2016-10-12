using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlobalSwapShop;

public partial class AddItem : GlobalPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(upAvatarTrigger);

        if (Session["addItemImage"] != null)
        {
            if (Session["addItemImage"].ToString() != "")
            {
                this.imgUserAvatar.ImageUrl = Session["addItemImage"].ToString();

            }
        }
    }

    System.Object
findControl(System.Web.UI.ControlCollection collection, String controlID)
    {
        System.Object returnValue = null;

        foreach (System.Web.UI.Control ctl in collection)
        {
            if (ctl.ID == controlID)
            {
                returnValue = ctl;
                break;
            }
            if (ctl.Controls.Count > 0)
                returnValue = findControl(ctl.Controls, controlID);

            if (returnValue != null)
                return returnValue;
        }

        return returnValue;

    }
    protected void AddItemClick(object sender, EventArgs e)
    {

    }
}