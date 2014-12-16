using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class GameState : MonoBehaviour 
{
	public static Player player;
	public static TimeManager tm;

	public void Save()
	{
		player = Player.current;
		tm = TimeManager.current;
		BinaryFormatter bf = new BinaryFormatter();
		
		FileStream file = File.Create (Application.persistentDataPath + "/savedPlayer.gd"); 
		bf.Serialize(file, player);
		file.Close();
		
		FileStream file2 = File.Create (Application.persistentDataPath + "/savedTime.gd"); 
		bf.Serialize(file2, tm);
		file2.Close();
	}
	
	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/savedPlayer.gd"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedPlayer.gd", FileMode.Open);
			player = (Player)bf.Deserialize(file);
			file.Close();
			
			FileStream file2 = File.Open(Application.persistentDataPath + "/savedTime.gd", FileMode.Open);
			tm = (TimeManager)bf.Deserialize(file2);
			file2.Close();
		}
	}
}