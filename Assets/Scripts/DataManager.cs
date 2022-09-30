using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
	
    public static DataManager Instance;
    
    public string playerName;
    public int score;
    public string maxName;
    
    private string path;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    [System.Serializable]
    class SaveData 
    {
    	public string maxName;
    	public int maxScore;	
    }
    
    void Awake()
    {
    	if (Instance != null) {
    		Destroy(gameObject);
    		return;
    	}
    	path = Application.persistentDataPath + "/savefile.json";
    	Instance = this;
    	LoadMaxSocre();
    	DontDestroyOnLoad(gameObject);
    	
    }
    
    public void SaveMaxScore(int ms)
    {
    	if (ms < score) {
    		return ;
    	}
    	
    	this.maxName = playerName;
    	this.score = ms;
    	
    	SaveData data = new SaveData();
    	data.maxName = playerName;
    	data.maxScore = ms;
    	
    	string json = JsonUtility.ToJson(data);
    	File.WriteAllText(path, json);
    }
    
    public void LoadMaxSocre()
    {
    	if (File.Exists(path)) {
    		string json = File.ReadAllText(path);
    		SaveData data = JsonUtility.FromJson<SaveData>(json);
    		maxName = data.maxName;
    		score = data.maxScore;
    	}
    }
 
}
