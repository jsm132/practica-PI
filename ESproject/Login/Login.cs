using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ESproject.Login
{
    class Login
    { 
       public static string LoginClient(string mail, string password, string secondFA, string telegramUser)
       {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "login";
            message.message.Add("mail", mail);

            // obtener el hash SHA256 del password
            byte[] passwordHash = KeyManager.KeyManager.getHash(password);
            // partir la mitad para el login y la mitad para el cifrado
            password = KeyManager.KeyManager.getLoginKey(passwordHash);

            message.message.Add("password", password);
            message.message.Add("secondFA", secondFA);
            message.message.Add("telegramUser", telegramUser);

            string loginMessage = JsonConvert.SerializeObject(message);

            User.setName(mail);
            User.setCipherKey(KeyManager.KeyManager.getCipherKey(passwordHash));
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
;           string respuestaServidor = Cliente.WriteMessage(loginMessage);
            
            if(secondFA.Equals("NO"))
                Cliente.closeConnection(); //Arreglar second step
            return respuestaServidor;
        }

        public static string SecondStep(string code)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "secondstep";
            message.message.Add("code", code);

            string SecondStepMessage = JsonConvert.SerializeObject(message);

            string respuestaServidor = Cliente.WriteMessage(SecondStepMessage);
            if(respuestaServidor.Equals("El código es correcto"))
                Cliente.closeConnection();
            //Aquí se ejecuta el hilo
            return respuestaServidor;
        }
    }
}
