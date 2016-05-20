using AutomationFrameWork.Exceptions;
using AutomationFrameWork.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomationFrameWork.Utils
{
    public class Utilities
    {
        private static readonly Utilities _instance = new Utilities();
        static Utilities ()
        {
        }
        public static Utilities Instance
        {
            get
            {
                return _instance;
            }
        }
        /// <summary>
        /// This method is use for
        /// get file in project with relative path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetRelativePath (string path)
        {
            return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)), "..//" + path));
        }
        /// <summary>
        /// This method is use for
        /// return JSON in string get by JSONXPath
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadJSONXPath (string RelativeFilePath, string JSONXPath)
        {
            JObject json = JObject.Parse(File.ReadAllText(GetRelativePath(RelativeFilePath)));
            if (json.SelectToken(JSONXPath) == null)
                throw new InvalidOperationException("Can not find JSON data with JSON path '" + JSONXPath + "', please input correct JSONXPath, Ex: ['Parrent Root'].['Child Root'] ");
            return json.SelectToken(JSONXPath).ToString();
        }
        /// <summary>
        /// This method is use for
        /// Return text in source text by using regular expression
        /// </summary>
        /// <param name="source"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public List<string> FindMatchText (string sourceText,string regex)
        {
            if (regex == null || regex.Trim().Length == 0 || regex.Length==0)
                throw new StepErrorException("Regular Expression cannot null or blank");           
            List<String> _returnMatchText = new List<string>();
            try 
            {              
                Regex _regex = new Regex(regex);               
                foreach (Match match in _regex.Matches(sourceText))
                {
                    _returnMatchText.Add(match.Value);
                }
            }
            catch (ArgumentException)
            {
                throw new StepErrorException("Regular Expression is invalid");
            }
            if (_returnMatchText.Count==0)
                throw new StepErrorException("Not found match text in source text");
            return _returnMatchText;
        }
    }
}
