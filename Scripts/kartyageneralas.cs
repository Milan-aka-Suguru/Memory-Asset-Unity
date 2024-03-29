using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kartyageneralas : MonoBehaviour
{   
    public GameObject cubePrefab;    
    public mozgatas mozgatas;
    public DatabaseCommands DatabaseCommands;
    public valasztas valasztas;

    void Start()
    {
        CreateObjects();
    }
    void SetTexture(GameObject g, int ind,string oszlopnev){

        // Create a new texture and load the image data
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(DatabaseCommands.GetImage("select " + oszlopnev + " from alapkepek where id=" + ind.ToString()));

        // Get the renderer component of the GameObject
        Renderer renderer = g.GetComponent<Renderer>();

        // Create a new material and assign the texture to its main texture property
        Material material = new Material(Shader.Find("Standard"));
        material.mainTexture = texture;

        // Assign the material to the renderer
        renderer.material = material;
    }
    void CreateObjects()
    {
        DatabaseCommands = GetComponent<DatabaseCommands>();
        //SQL.GetImage("select kep from alapkepek where id=1");
        for (int i = 1; i <= StateNameController.GridWidth * StateNameController.GridHeight / 2; i++)
        {
            // Create an empty GameObject
            GameObject emptyObject = new GameObject("P�r: " + i);
            emptyObject.transform.position = GameObject.Find("Asztal").transform.position;
            GameObject kartya1 = new GameObject("kartya1");
            GameObject kartya2 = new GameObject("kartya2");
            // Create and position the first cube as a child            
            GameObject cube1 = Instantiate(cubePrefab.transform.GetChild(0).gameObject, kartya1.transform);
            cube1.transform.localPosition = new Vector3(0f,0.01f,0f);           
            // Create and position the second cube as a child
            GameObject cube2 = Instantiate(cubePrefab.transform.GetChild(1).gameObject, kartya1.transform);
            cube2.transform.localPosition = Vector3.zero; // Adjust the position as needed
            SetTexture(cube2,i,"kep");
            SetTexture(cube1,1,"hatkep");
            kartya1.transform.parent = cube1.transform;
            kartya1.transform.parent = cube2.transform;
            GameObject cube3 = Instantiate(cubePrefab.transform.GetChild(0).gameObject, kartya2.transform);
            cube3.transform.localPosition = new Vector3(0f,0.01f,0f);            
            // Create and position the second cube as a child
            GameObject cube4 = Instantiate(cubePrefab.transform.GetChild(1).gameObject, kartya2.transform);
            cube4.transform.localPosition = Vector3.zero; // Adjust the position as needed
            SetTexture(cube4,i,"kep");
            SetTexture(cube3,1,"hatkep");
            kartya1.tag = "Kartya";
            kartya2.tag = "Kartya";
            kartya1.AddComponent<valasztas>();
            kartya2.AddComponent<valasztas>();
            BoxCollider boxCollider1 = kartya1.AddComponent<BoxCollider>();
            BoxCollider boxCollider2 = kartya2.AddComponent<BoxCollider>();
            boxCollider1.size = new Vector3(1.0f,1.0f,1.0f);
            boxCollider2.size = new Vector3(1.0f,1.0f,1.0f);
            kartya1.AddComponent<BoxCollider>();
            kartya2.AddComponent<BoxCollider>();
            kartya1.transform.parent = emptyObject.transform;
            kartya2.transform.parent = emptyObject.transform;
        }
        valasztas = GetComponent<valasztas>(); 
        valasztas.pontvalt();
        mozgatas = GetComponent<mozgatas>();
        mozgatas.Shuffle();
    }
}
