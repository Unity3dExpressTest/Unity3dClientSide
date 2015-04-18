using UnityEngine;
using System.Collections;

public class GlobalConsts : Singleton<GlobalConsts> {
    protected GlobalConsts() { }

    public string userID = SystemInfo.deviceUniqueIdentifier;
    public string serverIP = "52.6.61.57";
    public float red;
    public float blue;
    public float green;
}
