using UnityEngine;
using Unity.Entities;
using Newtonsoft.Json;
using AncestryResource;
using UnityEngine.Networking;
public partial class FSAncestrySystem : SystemBase
{
    protected override void OnCreate()
    {
        Enabled = false;
    }

    protected override void OnStartRunning()
    {
        RefRW<FSComponent> fsComponent = SystemAPI.GetSingletonRW<FSComponent>();
        RefRW<CurrentUserComponent> currentUserComponent = SystemAPI.GetSingletonRW<CurrentUserComponent>();

        string regRoute = string.Empty;

        switch (fsComponent.ValueRO.devEnvironment.ToString())
        {
            case "Integration":
                regRoute = fsComponent.ValueRO.regIntegration.ToString();
                break;
            case "Beta":
                regRoute = fsComponent.ValueRO.regBeta.ToString();
                break;
            case "Production":
                regRoute = fsComponent.ValueRO.regProduction.ToString();
                break;
        }

        string apiRoute = "platform/tree/ancestry";
        string person = "?person=" + currentUserComponent.ValueRO.personId;
        string generations = "&generations=4";
        string apiRequest = string.Format("{0}{1}{2}{3}",
            regRoute,
            apiRoute,
            person,
            generations);

        UnityWebRequest webRequest = UnityWebRequest.Get(apiRequest);
        webRequest.SetRequestHeader("Accept", "application/json");
        webRequest.SetRequestHeader("Authorization", "Bearer " + fsComponent.ValueRO.accessToken);

        webRequest.downloadHandler = new DownloadHandlerBuffer();

        UnityWebRequestAsyncOperation asyncOperation = webRequest.SendWebRequest();
        asyncOperation.completed += (AsyncOperation op) => { ServerResponse(asyncOperation); };
    }

    private void ServerResponse(UnityWebRequestAsyncOperation op)
    {
        AncestryJson ancestryJson = JsonConvert.DeserializeObject<AncestryJson>(op.webRequest.downloadHandler.text);

        for (int i = 0; i < ancestryJson.persons.Count; i++)
        {
            Entity entity = EntityManager.CreateEntity();
            EntityManager.AddComponent<AncestorComponent>(entity);
            RefRW<AncestorComponent> ancestorComponent = SystemAPI.GetComponentRW<AncestorComponent>(entity);

            ancestorComponent.ValueRW.name = ancestryJson.persons[i].display.name;
            ancestorComponent.ValueRW.sex = ancestryJson.persons[i].display.gender;
            ancestorComponent.ValueRW.pid = ancestryJson.persons[i].id;
            ancestorComponent.ValueRW.lifeSpan = ancestryJson.persons[i].display.lifespan;
        }
    }

    protected override void OnUpdate()
    {
        
    }
}
