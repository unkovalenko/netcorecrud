using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AnyASP.Models
{
    public interface IJsConfig
    {
        CfgItem GetParam(string name);
        bool? GetBoolParam(string name);
        int? GetIntParam(string name);
        string GetStrParam(string name);
        bool Exists(string name);
        bool SetConfigLine(string line);
    }

    public class  CfgItem
    {
        public string Name { get; set; }
        public bool? Bval { get; set; }
        public int? Ival { get; set; }
        public string Sval { get; set; }

    }
  
        public class CfgParameters
    {
        public CfgItem[] CfgItems { get; set; }
    }

    public class EJsConfig : IJsConfig
    {
        public CfgParameters Parameters;

        public bool SetConfigLine(string line)
        {
            try
            {
                Parameters =  JsonConvert.DeserializeObject<CfgParameters>(line);
                
                return true;
            }
            catch
            {
                return false;
            }

        }

        public CfgItem GetParam(string name)
        {
            if (Parameters == null)
            {
                return null;
            }
            foreach (CfgItem item in Parameters.CfgItems)
            {
                if (item.Name == name)
                {
                    return item;
                }                
            }
            return null;
        }

        public bool? GetBoolParam(string name)
        {
            CfgItem item = GetParam(name);
            if (item != null)
            {
                return item.Bval;
            }
            return null;
        }

        public int? GetIntParam(string name)
        {
            CfgItem item = GetParam(name);
            if (item != null)
            {
                return item.Ival;
            }
            return null;
        }

        public string GetStrParam(string name)
        {
            CfgItem item = GetParam(name);
            if (item != null)
            {
                return item.Sval;
            }
            return "";
        }

        public bool Exists(string name)
        {
            return GetParam(name) != null;
        }
    } 

}
