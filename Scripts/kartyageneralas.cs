using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kartyageneralas : MonoBehaviour
{
    // Start is called before the first frame update    
    public int hossz; // Change this to the desired number of objects
    public GameObject cubePrefab;
    public bool keverhet = false;
    public mozgatas mozgatas;
    void Start()
    {
        CreateObjects();
        
    }
    void CreateObjects()
    {
        for (int i = 0; i < hossz; i++)
        {
            // Create an empty GameObject
            GameObject emptyObject = new GameObject("Pár: " + i);
            emptyObject.transform.position = GameObject.Find("Asztal").transform.position;
            GameObject kartya1 = new GameObject("kartya1");
            GameObject kartya2 = new GameObject("kartya2");
            // Create and position the first cube as a child            
            GameObject cube1 = Instantiate(cubePrefab.transform.GetChild(0).gameObject, kartya1.transform);
            cube1.transform.localPosition = Vector3.zero;            
            // Create and position the second cube as a child
            GameObject cube2 = Instantiate(cubePrefab.transform.GetChild(1).gameObject, kartya1.transform);
            cube2.transform.localPosition = Vector3.zero; // Adjust the position as needed
            kartya1.transform.parent = cube1.transform;
            kartya1.transform.parent = cube2.transform;
            GameObject cube3 = Instantiate(cubePrefab.transform.GetChild(0).gameObject, kartya2.transform);
            cube3.transform.localPosition = Vector3.zero;            
            // Create and position the second cube as a child
            GameObject cube4 = Instantiate(cubePrefab.transform.GetChild(1).gameObject, kartya2.transform);
            cube4.transform.localPosition = Vector3.zero; // Adjust the position as needed
            kartya1.tag = "Kartya";
            kartya2.tag = "Kartya";
            kartya1.AddComponent<valasztas>();
            kartya2.AddComponent<valasztas>();
            BoxCollider boxCollider1 = kartya1.AddComponent<BoxCollider>();
            BoxCollider boxCollider2 = kartya2.AddComponent<BoxCollider>();
            boxCollider1.size = new Vector3(2.0f,2.0f,2.0f);
            boxCollider2.size = new Vector3(2.0f,2.0f,2.0f);
            kartya1.AddComponent<BoxCollider>();
            kartya2.AddComponent<BoxCollider>();
            kartya1.transform.parent = emptyObject.transform;
            kartya2.transform.parent = emptyObject.transform;
        }
        mozgatas = GetComponent<mozgatas>();
        mozgatas.keveres();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
