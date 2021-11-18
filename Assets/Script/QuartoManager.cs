using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuartoManager : MonoBehaviour
{
    public GameObject cama, guardaRoupas, travisseiro, cobertor,
    travisseiroPreto, cobertorPreto, camaPreto, guardaRoupasPreto;
    
    public AudioSource pesquisaItensQuarto;
    Vector2 camainitialPos, guardaRoupasinitialPos, travisseiroinitialPos, cobertorinitialPos;
    public AudioClip[] corretoItensLavanderia;
    public AudioClip[] inCorretoLavanderia;
    bool travisseiroCorreto, cobertorCorreto, camaCorreto, guardaRoupasCorreto = false;


    void Start(){
        pesquisaItensQuarto = gameObject.GetComponent<AudioSource>();


        
        camainitialPos = cama.transform.position;
        guardaRoupasinitialPos = guardaRoupas.transform.position;
        travisseiroinitialPos = travisseiro.transform.position;
        cobertorinitialPos = cobertor.transform.position;

    }

    public void DragCama(){
        cama.transform.position = Input.mousePosition;
    }

    public void DragGuardaRoupas(){
        guardaRoupas.transform.position = Input.mousePosition;
    }

    public void DragTravisseiro(){
        travisseiro.transform.position = Input.mousePosition;
    }

    public void DragCobertor(){
        cobertor.transform.position = Input.mousePosition;
    }


    public void DropCama(){
        float Distance = Vector3.Distance(cama.transform.position, camaPreto.transform.position);
        if (Distance < 50){
            cama.transform.position = camaPreto.transform.position;
            //pesquisaItensQuarto.clip = corretoItensBanheiro[1];
            //pesquisaItensQuarto.Play();
            camaCorreto = true;
        }else{
            cama.transform.position = camainitialPos;
            //pesquisaItensQuarto.clip = inCorretoBanheiro;
            //pesquisaItensQuarto.Play();
        }
    } 

    public void DropGuardaRoupas(){
        float Distance = Vector3.Distance(guardaRoupas.transform.position, guardaRoupasPreto.transform.position);
        if (Distance < 50){
            guardaRoupas.transform.position = guardaRoupasPreto.transform.position;
            //pesquisaItensQuarto.clip = corretoItensBanheiro[2];
            //pesquisaItensQuarto.Play();
            guardaRoupasCorreto = true;
        }else{
            guardaRoupas.transform.position = guardaRoupasinitialPos;
            //pesquisaItensQuarto.clip = inCorretoBanheiro;
            //pesquisaItensQuarto.Play();
        }
    }

    public void DropTravisseiro(){
        float Distance = Vector3.Distance(travisseiro.transform.position, travisseiroPreto.transform.position);
        if (Distance < 50){
            travisseiro.transform.position = travisseiroPreto.transform.position;
            //pesquisaItensQuarto.clip = corretoItensBanheiro[0];
            //pesquisaItensQuarto.Play();
            travisseiroCorreto = true;
        }else{
            travisseiro.transform.position = travisseiroinitialPos;
            //pesquisaItensQuarto.clip = inCorretoBanheiro;
            //pesquisaItensQuarto.Play();
        }
    } 

    public void DropCobertor(){
        float Distance = Vector3.Distance(cobertor.transform.position, cobertorPreto.transform.position);
        if (Distance < 50){
            cobertor.transform.position = cobertorPreto.transform.position;
            //pesquisaItensQuarto.clip = corretoItensBanheiro[3];
            //pesquisaItensQuarto.Play();
            cobertorCorreto = true;
        }else{
            cobertor.transform.position = cobertorinitialPos;
            //pesquisaItensQuarto.clip = inCorretoBanheiro;
            //pesquisaItensQuarto.Play();
        }
    } 

    



    void Update(){
    } 
}
