using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject CloneAtPosition(GameObject player, Vector2 position)
    {
        GameObject playerClone = Instantiate(player, position, player.transform.rotation);
        return playerClone;
    }
}
