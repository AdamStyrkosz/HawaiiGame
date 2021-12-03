using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject entryPrefab;
    public Transform entriesParent;
    public int maxScoresDisplayed;

    private Response response;

    public class Response
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("next")]
        public string next { get; set; }

        [JsonProperty("previous")]
        public string previous { get; set; }

        [JsonProperty("results")]
        public Result[] results { get; set; }
    }

    public class Result
    {
        [JsonProperty("pk")]
        public int pk { get; set; }

        [JsonProperty("nickname")]
        public string nickname { get; set; }

        [JsonProperty("points")]
        public int points { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }
    }

    public void GetLeaderboard()
    {
        response = null;

        WebClient client = new WebClient();
        string responseString = client.DownloadString("https://hikawaii.pythonanywhere.com/scoreboard/?format=json");

        response = JsonConvert.DeserializeObject<Response>(responseString);
    }

    public void DisplayLeaderboardEntries()
    {
        foreach (Transform item in entriesParent)
        {
            Destroy(item.gameObject);
        }

        if(response == null)
        {
            Debug.LogError("API error");
            return;
        }

        int loopLimit = maxScoresDisplayed;
        if (response.results.Length < maxScoresDisplayed)
        {
            loopLimit = response.results.Length;
        }

        for (int i = 0; i < loopLimit; i++)
        {
            GameObject newGo = Instantiate(entryPrefab, entriesParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = response.results[i].nickname;
            texts[1].text = response.results[i].points.ToString();
        }
    }
}
