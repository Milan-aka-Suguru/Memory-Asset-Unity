using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class mozgatas : MonoBehaviour {
	System.Random rnd = new System.Random();
	// Use this for initialization
	public int sorok;
	public kartyageneralas kartyageneralas;

	void Start () {

		
		
	}
	List<GameObject> kartyakmegkeresese(){
		List<GameObject> temp = new List<GameObject>();
		GameObject[] kartyaObjects = GameObject.FindGameObjectsWithTag("Kartya");

        // Loop through each GameObject with the tag "Kartya"
        foreach (GameObject obj in kartyaObjects)
        {
			if(obj.name != "peldakartya"){
				temp.Add(obj);
			}
		}
		return temp;
	}
	
	
	// Update is called once per frame
	void Update () {		
	}
	public void keveres(){
		List<Vector3> helyek = kartyahelyek();
		List<GameObject> kartyak = kartyakmegkeresese();
		for(int i = 0; kartyak.Count>i; i++){
			int r = rnd.Next(0,helyek.Count);
			kartyak[i].transform.position = helyek[r];
			kartyak[i].transform.GetChild(0).position = helyek[r];			
			kartyak[i].transform.GetChild(1).position = new Vector3(helyek[r].x,helyek[r].y-0.02f,helyek[r].z);
			helyek.RemoveAt(r);
		}
	}
	public List<Vector3> kartyahelyek(){
		float zz = Math.Abs(GameObject.Find("sarok1").transform.position[2]-GameObject.Find("sarok2").transform.position[2]); //kiszámoljuk a "játszó teret" mind2 dimenzióban, magasságot nem kell számolni
		float xx = Math.Abs(GameObject.Find("sarok1").transform.position[0]-GameObject.Find("sarok2").transform.position[0]); //hiszen az egy statik érték lesz, egy picit feljebb mint az "Asztal"
		// List<GameObject> kartyak = kartyakmegkeresese(); 
		int db = kartyakmegkeresese().Count; //megkeresi az összes "kartya" taggel rendelkező elemet és nem veszi figyelembe a példakártyát és lementi a darabszámot majd a listát teli kártyákkal eldobja.
		//fontos, hogy nem tudjuk lementeni globálba, mert ez egy dinamikus változó és a Unity összeszarja magát az ilyentől :P
		List<Vector3> temp = new List<Vector3>();
		for(int i = 0; i < sorok;i++){ 
			for(int j = 0; j < db/sorok+db%sorok; j++){ //a 2 for ciklus először végig megy az oszlopokon és annyiszor ahány sor van, megoldottam, hogy olyat is lekezeljen ami nem tökéletesen szimmetrikus, 
			//cserébe az egész esztétika elveszett,
			//de nincs jobb ötletem ennél
				temp.Add(new Vector3((xx/(sorok)*(i+0.5f))+GameObject.Find("sarok1").transform.position[0],GameObject.Find("Asztal").transform.position[1]+0.1f,zz/(db/sorok+db%sorok)*(j+0.5f)+GameObject.Find("sarok2").transform.position[2]));
			}
		}
		return temp;
	}
}
