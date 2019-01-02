/*
   根据模板文件创建各种格式的代码模板
    @author: felixwee
    @email:felixwee@163.com
    @blog: www.felixwee.com
 */
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DevExtEditor   {

    /* 创建常用文件类型扩展 */
    [MenuItem("Assets/Create/Lua Script",false,81)]
    public static void CreateLuaScript()
    {
        //获取创建代码时的文件路径下的所有对象
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        //根据第一个文件获取不前文件夹路径
        string folder=AssetDatabase.GetAssetPath(arr[0]);

        //将焦点定位到某个文件，并进行重命名       
        //id,回调处理，新建文件url,图标，源始文件url   
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,ScriptableObject.CreateInstance<CreateFileAction>(),folder + "/NewLuaScript.lua", null, "Assets/Editor/felixwee/templates/lua_template.lua");
    }
    /* 创建常用文件类型扩展 */
    [MenuItem("Assets/Create/XML", false, 81)]
    public static void CreateXML()
    {
        //获取创建代码时的文件路径下的所有对象
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        //根据第一个文件获取不前文件夹路径
        string folder = AssetDatabase.GetAssetPath(arr[0]);

        //将焦点定位到某个文件，并进行重命名       
        //id,回调处理，新建文件url,图标，源始文件url   
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateFileAction>(), folder + "/NewXml.xml", null, "Assets/Editor/felixwee/templates/xml_template.xml");
    }

    /* 创建常用文件类型扩展 */
    [MenuItem("Assets/Create/Text", false, 81)]
    public static void CreateText()
    {
        //获取创建代码时的文件路径下的所有对象
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        //根据第一个文件获取不前文件夹路径
        string folder = AssetDatabase.GetAssetPath(arr[0]);

        //将焦点定位到某个文件，并进行重命名       
        //id,回调处理，新建文件url,图标，源始文件url   
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateFileAction>(), folder + "/NewText.txt", null, "Assets/Editor/felixwee/templates/txt_template.txt");
    }

}
