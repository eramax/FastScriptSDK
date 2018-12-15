using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UiBase<T> : IUI<T> where T : class , IUI<T>, new()
    {
        protected T Myself { get; set; } 
        public string Type { get; set; }
        public string Key { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UiVariable> Vars { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PropList Props { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Prop Contents { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PropList Events { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Childerns { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TemplateLoader Loader { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RepeatWith { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UiFunction> Validators { get; set; }

        public static T New(string _Tag, string _Classes = null, string _Id = null, string _Content = null)
        {
            var ui = new T
            {
                Type = _Tag,
                Key = System.Guid.NewGuid().ToString("N").Substring(0, 10)
            };
            if (_Id != null) ui.AddProp("id", _Id);

            if (_Content != null) ui.AddContent(_Content);
            if (_Classes != null) ui.AddProp("className", _Classes);
            return ui;
        }
        public T AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null , string _Index = null)
        {
            Myself.Props = Myself.Props ?? new PropList();
            Myself.Props.AddProp(_PropName, _PropValue, _PropValueFunc, _Index);
            return Myself;
        }
        public T AddContent(object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null)
        {
            Myself.Contents = Myself.Contents ?? new Prop();
            Myself.Contents.Set(_PropValue, _PropValueFunc, _Index);
            return Myself;
        }
        public T AddEvent(string _EventName, object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null)
        {
            Myself.Events = Myself.Events ?? new PropList();
            Myself.Events.AddProp(_EventName, _PropValue, _PropValueFunc, _Index);
            return Myself;
        }
        public T AddValidator(UiFunction func)
        {
            Validators = Validators ?? new List<UiFunction>();
            Validators.Add(func);
            return Myself;
        }
        public T Add(T t)
        {
            Myself.Childerns = Myself.Childerns ??  new List<T>();
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

        public T Id(string value = null , UiFunction  fun = null , string index = null )
        { return AddProp("id", value, fun , index); }
        public T Class(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("className", value, fun, index); }
        public T type(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("type", value, fun, index); }
        public T name(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("name", value, fun, index); }
        public T Value(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("value", value, fun, index); }
        public T Content(string value = null, UiFunction fun = null, string index = null)
        { return AddContent(value, fun, index); }
        public T href(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("href", value, fun, index); }
        public T action(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("action", value, fun, index); }
        public T to(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("to", value, fun, index); }
        public T alt(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("alt", value, fun, index); }
        public T width(int? value = null, UiFunction fun = null, string index = null)
        { return AddProp("width", value, fun, index); }
        public T height(int? value = null, UiFunction fun = null, string index = null)
        { return AddProp("height", value, fun, index); }
        public T activeClassName(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("activeClassName", value, fun, index); }
        public T src(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("src", value, fun, index); }
        public T For(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("for", value, fun, index); }
        public T placeholder(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("placeholder", value, fun, index); }
        public T method(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("method", value, fun, index); }
        public T max(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("max", value, fun, index); }
        public T colspan(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("colspan", value, fun, index); }
        public T cols(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("cols", value, fun, index); }
        public T rows(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("rows", value, fun, index); }

        public T hidden() { return AddProp("hidden", true); }
        public T disabled() { return AddProp("disabled", true); }
        public T role(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("role", true); }

        public T aria_label(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("aria-label", true); }

        public T aria_expanded(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("aria-expanded", true); }

        public T data_target(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("data-target", true); }

        public T aria_hidden(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("aria-hidden", true); }

        public T exact() { return AddProp("exact", true); }
        public T selected() { return AddProp("selected", "selected"); }

        public T AddRoute(string action, string link, params string[] vars)
        { return AddProp("Routes", new XRoute(action, link, vars)); }

        //--------------------------------------- Events ---------------------------------//
        public T OnClick(UiFunction ufunc) { return AddEvent("OnClickFunc", null, ufunc); }
        public T OnChange(UiFunction ufunc) { return AddEvent("OnChangeFunc", null, ufunc); }


        //--------------------------------------- Templating ---------------------------------//
        public T LinkedVar(string propname, string var)
        { return AddProp(propname, null, new UiFunction("getVar", null, var)); }

        public T HideIf(string var = null, UiFunction func = null)
        { return AddProp("HideIf", null, func, var); }

        public T ShowIf(string var = null, UiFunction func = null)
        { return AddProp("ShowIf", null, func, var); }

        public T RepeatFor(string listName)
        {
            RepeatWith = listName;
            return Myself;
        }

        public T Include(string templateName, string link = null)
        {
            Loader = new TemplateLoader() { Name = templateName, Link = link };
            return Myself;
        }

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
            { return New(Tag.input, classes).type(type).name(name).Value(value).placeholder(placeholder); }

            public static T Label(string content, string classes = null)
            { return New(Tag.label, classes, null, content); }

            public static T Li(string classes = null) { return New(Tag.li, classes); }

            public static T Nav(string classes = null) { return New(Tag.nav, classes); }

            public static T Option(string content, string value, string classes = null)
            { return New(Tag.option, classes, null, content).Value(value); }

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
