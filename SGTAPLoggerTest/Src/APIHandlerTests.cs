using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGTAPLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TinCan;

namespace SGTAPLogger
{
    [TestClass()]
    public class APIHandlerTests
    {
        string SampleJson = "{\"actor\":{\"name\":\"Dummylearnername\",\"mbox\":\"mailto:Dummylearnerid@sg-tap.com\"},\"verb\":{\"id\":\"http://gamestrax.com/verbs/started\"},\"object\":{\"id\":\"http://gamestrax.com/games/NEWS/stages/1\",\"definition\":{\"type\":\"http://gamestrax.com/define/type/stage\"}},\"context\":{\"extensions\":{\"http://gamestrax.com/extensions/game_title\":\"1\",\"http://gamestrax.com/extensions/game_id\":\"Stage1\",\"http://gamestrax.com/extensions/game_version\":\"0\",\"http://gamestrax.com/extensions/session\":\"48224b55\"}},\"timestamp\":\"2023-02-09T16:23:54-05:00\"}";

        private string _username = "933228b62001613ab08416b6bdd63b903c8a1c6e";
        private string _password = "00cb487e1c0a66961ec834238997928dd8e80817";

        [TestMethod()]
        public async Task DoSendAPITest()
        {
            for(int i = 0; i < 25; i++)
            {
                APIHandler handler = new APIHandler(_username, _password);
                xCall call = new xCall("Adam Burich", "acb426", "started");
                call.SetActivity("UCG");
                //Assert.AreNotEqual(handler.SendCall(call), -1);
                Statement s = call.BuildStatement();
                string res = handler.SendCall(call);
                Result result = s.result;
                bool? success;
                int grade = 0;
                int status = -1;
                if (s.result != null)
                {
                    success = s.result.success;
                    if (success == true)
                    {
                        grade = 1;
                        status = 0;
                    }
                    else
                    {

                    }
                }
                else
                {
                    success = false;
                }
                Console.WriteLine(res);
                Assert.IsNotNull(res);
            }
        }

        [TestMethod()]
        public void JObjectFiddling()
        {
            string[] list = new string[3];
            Dictionary<String, Dictionary<String, Object[]>> ext = new Dictionary<string, Dictionary<string, object[]>>();
            Dictionary<String, Object[]> extensions = new Dictionary<String, Object[]>();
            extensions.Add("http://gamestrax.com/extensions/fields", list);
            extensions.Add("http://gamestrax.com/extensions/options", list);
            extensions.Add("http://gamestrax.com/extensions/correct_options", list);
            ext.Add("extensions", extensions);
            JObject jobject = JObject.Parse(JsonConvert.SerializeObject(ext));
            Assert.IsNotNull(jobject);
        }
    }
}