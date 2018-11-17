using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppSDK.Managers.UiManager;
using BulmaUiManager;

namespace WebApp.Models.Ui
{
    public class UiService
    {
        public Layout build3()
        {
            Layout layout = new Layout("bm1");
            BM warpper = BM.Div("wpp22");
            layout.Components = warpper;
            var con = BM.Conainer().IsFluid().AddTo(ref warpper);
            var navStart = BM.Div("navbar-start").Add(
                BM.NavLink("/", "Home", "navbar-item"),
                BM.NavLink("/about", "About", "navbar-item"),
                BM.NavLink("/users", "Users", "navbar-item"),
                BM.NavLink("/reports", "Reports", "navbar-item"),
                BM.Div("navbar-item has-dropdown is-hoverable").Add(BM.NavLink("/more", "More", "navbar-link")).Add(BM.Div("navbar-dropdown")
                .Add(BM.NavLink("/messages", "Messages", "navbar-item"), BM.NavLink("/settings", "Settings", "navbar-item"), BM.NavLink("/ads", "Ads", "navbar-item"))));

            var navEnd = BM.Div("navbar-end").Add(
                BM.Div("navbar-item").Add(BM.Div("buttons").Add(
                    BM.NavLink("/notify", "Notifications").IsButton().IsPrimary(),
                    BM.NavLink("/logout", "Logout").IsButton().IsDanger()
                )));

            var nav = BM.Nav("logo.gif", "/", navStart, navEnd, "navMenubd-example");
            con += nav;

            var con2 = BM.Conainer();
            BM aside = BM.Menu();
            //var ul1 =  BM.Ul("menu-list");
            //ul1.Add(
            //    BM.Li().Add(BM.NavLink("/", "Dashboard")),
            //    BM.Li().Add(BM.NavLink("/About", "About")),
            //    BM.Li().Add(BM.NavLink("/today", "Today")),
            //    BM.Li().Add(BM.NavLink("/dynamic", "Dynamic Content"))
            //    );
            ////var ul2 = BM.Ul("menu-list").Add(
            ////    BM.Li().Add(BM.NavLink("/table", "Table")),
            ////    BM.Li().Add(BM.NavLink("/template", "Template")),
            ////    BM.Li().Add(BM.NavLink("/githubrepos", "Get github repos")),
            ////    BM.Li().Add(BM.NavLink("/invitations", "Invitations")),
            ////    BM.Li().Add(BM.NavLink("/authentication", "Authentication"))
            ////    ) as BM;
            ////var ul3 = BM.Ul("menu-list").Add(
            ////    BM.Li().Add(BM.NavLink("/payments", "Payments")),
            ////    BM.Li().Add(BM.NavLink("/transfers", "Transfers")),
            ////    BM.Li().Add(BM.NavLink("/balance", "Balance"))
            ////    ) as BM;
            //warpper += BM.Block().Add(con2);

            //aside.Add(BM.MenuGroup("GENERAL", ul1));
            //aside.Add(BM.MenuGroup("Forms", ul2));
            //aside.Add(BM.MenuGroup("TRANSACTIONS", ul3));

            var root = "http://localhost:52752/api/ui/"; //http://sdk1.azurewebsites.net

            BM routes = new BM(Tag.ERoutes);
            routes.AddRoute(root + "GetDashboard", "/");
            routes.AddRoute(root + "GetAbout", "/about");
            routes.AddRoute(root + "GetToday", "/today");
            routes.AddRoute(root + "GetDynamicContent", "/dynamic");
            routes.AddRoute(root + "GetGithubRepos", "/githubrepos");
            routes.AddRoute(root + "GetTable", "/table");
            routes.AddRoute(root + "GetTemplate", "/template");
            con2.Add(BM.Row().Add(BM.Col(2, 0).IsHiddenMobile().IsSidebarMenu().Add(aside), BM.Col(10, 12).IsMainContent().Add(routes)));

            return layout;
        }
    }
}