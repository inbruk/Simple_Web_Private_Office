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
        public partial class Login : System.Web.UI.Page
        {
            private void RedirectToInternalPages()
            {
            CurrUserInCookieData currUserData = AuthenticationInCookie.GetCurrentLoggedUser(Request);

            if (currUserData.Type == (int)BL.DTO.UserTypeEnum.User)
            {
                Response.Redirect("User.aspx");
            }
            else if (currUserData.Type == (int)BL.DTO.UserTypeEnum.Administrator)
            {
                Response.Redirect("Administrator.aspx");
            }
            else
            {
                throw new Exception("Залогинился пользователь неподдерживаемого типа !");
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // если оказалось, что пользователь уже залогинен, то автоматически переходим на внутренние страницы
            if ( AuthenticationInCookie.IsUserLoggedIn(Request)==true )
            {
                RedirectToInternalPages();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String login = txbLogin.Text;
            String password = txbPassword.Text;
            BL.DTO.User currUser = null;
            try
            {
                currUser = BL.Tools.Login.LogIn(login, password);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Введеные логин и пароль не соответствуют ни одному незаблокированному пользователю системы !", this.Page, this);
                return;
            }

            AuthenticationInCookie.LogIn(Response, currUser);
            RedirectToInternalPages(); // после логина переходим на внутренние страницы
        }
    }
}   