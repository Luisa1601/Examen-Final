using ExamenBotTelegram.Implementaciones;
using ExamenBotTelegram.Modelos;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ExamenBotTelegram
{
    class Program
    {
        
        //luisa_e_bot - Nombre de bot en telegram

        static ITelegramBotClient botClient;
        static string tToken = "1826228497:AAHpMApG9OUDQnTxsU7ab1Gdm9w_EPKbEsc";
        static ClsPaciente basedatos = new ClsPaciente();

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(tToken);
            var me = botClient.GetMeAsync().Result;

            Console.WriteLine($"ID BOT: {me.Id} ---> NAME {me.FirstName}");

            //botClient.OnMessage += botClient_OnMessage

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Presione alguna tecla para salir...");
            Console.ReadKey();

            botClient.StopReceiving();

        }


        private async static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var mensaje = e.Message;

            if (mensaje == null || mensaje.Type != MessageType.Text)
                return;

            Console.WriteLine($"Mensaje de @{mensaje.Chat.Username}:" + mensaje.Text);
            ConsultaModelo consulta = new ConsultaModelo(mensaje.Chat.FirstName, mensaje.Text, DateTime.Today);

            basedatos.guardarConsultaBd(consulta);

            switch (mensaje.Text.Split(' ').GetValue(0))
            {
                
                //Según el mensaje leído podremos hacer cualquier tarea
                case "/hola":
                    await botClient.SendTextMessageAsync(
                        mensaje.Chat.Id,
                        $"Hola {mensaje.Chat.FirstName} para consultar el status de vacunación envía la palabra DPI seguido de espacio y el CUI a consultar, sin espacios. Ej: DPI 7845778850101 "
                        );
                    break;
                case "/start":
                    await botClient.SendTextMessageAsync(
                        mensaje.Chat.Id,
                        $"Hola {mensaje.Chat.FirstName} para consultar el status de vacunación envía la palabra DPI seguido de espacio y el CUI a consultar, sin espacios. Ej: DPI 7845778850101 "
                        );
                    break;
                case "DPI":
                    String dpi = mensaje.Text.Split(' ').GetValue(1).ToString();
                    Int64 nDPI = Convert.ToInt64(dpi);

                    var datospaciente = basedatos.consultaPaciente(nDPI);

                    if (String.IsNullOrEmpty(datospaciente.Nombres))
                    {
                        await botClient.SendTextMessageAsync(
                                mensaje.Chat.Id,
                                $"Lo siento {emojis.mdEmoji.pulgarAbajo} pero no existen resultados para el DPI {dpi}."
                            );
                    }
                    else {
                        
                            await botClient.SendTextMessageAsync(
                                mensaje.Chat.Id,
                                $"Gracias por consultar {mensaje.Chat.FirstName} {emojis.mdEmoji.smile}, la consulta del DPI {dpi} es la siguiente: "
                            );
                        
                            await botClient.SendTextMessageAsync(
                                mensaje.Chat.Id,
                                $"Nombre Completo: {datospaciente.Nombres} {datospaciente.Apellidos}. \nVacuna suministrada {datospaciente.Vacuna}. \nCantidad de dósis: {datospaciente.Ndosis.ToString()}. "
                            );
                    }


                    break;
                case "vacunas":
                    List<string> vacunas = basedatos.obtenerVacunas();
                    await botClient.SendTextMessageAsync(
                        mensaje.Chat.Id,
                        $"Gracias por consultar {mensaje.Chat.FirstName} {emojis.mdEmoji.smile}, Tenemos disponibles estas vacunas: "
                        );

                    foreach(string vacuna in vacunas)
                    {
                        await botClient.SendTextMessageAsync(
                                mensaje.Chat.Id,
                                $"{vacuna}"
                            );
                    }
                    break;

                default:
                    await botClient.SendTextMessageAsync(
                      mensaje.Chat.Id,
                      $"Lo siento {emojis.mdEmoji.pulgarAbajo}, parece que no ingresaste una opción válida. \n\nPuedes intentar nuevamente con DPI, hola, start, vacunas" 
                      );

                    break;
            }


        }
    }
}
