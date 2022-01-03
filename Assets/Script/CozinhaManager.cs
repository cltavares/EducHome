using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CozinhaManager : MonoBehaviour
{
    public GameObject liquidificador, pratos, fogao, geladeira,
    fogaoPreto, geladeiraPreto, liquidificadorPreto, pratosPreto;
    
    
    
    //cozinha
    public AudioSource pesquisaItensCozinha;
    Vector2 liquidificadorinitialPos, pratosinitialPos, fogaoinitialPos, geladeirainitialPos;
    public AudioClip[] corretoItensCozinha;
    public AudioClip[] inCorretoCozinha;
    bool fogaoCorreto, geladeiraCorreto, liquidificadorCorreto, pratosCorreto = false;
    float timer = 0.0f;
    int seconds = 0;
    [SerializeField]
    public Text contadorItensCozinhaText;
    private int contadorItensCozinha;



    void Start(){
        contadorItensCozinha = 0;
        pesquisaItensCozinha = gameObject.GetComponent<AudioSource>();


        
        liquidificadorinitialPos = liquidificador.transform.position;
        pratosinitialPos = pratos.transform.position;
        fogaoinitialPos = fogao.transform.position;
        geladeirainitialPos = geladeira.transform.position;

    }

    public void DragLiquidificador(){
        liquidificador.transform.position = Input.mousePosition;
    }

    public void DragPratos(){
        pratos.transform.position = Input.mousePosition;
    }

    public void DragFogao(){
        fogao.transform.position = Input.mousePosition;
    }

    public void DragGeladeira(){
        geladeira.transform.position = Input.mousePosition;
    }


    public void DropLiquidificador(){
        float Distance = Vector3.Distance(liquidificador.transform.position, liquidificadorPreto.transform.position);
        if (Distance < 50){
            liquidificador.transform.position = liquidificadorPreto.transform.position;
            pesquisaItensCozinha.clip = corretoItensCozinha[3];
            pesquisaItensCozinha.Play();
            contadorItensCozinha +=1;
            liquidificadorCorreto = true;
        }else{
            liquidificador.transform.position = liquidificadorinitialPos;
            pesquisaItensCozinha.clip = inCorretoCozinha[3];
            pesquisaItensCozinha.Play();
        }
    } 

    public void DropPratos(){
        float Distance = Vector3.Distance(pratos.transform.position, pratosPreto.transform.position);
        if (Distance < 50){
            pratos.transform.position = pratosPreto.transform.position;
            pesquisaItensCozinha.clip = corretoItensCozinha[0];
            pesquisaItensCozinha.Play();
            contadorItensCozinha +=1;
            pratosCorreto = true;
        }else{
            pratos.transform.position = pratosinitialPos;
            pesquisaItensCozinha.clip = inCorretoCozinha[0];
            pesquisaItensCozinha.Play();
        }
    }

    public void DropFogao(){
        float Distance = Vector3.Distance(fogao.transform.position, fogaoPreto.transform.position);
        if (Distance < 50){
            fogao.transform.position = fogaoPreto.transform.position;
            pesquisaItensCozinha.clip = corretoItensCozinha[1];
            pesquisaItensCozinha.Play();
            contadorItensCozinha +=1;
            fogaoCorreto = true;
        }else{
            fogao.transform.position = fogaoinitialPos;
            pesquisaItensCozinha.clip = inCorretoCozinha[1];
            pesquisaItensCozinha.Play();
        }
    } 

    public void DropGeladeira(){
        float Distance = Vector3.Distance(geladeira.transform.position, geladeiraPreto.transform.position);
        if (Distance < 50){
            geladeira.transform.position = geladeiraPreto.transform.position;
            pesquisaItensCozinha.clip = corretoItensCozinha[2];
            pesquisaItensCozinha.Play();
            contadorItensCozinha +=1;
            geladeiraCorreto = true;
        }else{
            geladeira.transform.position = geladeirainitialPos;
            pesquisaItensCozinha.clip = inCorretoCozinha[2];
            pesquisaItensCozinha.Play();
        }
    } 

    



    void Update(){

        contadorItensCozinhaText.text = "Itens:"+ contadorItensCozinha.ToString();
        Debug.Log(contadorItensCozinha);

        if(fogaoCorreto && geladeiraCorreto && liquidificadorCorreto && pratosCorreto){

            timer += Time.deltaTime;
            seconds = (int)(timer % 60);

            if (seconds == 5){
                Debug.Log("itens do banheiro");
                SceneManager.LoadScene("Parabens");
            }
        }
    }  

}
