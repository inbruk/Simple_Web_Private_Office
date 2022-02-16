using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;

using BL = BusinessLogicLayer;

namespace PresentationLayer.Auxiliary
{
    public class CurrUserInCookieData
    {
        public Int32 Id { get; }
        public String Login { get; }
        public Int32 Type { get; }

        public CurrUserInCookieData(String idStr, String login, String typeStr)
        {
            Id = Int32.Parse(idStr);
            Login = login;
            Type = Int32.Parse(typeStr);
        }
    }

    public static class AuthenticationInCookie
    {
        public static void LogIn( HttpResponse Response, BL.DTO.User currUser )
        {
            HttpCookie CurrentUserCookie = new HttpCookie("CurrentUser");
            CurrentUserCookie["Id"] = currUser.Id.ToString();
            CurrentUserCookie["Login"] = currUser.Login;
            CurrentUserCookie["Type"] = currUser.Type.ToString();
            CurrentUserCookie.Expires.Add( new TimeSpan(0, 15, 0) );
            Response.Cookies.Add(CurrentUserCookie);
        }

        public static void LogOff(HttpRequest Request, HttpResponse Response)
        {
            if (Request.Cookies["CurrentUser"] != null)
            {
                HttpCookie currentUserCookie = new HttpCookie("CurrentUser");
                currentUserCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(currentUserCookie);
            }
        }

        public static bool IsUserLoggedIn(HttpRequest Request)
        {
            HttpCookie currentUserCookie = Request.Cookies["CurrentUser"];
            if (currentUserCookie == null)
                return false;
            else
                return true;
        }

        public static CurrUserInCookieData GetCurrentLoggedUser(HttpRequest Request)
        {
            HttpCookie currentUserCookie = Request.Cookies["CurrentUser"];
            if (currentUserCookie == null)
            {
                throw new Exception("Вы пытаетесь получить данные пользователя, когда он не залогинен");
            }

            CurrUserInCookieData result = new CurrUserInCookieData(
                currentUserCookie["Id"], currentUserCookie["Login"], currentUserCookie["Type"] );

            return result;
        }
    }
}