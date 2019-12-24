using System;

[Serializable]
public struct LSystemCharActionPairs
{
    public char character;
    public bool isADummyCommand;
    public ActionType actionType;
}
