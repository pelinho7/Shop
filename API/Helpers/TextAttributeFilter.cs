namespace API.Helpers
{
    public class TextAttributeFilter
    {
        public TextAttributeFilter()
        {
        }

        public TextAttributeFilter(int attributeId, string value)
        {
            AttributeId = attributeId;
            Value = value;
        }

        public int AttributeId { get; set; }
        public string Value { get; set; }
    }
}