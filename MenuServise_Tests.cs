using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using  NUnit;
using NUnit.Framework;

namespace SecretSanta
{
    [TestFixture]
    class MenuServise_Tests
    {
        [Test]
        public void CreateParticipants_NormalCreate_CheckCount()
        {
            MenuServise.CreateParticipants(3)[0].Should().Be("");
           
        }
    }
}
