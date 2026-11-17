
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

        // Add our custom controller to Unity's Input System
        device = InputSystem.AddDevice<WiimoteDevice>();

        // Request button data
        remote.SendDataReportMode(
            InputDataType.REPORT_BUTTONS
        );

        Debug.Log( "Wiimote Input System bridge ready!" );
    }

    void Update ()
    {
        if ( remote == null || device == null )
            return;

        // Read data from Flafla2
        int result;

        do
        {
            result = remote.ReadWiimoteData();
        }
        while ( result > 0 );

        // Create a fresh state every frame
        WiimoteState state = new WiimoteState();

        // Transfer the A button
        if ( remote.Button.a )
        {
            state.buttons |= 1u;
        }

        // Send the state to Unity's Input System
        InputSystem.QueueStateEvent( device, state );
    }
}
