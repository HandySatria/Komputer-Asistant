Imports System.Threading
Imports Telegram.Bot
Imports Telegram.Bot.Exceptions
Imports Telegram.Bot.Polling
Imports Telegram.Bot.Types
Imports Telegram.Bot.Types.Enums
Imports Telegram.Bot.Types.ReplyMarkups
Imports Telegram.Bot.Types.Update
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports Telegram.Bot.Types.InputFiles
Imports System.Data.OleDb

Imports System.Diagnostics
Imports System.Timers

Public Class Form1
    Dim log As String
    Dim botClient As TelegramBotClient
    Dim cts As CancellationTokenSource
    Private ReadOnly timer As New System.Timers.Timer(1000) ' Timer dengan interval 1 detik
    Private ReadOnly stopwatch As New Stopwatch()

    Public Sub New()
        ' Inisialisasi komponen
        InitializeComponent()

        ' Menambahkan handler untuk event Elapsed dari timer
        AddHandler timer.Elapsed, AddressOf OnTimedEvent
    End Sub

    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        ' Update label atau kontrol lainnya dengan waktu yang telah berlalu
        Me.Invoke(Sub() UpdateElapsedTime())
    End Sub

    Private Sub UpdateElapsedTime()
        ' Format waktu yang telah berlalu
        Dim elapsed As TimeSpan = stopwatch.Elapsed
        LabelTimer.Text = String.Format("{0:00}:{1:00}:{2:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds)
    End Sub


    Private Sub SaveLog(message As String, chatId As String)
        Try
            Dim query As String = "INSERT INTO log([id_telegram], [dtm_log], [keterangan]) VALUES (@id_telegram, Now(),@keterangan)"

            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@id_telegram", chatId)
                    command.Parameters.AddWithValue("@keterangan", message)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function HandleUpdateAsync(botClient As ITelegramBotClient, update As Update, cancellationToken As CancellationToken) As Task
        Try
            If update.Type = UpdateType.CallbackQuery Then
                Dim callbackQuery = update.CallbackQuery
                Dim data = callbackQuery.Data
                Dim chatId = callbackQuery.Message.Chat.Id

                ' Hapus pesan yang mengandung inline keyboard setelah tombol ditekan
                Await botClient.DeleteMessageAsync(chatId, callbackQuery.Message.MessageId, cancellationToken)

                Select Case data
                    Case "Sticker"
                        Await botClient.SendStickerAsync(chatId:=chatId, sticker:=New InputOnlineFile("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Sticker"
                        SaveLog("Send Sticker", chatId)
                    Case "Gambar"
                        Await botClient.SendDocumentAsync(chatId:=chatId, document:=New InputOnlineFile("https://static.promediateknologi.id/crop/0x0:0x0/750x500/webp/photo/2023/04/10/InShot_20230410_090633955_1-989862021.jpg"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Image"
                        SaveLog("Send Image", chatId)
                    Case "Vidio"
                        Await botClient.SendVideoAsync(chatId:=chatId, video:=New InputOnlineFile("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Video"
                        SaveLog("Send Vidio", chatId)
                    Case "Screenshot"
                        ' Tangkap screenshot dari semua monitor
                        Dim bounds As Rectangle = Screen.AllScreens.Select(Function(screen) screen.Bounds).Aggregate(Function(a, b) Rectangle.Union(a, b))
                        Dim bmp As New Bitmap(bounds.Width, bounds.Height)
                        Using g As Graphics = Graphics.FromImage(bmp)
                            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size)
                        End Using

                        ' Simpan screenshot ke file sementara
                        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "screenshot.png")
                        bmp.Save(tempPath, ImageFormat.Png)

                        ' Kirim screenshot sebagai foto ke chat
                        Using stream As New FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.Read)
                            Await botClient.SendPhotoAsync(chatId:=chatId, photo:=New InputOnlineFile(stream, "screenshot.png"), caption:="Screenshot", cancellationToken:=cancellationToken)
                        End Using

                        ' Hapus file sementara
                        System.IO.File.Delete(tempPath)

                        log = log & Environment.NewLine & "- Send Screenshot"
                        SaveLog("Send Screenshot", chatId)
                    Case "ReplyKeyboard"
                        Dim replyKeyboard = New ReplyKeyboardMarkup(New List(Of List(Of KeyboardButton))() From
                        {
                            New List(Of KeyboardButton)() From
                            {
                                New KeyboardButton("Sticker"),
                                New KeyboardButton("Vidio")
                            },
                            New List(Of KeyboardButton)() From
                            {
                                New KeyboardButton("Gambar")
                            }
                        })

                        Await botClient.SendTextMessageAsync(
                            chatId:=chatId,
                            text:="Pilih fungsi yang ingin Anda jalankan :",
                            replyMarkup:=replyKeyboard,
                            cancellationToken:=cancellationToken
                        )
                        log = log & Environment.NewLine & "- Send ReplyKeyboard"
                    Case "Shutdown"
                        ' Kirim pesan konfirmasi ke chat
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Komputer sedang dimatikan...", cancellationToken:=cancellationToken)

                        ' Matikan komputer
                        Dim processInfo As New ProcessStartInfo("shutdown", "/s /t 0") With {
        .CreateNoWindow = True,
        .UseShellExecute = False
    }
                        Process.Start(processInfo)

                        log = log & Environment.NewLine & "- Shutdown Command Issued"
                        SaveLog("Shutdown", chatId)
                End Select

            Else
                Dim message = update.Message
                Dim messageText = message.Text
                Dim chatId = message.Chat.Id

                Select Case messageText
                    Case "Sticker"
                        Await botClient.SendStickerAsync(chatId:=chatId, sticker:=New InputOnlineFile("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Sticker"
                    Case "Vidio"
                        Await botClient.SendVideoAsync(chatId:=chatId, video:=New InputOnlineFile("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Video"
                    Case "Gambar"
                        Await botClient.SendDocumentAsync(chatId:=chatId, document:=New InputOnlineFile("https://static.promediateknologi.id/crop/0x0:0x0/750x500/webp/photo/2023/04/10/InShot_20230410_090633955_1-989862021.jpg"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Image"
                    Case Else
                        Dim inlineKeyboard = New InlineKeyboardMarkup(
                            {
                                New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Sticker", "Sticker"),
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Gambar", "Gambar"),
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Vidio", "Vidio")
                                },
                                New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Screenshot", "Screenshot")
                                },
                                 New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Shutdown", "Shutdown")
                                },
                                New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk ReplyKeyboard", "ReplyKeyboard")
                                }
                            }
                        )

                        Await botClient.SendTextMessageAsync(
                            chatId:=chatId,
                            text:="Pilih fungsi yang ingin Anda jalankan:",
                            replyMarkup:=inlineKeyboard,
                            cancellationToken:=cancellationToken
                        )
                End Select

                TextBox2.Invoke(Sub() UpdateTextBox(log))

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub UpdateTextBox(text As String)
        If TextBox2.InvokeRequired Then
            TextBox2.Invoke(Sub() UpdateTextBox(text))
        Else
            TextBox2.Text = text
        End If
    End Sub

    Private Function HandlePollingErrorAsync(botClient As ITelegramBotClient, exception As Exception, cancellationToken As CancellationToken) As Task
        Dim ErrorMessage As String = If(TypeOf exception Is ApiRequestException,
                                        $"Telegram API Error:{vbCrLf}[{DirectCast(exception, ApiRequestException).ErrorCode}]{vbCrLf}{DirectCast(exception, ApiRequestException).Message}",
                                        exception.ToString())

        Console.WriteLine(ErrorMessage)
        Return Task.CompletedTask
    End Function

    Private Async Sub Button1_ClickAsync(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Start Bot" Then
            Dim token As String = "6872091136:AAEW2qt4w9vcKFwxCzDzX5-_ecBBKcIc0p0"
            botClient = New TelegramBotClient(token)
            cts = New CancellationTokenSource()

            Dim m = Await botClient.GetMeAsync()
            Console.WriteLine($"Hello, World! I am user {m.Id} and my name is {m.FirstName}.")
            TextBox1.Text = $"Hello, World! I am user {m.Id} and my name is {m.FirstName}"

            botClient.StartReceiving(
                updateHandler:=AddressOf HandleUpdateAsync,
                pollingErrorHandler:=AddressOf HandlePollingErrorAsync,
                cancellationToken:=cts.Token
            )

            Dim mm = Await botClient.GetMeAsync()
            Console.WriteLine($"Start listening for @{mm.Username}")
            Console.ReadLine()
            Button1.Text = "Stop Bot"
            log = "- Bot Start"
            stopwatch.Start()
            timer.Start()
        Else
            cts.Cancel()
            Button1.Text = "Start Bot"
            log = "- Bot Stop"
            stopwatch.Stop()
            timer.Stop()

            ' Catat waktu yang telah berlalu
            Dim elapsed As TimeSpan = stopwatch.Elapsed
            MessageBox.Show($"Waktu yang telah berlalu: {elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}")

            ' Reset stopwatch
            stopwatch.Reset()
        End If
        TextBox2.Text = log
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = log
    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim chatId As Long = 1486234824
        Dim cancellationToken As CancellationToken = CancellationToken.None

        Try
            Await botClient.SendTextMessageAsync(
                chatId:=chatId,
                text:="Komputer masih menyala",
                cancellationToken:=cancellationToken
            )
        Catch ex As Exception
            MsgBox("Gagal mengirim pesan: " & ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Interval = 10000 ' Interval dalam milidetik (10000 ms = 10 detik)
        Timer1.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class
