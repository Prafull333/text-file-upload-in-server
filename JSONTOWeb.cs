using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;
using System.IO;

public class JSONTOWeb : MonoBehaviour
{
    public string UrlHost;

    public FileInfo text = new FileInfo("D:/Prafull Projects/JSON" + "/JSON.txt");

   // public FileStream fileStream = 

    public void Readdata()
    {
        StartCoroutine(ReadDataCoroutine());
    }

    public IEnumerator ReadDataCoroutine()
    {

        FileStream fileStream = text.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);


        byte[] data = new byte[fileStream.Length];
       // byte[] data = text.AppendText().Encoding.GetBytes();


        print(text.Name);

        yield return new WaitForSeconds(1);

      

        WWWForm from = new WWWForm();
        from.AddField("name", "huh");
        from.AddBinaryData("json_data",data, "data.txt");
       
         
        using (UnityWebRequest www = UnityWebRequest.Post(UrlHost + "/save-jsondata ", from))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isNetworkError)
            {
                StartCoroutine("LogIn");
                print("Your Internat is Not Working" + www.error);
                print(www.downloadHandler.text);
            }
            else
            {
                print("dataUpload");
                print(www.downloadHandler.text);

            }
        }

        //      //  yield return new WaitForSeconds(1);
    }
    }

