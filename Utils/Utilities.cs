using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Utils
{
    public class Utilities
    {
        private static readonly Utilities instance = new Utilities();
        static Utilities()
        {
        }
        public static Utilities Instance
        {
            get
            {
                return instance;
            }
        }
        /// <summary>
        /// This method is use for
        /// get file in project with relative path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetRelativePath(string path)
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
        public string ReadJSONXPath(string RelativeFilePath, string JSONXPath)
        {
            JObject json = JObject.Parse(File.ReadAllText(GetRelativePath(RelativeFilePath)));
            if (json.SelectToken(JSONXPath) == null)            
                throw new InvalidOperationException("Can not find JSON data with JSON path '" + JSONXPath + "', please input correct JSONXPath, Ex: ['Parrent Root'].['Child Root'] ");          
            return json.SelectToken(JSONXPath).ToString();
        }
    }
}
