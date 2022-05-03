using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using API.DTOs;
using API.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public class CreateHistoryService : ICreateHistoryService
    {
        private readonly ILogger<CreateHistoryService> logger;

        public CreateHistoryService(ILogger<CreateHistoryService> logger)
        {
            this.logger = logger;
        }

        public List<HistoryDto> CreateHistory<T>(List<IGrouping<int, T>> groupedData, int timezone, string location)
        {
            List<string> specialPropList = new List<string>(){
                "Deleted",
                "ModDate"
            };
            PropertyInfo deletedProp = null, modDateProp = null;
            //get type of data
            Type objectType = typeof(T);
            var allPropertyList = objectType.GetProperties().ToList();
            List<(string, PropertyInfo)> propertyToHistoryList = new List<(string, PropertyInfo)>();
            //get only property with DisplayNameAttribute
            for (int i = allPropertyList.Count - 1; i >= 0; i--)
            {
                if (Attribute.IsDefined(allPropertyList[i], typeof(System.ComponentModel.DisplayNameAttribute)))
                {
                    var name = allPropertyList[i].GetCustomAttribute<System.ComponentModel.DisplayNameAttribute>().DisplayName;
                    propertyToHistoryList.Add((name, allPropertyList[i]));
                }
                else if (allPropertyList[i].Name == "Deleted")
                {
                    deletedProp = allPropertyList[i];
                }
                else if (allPropertyList[i].Name == "ModDate")
                {
                    modDateProp = allPropertyList[i];
                }
                else
                {
                    allPropertyList.RemoveAt(i);
                }
            }

            List<HistoryDto> historyList = new List<HistoryDto>();
            foreach (var group in groupedData)
            {
                //list of all modification of current object
                var objectList = group.Select(x => x).ToList();
                for (int j = 0; j < objectList.Count; j++)
                {
                    HistoryDto history = new HistoryDto();
                    history.ObjectId = group.Key;
                    history.Moddate = ((DateTime)modDateProp.GetValue(objectList[j])).AddHours(timezone);
                    var dateTimeString=history.Moddate.ToString(new CultureInfo(location));
                    history.ModdateString = dateTimeString.Split(new char[]{' '})[0];//history.Moddate.ToString(new CultureInfo(location));
                    history.ModtimeString=dateTimeString.Substring(history.ModdateString.Length).Trim();
                    //define type of operation
                    if (j == 0)
                    {
                        history.Type = 0;//creation
                    }
                    else
                    {
                        if (((bool)deletedProp.GetValue(objectList[j])) == true)
                        {
                            history.Type = 2;
                            //continue;
                        }
                        else
                        {
                            history.Type = 1;//modify
                        }
                    }

                    List<PropertyHistoryDto> historyOfPropertiesList = new List<PropertyHistoryDto>();
                    //
                    foreach (var property in propertyToHistoryList)
                    {
                        var value = property.Item2.GetValue(objectList[j]);
                        string valueString = valueToString(value,timezone, location);
                        if (j > 0 && history.Type != 2)
                        {
                            //if prev value is equal to current value go to next property
                            //else add position to history
                            var prevValue = property.Item2.GetValue(objectList[j - 1]);
                            if ((dynamic)prevValue == (dynamic)value)
                            {
                                continue;
                            }
                            else
                            {
                                string prevValueString = valueToString(prevValue,timezone, location);
                                historyOfPropertiesList.Add(new PropertyHistoryDto(property.Item1, prevValueString, valueString));
                            }
                        }
                        //create mode add value of property
                        else
                        {
                            historyOfPropertiesList.Add(new PropertyHistoryDto(property.Item1, valueString));
                        }
                    }
                    history.PropertiesHistory = historyOfPropertiesList;
                    if(historyOfPropertiesList.Count()>0){
                        historyList.Add(history);
                    }
                }
            }
            return historyList.OrderByDescending(x=>x.Moddate).ToList();;
        }

        private string valueToString(object value, int timezone, string location)
        {
            string valueString = "";
            if (value.GetType() == typeof(System.Boolean))
            {
                if (((bool)value))
                {
                    valueString = "YES";
                }
                else
                {
                    valueString = "NO";
                }
            }
            else if (value.GetType() == typeof(System.DateTime))
            {
                valueString = ((System.DateTime)value).AddHours(timezone).ToString(CultureInfo.CreateSpecificCulture(location));
            }
            else if (value.GetType() == typeof(System.Decimal))
            {
                valueString = ((System.Decimal)value).ToString("0.####");
            }
            else if (value.GetType() == typeof(System.Double))
            {
                valueString = ((System.Double)value).ToString("0.####");
            }
            else if (value.GetType() == typeof(int))
            {
                valueString = ((int)value).ToString("0.####");
            }
            else
            {
                valueString = value.ToString();
            }
            return valueString;
        }
    }
}