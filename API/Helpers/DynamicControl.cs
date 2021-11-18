using System.Collections.Generic;

namespace API.Helpers
{
    public class DynamicControl
    {
        public DynamicControl()
        {
        }

        public DynamicControl(string name, string type, object value, List<DynamicSelectOption> selectOptions)
        {
            Name = name;
            Type = type;
            this.value = value;
            SelectOptions = selectOptions;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public object value { get; set; }
        public List<DynamicSelectOption> SelectOptions { get; set; }=new List<DynamicSelectOption>();
    }
}