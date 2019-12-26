#if UNITY_EDITOR
 using UnityEditor;
 using System.Collections.Generic;
 using System.IO;

public class GenerateEnum
{
    [MenuItem( "Tools/GenerateEnum" )]
     public static void Go( LStringData lStringData )
     {
         string enumName = "LStringCharacterTypes";
         HashSet<char> lStringCharacters = lStringData.LStringCharacterTypes;
         string filePathAndName = "Assets/Scripts/Enums/" + enumName + ".cs"; 
 
         using ( StreamWriter streamWriter = new StreamWriter( filePathAndName ) )
         {
             streamWriter.WriteLine( "[Serializable]" );
             streamWriter.WriteLine( "public struct " + enumName );
             streamWriter.WriteLine( "{" );
             foreach ( var character in lStringData.LStringCharacterTypes )
             {
                 streamWriter.WriteLine( "\t" + "char " + character + ";" );
             }
             streamWriter.WriteLine( "}" );
         }
         AssetDatabase.Refresh();
     }
 }
#endif