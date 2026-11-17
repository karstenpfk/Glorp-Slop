
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using System.Runtime.InteropServices;

[StructLayout( LayoutKind.Explicit, Size = 16 )]
public struct WiimoteState : IInputStateTypeInfo
{
    public FourCC format => new FourCC( 'W', 'I', 'I', 'M' );

    [FieldOffset( 0 )]
    [InputControl( name = "a", layout = "Button", bit = 0 )]
    [InputControl( name = "b", layout = "Button", bit = 1 )]
    [InputControl( name = "one", layout = "Button", bit = 2 )]
    [InputControl( name = "two", layout = "Button", bit = 3 )]
    [InputControl( name = "plus", layout = "Button", bit = 4 )]
    [InputControl( name = "minus", layout = "Button", bit = 5 )]
    [InputControl( name = "home", layout = "Button", bit = 6 )]
    [InputControl( name = "up", layout = "Button", bit = 7 )]
    public uint buttons;

    [FieldOffset( 4 )]
    public float accelX;

    [FieldOffset( 8 )]
    public float accelY;

    [FieldOffset( 12 )]
    public float accelZ;
}

[InputControlLayout( stateType = typeof( WiimoteState ) )]
public class WiimoteDevice : InputDevice
{
    public ButtonControl a { get; private set; }
    public ButtonControl b { get; private set; }
    public ButtonControl one { get; private set; }
    public ButtonControl two { get; private set; }
    public ButtonControl plus { get; private set; }
    public ButtonControl minus { get; private set; }
    public ButtonControl home { get; private set; }
    public ButtonControl up { get; private set; }

    public AxisControl accelX { get; private set; }
    public AxisControl accelY { get; private set; }
    public AxisControl accelZ { get; private set; }

    protected override void FinishSetup ()
    {
        base.FinishSetup();

        a = GetChildControl<ButtonControl>( "a" );
        b = GetChildControl<ButtonControl>( "b" );
        one = GetChildControl<ButtonControl>( "one" );
        two = GetChildControl<ButtonControl>( "two" );
        plus = GetChildControl<ButtonControl>( "plus" );
        minus = GetChildControl<ButtonControl>( "minus" );
        home = GetChildControl<ButtonControl>( "home" );
        up = GetChildControl<ButtonControl>( "up" );

        //accelX = GetChildControl<AxisControl>( "accelX" );
        //accelY = GetChildControl<AxisControl>( "accelY" );
        //accelZ = GetChildControl<AxisControl>( "accelZ" );
    }
}
