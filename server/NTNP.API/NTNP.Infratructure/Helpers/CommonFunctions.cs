using System.Reflection;

namespace NTNP.Infratructure.Helpers
{
    public static class CommonFunctions
    {
        public static bool NotMatch(object model, string keys, string keySearch)
        {
            // Check if keys is empty > by pass
            if (string.IsNullOrEmpty(keys))
            {
                return true;
            }
            // Split list key from string
            string[] listKey = keys.Split(",");
            // Check if search is null > by pass
            if (null == keySearch || keySearch.Length == 0) return true;
            // Get List Properties of current Object
            IEnumerable<PropertyInfo> properties = GetProperties(model);
            // Loop search
            foreach (string key in listKey)
            {
                // Get Property
                PropertyInfo property = properties.FirstOrDefault(x => x.Name.ToLower().Equals(key.ToLower()));
                if (property != null)
                {
                    // Get value of property
                    string value = property.GetValue(model)?.ToString();
                    // Check contains
                    if (value?.ToLower().Contains(keySearch.ToLower()) == true) return true;
                }
            }
            return false;
        }

        private static IEnumerable<PropertyInfo> GetProperties(object model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return model.GetType().GetProperties().AsEnumerable();
        }
    }
}
