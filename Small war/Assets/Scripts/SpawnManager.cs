using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnAtPosition(GameObject player, Vector2 position)
    {
        GameObject playerClone = Instantiate(player, position, player.transform.rotation);
        return playerClone;
    }
}
