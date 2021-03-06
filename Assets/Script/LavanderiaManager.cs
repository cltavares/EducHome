using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LavanderiaManager : MonoBehaviour
{
   public GameObject maquinaLavar, sabaoPo, balde, varalRoupas,
    baldePreto, varalRoupasPreto, maquinaLavarPreto, sabaoPoPreto;
    
    
    
    //cozinha
    public AudioSource pesquisaItensLavanderia;
    Vector2 maquinaLavarinitialPos, sabaoPoinitialPos, baldeinitialPos, varalRoupasinitialPos;
    public AudioClip[] corretoItensLavanderia;
    public AudioClip[] inCorretoLavanderia;
    bool baldeCorreto, varalRoupasCorreto, maquinaLavarCorreto, sabaoPoCorreto = false;
    float timer = 0.0f;
    int seconds = 0;
    [SerializeField]
    public Text contadorItensLavanderiaText;
    private int contadorItensLavanderia;


    void Start(){
        contadorItensLavanderia = 0;
        pesquisaItensLavanderia = gameObject.GetComponent<AudioSource>();


        
        maquinaLavarinitialPos = maquinaLavar.transform.position;
        sabaoPoinitialPos = sabaoPo.transform.position;
        baldeinitialPos = balde.transform.position;
        varalRoupasinitialPos = varalRoupas.transform.position;

    }

    public void DragMaquinaLavar(){
        maquinaLavar.transform.position = Input.mousePosition;
    }

    public void DragSabaoPo(){
        sabaoPo.transform.position = Input.mousePosition;
    }

    public void DragBalde(){
        balde.transform.position = Input.mousePosition;
    }

    public void DragVaralRoupas(){
        varalRoupas.transform.position = Input.mousePosition;
    }


    public void DropMaquinaLavar(){
        float Distance = Vector3.Distance(maquinaLavar.transform.position, maquinaLavarPreto.transform.position);
        if (Distance < 50){
            maquinaLavar.transform.position = maquinaLavarPreto.transform.position;
            pesquisaItensLavanderia.clip = corretoItensLavanderia[1];
            pesquisaItensLavanderia.Play();
            contadorItensLavanderia += 1;
            maquinaLavarCorreto = true;
            alterarImagem(maquinaLavar, maquinaLavarPreto);
        }else{
            maquinaLavar.transform.position = maquinaLavarinitialPos;
            pesquisaItensLavanderia.clip = inCorretoLavanderia[1];
            pesquisaItensLavanderia.Play();
        }
    } 

    public void DropSabaoPo(){
        float Distance = Vector3.Distance(sabaoPo.transform.position, sabaoPoPreto.transform.position);
        if (Distance < 50){
            sabaoPo.transform.position = sabaoPoPreto.transform.position;
            pesquisaItensLavanderia.clip = corretoItensLavanderia[2];
            pesquisaItensLavanderia.Play();
            contadorItensLavanderia += 1;
            sabaoPoCorreto = true;
            alterarImagem(sabaoPo, sabaoPoPreto);
        }else{
            sabaoPo.transform.position = sabaoPoinitialPos;
            pesquisaItensLavanderia.clip = inCorretoLavanderia[2];
            pesquisaItensLavanderia.Play();
        }
    }

    public void DropBalde(){
        float Distance = Vector3.Distance(balde.transform.position, baldePreto.transform.position);
        if (Distance < 50){
            balde.transform.position = baldePreto.transform.position;
            pesquisaItensLavanderia.clip = corretoItensLavanderia[0];
            pesquisaItensLavanderia.Play();
            contadorItensLavanderia += 1;
            baldeCorreto = true;
            alterarImagem(balde, baldePreto);
        }else{
            balde.transform.position = baldeinitialPos;
            pesquisaItensLavanderia.clip = inCorretoLavanderia[0];
            pesquisaItensLavanderia.Play();
        }
    } 

    public void DropVaralRoupas(){
        float Distance = Vector3.Distance(varalRoupas.transform.position, varalRoupasPreto.transform.position);
        if (Distance < 50){
            varalRoupas.transform.position = varalRoupasPreto.transform.position;
            pesquisaItensLavanderia.clip = corretoItensLavanderia[3];
            pesquisaItensLavanderia.Play();
            contadorItensLavanderia += 1;
            varalRoupasCorreto = true;
            alterarImagem(varalRoupas, varalRoupasPreto);
        }else{
            varalRoupas.transform.position = varalRoupasinitialPos;
            pesquisaItensLavanderia.clip = inCorretoLavanderia[3];
            pesquisaItensLavanderia.Play();
        }
    } 

    private void alterarImagem(GameObject imagem, GameObject imagemPreto)
    {
        imagem.GetComponent<Image>().enabled = false;
        imagemPreto.GetComponent<Image>().color = new Color(255,255,255);
    }

    void Update(){

        contadorItensLavanderiaText.text = "Itens: "+ contadorItensLavanderia.ToString();
        Debug.Log(contadorItensLavanderia);
        
        if(baldeCorreto && varalRoupasCorreto && maquinaLavarCorreto && sabaoPoCorreto){

            timer += Time.deltaTime;
            seconds = (int)(timer % 60);

            if (seconds == 3){
                SceneManager.LoadScene("Parabens");
            }
        }
    }  
}
