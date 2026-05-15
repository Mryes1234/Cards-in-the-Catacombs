using UnityEngine;

public class MaxCardTable : MonoBehaviour
{
    public Card card;
    public bool maxCard = false;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Card") && maxCard == false)
        {
            maxCard = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Card"))
        {
            maxCard = false;
        }
    }

    void Update()
    {
        if (maxCard == true)
        {
            
        }
    }
}
