using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpawnPlayer : MonoBehaviour

    
{
    [SerializeField]
    private Transform playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        NetworkManager.Singleton.StartHost();
        Transform playerTransform = Instantiate(playerPrefab);
        PlayerUnit player = playerTransform.GetComponent<PlayerUnit>();
        object[] stats = player.createVariables();
        player.AssignVaribles(stats);
        //playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
    }
}
