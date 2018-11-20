using System.Collections.Generic;
namespace AppSDK.Managers.UiManager.XLib
{
    public interface IUI<T>
    { 
        string Type { get; set; }
        string Key { get; set; }
        List<UiVariable> Vars { get; set; }
        Dictionary<string, Prop> Props { get; set; }
        List<T> Childerns { get; set; }
        T AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null);
        T UpdateProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null);
        T Add(params T[] t);
        T Add(T t);
        T AddTo(ref T t);
        T AddVar(string x, object init = null);

        T Id(string x);
        T Class(string x);
        T type(string x);
        T name(string x);
        T value(string x);
        T href(string x);
        T action(string x);
        T to(string x);
        T alt(string x);
        T width(int x);
        T height(int x);
        T activeClassName(string x);
        T src(string x);
        T For(string x);
        T placeholder(string x);
        T method(string x);
        T max(string x);
        T colspan(string x);
        T cols(string x);
        T rows(string x);

        T hidden();
        T disabled();
        T role(string x);
        T aria_label(string x);
        T aria_expanded(string x);
        T data_target(string x);
        T aria_hidden(string x);
        T exact();
        T selected();

        T AddRoute(string action, string link, params string[] vars);

        T OnClick(UiFunction ufunc);
        T OnChange(UiFunction ufunc);
        T LinkedVar(string propname, string var);
    }
}
