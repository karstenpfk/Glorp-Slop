using UnityEngine;
using UnityEngine.InputSystem;

public static class WiimoteRegistration
{
    [RuntimeInitializeOnLoadMethod(
        RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void Register ()
    {
        InputSystem.RegisterLayout<WiimoteDevice>(
            name: "Wiimote"
        );
    }
}