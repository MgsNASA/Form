using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject active;
    [SerializeField]
    private GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ButtonSetAciveFalse()
    {
        active.SetActive(false);
        book.SetActive(true);
    }
   public  void ButtonSetAciveTrue()
    {
        active.SetActive(false);
        book.SetActive(true);

    }

}
