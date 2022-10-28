namespace API.Helpers
{
    public class DefaultParamFilter
    {
        public DefaultParamFilter(DefaultFilterParamEnum type, bool greaterThen, double value)
        {
            Type = type;
            GreaterThen = greaterThen;
            Value = value;
        }

        public DefaultFilterParamEnum Type { get; set; }
        public bool GreaterThen { get; set; }
        public double Value { get; set; }
    }
}