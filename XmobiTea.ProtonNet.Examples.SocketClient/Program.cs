using System.Threading;
using XmobiTea.Data;
using XmobiTea.Logging;
using XmobiTea.ProtonNet.Client;
using XmobiTea.ProtonNet.Client.Socket;
using XmobiTea.ProtonNet.Client.Socket.Handlers;
using XmobiTea.ProtonNet.Client.Socket.Types;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Networking.Extensions;

namespace XmobiTea.ProtonNet.Examples.SocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager.SetDefaultLoggerFactory(DefaultLogType.Console);

            var clientFactory = ClientPeerFactory.NewBuilder()
                .Build();

            new Thread(() =>
            {
                System.Console.WriteLine("try running Tcp Client ");

                Thread.Sleep(500);

                var tcpSocketClientPeer = clientFactory.NewSocketClientPeer("http://127.0.0.1:32202", TransportProtocol.Tcp);
                tcpSocketClientPeer.Connect(true, (connectionId, serverSesionId) =>
                {
                    System.Console.WriteLine($"Tcp connectionId {connectionId} serverSesionId {serverSesionId}");

                    tcpSocketClientPeer.Send(new OperationRequest()
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
                                System.Console.WriteLine("Tcp Receive from Server: " + response.ToString());
                            }, new SendParameters()
                            {
                                Encrypted = false,
                            });

                    tcpSocketClientPeer.Send(new OperationEvent()
                        .SetEventCode("noModelEvent")
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
                            .Build()), new SendParameters()
                            {
                                Encrypted = true,
                            });
                }
                , (reason, message) =>
                {
                    System.Console.WriteLine("reason " + reason);
                    System.Console.WriteLine("message " + message);
                });

            }).Start();

            new Thread(() =>
            {
                System.Console.WriteLine("try running Udp Client ");

                Thread.Sleep(3000);

                var udpSocketClientPeer = clientFactory.NewSocketClientPeer("http://127.0.0.1:42202", TransportProtocol.Udp);
                udpSocketClientPeer.Connect(true, (connectionId, serverSesionId) =>
                {
                    System.Console.WriteLine($"Udp connectionId {connectionId} serverSesionId {serverSesionId}");

                    udpSocketClientPeer.Send(new OperationRequest()
                        .SetOperationCode("modelRequest")
                        .SetParameters(GNHashtable.NewBuilder()
                            .Add("testString", "123")
                            .Add("testBoolean", false)
                            .Add("testFloatMin", float.MinValue)
                            .Build()), response =>
                            {
                                System.Console.WriteLine("Udp Receive from Server: " + response.ToString());
                            }, new SendParameters()
                            {
                                Encrypted = false,
                            });

                    udpSocketClientPeer.Send(new OperationEvent()
                        .SetEventCode("modelEvent")
                        .SetParameters(GNHashtable.NewBuilder()
                            .Add("testString", "123")
                            .Add("testBoolean", false)
                            .Add("testFloatMin", float.MinValue)
                            .Build()), new SendParameters()
                            {
                                Encrypted = true,
                            });
                }
                , (reason, message) =>
                {
                    System.Console.WriteLine("reason " + reason);
                    System.Console.WriteLine("message " + message);
                });

            }).Start();

            new Thread(() =>
            {
                System.Console.WriteLine("try running Ws Client ");

                Thread.Sleep(5500);

                var wsSocketClientPeer = clientFactory.NewSocketClientPeer("ws://127.0.0.1:52202", TransportProtocol.Ws);
                wsSocketClientPeer.Connect(true, (connectionId, serverSesionId) =>
                {
                    System.Console.WriteLine($"Ws connectionId {connectionId} serverSesionId {serverSesionId}");

                    wsSocketClientPeer.Send(new OperationRequest()
                        .SetOperationCode("modelRequest")
                        .SetParameters(GNHashtable.NewBuilder()
                            .Add("testString", "123")
                            .Add("testBoolean", false)
                            .Add("testFloatMin", float.MinValue)
                            .Build()), response =>
                            {
                                System.Console.WriteLine("Ws Receive from Server: " + response.ToString());
                            }, new SendParameters()
                            {
                                Encrypted = false,
                            });

                    wsSocketClientPeer.Send(new OperationEvent()
                        .SetEventCode("modelEvent")
                        .SetParameters(GNHashtable.NewBuilder()
                            .Add("testString", "123")
                            .Add("testBoolean", false)
                            .Add("testFloatMin", float.MinValue)
                            .Build()), new SendParameters()
                            {
                                Encrypted = true,
                            });
                }
                , (reason, message) =>
                {
                    System.Console.WriteLine("reason " + reason);
                    System.Console.WriteLine("message " + message);
                });

            }).Start();

            new Thread(() =>
            {
                while (true)
                    clientFactory.Service();
            }).Start();

            System.Console.ReadLine();

        }

        class NoModelEventFromServerEventHandler : EventHandler
        {
            public override string GetCode() => "noModelEventFromServer";

            public override void Handle(OperationEvent operationEvent, SendParameters sendParameters, ISocketClientPeer clientPeer)
            {
                System.Console.WriteLine("Receive " + operationEvent.Parameters + ", client " + clientPeer.GetClientId());
            }

        }

        class ModelEventModel
        {

        }

        class ModelEventFromServerEventHandler : EventHandler<ModelEventModel>
        {
            public override string GetCode() => "modelEventFromServer";

            public override void Handle(ModelEventModel eventModel, OperationEvent operationEvent, SendParameters sendParameters, ISocketClientPeer clientPeer)
            {
                System.Console.WriteLine("Receive " + operationEvent.Parameters + ", client " + clientPeer.GetClientId());
            }
        }

    }

}
