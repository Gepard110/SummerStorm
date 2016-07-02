using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class fileManager
{
	//CSVデータを読み込んで、行と列を配列で返す関数
	public static int[] getCSVLength (string dataPath)
	{
		string data;
		//データが存在するか確認/なければnullを返す
		if (File.Exists (dataPath) == false) {
			return null;
		} else {
			//ファイルを読み込む
			FileStream fs = new FileStream (dataPath, FileMode.Open);
			StreamReader sr = new StreamReader (fs);
			data = sr.ReadToEnd ();
			sr.Close ();
		}
		string[] rows = data.Replace ("\r\n", "\n").Split ('\n');

		//行数dataRowsと列数dataColsを取得する
		int dataRows;
		int dataCols;
		dataRows = rows.Length;
		string[] cols = rows [0].Split ("," [0]);
		dataCols = cols.Length;

		//int型配列にdataRowsとdataColsを代入する
		int[] getLength = new int[2];
		getLength [0] = dataRows;
		getLength [1] = dataCols;
		return getLength;
	}


	//CSVデータを読み込んで、string型2次元配列で返す関数
	public static string[,] ReadFile (string dataPath)
	{
		string data;
		//データが存在するか確認/なければnullを返す
		if (File.Exists (dataPath) == false) {
			return null;
		} else {
			//ファイルを読み込む
			FileStream fs = new FileStream (dataPath, FileMode.Open);
			StreamReader sr = new StreamReader (fs);
			data = sr.ReadToEnd ();
			sr.Close ();
		}
		//読み込んだファイルを分断する
		string[] rows = data.Replace ("\r\n", "\n").Split ('\n');
		//行数dataRowsと列数dataColsを取得する
		int dataCols;
		int dataRows;
		dataRows = rows.Length;
		string[] cols = rows [0].Split ("," [0]);
		dataCols = cols.Length;
		//List型宣言
		List<string[]> csvList = new List<string[]> ();
		//rowsをsplitして、string配列colsに代入→それぞれのcolsをList型csvDataにAddする
		for (int i = 0; i < dataRows; i++) {
			cols = rows [i].Split ("," [0]);
			csvList.Add (cols);
		}

		//2次元配列の宣言
		string[,] csvData = new string[dataRows, dataCols];
		//List型→string[]型に変換
		int m = 0;
		foreach (string[] str in csvList) {
			for (int i = 0; i < str.Length; i++) {
				csvData [m, i] = str [i];
			}
			m++;
		}

		//戻り値
		return csvData;
	}

	//ResourceフォルダからCSVデータを読み込んで、string型2次元配列で返す関数
	public static string[,] ReadFileFromResourcesFolder (string dataPath)
	{
		//改行ごとに要素分けいた配列rowsを作成する
		TextAsset data = (TextAsset)Resources.Load (dataPath);
		//もし参照してなければ、nullを返す
		if (data == null) {
			return null;
		}
		string[] rows = data.text.Replace ("\r\n", "\n").Split ('\n');

		//行数dataRowsと列数dataColsを取得する
		int dataCols;
		int dataRows;
		dataRows = rows.Length;
		string[] cols = rows [0].Split ("," [0]);
		dataCols = cols.Length;
		//List型宣言
		List<string[]> csvList = new List<string[]> ();
		//rowsをsplitして、string配列colsに代入→それぞれのcolsをList型csvDataにAddする
		for (int i = 0; i < dataRows; i++) {
			cols = rows [i].Split ("," [0]);
			csvList.Add (cols);
		}

		//2次元配列の宣言
		string[,] csvData = new string[dataRows, dataCols];
		//List型→string[]型に変換
		int m = 0;
		foreach (string[] str in csvList) {
			for (int i = 0; i < str.Length; i++) {
				csvData [m, i] = str [i];
				//Debug.Log(str[i]);
			}
			m++;
		}

		//戻り値
		return csvData;
	}
		

	//CSVデータに2次元配列を上書きする
	public static void WriteData (string dataPath, string[,] newData)
	{
		//2次元配列をまとめるstring型変数の宣言
		string stringData = "";
		//2次元配列をまとめるstring型変数にまとめる
		for (int i = 0; i < newData.GetLength (0); i++) {
			for (int j = 0; j < newData.GetLength (1); j++) {
				if (j < newData.GetLength (1) - 1) {
					stringData += newData [i, j] + ",";
				} else if (j == newData.GetLength (1) - 1 && i < newData.GetLength (0) - 1) {
					stringData += newData [i, j] + "\n";
				} else {
					stringData += newData [i, j];
				}
			}
		}
		//データを書き込む
		FileStream fs = new FileStream (dataPath, FileMode.Create);
		StreamWriter sw = new StreamWriter (fs);
		sw.Write (stringData);
		sw.Flush ();
		sw.Close ();
	}

	//string2次元配列に新しい行を追加する
	public static string[,] AddStringArrayToCSV (string[,] arrayData, string[] data)
	{
		//配列の長さがあっているか確認/なければnullを返す
		if (arrayData.GetLength (1) != data.Length) {
			return null;
		} else {
			string[,] newArrayData = new string[arrayData.GetLength (0) + 1, arrayData.GetLength (1)];
			for (int i = 0; i < arrayData.GetLength (0) + 1; i++) {
				for (int j = 0; j < arrayData.GetLength (1); j++) {
					if (i == arrayData.GetLength (0)) {
						newArrayData [i, j] = data [j];
					} else {
						newArrayData [i, j] = arrayData [i, j];
					}
				}
			}
			return newArrayData;
		}
	}

	//txtファイルからデータを読み込む
	public static string getTextData(string dataPath){
		FileStream fs = new FileStream (dataPath, FileMode.Open);
		StreamReader sr = new StreamReader (fs);
		string text = sr.ReadToEnd ();
		sr.Close ();
		return text;
	}

	//jsonクラスを書き出す
//	public static void writeTextData(string dataPath, rankingJson rankingJson){
//		//jsonデータをstringにして、txt形式で書き出す
//		string jsonData = JsonUtility.ToJson(rankingJson);
//		FileStream fs = new FileStream (dataPath, FileMode.Create);
//		StreamWriter sw = new StreamWriter (fs);
//		sw.Write (jsonData);
//		sw.Flush ();
//		sw.Close ();
//	}

	public static string getPath ()
	{
		#if UNITY_EDITOR
		return Application.dataPath + "/Resources";
		#elif UNITY_ANDROID
		return Application.persistentDataPath + "";
		#elif UNITY_IPHONE
		return Application.persistentDataPath + "";
		#else
		return Application.dataPath + "";
		#endif
	}




}
			
