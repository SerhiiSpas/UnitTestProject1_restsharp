
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");

            var reguest = new RestRequest("posts/{postid}", Method.GET);
            reguest.AddUrlSegment("postid", 1);

            var responce = client.Execute(reguest);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(responce);

            var result = output["author"];

            Assert.That(result, Is.EqualTo("typicode"), "Erros author name ");
        }
    }
}
