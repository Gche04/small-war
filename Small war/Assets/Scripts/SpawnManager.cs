using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    
    public void SpawnAtPosition(int player, Vector2 position)
    {
        if (player == 1)
        {
            Instantiate(player1, position, player1.transform.rotation);
        }else
        {
            Instantiate(player2, position, player1.transform.rotation);
        }
    }
}
