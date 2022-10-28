using System.Collections.Generic;

namespace API.Helpers
{
    public class CheckboxAttributeFilter
    {
        public CheckboxAttributeFilter()
        {
        }

        public CheckboxAttributeFilter(int attributeId, bool equal)
        {
            AttributeId = attributeId;
            Equal = equal;
        }

        public int AttributeId { get; set; }
        public bool Equal { get; set; }
        public List<string> Values { get; set; }=new List<string>();
    }
}