
using UnityEngine;
using UnityEngine.InputSystem;
using WiimoteApi;

public class WiimoteBridge : MonoBehaviour
{
    private Wiimote remote;
    private WiimoteDevice device;

    void Start ()
    {
        // Find the connected Wii Remote
        WiimoteManager.FindWiimotes();

        if ( WiimoteManager.Wiimotes.Count == 0 )
        {
            Debug.LogError( "No Wiimote found!" );
            return;
        }

        remote = WiimoteManager.Wiimotes[ 0 ];

        device = InputSystem.AddDevice<WiimoteDevice>();

        remote.SendDataReportMode( InputDataType.REPORT_BUTTONS_ACCEL_EXT16 );

        // Request button data
        remote.SendDataReportMode(
        InputDataType.REPORT_BUTTONS_ACCEL_EXT16
        );

        Debug.Log( "Wiimote Input System bridge ready!" );
    }

    void Update ()
    {
        if ( remote == null || device == null )
        if ( remote == null || device == null )
            return;

        int result;

        do
        {
            result = remote.ReadWiimoteData();
        }
        while ( result > 0 );

        if ( remote.Nunchuck == null )
        {
            Debug.Log( "Waiting for Nunchuk..." );
            return;
        }
        else
        {
            Debug.Log( "Nunchuk detected!" );
        }

        float[ ] stick = remote.Nunchuck.GetStick01();

        float x = ( stick[ 0 ] - 0.5f ) * 2f;
        float y = ( stick[ 1 ] - 0.5f ) * 2f;
        // Deadzone
        if ( Mathf.Abs( x ) < 0.15f ) x = 0f;
        if ( Mathf.Abs( y ) < 0.15f ) y = 0f;

        WiimoteState state = new WiimoteState();

        if ( remote.Button.a )
            state.buttons |= 1u;

        state.nunchuckStick = new Vector2( x, y );

        InputSystem.QueueStateEvent( device, state );
    }
}
