using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eac.multiple.compressiontools.tests
{
    public class ConfigurationTest
    {
        [Fact]
        public void CliTemplateConfigValues()
        {
            CompressionToolConfigurationElement configElement = new CompressionToolConfigurationElement();
            configElement.Executable = "Path to executable";
            configElement.Parameters = "a lot of cli parameters";

            Assert.Equal("Path to executable", configElement.Executable);
            Assert.Equal("a lot of cli parameters", configElement.Parameters);
        }

        [Fact]
        public void CanLoadConfiguration()
        {
            Assert.NotNull(CompressionToolConfigurationSection.Instance);
        }
        [Fact]
        public void LoadsAllConfiguredElements()
        {
            IEnumerable<CompressionToolConfigurationElement> expectedElements =
                new List<CompressionToolConfigurationElement>
            {
                new CompressionToolConfigurationElement() { Executable="program 1", Parameters="%key% parameters"},
                new CompressionToolConfigurationElement() { Executable="program 2", Parameters="%key2% parameters"}
            };
            IEnumerable<CompressionToolConfigurationElement> configuredElements =
                Generify<CompressionToolConfigurationElement>(CompressionToolConfigurationSection.Instance.Templates);
            Assert.Equal(expectedElements, configuredElements);
        }
        static IEnumerable<T> Generify<T>(IEnumerable raw)
        {
            foreach (T item in raw)
                yield return item;
        }
    }
}
