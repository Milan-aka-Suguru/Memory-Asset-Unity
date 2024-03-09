using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misc : MonoBehaviour
{
    private int pontok;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void pontvalt(int p){
        pontok += p/2;
        GameObject.Find("Pontok").GetComponent<TMPro.TextMeshProUGUI>().text = pontok+"";
    }
    void nyert(){
        Debug.Log("eZ");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
