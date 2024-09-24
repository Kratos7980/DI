/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.carlos.EjerciciosListas;

/**
 *
 *
 * @author KRATOS
 * @version 1.0
 * Created on 17 sept 2024
 */
public class Persona {
    //Atributos
    private int edad;
    
    /**
     * Constructor por defecto.
     * @param edad edad de la persona.
     */
    public Persona(int edad){
        this.edad = edad;
    }
    
    //Getters y Setters
    
    /**
     * Devuelve la edad.
     * @return Edad actual.
     */
    public int getEdad(){
        return edad;
    }
    
    /**
     * Modifica la edad.
     * @param edad Edad nueva.
     */
    public void setEdad(int edad){
        this.edad = edad;
    }
}
