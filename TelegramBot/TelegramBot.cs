using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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
            if (e.Message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: $"Hi, I'm .Net Bot and I give you your profile information, write me /profile" +
                          $"\nLearn all commands: /commands"
                );
            }
            else if (e.Message.Text == "/commands")
            {
                await botClient.SendTextMessageAsync(
                    e.Message.Chat,
                    $"/start - to starting bot \n/commands - to view commands \n/About bot - to view information about a bot "
                );
            }
            else if (e.Message.Text == "/profile")
            {
                await botClient.SendTextMessageAsync(
                    e.Message.Chat,
                    $"👤 Your id: {e.Message.Chat.Id} \n🤖 It's bot or not: {e.Message.From.IsBot} " +
                    $"\n1️⃣ First Name: {e.Message.From.FirstName} \n2️⃣ Last Name: {e.Message.From.LastName}" +
                    $"\n🏳️ Country code: {e.Message.From.LanguageCode}"
                );
            }
            else if (e.Message.Text != null)
            {
                await botClient.SendTextMessageAsync(
                    e.Message.Chat,
                    $"Current temp: {OpenWeather<string>.GiveTheWeather(e.Message.Text)}");
            }
        }
    }
}