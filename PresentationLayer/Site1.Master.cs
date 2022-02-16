using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL = BusinessLogicLayer;
using PresentationLayer.Auxiliary;

namespace PresentationLayer
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool loggedIn = AuthenticationInCookie.IsUserLoggedIn(Request);

            // если оказалось, что пользователь не залогинен, то дизаблим кнопку выхода, иначе активируем
            // отслеживание на какой странице можно находиться будет внутри плейс холдеров
            btnLogout.Enabled = loggedIn;

            // пользователь залогинен нужно выставить головок, тип и логин пользователя
            if (loggedIn == true)
            {
                CurrUserInCookieData currUserData = AuthenticationInCookie.GetCurrentLoggedUser(Request);
                if (currUserData.Type == (int)BL.DTO.UserTypeEnum.User)
                {
                    lblTitle.Text = "Онлайн кабинет пользователя";
                    lblUser.Text = "Пользователь " + currUserData.Login;
                }
                else if (currUserData.Type == (int)BL.DTO.UserTypeEnum.Administrator)
                {
                    lblTitle.Text = "Онлайн кабинет администратора";
                    lblUser.Text = "Администратор " + currUserData.Login;
                }
                else
                {
                    throw new Exception("Залогинился пользователь неподдерживаемого типа !");
                }
            }
            else
            {
                lblTitle.Text = "Онлайн кабинет";
                lblUser.Text = "Пользователь еще не вошел";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthenticationInCookie.LogOff(Request,Response);
            Response.Redirect("Login.aspx");
        }
    }
}