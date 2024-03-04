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
        // for(int i = 0; darab > i; i++){
        // GameObject gameObject = new GameObject("Pár: "+i);
        // GameObject p1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // GameObject p2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		// var meshFilter = GameObject.AddComponent<MeshFilter>();
		// // gameObject.AddComponent<MeshRenderer>();
		// // // meshFilter.sharedMesh = objectToCreate;
		// gameObject.transform.position = gameObject.Find("Asztal");
		// // gameObject.transform.rotation = transform.rotation;
        // }
        CreateObjects();
        
    }
    void CreateObjects()
    {
        for (int i = 0; i < hossz; i++)
        {
            // Create an empty GameObject
            GameObject emptyObject = new GameObject("Pár: " + i);
            emptyObject.transform.position = GameObject.Find("Asztal").transform.position;
            // Create and position the first cube as a child
            GameObject cube1 = Instantiate(cubePrefab, emptyObject.transform);
            cube1.transform.localPosition = Vector3.zero;

            // Create and position the second cube as a child
            GameObject cube2 = Instantiate(cubePrefab, emptyObject.transform);
            cube2.transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f); // Adjust the position as needed
        }
        mozgatas = GetComponent<mozgatas>();
        mozgatas.keveres();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
