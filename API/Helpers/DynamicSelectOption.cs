namespace API.Helpers
{
    public class DynamicSelectOption
    {
        public DynamicSelectOption()
        {
        }

        public DynamicSelectOption(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public int Value { get; set; }
    }
}