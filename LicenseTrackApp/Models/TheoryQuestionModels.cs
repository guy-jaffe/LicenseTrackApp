using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.Models
{
    internal class TheoryQuestionModels
    {
    }


    public class Rootobject
    {
        public string help { get; set; }
        public bool success { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public bool include_total { get; set; }
        public int limit { get; set; }
        public string records_format { get; set; }
        public string resource_id { get; set; }
        public object total_estimation_threshold { get; set; }
        public Question[] records { get; set; }
        public Field[] fields { get; set; }
        public _Links _links { get; set; }
        public int total { get; set; }
        public bool total_was_estimated { get; set; }
    }

    public class _Links
    {
        public string start { get; set; }
        public string next { get; set; }
    }

    public class Question
    {
        public int _id { get; set; }
        public int version { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public DateTime lastBuildDate { get; set; }
        public string generator { get; set; }
        public string language { get; set; }
        public string title2 { get; set; }
        public string link3 { get; set; }
        public string guid { get; set; }
        public string description4 { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public DateTime pubDate { get; set; }
    }

    public class Field
    {
        public string id { get; set; }
        public string type { get; set; }
    }

}
