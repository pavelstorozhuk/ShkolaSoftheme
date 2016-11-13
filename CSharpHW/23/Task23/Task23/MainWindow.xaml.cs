using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;
using  System.Xml.Linq;

namespace Task23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path;
        private XmlDocument doc;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_OnClick(object sender, RoutedEventArgs e)
        {
            Text.Document.Blocks.Clear();
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            var doc = XDocument.Load(fileDialog.FileName);
            _path = fileDialog.FileName;
            Text.AppendText(doc.ToString());
        }

        private XmlNode CreateBook()
        {
            XmlNode book = doc.CreateElement("book");
            XmlNode author = doc.CreateElement("author");
            XmlNode title = doc.CreateElement("title");
            XmlNode price = doc.CreateElement("price");
            XmlNode genre = doc.CreateElement("genre");
            XmlNode publish_date = doc.CreateElement("publish_date");
            XmlNode description = doc.CreateElement("description");


            XmlAttribute attr = doc.CreateAttribute("id");
            attr.Value = IdBox.Text;
            book.Attributes.Append(attr);


            XmlNode textAuthor = doc.CreateTextNode(AuthorBox.Text);
            XmlNode textTitle = doc.CreateTextNode(TitleBox.Text);
            XmlNode textPrice = doc.CreateTextNode(PriceBox.Text);
            XmlNode textGenre = doc.CreateTextNode(GenreBox.Text);
            XmlNode textPublish_date = doc.CreateTextNode(GenreBox.Text);
            XmlNode textDescription = doc.CreateTextNode(DescriptionBox.Text);

            author.AppendChild(textAuthor);
            title.AppendChild(textTitle);
            price.AppendChild(textPrice);
            genre.AppendChild(textGenre);
            publish_date.AppendChild(textPublish_date);
            description.AppendChild(textDescription);

            book.AppendChild(author);
            book.AppendChild(title);
            book.AppendChild(price);
            book.AppendChild(genre);
            book.AppendChild(genre);
            book.AppendChild(publish_date);
            book.AppendChild(description);
            return book;
        }
        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (IdBox == null || _path == string.Empty)
                return;
            doc = new XmlDocument();
            if (_path == null)
                return;
            doc.Load(_path);
            var navigator = doc.CreateNavigator();
          
   
            XmlNode root = doc.DocumentElement;
         
            root.AppendChild(CreateBook());
            doc.Save(_path);
              var doc2 = XDocument.Load(_path);
            Text.Document.Blocks.Clear();
            Text.AppendText(doc2.ToString());
          
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (IdBox == null || _path ==string.Empty)
                return;
            var document = XDocument.Load(_path);
            var b1 = document.Descendants("book")
                        .Where(b => b.FirstAttribute.Value==IdBox.Text).ToList();
                                  
           // var nodes = document.Elements().Where(x => x.Element("book").Attribute("id").Value== IdBox.Text).ToList();

            foreach (var node in b1)
                node.Remove();
            document.Save(_path);
            document = XDocument.Load(_path);
            Text.Document.Blocks.Clear();
            Text.AppendText(document.ToString());
        }


        private void Find_OnClick(object sender, RoutedEventArgs e)
        {
            if (AuthorBox.Text == String.Empty)
                return;
            var document = XDocument.Load(_path);

            var query= document.Descendants("book")
                      .Where(b => b.Elements("author")
                                   .Any(f => (string)f == AuthorBox.Text));
            string buf = "";
            foreach (var result in query)
            {
                buf += result.Name + ":" + result.Value + "\n";
               
            }
            MessageBox.Show(buf);
        }
    }
}
