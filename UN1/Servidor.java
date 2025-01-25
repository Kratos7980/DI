import java.io.*;
import java.net.*;
import java.util.*;

public class Servidor {
    // Mapa para asociar usuarios a sus flujos de salida
    private static Map<String, PrintWriter> usuariosConectados = new HashMap<>();

    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(12345)) {
            System.out.println("Servidor iniciado. Esperando conexiones...");
            while (true) {
                Socket socket = serverSocket.accept();
                new HiloCliente(socket).start();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    static class HiloCliente extends Thread {
        private Socket socket;
        private String nombreUsuario;
        private PrintWriter salida;

        public HiloCliente(Socket socket) {
            this.socket = socket;
        }

        @Override
        public void run() {
            try (
                BufferedReader entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            ) {
                salida = new PrintWriter(socket.getOutputStream(), true);

                // Registrar al usuario
                salida.println("Introduce tu nombre de usuario:");
                nombreUsuario = entrada.readLine();
                synchronized (usuariosConectados) {
                    usuariosConectados.put(nombreUsuario, salida);
                }
                System.out.println(nombreUsuario + " se ha conectado.");

                // Escuchar mensajes
                String mensaje;
                while ((mensaje = entrada.readLine()) != null) {
                    System.out.println("Mensaje recibido: " + mensaje);
                    procesarMensaje(mensaje);
                }
            } catch (IOException e) {
                System.out.println(nombreUsuario + " se ha desconectado.");
            } finally {
                // Eliminar al usuario de la lista de conectados
                if (nombreUsuario != null) {
                    synchronized (usuariosConectados) {
                        usuariosConectados.remove(nombreUsuario);
                    }
                }
                try {
                    socket.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        private void procesarMensaje(String mensaje) {
            // El mensaje debe tener un formato "receptor:contenido"
            String[] partes = mensaje.split(":", 2);
            if (partes.length == 2) {
                String receptor = partes[0];
                String contenido = partes[1];

                // Buscar al receptor y enviar el mensaje
                synchronized (usuariosConectados) {
                    PrintWriter salidaReceptor = usuariosConectados.get(receptor);
                    if (salidaReceptor != null) {
                        salidaReceptor.println("Mensaje de " + nombreUsuario + ": " + contenido);
                    } else {
                        salida.println("El usuario " + receptor + " no está conectado.");
                    }
                }
            } else {
                salida.println("Formato incorrecto. Usa: receptor:mensaje");
            }
        }
    }
}
