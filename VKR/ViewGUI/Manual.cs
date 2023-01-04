using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html;
using Monitel.Rtdb.Api.Config;

namespace ViewGUI
{
    public class Manual
    {
        public void CreateHtmlDoc(string path)
        {
            // Подготовьте выходной путь для сохранения документа
            string documentPath = path;

            // Инициализировать пустой HTML-документ
            using (var document = new HTMLDocument())
            {
                using (var stream = new StreamReader(@"C:\Users\Admin\Desktop\fff.txt"))
                {
                    string[] str = stream.ReadToEnd().Split('\n');
                    string t = String.Join(", ", str);
                    // Создайте текстовый элемент и добавьте его в документ
                    var text = document.CreateTextNode(t);
                    document.Body.AppendChild(text);

                    // Сохраните документ на диск
                    document.Save(documentPath);
                }
            }
        }
    }
}
