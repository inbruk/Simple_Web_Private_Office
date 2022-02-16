using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL = BusinessLogicLayer;
using PresentationLayer.Auxiliary;

namespace PresentationLayer
{
    public partial class Administrator : System.Web.UI.Page
    {
        private BL.DTO.User LoadProfileFromDB()
        {
            CurrUserInCookieData currUserData = AuthenticationInCookie.GetCurrentLoggedUser(Request);
            BL.DTO.User currUser = BL.Tools.Administrator.AdministratorGetById(currUserData.Id);
            return currUser;
        }

        private List<BL.DTO.UserAccountUserType> LoadUsersListFromDB()
        {
            List<BL.DTO.UserAccountUserType> result = 
                BL.Tools.Administrator.ServiceUsageGetByTypeId( BL.DTO.UserTypeEnum.User, false );
            return result;
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

        private void LoadAndRefreshUsersList()
        {
            List<BL.DTO.UserAccountUserType> _internalData = LoadUsersListFromDB();
            gvUsersList.DataSource = _internalData;
            gvUsersList.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // если оказалось, что пользователь не залогинен, то автоматически переходим на страницу входа
            if (AuthenticationInCookie.IsUserLoggedIn(Request) == false)
            {
                Response.Redirect("Login.aspx");
            }

            if (!this.IsPostBack) // если первый раз, то обновляем интерфейс по данным
            {
                LoadAndRefreshProfile();
                LoadAndRefreshUsersList();
            }
        }

        protected void btnProfileCancel_Click(object sender, EventArgs e)
        {
            LoadAndRefreshProfile();
            LoadAndRefreshUsersList();
        }

        protected void btnProfileSave_Click(object sender, EventArgs e)
        {
            GetValuesAndSaveProfile();
            LoadAndRefreshUsersList();
        }

        protected void gvUsersList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            List<BL.DTO.UserAccountUserType> _internalData = LoadUsersListFromDB();
            BL.DTO.UserAccountUserType dataRow = _internalData[e.NewEditIndex];
            Response.Redirect("User.aspx?userId=" + dataRow.UserId);
        }
    }
}