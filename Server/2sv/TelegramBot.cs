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

        public void init(string code)
        {
            this.code = code;
            bot.StartReceiving();
            bot.OnMessage += bot_onMessage;
        }

        private void bot_onMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text == "/codigo")
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "su código de autenticación es: " + this.code);
                }
                else
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Comando no reconocido, escriba /codigo para reclamar su código de autenticación.");
                }
            }
        }
    }
}
