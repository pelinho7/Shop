using System.Collections.Generic;

namespace API.Helpers
{
    public class DynamicControl
    {
        public DynamicControl()
        {
        }

        public DynamicControl(string name, string label, object value, List<DynamicSelectOption> selectOptions)
        {
            Name = name;
            Label = label;
            this.value = value;
            SelectOptions = selectOptions;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public object value { get; set; }
        public List<DynamicSelectOption> SelectOptions { get; set; }=new List<DynamicSelectOption>();
    }
}