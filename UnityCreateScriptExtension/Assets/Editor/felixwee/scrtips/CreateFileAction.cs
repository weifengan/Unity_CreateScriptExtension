/*
    完成模板中特定内容的替换并更新件内容
    @author: felixwee
    @email:felixwee@163.com
    @blog: www.felixwee.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class CreateFileAction : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        UnityEngine.Object obj = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(obj);
    }

    private UnityEngine.Object CreateScriptAssetFromTemplate(string fullPath, string resourceFile)
    {
        //读取原文件内容
        StreamReader streamReader = new StreamReader(resourceFile);
        string text = streamReader.ReadToEnd();
        streamReader.Close();

        //只获取文件名不包括扩展名
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath);

        //如果是Lua，对模板中变量进行替换 
        text =text.Replace("#LuaClass#", fileNameWithoutExtension);

        //将替换好的内容写入文件
        StreamWriter streamWriter = new StreamWriter(fullPath);
        streamWriter.Write(text);
        streamWriter.Close();
        //导入指定路径下的资源  
        AssetDatabase.ImportAsset(fullPath);
        //返回指定路径下的Object对象
        return AssetDatabase.LoadAssetAtPath(fullPath, typeof(UnityEngine.Object));
    }
}
