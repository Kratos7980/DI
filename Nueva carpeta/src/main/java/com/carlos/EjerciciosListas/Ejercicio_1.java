/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */

package com.carlos.EjerciciosListas;

import static com.carlos.EjerciciosListas.MetodosExteriores.generaNumeroAleatorio;
import com.carlos.ListaDinamica.ListaEnlazada;
import com.carlos.ListaDinamica.Nodo;
import java.util.ArrayList;

/**
 *
 *
 * @author KRATOS
 * @version 1.0
 * Created on 17 sept 2024
 */
public class Ejercicio_1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        final double CINCOYDIEZ = 1;
        final double ONCEYDIECISIETE = 2.5;
        final double MAYORDIECIOCHO = 3.5;
        
        double monedero = 0;
        int pos = 0;
        
        System.out.println("Con ListaEnlazada");
        
        ListaEnlazada <Persona> lista = generarPersonas();
        while(pos < lista.cuantosElementos()){
            Persona p = lista.devolverDato(pos);
            if(p.getEdad() > 4 && p.getEdad() < 11){
                monedero = monedero + CINCOYDIEZ;
            }else if (p.getEdad() > 10 && p.getEdad() < 18){
                monedero = monedero + ONCEYDIECISIETE;
            }else if (p.getEdad() > 17){
                monedero = monedero + MAYORDIECIOCHO;
            }
            
            pos++;
        }
        System.out.printf("La cantidad recaudada es de: %.2f",monedero);
        lista.listaVacia();
        
        System.out.println("----------------------------");
        System.out.println("Con ArrayList");
        
        ArrayList<Persona> lista2 = generarPersonasArray();
        pos = 0;
        monedero = 0;
        while(pos < lista2.size()){
            Persona p = lista2.get(pos);
            if(p.getEdad() > 4 && p.getEdad() < 11){
                monedero = monedero + CINCOYDIEZ;
            }else if (p.getEdad() > 10 && p.getEdad() < 18){
                monedero = monedero + ONCEYDIECISIETE;
            }else if (p.getEdad() > 17){
                monedero = monedero + MAYORDIECIOCHO;
            }
            pos++;
        }
        System.out.printf("La cantidad recaudada es de: %.2f",monedero);
        lista2.clear();
    }
    
    private static ListaEnlazada generarPersonas(){
        ListaEnlazada lista = new ListaEnlazada();
        int numPersonas = generaNumeroAleatorio(0,50);
        int cont = 0;
        while(cont < numPersonas){
           int edad = generaNumeroAleatorio(5,60);
           Persona p = new Persona(edad);
           lista.insertarPrimero(p);
           cont++;
        }
        
        return lista;
    }
    
    private static ArrayList generarPersonasArray(){
        ArrayList<Persona> lista = new ArrayList<>();
        int numPersonas = generaNumeroAleatorio(0,50);
        int cont = 0;
        while(cont < numPersonas){
           int edad = generaNumeroAleatorio(5,60);
           Persona p = new Persona(edad);
           lista.add(p);
           cont++;
        }
        
        return lista;
    }

}
