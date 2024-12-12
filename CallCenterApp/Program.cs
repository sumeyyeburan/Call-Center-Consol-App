using CallCenterApp;

MessageManager messageManager=new MessageManager();

Console.WriteLine("\nÇağrı Merkezi Sistemine Hoşgeldiniz!");

while (true)
{
    Console.WriteLine("\n1.Mesaj Gönder");
    Console.WriteLine("2.Mesajları Görüntüle");
    Console.WriteLine("3.Yanıt Gönder");
    Console.WriteLine("4.Mesajı Sil");
    Console.WriteLine("5.Çıkış");

    Console.Write("\nSeçiminiz: ");
    string choice=Console.ReadLine();

    bool success=int.TryParse(choice, out int result);

    if (success)
    {
        switch (result)
        {
            case 1:
                Console.WriteLine("\nMesajınızı giriniz: ");
                string userMessage = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userMessage))
                {
                    Console.WriteLine("\nMesaj içeriği boş olamaz!");
                    continue;
                }
                Console.WriteLine("Mesajınıza ait ID bilgisini giriniz: ");
                string UserID = Console.ReadLine();
                //UserID değeri eğer integer ise userIDCheck true olur ve değer userID değerine atanır, eğer değilse userIDCheck false olur ve userID değerine 0 atanır.
                bool userIDCheck = int.TryParse(UserID, out int userID);
                if (userIDCheck)
                {
                    if (userID >= 0)
                    {
                        messageManager.AddMessage(userMessage, userID);
                    }
                    else
                    {
                        Console.WriteLine("\nID bilgisi negatif sayı olamaz!");
                    }
                }
                else
                {
                    Console.WriteLine("\nID bilgisi integer olmalı!");
                }
                break;

            case 2:
                messageManager.GetMessages();
                break;

            case 3:
                Console.Write("\nYanıtlamak istediğiniz mesajın ID bilgisini giriniz: ");
                string MessageID = Console.ReadLine();
                bool messageIDCheck = int.TryParse(MessageID, out int messageID);
                if (messageIDCheck)
                {
                    if (messageID >= 0)
                    {
                        Console.Write("Yanıtınızı yazın: ");
                        string response = Console.ReadLine();
                        messageManager.AddResponse(messageID, response);
                    }
                    else
                    {
                        Console.WriteLine("\nID bilgisi negatif sayı olamaz!");
                    }
                }
                else
                {
                    Console.WriteLine("\nID bilgisi integer olmalı!");
                }
                break;

            case 4:
                Console.Write("\nSilmek istediğiniz mesajın ID bilgisini giriniz: ");
                string DeleteID =Console.ReadLine();
                bool deleteIDCheck = int.TryParse(DeleteID, out int deleteID);
                if (deleteIDCheck)
                {
                    if (deleteID >= 0)
                    {
                        messageManager.DeleteMessage(deleteID);
                    }
                    else
                    {
                        Console.WriteLine("\nID bilgisi negatif sayı olamaz!");
                    }
                }
                else
                {
                    Console.WriteLine("\nID bilgisi integer olmalı!");
                }
                break;

            case 5:
                Console.WriteLine("\nÇıkış yapılıyor...");
                return;

            default:
                Console.WriteLine("\nGeçersiz seçim, tekrar deneyin.");
                break;
        }
    }
    else
    {
        Console.WriteLine("\nInteger dışında bir sayı girdiniz,tekrar deneyiniz!");
        Console.WriteLine("\n************************************************************");
        continue;
    }
}