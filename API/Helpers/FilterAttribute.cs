using System.Collections.Generic;

namespace API.Helpers
{
    public class FilterAttribute
    {
        public FilterAttribute()
        {
        }

        public FilterAttribute(string label, string type, List<DynamicControl> dynamicControls)
        {
            Label = label;
            Type = type;
            DynamicControls = dynamicControls;
        }

        public string Label { get; set; }
        public string Type { get; set; }
        public List<DynamicControl> DynamicControls { get; set; }
    }
}