using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UiBase<T> : IUI<T> where T : IUI<T>, new()
    {
        private T Myself = new T();
        public string Type { get; set; }
        public string Key { get; set; }
        public List<UiVariable> Vars { get; set; }
        public Dictionary<string, Prop> Props { get; set; }
        public List<T> Childerns { get; set; }
        public static T New(string _Tag, string _Classes = null, string _Id = null, string _Content = null)
        {
            var ui = new T
            {
                Type = _Tag,
                Key = System.Guid.NewGuid().ToString("N").Substring(0, 10)
            };
            if (_Id != null) ui.AddProp("id", _Id);

            if (_Content != null) ui.AddProp("Content", _Content);
            if (_Classes != null) ui.AddProp("className", _Classes);
            return ui;
        }
        public T AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null)
        {
            if (Myself.Props == null) Myself.Props = new Dictionary<string, Prop>();
            if (!Myself.Props.ContainsKey(_PropName)) Myself.Props.Add(_PropName, new Prop());

            if (_PropValue != null)
            {
                if (Myself.Props[_PropName].PropValues == null) Myself.Props[_PropName].PropValues = new List<object>();
                Myself.Props[_PropName].PropValues.Add(_PropValue);
            }

            if (_PropValueFunc != null)
            {
                if (Myself.Props[_PropName].PropValueFuncs == null) Myself.Props[_PropName].PropValueFuncs = new List<UiFunction>();
                Myself.Props[_PropName].PropValueFuncs.Add(_PropValueFunc);
            }
            return Myself;
        }
        public T UpdateProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null)
        {
            if (Myself.Props == null) Myself.Props = new Dictionary<string, Prop>();
            if (!Myself.Props.ContainsKey(_PropName)) Myself.Props.Add(_PropName, new Prop());

            if (_PropValue != null)
            {
                if (Myself.Props[_PropName].PropValues == null) Myself.Props[_PropName].PropValues = new List<object>();
                Myself.Props[_PropName].PropValues.Add(_PropValue);
            }

            if (_PropValueFunc != null)
            {
                if (Myself.Props[_PropName].PropValueFuncs == null) Myself.Props[_PropName].PropValueFuncs = new List<UiFunction>();
                Myself.Props[_PropName].PropValueFuncs.Add(_PropValueFunc);
            }
            return Myself;
        }
        public T Add(T t)
        {
            if (Myself.Childerns == null) Myself.Childerns = new List<T>();
            Myself.Childerns.Add(t);
            return Myself;
        }
        public T Add(params T[] t)
        {
            if (Myself.Childerns == null) Myself.Childerns = new List<T>();
            Myself.Childerns.AddRange(t);
            return Myself;
        }



        public T AddTo(ref T t)
        {
            t.Add(Myself);
            return Myself;
        }

        public T AddVar(string x, object init = null)
        {
            if (Myself.Vars == null) Myself.Vars = new List<UiVariable>();
            Myself.Vars.Add(new UiVariable() { VarName = x, VarInit = init });
            return Myself;
        }



        //--------------------------------------- ATRUBUITES ---------------------------------//
        public T Id(string x) { return AddProp("id", x); }
        public T Class(string x) { return AddProp("className", x); }
        public T type(string x) { return AddProp("type", x); }
        public T name(string x) { return AddProp("name", x); }
        public T value(string x) { return AddProp("value", x); }
        public T href(string x) { return AddProp("href", x); }
        public T action(string x) { return AddProp("action", x); }
        public T to(string x) { return AddProp("to", x); }
        public T alt(string x) { return AddProp("alt", x); }
        public T width(int x) { return AddProp("width", x); }
        public T height(int x) { return AddProp("height", x); }
        public T activeClassName(string x) { return AddProp("activeClassName", x); }
        public T src(string x) { return AddProp("src", x); }
        public T For(string x) { return AddProp("for", x); }
        public T placeholder(string x) { return AddProp("placeholder", x); }
        public T method(string x) { return AddProp("method", x); }
        public T max(string x) { return AddProp("max", x); }
        public T colspan(string x) { return AddProp("colspan", x); }
        public T cols(string x) { return AddProp("cols", x); }
        public T rows(string x) { return AddProp("rows", x); }

        public T hidden() { return AddProp("hidden", true); }
        public T disabled() { return AddProp("disabled", true); }
        public T role(string x) { return AddProp("role", true); }
        public T aria_label(string x) { return AddProp("aria-label", true); }
        public T aria_expanded(string x) { return AddProp("aria-expanded", true); }
        public T data_target(string x) { return AddProp("data-target", true); }
        public T aria_hidden(string x) { return AddProp("aria-hidden", true); }
        public T exact() { return AddProp("exact", true); }
        public T selected() { return AddProp("selected", "selected"); }

        public T AddRoute(string action, string link, params string[] vars)
        { return AddProp("Routes", new XRoute(action, link, vars)); }

        public T OnClick(UiFunction ufunc) { return AddProp("OnClickFunc", null, ufunc); }
        public T OnChange(UiFunction ufunc) { return AddProp("OnChangeFunc", null, ufunc); }
        public T LinkedVar(string propname, string var)
        { return AddProp(propname, null, new UiFunction() { FuncName = "getVar", Paramaters = new[] { var } }); }

        public class Tags
        {
            public static T A(string href = null, string classes = null) => New(Tag.a, classes).href(href);
            public static T Br(string classes = null) { return New(Tag.br, classes); }

            public static T Button(string classes = null, string content = null, UiFunction ufunc = null)
            { return New(Tag.button, classes, null, content).OnClick(ufunc); }

            public static T Code(string classes = null, string content = null)
            { return New(Tag.code, classes, null, content); }

            public static T Div(string classes = null) { return New(Tag.div, classes); }

            public static T Form(string action = null, string classes = null, string id = null)
            { return New(Tag.form, classes, id).action(action); }

            public static T H1(string content = null) { return New(Tag.h1, null, content); }
            public static T H2(string content = null) { return New(Tag.h2, null, content); }
            public static T H3(string content = null) { return New(Tag.h3, null, content); }
            public static T H4(string content = null) { return New(Tag.h4, null, content); }
            public static T H5(string content = null) { return New(Tag.h5, null, content); }

            public static T Header(string classes = null) { return New(Tag.header, classes); }

            public static T Hr() { return New(Tag.hr); }

            public static T I(string content = null, string classes = null)
            { return New(Tag.i, classes, null, content); }

            public static T Img(string src, string alt, string classes = null)
            { return New(Tag.img, classes).src(src).alt(alt); }

            public static T Input(string type, string classes = null, string name = null, string value = null, string placeholder = null)
            { return New(Tag.input, classes).type(type).name(name).value(value).placeholder(placeholder); }

            public static T Label(string content, string classes = null)
            { return New(Tag.label, classes, null, content); }

            public static T Li(string classes = null) { return New(Tag.li, classes); }

            public static T Nav(string classes = null) { return New(Tag.nav, classes); }

            public static T Option(string content, string value, string classes = null)
            { return New(Tag.option, classes, null, content).value(value); }

            public static T P(string content, string classes = null)
            { return New(Tag.p, classes, null, content); }

            public static T Select(string classes = null) { return New(Tag.select, classes); }

            public static T Span(string classes = null) { return New(Tag.span, classes); }

            public static T Table(string classes = null) { return New(Tag.table, classes); }

            public static T Tbody(string classes = null) { return New(Tag.tbody, classes); }

            public static T Td(string content = null, string classes = null)
            { return New(Tag.td, classes, null, content); }

            public static T TextArea(string classes = null) { return New(Tag.textarea, classes); }

            public static T Tfoot(string classes = null) { return New(Tag.tfoot, classes); }

            public static T Th(string content = null, string classes = null)
            { return New(Tag.th, classes, null, content); }

            public static T Thead(string classes = null) { return New(Tag.thead, classes); }

            public static T Tr(string classes = null) { return New(Tag.tr, classes); }

            public static T Ul(string classes = null) { return New(Tag.ul, classes); }

            public static T Article(string classes = null) { return New(Tag.article, classes); }

            public static T Aside(string classes = null) { return New(Tag.aside, classes); }

            public static T Footer(string classes = null) { return New(Tag.footer, classes); }

            public static T Address(string content = null, string classes = null)
            { return New(Tag.address, classes, null, content); }

            public static T Bold(string content = null, string classes = null)
            { return New(Tag.b, classes, null, content); }

            public static T Blockquote(string content = null, string classes = null)
            { return New(Tag.blockquote, classes, null, content); }

            public static T Em(string content = null, string classes = null)
            { return New(Tag.em, classes, null, content); }

            public static T Canvas(string classes = null) { return New(Tag.canvas, classes); }

            public static T Caption(string content = null, string classes = null)
            { return New(Tag.caption, classes, null, content); }

            public static T Colgroup(string classes = null) { return New(Tag.colgroup, classes); }

            public static T Col(string classes = null) { return New(Tag.col, classes); }

            public static T Fieldset(string classes = null) { return New(Tag.fieldset, classes); }

            public static T Legend(string content = null, string classes = null)
            { return New(Tag.legend, classes, null, content); }

            public static T Main(string classes = null) { return New(Tag.main, classes); }

            public static T Progress(string classes = null) { return New(Tag.progress, classes); }

            public static T Q(string content = null, string classes = null)
            { return New(Tag.q, classes, null, content); }

            public static T Small(string content = null, string classes = null)
            { return New(Tag.small, classes, null, content); }

            public static T Strong(string content = null, string classes = null)
            { return New(Tag.strong, classes, null, content); }

            public static T U(string content = null, string classes = null)
            { return New(Tag.u, classes, null, content); }
        }
    }
}
