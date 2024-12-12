using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CallCenterApp
{
    internal class MessageManager
    {
        private List<Message> messages=new List<Message> ();

        // message ekleme
        public void AddMessage(string userMessage, int userID)
        {
            // any metodu ile aynı id ye sahip başka bir mesaj var mı kontrol eder,true ya da false değeri döndürür
            if (messages.Any(m => m.ID == userID))
            {
                Console.WriteLine("\nBu ID zaten kullanılıyor. Farklı bir ID giriniz.");
                Console.WriteLine();
                return; // Çakışma durumunda metottan çık
            }

            // Yeni bir Message nesnesi oluştur ve listeye ekle
            messages.Add(new Message
            {
                ID = userID,
                UserMessage = userMessage,
                Response = null
            });

            Console.WriteLine("\nMesajınız başarılı bir şekilde kaydedildi!");
            Console.WriteLine();
        }

        // mesajları getirme
        public void GetMessages()
        {
            //  messages.count eleman sayısını döndürür
            if (messages.Count == 0)
            {
                Console.WriteLine("\nMesaj bulunamamaktadır.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nAlınan Mesajlar: ");
                Console.WriteLine();
                foreach (var message in messages)
                {
                    Console.WriteLine($"ID: {message.ID} \nMesaj: {message.UserMessage} \nYanıt: {message.Response ?? "Yanıt bekleniyor"}");
                    Console.Write("------------------");
                    Console.WriteLine();
                }
            }
        }

        // yanıt ekleme
        public void AddResponse(int messageID , string response)
        {
            var control = false;
            foreach (var message in messages)
            {
                if (messageID == message.ID)
                {
                    message.Response = response;
                    control = true;
                    break;
                }
            }

            if (control == true)
            {
                Console.WriteLine("\nMesaj başarılı bir şekilde eklendi.");
            }
            else
            {
                Console.WriteLine("\nBelirtilen ID değerine sahip bir mesaj bulunamadı.");
            }
            Console.WriteLine();
        }

        // message silme
        public void DeleteMessage(int deleteID)
        {
            // removeAll komutu koleksiyonda bulunan ögeleri belirli koşula göre siler ve sildiği öge sayısını döndürür
            int removedID = messages.RemoveAll(m => m.ID == deleteID);
            Console.WriteLine();
            if (removedID > 0)
            {
                Console.WriteLine($"ID bilgisi {deleteID} olan mesajınız silinmiştir.");
            }
            else
            {
                Console.WriteLine("Belirtilen ID'ye sahip mesaj bulunamadı.");
            }
            Console.WriteLine();
        }
    }
}   
    
