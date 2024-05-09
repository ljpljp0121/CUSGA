using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public Door door;
    public GameObject[] npcs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            door.GetComponent<SpriteRenderer>().color = Color.white;
            door.hasKey = true;
            foreach (GameObject npc in npcs)
            {
                npc.SetActive(true);
            }
            Destroy(this);
        }
    }
}
