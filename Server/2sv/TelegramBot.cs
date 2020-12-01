using Server.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Server._2FA
{
    class TelegramBot
    {
        static TelegramBotClient bot = new TelegramBotClient("1117925050:AAEetlNxB6kGWH2aywNZgqsdzwnvOaR5rPI");
        string code = "";
        public string actualUsername = "";

        public void init(string code,  string telegramUsername)
        {
            this.code = code;
            bot.StartReceiving();
            bot.OnMessage += bot_onMessage;
            actualUsername = telegramUsername;
        }

        private void bot_onMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text == "/codigo")
                {
                    if (e.Message.Chat.Username.Equals(actualUsername))
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Bienvenido/a " + actualUsername + " su código de autenticación es: " + this.code);
                    }else
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Este usuario de telegram no cuenta con la verificación en dos pasos o no se encuentra actualmente en el proceso de autenticación, no se le enviará ninún código de autenticación.");
                    }
                }
                else
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Comando no reconocido, escriba /codigo para reclamar su código de autenticación.");
                }
            }
        }

        public void botStop()
        {
            bot.StopReceiving();
        }
    }
}
