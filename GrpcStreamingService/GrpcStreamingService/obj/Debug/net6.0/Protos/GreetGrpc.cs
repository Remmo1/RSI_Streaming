// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcStreamingService {
  public static partial class ImageService
  {
    static readonly string __ServiceName = "greet.ImageService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcStreamingService.ImageData> __Marshaller_greet_ImageData = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcStreamingService.ImageData.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcStreamingService.ImageData, global::Google.Protobuf.WellKnownTypes.Empty> __Method_StreamToServer = new grpc::Method<global::GrpcStreamingService.ImageData, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "StreamToServer",
        __Marshaller_greet_ImageData,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcStreamingService.ImageData> __Method_StreamToClient = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcStreamingService.ImageData>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "StreamToClient",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_greet_ImageData);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcStreamingService.GreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ImageService</summary>
    [grpc::BindServiceMethod(typeof(ImageService), "BindService")]
    public abstract partial class ImageServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> StreamToServer(grpc::IAsyncStreamReader<global::GrpcStreamingService.ImageData> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task StreamToClient(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::IServerStreamWriter<global::GrpcStreamingService.ImageData> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ImageServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_StreamToServer, serviceImpl.StreamToServer)
          .AddMethod(__Method_StreamToClient, serviceImpl.StreamToClient).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ImageServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_StreamToServer, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::GrpcStreamingService.ImageData, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.StreamToServer));
      serviceBinder.AddMethod(__Method_StreamToClient, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcStreamingService.ImageData>(serviceImpl.StreamToClient));
    }

  }
}
#endregion
