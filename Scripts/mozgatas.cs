using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mozgatas : MonoBehaviour {
	
	public float margin; // Declared here, so you could change value in Unity
    public kartyageneralas kartyageneralas;

    System.Random rnd = new System.Random();

    List<GameObject> CardFinder(){
		List<GameObject> temp = new List<GameObject>();
		GameObject[] Cards = GameObject.FindGameObjectsWithTag("Kartya"); // Loop through each GameObject with the tag "Kartya"
        
		foreach (GameObject obj in Cards)
        {
			if(obj.name != "peldakartya") { // Add every card except for "TemplateCard"
				temp.Add(obj);
			}
		}
		return temp;
	}

	public List<Vector3> CardVectors()
	{
		float cardWidth = 0.7f; //Majd ki kéne cserélni az object valódi távolságára, de úgyis ennyi lesz.
		float cardHeight = 1.2f;
		
		float offsetX = StateNameController.GridWidth * (cardWidth + 2 * margin) / 2;
        float offsetY = StateNameController.GridHeight * (cardHeight + 2 * margin) / 2;

        List<Vector3> Vectors = new List<Vector3>();

		for(int i = 0; i < StateNameController.GridWidth; i++)
		{
			for(int j = 0; j < StateNameController.GridHeight; j++)
			{
				Vectors.Add(new Vector3(i*(cardWidth + 2 * margin) + cardWidth/2 - offsetX,0f,j * (cardHeight + 2 * margin) + cardHeight/2 - offsetY));
			}
		}
		return Vectors;
    }

    public void Shuffle()
    {
        List<Vector3> Vectors = CardVectors();
        List<GameObject> kartyak = CardFinder();
        for (int i = 0; kartyak.Count > i; i++)
        {
            int r = rnd.Next(0, Vectors.Count);
            kartyak[i].transform.position = Vectors[r];
            // kartyak[i].transform.GetChild(1).position = Vectors[r];
			// Debug.Log(kartyak[i].transform.GetChild(0).name);
			// Debug.Log(kartyak[i].transform.GetChild(1).name);
            // kartyak[i].transform.GetChild(0).position = new Vector3(Vectors[r].x, Vectors[r].y+0.02f, Vectors[r].z);
            Vectors.RemoveAt(r);
        }
    } 
}
