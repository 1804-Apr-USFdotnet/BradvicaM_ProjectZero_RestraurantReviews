using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.Mapping;

namespace RR.Tests.Mappings
{
    [TestClass]
    public class MappingProfileTests
    {
        [TestMethod]
        public void MappingProfile_Mappings_MapCorrectly()
        {
            var config = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));

            config.AssertConfigurationIsValid();
        }
    }
}
