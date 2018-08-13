using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Needed for Binary Formatting
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Week5BinaryFormatter
{
    //Take in an instance of our data wrapper class and save it to a file
    public static void SaveData(DataWrapper data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/data.sav", FileMode.Create);

        //On whatever is calling this there would be something along the lines of:
        //DataWrapper data = new DataWrapper(name, score);
        //which gets the data ready to save

        bf.Serialize(stream, data);
        stream.Close();
    }

    //Load an instance of our data wrapper class as a file
    public static DataWrapper LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/data.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/data.sav", FileMode.Open);

            DataWrapper data = bf.Deserialize(stream) as DataWrapper;
            return data;
        }
        else
        {
            return null;
        }
    }
}

//This will store the relevant data
//We will need to make an instance of this somewhere and populate it with data
[System.Serializable]
public class DataWrapper
{
    //variables
    [SerializeField]
    public string playerName;
    [SerializeField]
    public int playerScore;

    public DataWrapper(string _playerName, int _playerScore)
    {
        playerName = _playerName;
        playerScore = _playerScore;
    }
}
