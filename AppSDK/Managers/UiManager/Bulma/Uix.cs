using System;
using System.Linq;
using AppSDK.Managers.UiManager.XLib;

namespace AppSDK.Managers.UiManager.Bulma
{
    public class Uix : UiBase<Uix>
    {
        public static Uix operator +(Uix left, Uix right)
        {
            left.Add(right);
            return left;
        }

        public Uix Is(int x, UiFunction func = null) { return AddProp("className", "is-" + x, func); }

        public Uix IsDesktop(string x, UiFunction func = null)
        { return AddProp("className", "is-desktop", func); }

        public Uix IsMobile(string x, UiFunction func = null)
        { return AddProp("className", "is-mobile", func); }

        public Uix Mobile(int x, UiFunction func = null)
        { return AddProp("className", "is-" + x + "-mobile", func); }

        public Uix Tablet(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-tablet", func); }

        public Uix Desktop(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-desktop", func); }

        public Uix Wide(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-widescreen", func); }

        public Uix FullHD(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-fullhd", func); }

        public Uix IsFluid() { return AddProp("className", "is-fluid"); }

        public Uix IsRight() { return AddProp("className", "is-right"); }
        public Uix IsLeft() { return AddProp("className", "is-left"); }

        public Uix IsCentered() { return AddProp("className", "is-centered"); }
        public Uix IsHalf() { return AddProp("className", "is-half"); }
        public Uix IsMultiline() { return AddProp("className", "is-multiline"); }
        public Uix IsNarrow() { return AddProp("className", "is-narrow"); }

        public Uix IsSmall() { return AddProp("className", "is-small"); }
        public Uix IsMedium() { return AddProp("className", "is-medium"); }
        public Uix IsLarge() { return AddProp("className", "is-large"); }

        public Uix IsWhite() { return AddProp("className", "is-white"); }
        public Uix IsLight() { return AddProp("className", "is-light"); }
        public Uix IsDark() { return AddProp("className", "is-dark"); }
        public Uix IsBlack() { return AddProp("className", "is-black"); }
        public Uix IsLink() { return AddProp("className", "is-link"); }

        public Uix IsPrimary() { return AddProp("className", "is-primary"); }
        public Uix IsInfo() { return AddProp("className", "is-info"); }
        public Uix IsSuccess() { return AddProp("className", "is-success"); }
        public Uix IsWarning() { return AddProp("className", "is-warning"); }
        public Uix IsDanger() { return AddProp("className", "is-danger"); }

        public Uix IsOutlined() { return AddProp("className", "is-outlined"); }
        public Uix IsInverted() { return AddProp("className", "is-inverted"); }

        public Uix IsButton() { return AddProp("className", "button"); }
        public Uix IsHovered() { return AddProp("className", "is-hovered"); }
        public Uix IsFocused() { return AddProp("className", "is-focused"); }
        public Uix IsActive() { return AddProp("className", "is-active"); }
        public Uix IsLoading() { return AddProp("className", "is-loading"); }

        public Uix IsSidebarMenu() { return AddProp("className", "is-sidebar-menu"); }
        public Uix IsHiddenMobile() { return AddProp("className", "is-hidden-mobile"); }
        public Uix IsMainContent() { return AddProp("className", "is-main-content"); }

        public Uix IsNavItem() { return AddProp("className", "nav-item"); }
        public Uix IsNavMenu() { return AddProp("className", "nav-menu"); }

        public Uix IsMenuList() { return AddProp("className", "menu-list"); }

        public class BMTags
        {
            public static Uix Div(string classes = null, string content = null)
            { return New(Tag.div, classes, null, content); }

            public static Uix Conainer(string classes = null) { return New(Tag.div, "container" + classes); }

            public static Uix Row(string classes = null) { return New(Tag.div, "columns" + classes); }

            public static Uix Col(int desktop, int mobile, string classes = null)
            {
                return New(Tag.div, "column").Mobile(mobile).Desktop(desktop)
                      .Wide(desktop).FullHD(desktop).Tablet(mobile);
            }

            public static Uix Section(string classes = null) { return New(Tag.section, "section" + classes); }

            public static Uix Buttun(string classes = null, string content = null)
            { return New(Tag.button, "button" + classes, null, content); }

            public static Uix AButtun(string classes = null, string content = null)
            { return New(Tag.a, "button" + classes, null, content); }

            public static Uix P(string content = null) { return New(Tag.p, "content", null, content); }

            public static Uix TD(string content = null, string classes = null)
            { return New(Tag.td, classes, null, content); }

            public static Uix TR(string classes = null) { return New(Tag.tr, classes); }

            public static Uix Box(string classes = null) { return New(Tag.div, "box" + classes); }

            public static Uix Notification(string content = null)
            { return New(Tag.p, "notification", null, content).Add(Buttun("delete")); }

            public static Uix tag(string content) { return New(Tag.span, "tag", null, content); }

            public static Uix Article(string title, string content)
            { return New(Tag.article, "message").Add(Div("message-header", title), Div("message-body", content)); }

            public static Uix Img(string link, string alt, int width, int height)
            { return New(Tag.img).src(link).width(width).height(height).alt(alt); }

            public static Uix Span(string classes = null) { return New(Tag.span, classes); }

            public static Uix Nav(string brandImage, string brandLink, Uix left, Uix right, string navid)
            {
                var ar = New(Tag.nav, "navbar");
                var d1 = Div("navbar-brand");
                d1 += NavLink(brandLink).Class("navbar-item").Add(Img(brandImage, "image", 112, 28));
                d1 += New(Tag.a, "navbar-burger burger")
                    .LinkedVar("is-active", navid).OnClick(new UiFunction() { FuncName = "toggle", Paramaters = new[] { navid } })
                    .aria_label("menu").role("button").aria_expanded("false").data_target(navid).AddVar(navid, false)
                    .Add(Span().aria_hidden("true"), Span().aria_hidden("true"), Span().aria_hidden("true"));

                var d2 = New(Tag.div, "navbar-menu", navid).LinkedVar("is-active", navid)
                    .Add(Conainer().Add(Row().Add(Col(5, 12).Add(left), Col(5, 12).Add(right))));
                ar += d1;
                ar += d2;
                return ar;
            }

            public static Uix Menu() { return New(Tag.aside, "menu"); }

            public static Uix MenuGroup(string label, Uix ul)
            { return Div().Add(New(Tag.p, "menu-label", null, label), ul.IsMenuList()); }

            public static Uix NavLink(string link, string content = null, string classes = null)
            { return New(Tag.NavLink, classes, null, content).to(link).activeClassName("is-active").exact(); }

            public static Uix H1(string content = null) { return New(Tag.h1, "title", null, content).Is(1); }
            public static Uix H2(string content = null) { return New(Tag.h1, "title", null, content).Is(2); }
            public static Uix H3(string content = null) { return New(Tag.h1, "title", null, content).Is(3); }
            public static Uix H4(string content = null) { return New(Tag.h1, "title", null, content).Is(4); }
            public static Uix H5(string content = null) { return New(Tag.h1, "title", null, content).Is(5); }
            public static Uix H(int size, string content = null)
            { return New(Tag.h1, "title", null, content).Is(size); }

            public static Uix Block() { return New(Tag.div, "block"); }

            public static Uix Label(string content, string classes = null)
            { return New(Tag.label, classes + "label", null, content); }

            public static Uix Control() { return New(Tag.div, "control"); }

            public static Uix Field(string label, string inputid, string _type = "text", string placeholder = null)
            {
                return New(Tag.div, "field").Add(Label(label), Control()
                    .Add(Tags.Input(inputid, _type, placeholder).AddVar(inputid, String.Empty)));
            }
            public static Uix Table(Uix[] trs, params string[] threads)
            {
                var ths = threads.ToList().Select(i => New(Tag.th, null, null, i));
                var tb = New(Tag.table, "table is-bordered is-striped is-hoverable is-fullwidth")
                    .Add(New(Tag.thead).Add(New(Tag.tr).Add(ths.ToArray())));
                tb.Add(New(Tag.tbody).Add(trs));
                return tb;
            }
            public static Uix Table(Uix template, params string[] threads)
            {
                var ths = threads.ToList().Select(i => New(Tag.th, null, null, i));
                var tb = New(Tag.table, "table is-bordered is-striped is-hoverable is-fullwidth")
                    .Add(New(Tag.thead).Add(New(Tag.tr).Add(ths.ToArray())));
                tb.Add(New(Tag.tbody).Add(template));
                return tb;
            }
            public static Uix Template(string classes = null) { return New(Tag.Template, classes); }

        }
    }
    public class TT
    {
        public TT()
        {
            Uix.New("div").action("dasda").activeClassName("dadasd").alt("fsfdsf").aria_label("fafsf");
            var c = Uix.Tags.A().action("daasdasda").cols("sadsf").data_target("fsfs");
            c.Add(Uix.BMTags.AButtun("dasdasd").cols("fsfd")).aria_expanded("fsfs");
            

        }
    }
}
