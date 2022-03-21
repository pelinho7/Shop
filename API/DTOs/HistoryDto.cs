using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class HistoryDto
    {
        public int ObjectId { get; set; }
        public int Type { get; set; }//0 create 1 mod 2 delete
        public DateTime Moddate { get; set; }
        public string ModtimeString { get; set; }
        public string ModdateString { get; set; }
        public List<PropertyHistoryDto> PropertiesHistory { get; set; }
    }
}