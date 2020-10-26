using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ESproject.KeyManager;

namespace ESproject.Registro {
    class Registro {
        public static string Register(string mail, string password) {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "register";
            message.message.Add("mail", mail);

            // obtener el hash SHA256 del password
            byte[] passwordHash = KeyManager.KeyManager.getHash(password);
            // partir la mitad para el login y la mitad para el cifrado
            password = KeyManager.KeyManager.getLoginKey(passwordHash);

            message.message.Add("password", password);

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }
    }
}
