using eac.multiple.compressiontools.configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace eac.multiple.compressiontools.tests
{
    public class ConfigurationTest
    {
        public IEnumerable<char> xox { get; private set; }

        [Fact]
        public void CliTemplateConfigValues()
        {
            CompressionToolConfigurationElement configElement = new CompressionToolConfigurationElement();
            configElement.Executable = "Path to executable";
            configElement.Parameters = "a lot of cli parameters";
            configElement.Extension = "xox";

            Assert.Equal("Path to executable", configElement.Executable);
            Assert.Equal("a lot of cli parameters", configElement.Parameters);
            Assert.Equal("xox", configElement.Extension);
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
                new CompressionToolConfigurationElement() { Executable="program 1", Parameters="%key% parameters", Extension="xox"},
                new CompressionToolConfigurationElement() { Executable="program 2", Parameters="%key2% parameters", Extension="lol"}
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
