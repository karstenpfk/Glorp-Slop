using UnityEngine;
using WiimoteApi;

public class TestPlayer : MonoBehaviour
{
    private void Start ()
    {
        WiimoteManager.FindWiimotes();
        Debug.Log( "Found wii remote: " + WiimoteManager.Wiimotes.Count );
    }
    public void TestInput ()
    {
        Debug.Log( "JUMP PRESSED!" );
    }
}
