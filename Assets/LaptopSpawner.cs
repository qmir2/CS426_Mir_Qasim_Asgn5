using UnityEngine;
using UnityEngine.Networking;

public class LaptopSpawner : NetworkBehaviour {

    public GameObject laptopPrefab;

    private void spawnLaptop(Vector3[] positions)
    {

        for(int i = 0; i < positions.Length; i++)
        {
            var rotation = Quaternion.Euler(0, 0, 0);

            var laptop = (GameObject)Instantiate(laptopPrefab, positions[i], rotation);
            NetworkServer.Spawn(laptop);

        }

    }

    public override void OnStartServer()
    {
        Vector3[] laptopPositions = new Vector3[] { new Vector3(63.1f, 1.49f, 37.49f), new Vector3(6.0f, 0.0f, 12.0f) };
        spawnLaptop(laptopPositions);

    }
}
