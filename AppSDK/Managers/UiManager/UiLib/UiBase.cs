using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UiBase<T> : IUiComponent where T : class, IUiComponent, new()
    {
        protected T Myself { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public PropList Props { get; set; }       
        public Prop Contents { get; set; }       
        public Dictionary<string, List<UiFunction>> Events { get; set; }       
        public List<IUiComponent> Childerns { get; set; }       
        public string RepeatWith { get; set; }        
        public TemplateLoader Loader { get; set; }
        public string Disabled { get; set; }  


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
        public T AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null)
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
        public T AddEvent(string _EventName, UiFunction _PropValueFunc)
        {
            Myself.Events = Myself.Events ?? new Dictionary<string, List<UiFunction>>();
            if (!Myself.Events.ContainsKey(_EventName))
                Myself.Events.Add(_EventName, new List<UiFunction>());
            Myself.Events[_EventName].Add(_PropValueFunc);
            return Myself;
        }
        public T Add(T t)
        {
            Myself.Childerns = Myself.Childerns ?? new List<IUiComponent>();
            Myself.Childerns.Add(t);
            return Myself;
        }
        public T Add(params T[] t)
        {
            if (Myself.Childerns == null) Myself.Childerns = new List<IUiComponent>();
            Myself.Childerns.AddRange(t);
            return Myself;
        }
        public T AddTo(ref T t)
        {
            if (t.Childerns == null) t.Childerns = new List<IUiComponent>();
            t.Childerns.Add(Myself);
            return Myself;
        }

        void IUiComponent.AddProp(string _PropName, object _PropValue, UiFunction _PropValueFunc, string _Index)
        {
            this.AddProp(_PropName, _PropValue, _PropValueFunc, _Index);
        }

        void IUiComponent.AddEvent(string _EventName, UiFunction _PropValueFunc)
        {
            this.AddEvent(_EventName, _PropValueFunc);
        }

        void IUiComponent.AddContent(object _PropValue, UiFunction _PropValueFunc, string _Index)
        {
            this.AddContent(_PropValue, _PropValueFunc, _Index);
        }

        //--------------------------------------- ATRUBUITES ---------------------------------//

        public T Id(string value = null, UiFunction fun = null, string index = null)
        { return AddProp("id", value, fun, index); }
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


        //--------------------------------------- Events ---------------------------------//
        public T OnClick(UiFunction ufunc) { return AddEvent("onClick", ufunc); }
        public T OnChange(UiFunction ufunc) { return AddEvent("onChange", ufunc); }


        //--------------------------------------- Templating ---------------------------------//

        public T RepeatFor(string listName)
        {
            RepeatWith = listName;
            return Myself;
        }

        public T Import(string templateName, string link = null)
        {
            var LoaderTag = New(Tag.Loader);
            LoaderTag.Loader = new TemplateLoader() { Name = templateName };
            if (link == null) LoaderTag.Loader.LoadFromPartials = templateName;
            Add(LoaderTag);
            return Myself;
        }


    }
}
