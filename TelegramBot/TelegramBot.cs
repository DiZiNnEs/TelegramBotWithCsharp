using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBot
{
    public static class TelegramBot
    {
        static ITelegramBotClient botClient;

        public static void TelegramBotMain(string TOKEN)
        {
            botClient = new TelegramBotClient(TOKEN);

            User me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, Bro! I am bot {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "You said:\n" + e.Message.Text
                );
            }

            if (e.Message.Text == "Hello")
            {
                await botClient.SendTextMessageAsync(
                    e.Message.Chat,
                    $"Hello, I'm bot and my name is .Net Core Bot for testing, {e.Message.Chat.Username}, {e.Message.Contact.PhoneNumber}, {e.Message.Chat.Photo}"
                );
            }

            Console.WriteLine(e.Message.From.FirstName);
        }
    }
}
