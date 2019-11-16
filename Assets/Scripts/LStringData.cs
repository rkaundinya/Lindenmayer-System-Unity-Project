using System;
using System.Collections.Generic;

public class LStringData
{
    public List <string> LSystemStrings = new List<string>();
    public List<char> LSystemDummyCommands = new List<char>();
    public Dictionary<char, string> StringMutationRuleMap = new Dictionary<char, string>();
    public Dictionary<char, Delegate> LSystemCharToActionMap 
        = new Dictionary<char, Delegate>();

    public void ClearAllData()
    {
        LSystemStrings.Clear();
        LSystemDummyCommands.Clear();
        StringMutationRuleMap.Clear();
        LSystemCharToActionMap.Clear();
    }
}

// TODO... Add a Clear() method to clear all LString data if you so wish