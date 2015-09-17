using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delighted.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delighted.Api.DelightedData;

namespace Delighted.Api.Tests {
    [TestClass()]
    public class ClientTests {
        [TestMethod()]
        public void AddPersonTest() {
            var client = new Delighted.Api.Client("yourkey");
            var r = client.AddPerson(new Person()
            {
                Email = "hello" + System.DateTime.Now.Ticks.ToString() + "@sinch.com",
                Send = false
            }).Result;
            Assert.IsTrue(r.Id != null);
            var dic = new Dictionary<string, string>();
                dic.Add("survey_origin", "APIWorld");
            var r2= client.AddResult(new AddResult()
            {
                PersonId = r.Id.ToString(),
                Score = 5,
                Properties = dic
            }).Result;
            Assert.IsTrue(r2.Id > 0);
        }
        //"survey_origin"

    }
}