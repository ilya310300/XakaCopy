using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Table
{
    #region ExceptionInfo
    public class ExceptionInfo
    {
        public Exception exception { get; set; }
        public object info { get; set; }
    }
    #endregion

    #region Info

    [DataContract]
    public class Restaurants
    {
        [DataMember] public List<Restaurant> restaurants { get; set; }
    }

    [DataContract]
    public class Restaurant
    {
        [DataMember] public string id { get; set; }
        [DataMember] public string title { get; set; }
        [DataMember] public string campus { get; set; }
        [DataMember] public string phone { get; set; }
        [DataMember] public string timetable { get; set; }
        [DataMember] public string image { get; set; }
        public string TitleAndTimetable
        {
            get { return title + ", " + timetable; }
        }
        public string CampusAndPhone
        {
            get { return campus + ", " + phone; }
        }
    }

    [DataContract]
    public class Dishes
    {
        [DataMember] public List<Dish> dishes { get; set; }
    }

    [DataContract]
    public class Dish
    {
        [DataMember] public string id { get; set; }
        [DataMember] public string restaurant_id { get; set; }
        [DataMember] public string category { get; set; }
        [DataMember] public string title { get; set; }
        [DataMember] public string availability { get; set; }
        [DataMember] public string description { get; set; }
        [DataMember] public string calories { get; set; }
        [DataMember] public string proteins { get; set; }
        [DataMember] public string fats { get; set; }
        [DataMember] public string carbs { get; set; }
        [DataMember] public string weight { get; set; }
        [DataMember] public string price { get; set; }
        [DataMember] public string image_1 { get; set; }
        [DataMember] public string image_2 { get; set; }
        [DataMember] public string image_3 { get; set; }

        public string TitleAndWeight
        {
            get { return title + " (" + weight + ")"; }
        }
    }
    #endregion

    public class GetRequest
    {
        public static ExceptionInfo GET(string Data, object classInfo)
        {
            ExceptionInfo exceptionInfo = new ExceptionInfo();
            try
            {
                HttpWebRequest request =
                    (HttpWebRequest) WebRequest.Create("https://food.spatecon.ru/api/" + Data);
                WebResponse response = request.GetResponse();
                Stream dataSteam = response.GetResponseStream();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(classInfo.GetType());
                exceptionInfo.info = jsonFormatter.ReadObject(dataSteam);
                exceptionInfo.exception = null;
                return exceptionInfo;
            }
            catch (Exception ex)
            {
                exceptionInfo.info = null;
                exceptionInfo.exception = ex;
                return exceptionInfo;
            }
        }

    }
}
