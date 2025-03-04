﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESproject._2FA
{
    class SecondFA
    {
        public static string Activate2FA(string mail, string telegramUser)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "activate2FA";
            message.message.Add("mail", mail);

            message.message.Add("telegramUser", telegramUser);

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }
        public static string checkIf2FAIsActivated(string mail)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "check2FAStatus";
            message.message.Add("mail", mail);

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }

        public static string getTelegramUsername(string mail)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "getTelegramUsername";
            message.message.Add("mail", mail);

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }
    }
}
