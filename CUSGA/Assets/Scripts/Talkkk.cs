using UnityEngine;

public class Talkkk : MonoBehaviour
{
    public GameObject talk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            talk.SetActive(true);
            collision.GetComponent<Player>().downDie = true;
        }
    }
}
