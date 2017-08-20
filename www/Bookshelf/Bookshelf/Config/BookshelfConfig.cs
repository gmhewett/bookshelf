namespace Bookshelf.Config
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Microsoft.Azure;

    public class BookshelfConfig : IBookshelfConfig
    {
        public T Get<T>(string key)
        {
            string setting = CloudConfigurationManager.GetSetting(key);
            if (string.IsNullOrWhiteSpace(setting))
            {
                throw new KeyNotFoundException();
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(setting);
        }
    }
}