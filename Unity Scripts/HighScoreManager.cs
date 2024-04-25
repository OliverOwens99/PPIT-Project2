using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class HighScoreManager : MonoBehaviour
{
    private const string expressURL = "http://localhost:4000/highscores";

    // Create a serializable class to hold the data
    [System.Serializable]
    public class ScoreData
    {
        public string username;
        public int score;
    }

    public void SubmitScore(string username, int score)
    {
        // Create a new ScoreData object
        ScoreData data = new ScoreData();
        data.username = username;
        data.score = score;

        // Serialize the ScoreData object to JSON
        string json = JsonUtility.ToJson(data);

        StartCoroutine(PostScore(json));
    }

    IEnumerator PostScore(string json)
    {
        // Convert the JSON string to a byte array
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        // Create a new UnityWebRequest and set the method to POST
        using (UnityWebRequest www = UnityWebRequest.Put(expressURL, bodyRaw))
        {
            www.method = UnityWebRequest.kHttpVerbPOST;
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Score submitted successfully!");
            }
        }
    }
}