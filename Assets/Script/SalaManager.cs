using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SalaManager : MonoBehaviour
{
	public GameObject televisao, sofa, vasoPlantas, mesa,
    vasoPlantasPreto, mesaPreto, televisaoPreto, sofaPreto;

    public AudioSource pesquisaItensSala;
    Vector2 televisaoinitialPos, sofainitialPos, vasoPlantasinitialPos, mesainitialPos;
    public AudioClip[] corretoItensSala;
    public AudioClip[] inCorretoSala;
    bool vasoPlantasCorreto, mesaCorreto, televisaoCorreto, sofaCorreto = false;
    float timer = 0.0f;
    int seconds = 0;
    [SerializeField]
    public Text contadorItensSalaText;
    private int contadorItensSala;


    void Start(){
        contadorItensSala = 0;
        pesquisaItensSala = gameObject.GetComponent<AudioSource>();


        
        televisaoinitialPos = televisao.transform.position;
        sofainitialPos = sofa.transform.position;
        vasoPlantasinitialPos = vasoPlantas.transform.position;
        mesainitialPos = mesa.transform.position;

    }

    public void DragTelevisao(){
        televisao.transform.position = Input.mousePosition;
    }

    public void DragSofa(){
        sofa.transform.position = Input.mousePosition;
    }

    public void DragVasoPlantas(){
        vasoPlantas.transform.position = Input.mousePosition;
    }

    public void DragMesa(){
        mesa.transform.position = Input.mousePosition;
    }


    public void DropTelevisao(){
        float Distance = Vector3.Distance(televisao.transform.position, televisaoPreto.transform.position);
        if (Distance < 50){
            televisao.transform.position = televisaoPreto.transform.position;
            pesquisaItensSala.clip = corretoItensSala[0];
            pesquisaItensSala.Play();
            contadorItensSala += 1;
            televisaoCorreto = true;
        }else{
            televisao.transform.position = televisaoinitialPos;
            pesquisaItensSala.clip = inCorretoSala[0];
            pesquisaItensSala.Play();
        }
    } 

    public void DropSofa(){
        float Distance = Vector3.Distance(sofa.transform.position, sofaPreto.transform.position);
        if (Distance < 50){
            sofa.transform.position = sofaPreto.transform.position;
            pesquisaItensSala.clip = corretoItensSala[1];
            pesquisaItensSala.Play();
            contadorItensSala += 1;
            sofaCorreto = true;
        }else{
            sofa.transform.position = sofainitialPos;
            pesquisaItensSala.clip = inCorretoSala[1];
            pesquisaItensSala.Play();
        }
    }

    public void DropVasoPlantas(){
        float Distance = Vector3.Distance(vasoPlantas.transform.position, vasoPlantasPreto.transform.position);
        if (Distance < 50){
            vasoPlantas.transform.position = vasoPlantasPreto.transform.position;
            pesquisaItensSala.clip = corretoItensSala[2];
            pesquisaItensSala.Play();
            contadorItensSala += 1;
            vasoPlantasCorreto = true;
        }else{
            vasoPlantas.transform.position = vasoPlantasinitialPos;
            pesquisaItensSala.clip = inCorretoSala[2];
            pesquisaItensSala.Play();
        }
    } 

    public void DropMesa(){
        float Distance = Vector3.Distance(mesa.transform.position, mesaPreto.transform.position);
        if (Distance < 50){
            mesa.transform.position = mesaPreto.transform.position;
            pesquisaItensSala.clip = corretoItensSala[3];
            pesquisaItensSala.Play();
            contadorItensSala += 1;
            mesaCorreto = true;
        }else{
            mesa.transform.position = mesainitialPos;
            pesquisaItensSala.clip = inCorretoSala[3];
            pesquisaItensSala.Play();
        }
    } 

    



    void Update(){

        contadorItensSalaText.text = "Itens:"+ contadorItensSala.ToString();
        Debug.Log(contadorItensSala);
        
        if(vasoPlantasCorreto && mesaCorreto && televisaoCorreto && sofaCorreto ){

            timer += Time.deltaTime;
            seconds = (int)(timer % 60);

            if (seconds == 5){
                SceneManager.LoadScene("Parabens");
            }
        }
    } 
}
