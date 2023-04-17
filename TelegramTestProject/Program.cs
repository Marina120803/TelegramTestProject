using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    static ITelegramBotClient bot = new TelegramBotClient("5808263407:AAELBVoiS4qc3hOJpEOmiWgJDIvxb1YZTvU");

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

        String message = update.Message.Text;
        long chatId = update.Message.Chat.Id;



        if (message.Equals("/start"))
        {
            ReplyKeyboardMarkup Start = new(new[]
            {
                new KeyboardButton[] { "Привет", "Пока" },
                new KeyboardButton[] { "У меня температура","У меня болит голова" },
                new KeyboardButton[] { "У меня кашель","У меня насморк" },
            });


            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Здравствуйте, пациент!",
               replyMarkup: Start 
           );
        }

        if (message.ToLower().Contains("привет"))
        {
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Как твоё здоровье?"
           );
        }

        if (message.ToLower().Contains("пока"))
        {
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Не болей!)"
           );
        }

        if (message.ToLower().Contains("у меня температура"))
        {
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Выпейте парацетамол, если температура выше 38 градусов"
           );
        }

        if (message.ToLower().Contains("у меня болит голова"))
        {
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Можно принять прохладный душ, помыть голову, то есть остудить организм. Когда нет возможности сходить в душ, можно намочить прохладной водой полотенце, положить на голову и так полежать какое-то время. Если от таких общих мероприятий головная боль не проходит, можно выпить таблетку обезболивающего: парацетамол, ацетилсалициловую кислоту либо любое нестероидное противовоспалительное средство, которое есть в аптечке."
           );
        }

        if (message.ToLower().Contains("у меня кашель"))
        {
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Своевременно лечить простудные заболевания.\r\nЕжегодно делать флюорографию.\r\nЗаниматься физкультурой и спортом.\r\nРегулярно совершать пешие прогулки.\r\nПроводить процедуры закаливания.\r\nПроветривать квартиру.\r\nПринимать витаминные комплексы."
           );
        }

        if (message.ToLower().Contains("у меня насморк"))
        {
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Можно полоскать ротоглотку настойкой календулы, принимать таблетки для рассасывания. Врачи советуют избегать резких запахов, ограничить использование бытовой химии, которая может раздражать слизистую. При интенсивных болях нужно принимать теплую, химически и механически щадящую пищу — супы, каши. Если горло очень болит или боль сопровождается лихорадкой, слабостью, необходимо в кратчайшие сроки обратиться к врачу."
           );
        }
    }

    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

        var cts = new CancellationTokenSource();

        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // разрешено получать все виды апдейтов
        };

        bot.StartReceiving(
        HandleUpdateAsync,
        HandleErrorAsync,
        receiverOptions, 
        cancellationToken

        );

        Console.ReadLine();


    }
}