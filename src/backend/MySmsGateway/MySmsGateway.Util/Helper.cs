using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Util
{
    public static class Helper
    {
        public static bool ValidateModel()
        {
            // check if input is valid
            //var results = new List<ValidationResult>();
            //if (Validator.TryValidateObject(model, new ValidationContext(model), results, true))
            //{
            //    var name = model.Name;
            //}
            return false;
        }

        public static string ReadResourceAsString(Assembly assembly,string resourceName)
        {
            using (var stream=assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader=new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
