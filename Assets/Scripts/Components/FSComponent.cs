using Unity.Entities;
using Unity.Collections;

public struct FSComponent : IComponentData
{
    public FixedString64Bytes clientID;
    public FixedString4096Bytes idToken;
    public FixedString64Bytes accessToken;
    public FixedString64Bytes outState;
    public FixedString128Bytes authCode;
    public FixedString128Bytes devEnvironment;
    public FixedString128Bytes authIntegration;
    public FixedString128Bytes tokenIntegration;
    public FixedString128Bytes regIntegration;
    public FixedString128Bytes authBeta;
    public FixedString128Bytes tokenBeta;
    public FixedString128Bytes regBeta;
    public FixedString128Bytes authProduction;
    public FixedString128Bytes tokenProduction;
    public FixedString128Bytes regProduction;
    public FixedString128Bytes codeVerifier;
    public FixedString128Bytes WebCallbackLocation;
    public FixedString128Bytes PcCallBackUri;
    public FixedString128Bytes PcListenerUri;
}
