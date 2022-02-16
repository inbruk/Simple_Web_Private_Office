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
    public partial class User : System.Web.UI.Page
    {
        private Int32 GetActualUserId()
        {
            Int32 userId = 0;
            String userIdStr = Request.QueryString["userId"];
            if (userIdStr != null)
            {
                userId = Int32.Parse(userIdStr);
            }
            else
            {
                CurrUserInCookieData currUserData = AuthenticationInCookie.GetCurrentLoggedUser(Request);
                userId = currUserData.Id;
            }

            return userId;
        }

        private BL.DTO.User LoadProfileFromDB()
        {
            Int32 userId = GetActualUserId();
            BL.DTO.User currUser = BL.Tools.User.UserGetById(userId);
            return currUser;
        }

        private BL.DTO.Account LoadAccountFromDB()
        {
            Int32 userId = GetActualUserId();
            BL.DTO.Account currAccount = BL.Tools.User.AccountGetByUserId(userId);
            return currAccount;
        }

        private void LoadAndRefreshProfile()
        {
            BL.DTO.User currUser = LoadProfileFromDB();

            // помещаем в контролы
            txbLogin.Text = currUser.Login;
            txbPassword.Text = currUser.Password;
            cbxBlocked.Checked = currUser.Blocked;
            txbCreationDate.Text = currUser.CreationDate.ToString();
            txbFullName.Text = currUser.FullName;
            txbPassportNumber.Text = currUser.PassportNumber;
            txbAddress.Text = currUser.Address;
            txbHomePhone.Text = currUser.HomePhone;
            txbWorkPhone.Text = currUser.WorkPhone;
            txbMobilePhone.Text = currUser.MobilePhone;
            txbWebPage.Text = currUser.WebPage;
            txbICQ.Text = currUser.ICQ;
            txbEmail.Text = currUser.Email;
        }

        private void LoadAndRefreshAccount()
        {
            BL.DTO.Account currAccount = LoadAccountFromDB();

            // помещаем в контролы
            txbPersonalAccount.Text = currAccount.PersonalAccount.ToString();
            txbBalance.Text = currAccount.Balance.ToString();
            txbRecommendedPayment.Text = currAccount.RecommendedPayment.ToString();
            txbCredit.Text = currAccount.Credit.ToString();
        }

        private void GetValuesAndSaveProfile()
        {
            BL.DTO.User currUser = LoadProfileFromDB();

            currUser.Login = txbLogin.Text;
            currUser.Password = txbPassword.Text;
            currUser.FullName = txbFullName.Text;
            currUser.PassportNumber = txbPassportNumber.Text;
            currUser.Address = txbAddress.Text;
            currUser.HomePhone = txbHomePhone.Text;
            currUser.WorkPhone = txbWorkPhone.Text;
            currUser.MobilePhone = txbMobilePhone.Text;
            currUser.WebPage = txbWebPage.Text;
            currUser.ICQ = txbICQ.Text;
            currUser.Email = txbEmail.Text;

            BL.Tools.User.UserUpdate(currUser);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // если оказалось, что пользователь не залогинен, то автоматически переходим на страницу входа
            if (AuthenticationInCookie.IsUserLoggedIn(Request) == false)
            {
                Response.Redirect("Login.aspx");
            }

            // проверим, нужно ли показывать кнопку возврата на страницу Администратора
            String userIdStr = Request.QueryString["userId"];
            if (userIdStr != null)
            {
                btnGotoAdministrator.Visible = true;
            }
            else
            {
                btnGotoAdministrator.Visible = false;
            }

            if ( !this.IsPostBack ) // если первый раз, то обновляем интерфейс по данным
            {
                LoadAndRefreshProfile();
                LoadAndRefreshAccount();
            }
        }

        protected void btnProfileCancel_Click(object sender, EventArgs e)
        {
            LoadAndRefreshProfile();
            LoadAndRefreshAccount();
        }

        protected void btnProfileSave_Click(object sender, EventArgs e)
        {
            GetValuesAndSaveProfile();
            LoadAndRefreshAccount();
        }

        protected void btnGotoAdministrator_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrator.aspx");
        }
    }
}