﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UiFunction
    {
        public string FuncName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<FunctionParameter> Paramaters { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UiFunction> NextFuncs { get; set; }
        public UiFunction(string name)
        {
            FuncName = name;
        }
        public UiFunction AddParameter(string _PropName, object _DefaultValue = null, string _Index = null , bool _SendByRef = false)
        {
            Paramaters = Paramaters ?? new List<FunctionParameter>();
            Paramaters.Add(new FunctionParameter() { ParameterName = _PropName, DefaultVal = _DefaultValue, Index = _Index,SendByRefence=_SendByRef });
            return this; 
        }
    }
}
