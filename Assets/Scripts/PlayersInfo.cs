using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayersInfo
{
    public int id;
    public string name;
    public string email;
    public string username;
    public int points;
    public int platformIndex;
    public string platformName;
    public int countryIndex;
    public string countryName;
    public List<CharsInfo> heroes; 
}
