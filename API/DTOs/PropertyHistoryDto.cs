namespace API.DTOs
{
    public class PropertyHistoryDto
    {
        public PropertyHistoryDto()
        {
        }

        public PropertyHistoryDto(string name, string oldValue)
        {
            Name = name;
            OldValue = oldValue;
        }
        public PropertyHistoryDto(string name, string oldValue, string newValue)
        {
            Name = name;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string Name { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}