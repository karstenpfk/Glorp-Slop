
using UnityEngine;
using WiimoteApi;

public class WiimoteButtonTest : MonoBehaviour
{
    private Wiimote remote;

    void Start ()
    {
        WiimoteManager.FindWiimotes();

        if ( WiimoteManager.Wiimotes.Count > 0 )
        {
            remote = WiimoteManager.Wiimotes[ 0 ];

            remote.SendDataReportMode(
                InputDataType.REPORT_BUTTONS
            );

            Debug.Log( "Wiimote found!" );
        }
        else
        {
            Debug.LogError( "No Wiimote found!" );
        }
    }

    void Update ()
    {
        if ( remote == null ) return;

        int result;

        do
        {
            result = remote.ReadWiimoteData();
        }
        while ( result > 0 );

        if ( remote.Button.a )
        {
            Debug.Log( "A BUTTON PRESSED!" );
        }
    }
}
