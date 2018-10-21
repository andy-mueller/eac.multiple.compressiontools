using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace eac.multiple.compressiontools.configuration
{
    public class CompressionToolConfigurationSection : ConfigurationSection
    {
        public static CompressionToolConfigurationSection Instance
        {
            get { return (CompressionToolConfigurationSection)ConfigurationManager.GetSection("compression-tools-section"); }
        }

        [ConfigurationProperty("compression-tools")]
        [ConfigurationCollection(typeof(CompressionToolConfigurationElementsCollection), AddItemName = "add")]
        public CompressionToolConfigurationElementsCollection Templates
        {
            get
            {
                return (CompressionToolConfigurationElementsCollection)base["compression-tools"];
            }
        }
    }
}
