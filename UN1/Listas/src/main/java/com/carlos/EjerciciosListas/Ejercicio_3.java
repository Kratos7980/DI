/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */

package com.carlos.EjerciciosListas;

import static com.carlos.EjerciciosListas.MetodosExteriores.generaNumeroAleatorio;
import com.carlos.PilaDinamica.PilaDinamica;

/**
 *
 *
 * @author Carlos-García-Villa
 * @version 1.0
 * Created on 17 sept 2024
 */
public class Ejercicio_3 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        int top = 0;
        int codigo;
        int tarea;
        
        PilaDinamica pila = new PilaDinamica();
        
        System.out.println("Añado 10 informes");
        
        while(top < 10){
            codigo = generaNumeroAleatorio(1000,100000);
            tarea = generaNumeroAleatorio(0,2);
            Informe i = new Informe(codigo,tarea);
            pila.push(i);
            top++;
        }
        
        System.out.printf("La pila tiene ahora %d informes \n",pila.size());
        System.out.println("Saco los informes uno a uno:");
        
        while(!pila.isEmpty()){
            Informe i = (Informe) pila.pop();
            System.out.println(i.getCodigo()+" "+i.getTarea());
        }
        
        System.out.println("¿La pila está vacía? "+pila.isEmpty());
        System.out.println("Añado 5 informes");
        
        top = 0;
        
        while(top < 5){
            codigo = generaNumeroAleatorio(1000,100000);
            tarea = generaNumeroAleatorio(0,2);
            Informe i = new Informe(codigo,tarea);
            pila.push(i);
            top++;
        }
        
        System.out.printf("La pila tiene ahora %d informes",pila.size());
        
    }

}
