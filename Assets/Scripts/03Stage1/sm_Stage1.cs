using UnityEngine;
using System.Collections;

public class sm_Stage1 : MonoBehaviour {
	public GameObject panel;
	static int firstRows;
	static int firstCols;
	public Sprite[] sprite = new Sprite[10];
	public GameObject[,] backgroundSprite = new GameObject[1,1];
	// Use this for initialization
	void Start () {
		string[,] mapData = fileManager.ReadFileFromResourcesFolder ("CSV/first");
		backgroundSprite = CreateMap (mapData);
	}
	
	// Update is called once per frame
	void Update () {
	} 

	GameObject[,] CreateMap(string[,] allData){
		GameObject[,] bgSprite = new GameObject[allData.GetLength (0), allData.GetLength (1)];
		for(int i=0;i<allData.GetLength(0);i++){
			for(int j=0;j<allData.GetLength(1);j++){
				bgSprite[i,j] = Instantiate(panel,new Vector3(0.5f+j,29.5f-i,0),Quaternion.identity) as GameObject;
				bgSprite[i,j].name = i.ToString()+j.ToString();
				bgSprite[i,j].GetComponent<SpriteRenderer>().sprite = sprite[int.Parse(allData[i,j])];
				if(allData[i,j] == "4" || allData[i,j] == "5" || allData[i,j] == "6"){
					bgSprite[i,j].AddComponent<BoxCollider2D>();
				}
			}
		}
		return bgSprite;
	}
}
