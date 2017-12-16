using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Data;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour {

    private static LoginPanel _instance = null;
    public static LoginPanel Instance { get { return _instance; } }

    public UILabel loginUserName;
    public UILabel loginPassword;
    public UISprite mistake;

    void Start()
    {
        MysqlConnector mysqlConnector = new MysqlConnector();
        mysqlConnector.SetServer("127.0.0.1");
        mysqlConnector.SetPort("3306");
        mysqlConnector.SetUserID("root");
        mysqlConnector.SetPassword("root");
        mysqlConnector.SetDataBase("databasehomework");
        mysqlConnector.SetCharset("utf8");
        SqlAccess sqla = new SqlAccess();
    }
    
    void Awake()
    {
        _instance = this;
    }

    public void OnLoginClick()
    {
        loginUserName = GameObject.Find("InputUsername/Control - Simple Input Field/Label").GetComponent<UILabel>();
        loginPassword = GameObject.Find("InputPassword/Control - Simple Input Field/Label").GetComponent<UILabel>();
        
        if (loginUserName.text == "lcp" && loginPassword.text == "ok123456")
        {
            return;
        }
        else
        {
            mistake = transform.Find("MistakeLabel").GetComponent<UISprite>();
            mistake.gameObject.SetActive(true);
            HideSprite(mistake.gameObject);
        }
        
    }
    IEnumerator HideSprite(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        go.SetActive(false);
    }
}
