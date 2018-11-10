using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager
{
    public class Ui
    {
        public string Type;
        public string Key;
        public List<UiVariable> Vars { get; set; }
        public Dictionary<string, Prop> Props { get; set; }
        public List<Ui> Childerns { get; set; }
        public Ui(string _Tag, string _Classes = null, string _Id = null, string _Content = null)
        {
            Type = _Tag;
            Key = System.Guid.NewGuid().ToString("N").Substring(0, 10);
            if(_Id != null) AddProp("id", _Id);
            if (_Content != null) AddProp("Content", _Content);
            if (_Classes != null) AddProp("className", _Classes);
        }
        public Ui AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null)
        {
            if (Props == null) this.Props = new Dictionary<string, Prop>();
            if (!Props.ContainsKey(_PropName)) Props.Add(_PropName, new Prop());

            if (_PropValue != null)
            {
                if (Props[_PropName].PropValues == null) Props[_PropName].PropValues = new List<object>();
                Props[_PropName].PropValues.Add(_PropValue);
            }

            if (_PropValueFunc != null)
            {
                if (Props[_PropName].PropValueFuncs == null) Props[_PropName].PropValueFuncs = new List<UiFunction>();
                Props[_PropName].PropValueFuncs.Add(_PropValueFunc);
            }
            return this;
        }
        public Ui UpdateProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null)
        {
            if (Props == null) this.Props = new Dictionary<string, Prop>();
            if (!Props.ContainsKey(_PropName)) Props.Add(_PropName, new Prop());

            if (_PropValue != null)
            {
                if (Props[_PropName].PropValues == null) Props[_PropName].PropValues = new List<object>();
                Props[_PropName].PropValues.Add(_PropValue);
            }

            if (_PropValueFunc != null)
            {
                if (Props[_PropName].PropValueFuncs == null) Props[_PropName].PropValueFuncs = new List<UiFunction>();
                Props[_PropName].PropValueFuncs.Add(_PropValueFunc);
            }
            return this;
        }
        public Ui Add(params Ui[] t)
        {
            if (Childerns == null) Childerns = new List<Ui>();
            Childerns.AddRange(t);
            return this;
        }
        public Ui Add(Ui t)
        {
            if (Childerns == null) Childerns = new List<Ui>();
            Childerns.Add(t);
            return this;
        }

        public static Ui operator +(Ui left, Ui right)
        {
            left.Add(right);
            return left;
        }

        public Ui addTo(ref Ui t)
        {
            t.Add(this);
            return this;
        }

        public Ui AddVar(string x, object init = null)
        {
            if (Vars == null) Vars = new List<UiVariable>();
            Vars.Add(new UiVariable() { VarName = x, VarInit = init });
            return this;
        }
        public Ui Id(string x) { return AddProp("id", x); }
        public Ui Class(string x) { return AddProp("className", x); }
        public Ui type(string x) { return AddProp("type", x); }
        public Ui name(string x) { return AddProp("name", x); }
        public Ui value(string x) { return AddProp("value", x); }
        public Ui href(string x) { return AddProp("href", x); }
        public Ui action(string x) { return AddProp("action", x); }
        public Ui to(string x) { return AddProp("to", x); }
        public Ui alt(string x) { return AddProp("alt", x); }
        public Ui width(int x) { return AddProp("width", x); }
        public Ui height(int x) { return AddProp("height", x); }
        public Ui activeClassName(string x) { return AddProp("activeClassName", x); }
        public Ui src(string x) { return AddProp("src", x); }
        public Ui For(string x) { return AddProp("for", x); }
        public Ui placeholder(string x) { return AddProp("placeholder", x); }
        public Ui method(string x) { return AddProp("method", x); }
        public Ui max(string x) { return AddProp("max", x); }
        public Ui colspan(string x) { return AddProp("colspan", x); }
        public Ui cols(string x) { return AddProp("cols", x); }
        public Ui rows(string x) { return AddProp("rows", x); }

        public Ui hidden() { return AddProp("hidden", true); }
        public Ui disabled() { return AddProp("disabled", true); }
        public Ui role(string x) { return AddProp("role", true); }
        public Ui aria_label(string x) { return AddProp("aria-label", true); }
        public Ui aria_expanded(string x) { return AddProp("aria-expanded", true); }
        public Ui data_target(string x) { return AddProp("data-target", true); }
        public Ui aria_hidden(string x) { return AddProp("aria-hidden", true); }
        public Ui exact() { return AddProp("exact", true); }
        public Ui selected() { return AddProp("selected", "selected"); }

        public Ui AddRoute(string action, string link, params string[] vars)
        { return AddProp("Routes", new XRoute(action, link, vars)); }

        public Ui OnClick(UiFunction ufunc) { return AddProp("OnClickFunc", null, ufunc); }
        public Ui OnChange(UiFunction ufunc) { return AddProp("OnChangeFunc", null, ufunc); }
        public Ui LinkedVar(string propname, string var)
        { return AddProp(propname, null, new UiFunction() { FuncName = "getVar", Paramaters = new[] { var } }); }

        //------------------------------ Tags ------------------------------------/
        public static Ui A(string href = null, string classes = null) { return new Ui(Tag.a, classes).href(href); }

        public static Ui Br(string classes = null) { return new Ui(Tag.br, classes); }

        public static Ui Button(string classes = null, string content = null, UiFunction ufunc = null)
        { return new Ui(Tag.button, classes, null, content).OnClick(ufunc); }

        public static Ui Code(string classes = null, string content = null)
        { return new Ui(Tag.code, classes, null, content); }

        public static Ui Div(string classes = null) { return new Ui(Tag.div, classes); }

        public static Ui Form(string action = null, string classes = null, string id = null)
        { return new Ui(Tag.form, classes, id).action(action); }

        public static Ui H1(string content = null) { return new Ui(Tag.h1, null, content); }
        public static Ui H2(string content = null) { return new Ui(Tag.h2, null, content); }
        public static Ui H3(string content = null) { return new Ui(Tag.h3, null, content); }
        public static Ui H4(string content = null) { return new Ui(Tag.h4, null, content); }
        public static Ui H5(string content = null) { return new Ui(Tag.h5, null, content); }

        public static Ui Header(string classes = null) { return new Ui(Tag.header, classes); }

        public static Ui Hr() { return new Ui(Tag.hr); }

        public static Ui I(string content = null, string classes = null)
        { return new Ui(Tag.i, classes, null, content); }

        public static Ui Img(string src, string alt, string classes = null)
        { return new Ui(Tag.img, classes).src(src).alt(alt); }

        public static Ui Input(string type, string classes = null, string name = null, string value = null, string placeholder = null)
        { return new Ui(Tag.input, classes).type(type).name(name).value(value).placeholder(placeholder); }

        public static Ui Label(string content, string classes = null)
        { return new Ui(Tag.label, classes, null, content); }

        public static Ui Li(string classes = null) { return new Ui(Tag.li, classes); }

        public static Ui Nav(string classes = null) { return new Ui(Tag.nav, classes); }

        public static Ui Option(string content, string value, string classes = null)
        { return new Ui(Tag.option, classes, null, content).value(value); }

        public static Ui P(string content, string classes = null)
        { return new Ui(Tag.p, classes, null, content); }

        public static Ui Select(string classes = null) { return new Ui(Tag.select, classes); }

        public static Ui Span(string classes = null) { return new Ui(Tag.span, classes); }

        public static Ui Table(string classes = null) { return new Ui(Tag.table, classes); }

        public static Ui Tbody(string classes = null) { return new Ui(Tag.tbody, classes); }

        public static Ui Td(string content = null, string classes = null)
        { return new Ui(Tag.td, classes, null, content); }

        public static Ui TextArea(string classes = null) { return new Ui(Tag.textarea, classes); }

        public static Ui Tfoot(string classes = null) { return new Ui(Tag.tfoot, classes); }

        public static Ui Th(string content = null, string classes = null)
        { return new Ui(Tag.th, classes, null, content); }

        public static Ui Thead(string classes = null) { return new Ui(Tag.thead, classes); }

        public static Ui Tr(string classes = null) { return new Ui(Tag.tr, classes); }

        public static Ui Ul(string classes = null) { return new Ui(Tag.ul, classes); }

        public static Ui Article(string classes = null) { return new Ui(Tag.article, classes); }

        public static Ui Aside(string classes = null) { return new Ui(Tag.aside, classes); }

        public static Ui Footer(string classes = null) { return new Ui(Tag.footer, classes); }

        public static Ui Address(string content = null, string classes = null)
        { return new Ui(Tag.address, classes, null, content); }

        public static Ui Bold(string content = null, string classes = null)
        { return new Ui(Tag.b, classes, null, content); }

        public static Ui Blockquote(string content = null, string classes = null)
        { return new Ui(Tag.blockquote, classes, null, content); }

        public static Ui Em(string content = null, string classes = null)
        { return new Ui(Tag.em, classes, null, content); }

        public static Ui Canvas(string classes = null) { return new Ui(Tag.canvas, classes); }

        public static Ui Caption(string content = null, string classes = null)
        { return new Ui(Tag.caption, classes, null, content); }

        public static Ui Colgroup(string classes = null) { return new Ui(Tag.colgroup, classes); }

        public static Ui Col(string classes = null) { return new Ui(Tag.col, classes); }

        public static Ui Fieldset(string classes = null) { return new Ui(Tag.fieldset, classes); }

        public static Ui Legend(string content = null, string classes = null)
        { return new Ui(Tag.legend, classes, null, content); }

        public static Ui Main(string classes = null) { return new Ui(Tag.main, classes); }

        public static Ui Progress(string classes = null) { return new Ui(Tag.progress, classes); }

        public static Ui Q(string content = null, string classes = null)
        { return new Ui(Tag.q, classes, null, content); }

        public static Ui Small(string content = null, string classes = null)
        { return new Ui(Tag.small, classes, null, content); }

        public static Ui Strong(string content = null, string classes = null)
        { return new Ui(Tag.strong, classes, null, content); }

        public static Ui U(string content = null, string classes = null)
        { return new Ui(Tag.u, classes, null, content); }
    }
}
