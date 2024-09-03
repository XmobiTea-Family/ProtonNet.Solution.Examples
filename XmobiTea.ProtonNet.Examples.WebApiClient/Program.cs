using System.Threading;
using XmobiTea.Data;
using XmobiTea.Logging;
using XmobiTea.ProtonNet.Client;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Networking.Extensions;

namespace XmobiTea.ProtonNet.Examples.WebApiClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager.SetDefaultLoggerFactory(DefaultLogType.Console);

            var clientFactory = ClientPeerFactory.NewBuilder()
                .Build();

            var webApiClientPeer = clientFactory.NewWebApiClientPeer("http://127.0.0.1:22202");

            webApiClientPeer.Send(new OperationRequest()
                .SetOperationCode("noModelRequest")
                .SetParameters(GNHashtable.NewBuilder()
                    .Add("testString", "123")
                    .Add("testBoolean", false)
                    .Add("testBoolTrue", true)
                    .Add("testFloatMin", float.MinValue)
                    .Add("testFloatMax", float.MaxValue)
                    .Add("testIntMin", int.MinValue)
                    .Add("testIntMax", int.MaxValue)
                    .Add("testByteMin", byte.MinValue)
                    .Add("testByteMax", byte.MaxValue)
                    .Add("testSByteMin", sbyte.MinValue)
                    .Add("testSByteMax", sbyte.MaxValue)
                    .Add("testShortMin", short.MinValue)
                    .Add("testShortMax", short.MaxValue)
                    .Add("testUShortMin", ushort.MinValue)
                    .Add("testUShortMax", ushort.MaxValue)
                    .Add("testUIntMin", uint.MinValue)
                    .Add("testUIntMax", uint.MaxValue)
                    .Add("testLongMin", long.MinValue)
                    .Add("testLongMax", long.MaxValue)
                    .Add("testULongMin", ulong.MinValue)
                    .Add("testULongMax", ulong.MaxValue)
                    .Add("testDoubleMin", double.MinValue)
                    .Add("testDoubleMax", double.MaxValue)
                    .Build()), response =>
                    {
                        System.Console.WriteLine("WebApi Receive from Server: " + response.ToString());
                    }, new SendParameters()
                    {
                        Encrypted = false,
                    });

            webApiClientPeer.Send(new OperationRequest()
                .SetOperationCode("modelRequest")
                .SetParameters(GNHashtable.NewBuilder()
                    .Add("testString", "123456")
                    .Add("testBoolean", false)
                    .Add("testFloatMin", float.MinValue)
                    .Build()), response =>
                    {
                        System.Console.WriteLine("WebApi Receive from Server: " + response.ToString());
                    }, new SendParameters()
                    {
                        Encrypted = false,
                    });

            new Thread(() =>
            {
                while (true)
                    clientFactory.Service();
            }).Start();

            System.Console.ReadLine();

        }

    }

}
