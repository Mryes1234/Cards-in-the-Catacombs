using UnityEngine;
using UnityEngine.UI;

public class Drawing : MonoBehaviour
{
    public Button myButton;
    public GameManager gm;
    public bool drawable = true;
    void Start()
    {
        myButton.onClick.AddListener(OnButtonClicked);
    }
    void OnButtonClicked()
    {
        Debug.Log("Button was clicked!");
        if (drawable == true)
        {
            gm.Draw();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
