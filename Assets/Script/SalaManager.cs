using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaManager : MonoBehaviour
{
	public GameObject televisao, sofa, vasoPlantas, mesa,
    vasoPlantasPreto, mesaPreto, televisaoPreto, sofaPreto;

    public AudioSource pesquisaItensSala;
    Vector2 televisaoinitialPos, sofainitialPos, vasoPlantasinitialPos, mesainitialPos;
    public AudioClip[] corretoItensSala;
    public AudioClip[] inCorretoSala;
    bool vasoPlantasCorreto, mesaCorreto, televisaoCorreto, sofaCorreto = false;


    void Start(){
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
            mesaCorreto = true;
        }else{
            mesa.transform.position = mesainitialPos;
            pesquisaItensSala.clip = inCorretoSala[3];
            pesquisaItensSala.Play();
        }
    } 

    



    void Update(){
    } 
}
