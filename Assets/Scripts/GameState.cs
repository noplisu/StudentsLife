using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class GameState{

	public static Player player;
	public static TimeManager tm;
	 

	public static void Save()
	{
		player = Player.current;
		tm = TimeManager.current;
		BinaryFormatter bf = new BinaryFormatter();

		FileStream file = File.Create (Application.persistentDataPath + "/savedPlayer.gd"); 
		bf.Serialize(file, GameState.player);
		file.Close();

		FileStream file2 = File.Create (Application.persistentDataPath + "/savedTime.gd"); 
		bf.Serialize(file2, GameState.tm);
		file2.Close();
	}

	public static void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/savedPlayer.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedPlayer.gd", FileMode.Open);
			GameState.player = (Player)bf.Deserialize(file);
			file.Close();

			FileStream file2 = File.Open(Application.persistentDataPath + "/savedTime.gd", FileMode.Open);
			GameState.tm = (TimeManager)bf.Deserialize(file2);
			file2.Close();
	}


}
