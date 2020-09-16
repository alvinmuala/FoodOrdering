using System.IO;

namespace FoodOrdering.Web.Utilities
{
    public class JsonHelper
    {
        public string ReadFromFile(string fileName, string location)
        {
            var root = "wwwroot";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                root,
                location,
                fileName
            );

            string jsonResult;

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public void WriteToFile(string fileName, string location, string jSONString)
        {
            var root = "wwwroot";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                root,
                location,
                fileName
            );

            using var streamWriter = File.CreateText(path);
            streamWriter.Write(jSONString);
        }
    }
}
