using UnityEngine;

public class OSCController : MonoBehaviour
{
    #region Field

    public string serverId = "MaxMSP";
    public string serverIp = "127.0.0.1";
    public int    serverPort = 12000;

    public KeyCode debugKey = KeyCode.S;
    public string  debugMessage = "/sample";

    public bool enableShowDebugLog = true;

    #endregion Field

    void Start ()
    {
        OSCHandler.Instance.Init(this.serverId, this.serverIp, this.serverPort);
        ShowDebugLog();
    }

    void Update()
    {
        if (Input.GetKeyDown(this.debugKey))
        {
            SendDebugMessageToClient();
        }
    }

    private void SendDebugMessageToClient()
    {
        OSCHandler.Instance.SendMessageToClient
            (this.serverId, this.debugMessage, Time.timeSinceLevelLoad);

        ShowDebugLog();
    }

    private void ShowDebugLog()
    {
        if (this.enableShowDebugLog == false)
        {
            return;
        }

        Debug.Log("OSC (" + this.serverId + ", "
                          + this.serverIp + ", "
                          + this.serverPort + ")");
    }
}