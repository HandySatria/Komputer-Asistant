
Imports System.Threading
Imports System.Threading.Tasks
Imports Telegram.Bot
Imports Telegram.Bot.Exceptions
Imports Telegram.Bot.Polling
Imports Telegram.Bot.Types
Imports Telegram.Bot.Types.Enums
Imports Telegram.Bot.Types.Receiving
Imports Telegram.Bot.Types.Update
Imports System.IO

Module generalFunction
    Private botClient As TelegramBotClient

    Public connectionString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};"
    Public token As String
    Public password As String
    Public intervalNotif As Integer
    Public isUseNotif As Boolean
    Public isStartUp As Boolean
    Private Function GetDatabasePath() As String
        Dim appDirectory As String = AppDomain.CurrentDomain.BaseDirectory
        Return Path.Combine(appDirectory, "Data", "LaptopAsistantDb.accdb")
    End Function

    Sub Main()
        Dim token As String = "6872091136:AAEW2qt4w9vcKFwxCzDzX5-_ecBBKcIc0p0"
        botClient = New TelegramBotClient(token)

        Dim cts As New CancellationTokenSource()

        Dim receiverOptions As New ReceiverOptions With {
            .AllowedUpdates = Array.Empty(Of UpdateType)()
        }

        botClient.StartReceiving(
            updateHandler:=AddressOf HandleUpdateAsync,
            pollingErrorHandler:=AddressOf HandlePollingErrorAsync,
            receiverOptions:=receiverOptions,
            cancellationToken:=cts.Token
        )

        Dim m = botClient.GetMeAsync().Result
        Console.WriteLine($"Start listening for @{m.Username}")
        Console.ReadLine()

        ' Send cancellation request to stop bot
        cts.Cancel()
    End Sub

    Private Async Function HandleUpdateAsync(botClient As ITelegramBotClient, update As Update, cancellationToken As CancellationToken) As Task
        ' Only process Message updates: https://core.telegram.org/bots/api#message
        If Not TypeOf update.Message Is Message Then
            Return
        End If

        Dim message = DirectCast(update.Message, Message)

        ' Only process text messages
        If message.Text Is Nothing Then
            Return
        End If

        Dim messageText = message.Text

        Dim chatId = message.Chat.Id

        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.")

        ' Echo received message textx
        Dim sentMessage = Await botClient.SendTextMessageAsync(
            chatId:=chatId,
            text:="You said:" & vbCrLf & messageText,
            cancellationToken:=cancellationToken)
    End Function

    Private Function HandlePollingErrorAsync(botClient As ITelegramBotClient, exception As Exception, cancellationToken As CancellationToken) As Task
        Dim ErrorMessage As String = If(TypeOf exception Is ApiRequestException,
                                        $"Telegram API Error:{vbCrLf}[{DirectCast(exception, ApiRequestException).ErrorCode}]{vbCrLf}{DirectCast(exception, ApiRequestException).Message}",
                                        exception.ToString())

        Console.WriteLine(ErrorMessage)
        Return Task.CompletedTask
    End Function
End Module
