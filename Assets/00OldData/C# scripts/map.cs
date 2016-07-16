using UnityEngine;
using System.Collections;

public class map : MonoBehaviour {
	public GameObject panel;
	string[,] allData = new string [30,30];
	static int firstRows;
	static int firstCols;
	public Sprite[] sprite = new Sprite[10];
	public GameObject[,] back = new GameObject[30,30];
	// Use this for initialization
	void Start () {
		ReadFile ("Maps/first");
		for(int i=0;i<30;i++){
			for(int j=0;j<30;j++){
				back[i,j] = Instantiate(panel,new Vector3(0.5f+j,29.5f-i,0),Quaternion.identity) as GameObject;
				back[i,j].name = i.ToString()+j.ToString();
				back[i,j].GetComponent<SpriteRenderer>().sprite = sprite[int.Parse(allData[i,j])];
				if(allData[i,j] == "4"){
					back[i,j].AddComponent<BoxCollider2D>();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ReadFile (string file){
		TextAsset stage = (TextAsset)Resources.Load (file);
		string[] row = stage.text.Split ("\n" [0]);
		firstRows = row.Length;
		string[] col = row [1].Split ("," [0]);
		firstCols = col.Length;

		for (int i = 0; i < firstRows; i++) {
			for (int j = 0; j < firstCols; j++) {
				col = row [i].Split ("," [0]);
				allData [i, j] = col [j];
			}
		}
	}

}
