using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitHandler;
    UnitHandler handlerScript;
    public GameObject human;
    public GameObject orc;
    GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        handlerScript = unitHandler.GetComponent<UnitHandler>();
        InvokeRepeating("SpawnUnits", 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnUnits()
    {
        Instantiate(orc);
        instance = Instantiate(human);
        handlerScript.footies.Add(instance);
    }
}
