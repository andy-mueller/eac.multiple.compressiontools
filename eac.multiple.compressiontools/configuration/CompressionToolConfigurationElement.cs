﻿using System.Configuration;
using System.Linq;


namespace eac.multiple.compressiontools.configuration
{
    public class CompressionToolConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("executable", IsRequired = true)]
        public string Executable
        {
            get { return (string)this["executable"]; }
            set { this["executable"] = value; }
        }
        [ConfigurationProperty("parameters", IsRequired = true)]
        public string Parameters
        {
            get { return (string)this["parameters"]; }
            set { this["parameters"] = value; }
        }

        [ConfigurationProperty("extension", IsRequired = true)]
        public string Extension
        {
            get { return (string)this["extension"]; }
            set { this["extension"] = value; }
        }

        public override string ToString()
        {
            return "[CliConfig, executable=" + Executable + ". parameters=" + Parameters + "]";
        }
    }
}
