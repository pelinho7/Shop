namespace API.Helpers
{
    public class NumberAttributeFilter
    {
        public NumberAttributeFilter()
        {
        }

        public NumberAttributeFilter(int attributeId, bool greaterThen, double value)
        {
            AttributeId = attributeId;
            GreaterThen = greaterThen;
            Value = value;
        }

        public int AttributeId { get; set; }
        public bool GreaterThen { get; set; }
        public double Value { get; set; }
    }
}