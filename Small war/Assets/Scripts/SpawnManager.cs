using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] GameObject player1;
    //[SerializeField] GameObject player2;


    public void SpawnAtPosition(GameObject player, Vector2 position)
    {
        //if (player == 1)
        //{
        //player.transform.localRotation = Quaternion.identity;
        GameObject playerClone = Instantiate(player, position, player.transform.rotation);
        //}else
        //{
        //Instantiate(player2, position, player1.transform.rotation);
        //}
    }
}
