using TMPro;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject loginButton;

    private List<string> pidList = new List<string>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void BeenClicked()
    {
        loginButton.SetActive(false);

        World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<FSLoginSystem>().Enabled = true;
    }

    public void GetAuthResultsWeb(string result)
    {
        World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<FSLoginSystem>().GetAuthResultsWeb(result);
    }
}
