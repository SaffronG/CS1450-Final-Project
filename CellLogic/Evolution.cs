namespace CellLogic;

[Flags]
public enum Evolution : byte
{
    TopLeft =       0b1 << 0, //00000001
    Top  =          0b1 << 1, //00000010
    TopRight  =     0b1 << 2, //00000100
    Right  =        0b1 << 3, //00001000
    BottomRight  =  0b1 << 4, //00010000
    Bottom  =       0b1 << 5, //00100000
    BottomLeft  =   0b1 << 6, //01000000
    Left  =         0b1 << 7, //10000000
}