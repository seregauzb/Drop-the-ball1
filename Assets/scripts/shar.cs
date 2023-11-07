using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class shar : MonoBehaviour
{
    public Vector3 bosh;
    public bool tur=true,otildi=false,autoplay=false;
    public int pul,tikilganpul;
    public float foizi=1,oytime=0,ortime=0,sanoq=0;
    public TMP_Text tikpultext,foiztext,pultext;
    public byte kun=0,ornkul,bolnum=0,koef=1;
    string kunso;
    PhysicMaterial pm;
    public Texture[] ballssss;
    public RawImage image;
    public GameObject win;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        bolnum=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3.txt"));
        image.texture=ballssss[bolnum];
        gameObject.GetComponent<SphereCollider>().material.bounciness=1f;
        bosh=new Vector3(transform.position.x,transform.position.y,transform.position.z);
        tashla();
        pultikishp();
        kunso=File.ReadAllText(Application.persistentDataPath + "/maqollar.txt");
        kun=sammy(kunso);
        kunso=File.ReadAllText(Application.persistentDataPath + "/maqollar1.txt");
        ornkul=sammy(kunso);
        oytime=float.Parse(File.ReadAllText(Application.persistentDataPath + "/oyvaqt.txt"));
        ortime=float.Parse(File.ReadAllText(Application.persistentDataPath + "/oyvaqt1.txt"));
        pul=pulochish(File.ReadAllText(Application.persistentDataPath + "/hayvonlar.txt"));
        pultext.text=pul.ToString();
        saralash("ballnum.ToString()","/a.txt",0);
        saralash("Int.Parse()","/b.txt",1);
    }

    // Update is called once per frame
    void Update()
    {
        oytime+=Time.deltaTime;
        ortime+=Time.deltaTime;
        kun+=timerkun();
        ornkul+=timeroykun();
        if(tur){
            transform.position=bosh;
            if(autoplay){
                tur=false;
                tashla();
                pulol();
            }
        }
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.GetComponent<savat>()==null){
        Destroy(Instantiate(sound,transform.position,transform.rotation),5);
        }
    }
    void saralash(string ss,string adressa,byte bul){
        if(File.ReadAllText(Application.persistentDataPath + adressa)==ss){
            switch(bul){
                case 0:koef=2;break;
                case 1:gameObject.GetComponent<SphereCollider>().material.bounciness=0.7f;break;
            }
        }
    }
    
    public void apl(){
        autoplay=true;
    }
    public void tashla(){
        if(tikilganpul>=100){
        int a=Random.Range(0,2);
        if(a==0){
            a=-1;
        }
        transform.position=bosh;
        transform.position+=new Vector3(a,0,0);
        transform.GetComponent<Rigidbody>().velocity=Vector3.zero;
        otildi=false;
        }
    }
    public void turrma(){
        if(tikilganpul>=100){
        tur=false;
        }
    }
    public void pultikishp(){
        if(tikilganpul<=pul-100){
        tikilganpul+=100;
        tikpultext.text="SUM: "+tikilganpul.ToString();
        }
    }
    public void pultikishm(){
        if(tikilganpul>0){
        tikilganpul-=100;
        tikpultext.text="SUM: "+tikilganpul.ToString();
        }
    }
    public void pulol(){
        pul-=tikilganpul;
        pultext.text=pul.ToString();
        if(tikilganpul>=15000){
            File.WriteAllText(Application.persistentDataPath + "/botir.txt","onam");
        }
        if(pul==0){
            File.WriteAllText(Application.persistentDataPath + "/yulduz.txt","O'zbekiston");
        }
    }
    public void tiktek(){
        while(tikilganpul>pul){
            tikilganpul-=100;
        }
        tikpultext.text="SUM: "+tikilganpul.ToString();
        pultext.text="SUM: "+pul.ToString();
        foiztext.text=foizi.ToString()+"x"; 
    }
    public void tomainmenu(){
        samus();
        samus1();
        pulkodlash();
        SceneManager.LoadScene("Bosh menu");
    }
    byte timerkun(){
        byte qu=0;
        while(ortime>3600*24){
            ortime-=3600*24;
            qu++;
        }
        return qu;
    }
    byte timeroykun(){
        byte qu=0;
        while(oytime>3600*24){
            oytime-=3600*24;
            qu++;
        }
        return qu;
    }
    void samus(){
        string maqol="";
        switch(kun){
            case 0:maqol="Ona bilan bola gul bilan lola";break;
            case 1:maqol="Mehr ko'zda";break;
            case 2:maqol="Oshing halol bo'lsa ko'chada ye";break;
            case 3:maqol="Ari zaxrin chekmagan bol qadrini bilmas";break;
            case 4:maqol="Axtargan topar";break;
            case 5:maqol="Ahdi borning baxti bor";break;
            case 6:maqol="Bog' jamoli bog'bondan";break;            
        }
        File.WriteAllText(Application.persistentDataPath + "/maqollar.txt",maqol);
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt1.txt",ortime.ToString());
    }
    void samus1(){
        string maqol="";
        switch(ornkul){
            case 0:maqol="Ona bilan bola gul bilan lola";break;
            case 1:maqol="Mehr ko'zda";break;
            case 2:maqol="Oshing halol bo'lsa ko'chada ye";break;
            case 3:maqol="Ari zaxrin chekmagan bol qadrini bilmas";break;
            case 4:maqol="Axtargan topar";break;
            case 5:maqol="Ahdi borning baxti bor";break;
            case 6:maqol="Bog' jamoli bog'bondan";break;            
        }
        File.WriteAllText(Application.persistentDataPath + "/maqollar1.txt",maqol);
    }
    byte sammy(string satr){
        byte qqq=0;
        if(satr=="Ona bilan bola gul bilan lola"){
            qqq= 0;
        }
        if(satr=="Mehr ko'zda"){
            qqq= 1;
        }
        if(satr=="Oshing halol bo'lsa ko'chada ye"){
            qqq= 2;
        }
        if(satr=="Ari zaxrin chekmagan bol qadrini bilmas"){
            qqq= 3;
        }
        if(satr=="Axtargan topar"){
            qqq= 4;
        }
        if(satr=="Ahdi borning baxti bor"){
            qqq=5;
        }
        if(satr=="Bog' jamoli bog'bondan"){
            qqq= 6;
        }
        return qqq;
    }
    void pulkodlash(){
        string soz="";string son=pul.ToString();
        char[] ch1=son.ToCharArray();
        foreach(var v in ch1){
            
            switch(int.Parse(v.ToString())){
                case 0:soz+="ciklop";break;
                case 1:soz+="tiger";break;
                case 2:soz+="elephand";break;
                case 3:soz+="duck";break;
                case 4:soz+="sheep";break;
                case 5:soz+="wolf";break;
                case 6:soz+="hyena";break;
                case 7:soz+="coyote";break;
                case 8:soz+="zebra";break;
                case 9:soz+="buffalo";break;
            }
            soz+="|";
        }
        File.WriteAllText(Application.persistentDataPath + "/hayvonlar.txt",soz);
    }
    int pulochish(string s){
        char[] ch1=s.ToCharArray();
        string[] tillar=new string[9];
        byte dt=0,sanoq=0;
        string soz="";
        string javob="";
        foreach(var a in ch1){
            if(a.ToString()!="|"){
            soz+=a.ToString();dt++;
            }else{
                dt=0;tillar[sanoq]=soz;sanoq++;soz="";
            }
        }
        while(sanoq>0){
            sanoq--;
            s=tillar[sanoq];
        if(s=="ciklop"){
            javob+="0";
        }
        if(s=="tiger"){
            javob+="1";
        }
        if(s=="elephand"){
            javob+="2";
        }
        if(s=="duck"){
            javob+="3";
        }
        if(s=="sheep"){
            javob+="4";
        }
        if(s=="wolf"){
            javob+="5";
        }
        if(s=="hyena"){
            javob+="6";
        }
        if(s=="coyote"){
            javob+="7";
        }
        if(s=="zebra"){
            javob+="8";
        }
        if(s=="buffalo"){
            javob+="9";
        }
        Debug.Log(javob);
        }
        soz="";
        ch1=javob.ToCharArray();
        Debug.Log(javob);
        foreach(var a in ch1){
            soz=a.ToString()+soz;
        }
        return int.Parse(soz);
    }

}
