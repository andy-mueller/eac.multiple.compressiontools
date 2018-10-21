using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace eac.multiple.compressiontools.configuration
{
    [ConfigurationCollection(typeof(CompressionToolConfigurationElement), AddItemName = "compression-tool", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class CompressionToolConfigurationElementsCollection : ConfigurationElementCollection, IEnumerable<CompressionToolConfigurationElement>
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "compression-tool"; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new CompressionToolConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CompressionToolConfigurationElement)element).Executable;
        }

        IEnumerator<CompressionToolConfigurationElement> IEnumerable<CompressionToolConfigurationElement>.GetEnumerator()
        {
            foreach (CompressionToolConfigurationElement elem in this)
            {
                yield return elem;
            }
        }
    }
}
