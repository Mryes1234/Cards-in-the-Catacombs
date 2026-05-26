// using UnityEngine;

// public class MaxCardTable : MonoBehaviour
// {
//     public GameManager gm;
//     public Card card;
//     private Quaternion initialRotation;
//     private Vector3 initialTransform;
//     public bool maxCard = false;
//     void Start()
//     {
        
//     }

//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Card") && maxCard == false)
//         {
//             maxCard = true;
//         }
//         else
//         {
//             if (maxCard == true)
//             {
//                 gm.UpdateCardPositions();
//             }
//         }
//     }

//     void OnTriggerExit2D(Collider2D collision)
//     {
//        if (collision.gameObject.CompareTag("Card"))
//         {
//             maxCard = false;
//         }
//     }

//     void Update()
//     {
        
//     }
// }
