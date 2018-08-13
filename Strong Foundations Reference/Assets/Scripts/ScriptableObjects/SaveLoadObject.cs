using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;                                //Allows reading and writing files
using System.Text;                              //Allows saving and loading text files
using System.Security.Cryptography;             //Allows for hashing and encryption

[System.Serializable]//Class needs to be serialisable
[CreateAssetMenu(menuName = "Save Object")]//Allows creating and instance of our SO from the menu
public class SaveLoadObject : ScriptableObject
{
    [SerializeField]
    public string saveName; //save file name

    //Store save worthy data as variables here
    [SerializeField]
    string playerName;
    [SerializeField]
    float playerStat;
    //etc

    //Push the content of this object to a JSON file
    void Save()
    {
        string data = JsonUtility.ToJson(this, true);

        string hashKey = GenerateHash(data);
        //add save slot later
        PlayerPrefs.SetString("HashKey", hashKey);

        string saveStatePath = Path.Combine(Application.persistentDataPath, saveName + ".json");
        File.WriteAllText(saveStatePath, data);
    }

    void Load()
    {
        string saveStatePath = Path.Combine(Application.persistentDataPath, saveName + ".json");
        if (File.Exists(saveStatePath))
        {
            //make sure the hash code matches
            string json = File.ReadAllText(saveStatePath);

            if (EncryptionCheck(json))
            {
                //Overwrite this scriptable object with the JSON data
                JsonUtility.FromJsonOverwrite(json, this); 
            }
            else
            {
                //Load failed because the hash didn't match
            }
        }
        else
        {
            //Load failed because there's no save file at that path
        }
    }

    bool EncryptionCheck(string json)
    {
        string hash = GenerateHash(json);//Generate the hash again for comparison

        if(PlayerPrefs.HasKey("HashKey"))
        {
            string hashKey = PlayerPrefs.GetString("HashKey");
            if (hash == hashKey) //If the hashes match we have no tampering
            {
                return true; //We'll allow the load
            }
            else
            {
                return false; //Save file has been modified
            }
        }
        else //If we have no hash we have no comparison, so fail
        {
            return false;
        }
    }

    //Generates our hash key for some mild encryption, don't worry if this is super hard to follow
    //Encryption is stupidly complex
    //The short version is this makes a big hexadecimal code that represents our data in the object
    string GenerateHash(string data)
    {
        string hash = string.Empty;

        //set up Sha
        SHA256Managed crypt = new SHA256Managed();

        //compute hash 
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));

        foreach (byte bit in crypto)
        {
            hash += bit.ToString("x2");
        }

        return hash;
    }
}
