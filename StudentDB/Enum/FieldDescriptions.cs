using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB.Enum
{
    internal class FieldDescriptions
    {
        private static readonly Dictionary<ModifyField, string> descriptions = new Dictionary<ModifyField, string>
    {
        { ModifyField.FirstName, "Förnamn" },
        { ModifyField.LastName, "Efternamn" },
        { ModifyField.City, "Stad" }
    };

        public static string GetDescription(ModifyField field)
        {
            return descriptions[field];
        }
    }
}
