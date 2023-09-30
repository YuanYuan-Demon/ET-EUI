using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public partial class UICodeSpawner
{
    private static void SpawnCodeForSubUI(GameObject objPanel)
    {
        if (null == objPanel)
        {
            return;
        }

        string strDlgName = objPanel.name;

        string strFilePath = Application.dataPath + "/Scripts/Codes/HotfixView/Client/Demo/UIBehaviour/CommonUI";

        if (!Directory.Exists(strFilePath))
        {
            Directory.CreateDirectory(strFilePath);
        }

        strFilePath = Application.dataPath + "/Scripts/Codes/HotfixView/Client/Demo/UIBehaviour/CommonUI/" + strDlgName + "ViewSystem.cs";

        StreamWriter sw = new(strFilePath, false, Encoding.UTF8);

        StringBuilder strBuilder = new();
        strBuilder.AppendLine()
                .AppendLine("using UnityEngine;");
        strBuilder.AppendLine("using UnityEngine.UI;");
        strBuilder.AppendLine("namespace ET.Client");
        strBuilder.AppendLine("{");
        strBuilder.AppendLine("\t[ObjectSystem]");
        strBuilder.AppendFormat("\tpublic class {0}AwakeSystem : AwakeSystem<{1},Transform> \r\n", strDlgName, strDlgName);
        strBuilder.AppendLine("\t{");
        strBuilder.AppendFormat("\t\tprotected override void Awake({0} self,Transform transform)\n", strDlgName);
        strBuilder.AppendLine("\t\t{");
        strBuilder.AppendLine("\t\t\tself.uiTransform = transform;");
        strBuilder.AppendLine("\t\t}");
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("\n");

        strBuilder.AppendLine("\t[ObjectSystem]");
        strBuilder.AppendFormat("\tpublic class {0}DestroySystem : DestroySystem<{1}> \r\n", strDlgName, strDlgName);
        strBuilder.AppendLine("\t{");
        strBuilder.AppendFormat("\t\tprotected override void Destroy({0} self)", strDlgName);
        strBuilder.AppendLine("\n\t\t{");

        strBuilder.AppendFormat("\t\t\tself.DestroyWidget();\r\n");

        strBuilder.AppendLine("\t\t}");
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");

        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }

    private static void SpawnCodeForSubUIBehaviour(GameObject objPanel)
    {
        if (null == objPanel)
        {
            return;
        }

        string strDlgName = objPanel.name;

        string strFilePath = Application.dataPath + "/Scripts/Codes/ModelView/Client/Demo/UIBehaviour/CommonUI";

        if (!Directory.Exists(strFilePath))
        {
            Directory.CreateDirectory(strFilePath);
        }

        strFilePath = Application.dataPath + "/Scripts/Codes/ModelView/Client/Demo/UIBehaviour/CommonUI/" + strDlgName + ".Designer.cs";

        StreamWriter sw = new(strFilePath, false, Encoding.UTF8);

        StringBuilder strBuilder = new();
        strBuilder.AppendLine()
                .AppendLine("using UnityEngine;")
                .AppendLine("using UnityEngine.UI;")
                .AppendLine("namespace ET.Client")
                .AppendLine("{")
                .AppendLine("\t[EnableMethod]")
                .AppendLine("\t[ChildOf]")
                .AppendFormat("\tpublic partial class {0} : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy \r\n", strDlgName)
                .AppendLine("\t{");

        CreateDeclareCode(ref strBuilder);
        CreateWidgetBindCode(ref strBuilder, objPanel.transform);
        CreateDestroyWidgetCode(ref strBuilder);
        strBuilder.AppendLine("\t\tpublic Transform uiTransform = null;");
        strBuilder.AppendLine("\t}");
        strBuilder.AppendLine("}");

        sw.Write(strBuilder);
        sw.Flush();
        sw.Close();
    }

    public static void SpawnSubUICode(GameObject gameObject)
    {
        Path2WidgetCachedDict?.Clear();
        Path2WidgetCachedDict = new();
        FindAllWidgets(gameObject.transform, "");
        SpawnCodeForSubUI(gameObject);
        SpawnCodeForSubUIBehaviour(gameObject);
        AssetDatabase.Refresh();
    }
}