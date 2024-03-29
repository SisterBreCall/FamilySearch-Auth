using Unity.Burst;
using Unity.Entities;

[BurstCompile]
public partial struct CreateFSEntity : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        Entity entity = state.EntityManager.CreateSingleton<FSComponent>("FSAuth");
        state.EntityManager.AddComponent<IdentityComponent>(entity);
        state.EntityManager.AddComponent<CurrentUserComponent>(entity);

        RefRW<FSComponent> fsComponent = SystemAPI.GetSingletonRW<FSComponent>();

        fsComponent.ValueRW.authIntegration = "https://identint.familysearch.org/cis-web/oauth2/v3/authorization";
        fsComponent.ValueRW.tokenIntegration = "https://identint.familysearch.org/cis-web/oauth2/v3/token";
        fsComponent.ValueRW.regIntegration = "https://api-integ.familysearch.org/";

        fsComponent.ValueRW.authBeta = "https://identbeta.familysearch.org/cis-web/oauth2/v3/authorization";
        fsComponent.ValueRW.tokenBeta = "https://identbeta.familysearch.org/cis-web/oauth2/v3/token";
        fsComponent.ValueRW.regBeta = "https://apibeta.familysearch.org/";

        fsComponent.ValueRW.authProduction = "https://ident.familysearch.org/cis-web/oauth2/v3/authorization";
        fsComponent.ValueRW.tokenProduction = "https://ident.familysearch.org/cis-web/oauth2/v3/token";
        fsComponent.ValueRW.regProduction = "https://api.familysearch.org/";

        // Set to Integration, Beta, or Production
        fsComponent.ValueRW.devEnvironment = "Production";

        // FamilySearch API Key
        fsComponent.ValueRW.clientID = "";

        // Web Callback Location
        fsComponent.ValueRW.WebCallbackLocation = "";

        // PC Redirect URI
        fsComponent.ValueRW.PcCallBackUri = "http://127.0.0.1:5000";
        fsComponent.ValueRW.PcListenerUri = "http://127.0.0.1:5000/";
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
}
