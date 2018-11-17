using AppSDK.Managers.UiManager;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BulmaUiManager
{
    public class BM : Ui, IUiManager<BM>
    {
        public BM(string tag, string classes = null, string _id = null, string content = null)
              : base(tag, classes, _id, content)
        {
        }
        public BM AddTo(ref BM t)
        {
            if (t.Childerns == null) t.Childerns = new List<Ui>();
            t.Childerns.Add(this);
            return this;
        }
        public static BM operator +(BM left, BM right)
        {
            if (left.Childerns == null) left.Childerns = new List<Ui>();
            left.Childerns.Add(right);
            return left;
        }
        public BM Add(params BM[] t)
        {
            if (Childerns == null) Childerns = new List<Ui>();
            if (t != null) Childerns.AddRange(t);
            return this;
        }
        public BM Is(int x, UiFunction func = null) { return AddProp("className", "is-" + x, func) as BM; }

        public BM IsDesktop(string x, UiFunction func = null)
        { return AddProp("className", "is-desktop", func) as BM; }

        public BM IsMobile(string x, UiFunction func = null)
        { return AddProp("className", "is-mobile", func) as BM; }

        public BM Mobile(int x, UiFunction func = null)
        { return AddProp("className", "is-" + x + "-mobile", func) as BM; }

        public BM Tablet(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-tablet", func) as BM; }

        public BM Desktop(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-desktop", func) as BM; }

        public BM Wide(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-widescreen", func) as BM; }

        public BM FullHD(int x, UiFunction func = null)
        { return AddProp("className", " is-" + x + "-fullhd", func) as BM; }

        public BM IsFluid() { return AddProp("className", "is-fluid") as BM; }

        public BM IsRight() { return AddProp("className", "is-right") as BM; }
        public BM IsLeft() { return AddProp("className", "is-left") as BM; }

        public BM IsCentered() { return AddProp("className", "is-centered") as BM; }
        public BM IsHalf() { return AddProp("className", "is-half") as BM; }
        public BM IsMultiline() { return AddProp("className", "is-multiline") as BM; }
        public BM IsNarrow() { return AddProp("className", "is-narrow") as BM; }

        public BM IsSmall() { return AddProp("className", "is-small") as BM; }
        public BM IsMedium() { return AddProp("className", "is-medium") as BM; }
        public BM IsLarge() { return AddProp("className", "is-large") as BM; }

        public BM IsWhite() { return AddProp("className", "is-white") as BM; }
        public BM IsLight() { return AddProp("className", "is-light") as BM; }
        public BM IsDark() { return AddProp("className", "is-dark") as BM; }
        public BM IsBlack() { return AddProp("className", "is-black") as BM; }
        public BM IsLink() { return AddProp("className", "is-link") as BM; }

        public BM IsPrimary() { return AddProp("className", "is-primary") as BM; }
        public BM IsInfo() { return AddProp("className", "is-info") as BM; }
        public BM IsSuccess() { return AddProp("className", "is-success") as BM; }
        public BM IsWarning() { return AddProp("className", "is-warning") as BM; }
        public BM IsDanger() { return AddProp("className", "is-danger") as BM; }

        public BM IsOutlined() { return AddProp("className", "is-outlined") as BM; }
        public BM IsInverted() { return AddProp("className", "is-inverted") as BM; }

        public BM IsButton() { return AddProp("className", "button") as BM; }
        public BM IsHovered() { return AddProp("className", "is-hovered") as BM; }
        public BM IsFocused() { return AddProp("className", "is-focused") as BM; }
        public BM IsActive() { return AddProp("className", "is-active") as BM; }
        public BM IsLoading() { return AddProp("className", "is-loading") as BM; }

        public BM IsSidebarMenu() { return AddProp("className", "is-sidebar-menu") as BM; }
        public BM IsHiddenMobile() { return AddProp("className", "is-hidden-mobile") as BM; }
        public BM IsMainContent() { return AddProp("className", "is-main-content") as BM; }

        public BM IsNavItem() { return AddProp("className", "nav-item") as BM; }
        public BM IsNavMenu() { return AddProp("className", "nav-menu") as BM; }

        public BM IsMenuList() { return AddProp("className", "menu-list") as BM; }


        //------------------------------ Tags ------------------------------------/
        public static BM Div(string classes = null, string content = null)
        { return new BM(Tag.div, classes, null, content); }

        public static BM Conainer(string classes = null) { return new BM(Tag.div, "container" + classes); }

        public static BM Row(string classes = null) { return new BM(Tag.div, "columns" + classes); }

        public static BM Col(int desktop, int mobile, string classes = null)
        { return new BM(Tag.div, "column").Mobile(mobile).Desktop(desktop)
                .Wide(desktop).FullHD(desktop).Tablet(mobile);
        }

        public static BM Section(string classes = null) { return new BM(Tag.section, "section" + classes); }

        public static BM Buttun(string classes = null, string content = null)
        { return new BM(Tag.button, "button" + classes, null, content); }

        public static BM AButtun(string classes = null, string content = null)
        { return new BM(Tag.a, "button" + classes, null, content); }

        public static BM P(string content = null) { return new BM(Tag.p, "content", null, content); }

        public static BM TD(string content = null, string classes = null)
        { return new BM(Tag.td, classes, null, content); }

        public static BM TR(string classes = null) { return new BM(Tag.tr, classes); }

        public static BM Box(string classes = null) { return new BM(Tag.div, "box" + classes); }

        public static BM Notification(string content = null)
        { return new BM(Tag.p, "notification", null, content).Add(Buttun("delete")); }

        public static BM tag(string content) { return new BM(Tag.span, "tag", null, content); }

        public static BM Article(string title, string content)
        { return new BM(Tag.article, "message").Add(Div("message-header", title), Div("message-body", content)); }

        public static BM Img(string link, string alt, int width, int height)
        { return new BM(Tag.img).src(link).width(width).height(height).alt(alt) as BM; }

        public new static BM Span(string classes = null) { return new BM(Tag.span, classes); }

        public static BM Nav(string brandImage, string brandLink, BM left, BM right, string navid)
        {
            var ar = new BM(Tag.nav, "navbar") as BM;
            var d1 = Div("navbar-brand");
            d1 += NavLink(brandLink).Class("navbar-item").Add(Img(brandImage, "image", 112, 28)) as BM;
            d1 += new BM(Tag.a, "navbar-burger burger")
                .LinkedVar("is-active", navid).OnClick(new UiFunction() { FuncName = "toggle", Paramaters = new[] { navid } })
                .aria_label("menu").role("button").aria_expanded("false").data_target(navid).AddVar(navid , false)
                .Add(Span().aria_hidden("true"), Span().aria_hidden("true"), Span().aria_hidden("true")) as BM;

            var d2 = new BM(Tag.div, "navbar-menu", navid).LinkedVar("is-active", navid)
                .Add(Conainer().Add(Row().Add(Col(5, 12).Add(left), Col(5, 12).Add(right)))) as BM;
            ar += d1;
            ar += d2;
            return ar;
        }

        public static BM Menu() { return new BM(Tag.aside, "menu"); }

        public static BM MenuGroup(string label, BM ul)
        { return Div().Add(new BM(Tag.p, "menu-label", null, label), ul.IsMenuList()); }

        public static BM NavLink(string link, string content = null, string classes = null)
        { return new BM(Tag.NavLink, classes, null, content).to(link).activeClassName("is-active").exact() as BM; }

        public new static BM H1(string content = null) { return new BM(Tag.h1, "title", null, content).Is(1); }
        public new static BM H2(string content = null) { return new BM(Tag.h1, "title", null, content).Is(2); }
        public new static BM H3(string content = null) { return new BM(Tag.h1, "title", null, content).Is(3); }
        public new static BM H4(string content = null) { return new BM(Tag.h1, "title", null, content).Is(4); }
        public new static BM H5(string content = null) { return new BM(Tag.h1, "title", null, content).Is(5); }
        public static BM H(int size, string content = null)
        { return new BM(Tag.h1, "title", null, content).Is(size); }

        public static BM Block() { return new BM(Tag.div, "block"); }

        public new static BM Label(string content, string classes = null)
        { return new BM(Tag.label, classes + "label", null, content); }

        public static BM Control() { return new BM(Tag.div, "control"); }

        public static BM Field(string label, string inputid, string _type = "text", string placeholder = null)
        {
            return new BM(Tag.div, "field").Add(Label(label), Control()
                .Add(Input(inputid, _type, placeholder).AddVar(inputid,String.Empty))) as BM;
        }
        public static BM Table(BM[] trs, params string[] threads)
        {
            var ths = threads.ToList().Select(i => new BM(Tag.th, null, null, i));
            var tb = new BM(Tag.table, "table is-bordered is-striped is-hoverable is-fullwidth")
                .Add(new BM(Tag.thead).Add(new BM(Tag.tr).Add(ths.ToArray())));
            tb.Add(new BM(Tag.tbody).Add(trs));
            return tb;
        }
        public static BM Table(BM template, params string[] threads)
        {
            var ths = threads.ToList().Select(i => new BM(Tag.th, null, null, i));
            var tb = new BM(Tag.table, "table is-bordered is-striped is-hoverable is-fullwidth")
                .Add(new BM(Tag.thead).Add(new BM(Tag.tr).Add(ths.ToArray())));
            tb.Add(new BM(Tag.tbody).Add(template));
            return tb;
        }
        public static BM Template(string classes = null) { return new BM(Tag.Template, classes); }
    }
}
