using System.Collections.Generic;
namespace AppSDK.Managers.UiManager.XLib
{
    public interface IUI<T>
    { 
        string Type { get; set; }
        string Key { get; set; }
        List<UiVariable> Vars { get; set; }
        PropList Props { get; set; }
        Prop Contents { get; set; }
        PropList Events { get; set; }
        List<T> Childerns { get; set; }
        string RepeatWith { get; set; }
        T AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null);
        T AddEvent(string _EventName, object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null);
        T AddContent(object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null);
        T Add(params T[] t);
        T Add(T t);
        T AddTo(ref T t);
        T AddVar(string x, object init = null);

        T Id(string value = null , UiFunction  fun = null , string index = null );
        T Class(string value = null , UiFunction  fun = null , string index = null );
        T type(string value = null , UiFunction  fun = null , string index = null );
        T name(string value = null , UiFunction  fun = null , string index = null );
        T Value(string value = null , UiFunction  fun = null , string index = null );
        T Content(string value = null, UiFunction fun = null, string index = null);
        T href(string value = null , UiFunction  fun = null , string index = null );
        T action(string value = null , UiFunction  fun = null , string index = null );
        T to(string value = null , UiFunction  fun = null , string index = null );
        T alt(string value = null , UiFunction  fun = null , string index = null );
        T width(int? value = null, UiFunction fun = null, string index = null);
        T height(int? value = null, UiFunction fun = null, string index = null);
        T activeClassName(string value = null , UiFunction  fun = null , string index = null );
        T src(string value = null , UiFunction  fun = null , string index = null );
        T For(string value = null , UiFunction  fun = null , string index = null );
        T placeholder(string value = null , UiFunction  fun = null , string index = null );
        T method(string value = null , UiFunction  fun = null , string index = null );
        T max(string value = null , UiFunction  fun = null , string index = null );
        T colspan(string value = null , UiFunction  fun = null , string index = null );
        T cols(string value = null , UiFunction  fun = null , string index = null );
        T rows(string value = null , UiFunction  fun = null , string index = null );

        T hidden();
        T disabled();
        T role(string value = null , UiFunction  fun = null , string index = null );
        T aria_label(string value = null , UiFunction  fun = null , string index = null );
        T aria_expanded(string value = null , UiFunction  fun = null , string index = null );
        T data_target(string value = null , UiFunction  fun = null , string index = null );
        T aria_hidden(string value = null , UiFunction  fun = null , string index = null );
        T exact();
        T selected();

        T AddRoute(string action, string link, params string[] vars);

        T OnClick(UiFunction ufunc);
        T OnChange(UiFunction ufunc);
        T LinkedVar(string propname, string var);
        T RepeatFor(string listName);
        T Include(string templateName, string link = null);
        T AddValidator(UiFunction func);
        T HideIf(string var = null, UiFunction func = null);
        T ShowIf(string var = null, UiFunction func = null);
    }
}
