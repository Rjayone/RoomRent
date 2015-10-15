using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RoomRent
{
    class XMLFileOperator{

        private string pathToXml;
  

        public XMLFileOperator(string pathToXml) {
            this.pathToXml = pathToXml;
        }

        public void CreateXmlFile(){
            XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("flats");
            textWritter.WriteEndElement();
            textWritter.Close();
        }

        public List<Flat> getAllFlatsFromXml() {
            List<Flat> list = new List<Flat>();
            XElement root = XElement.Load("file.xml");
            IEnumerable<XElement> flats =
            from el in root.Elements("flat")
            select el;
            foreach (XElement el in flats)
            {
                Flat flat = new Flat();
                flat.Id = (long)el.Attribute("id");
                flat.RoomCount = (int)el.Element("roomCount");
                flat.Price = (int)el.Element("price");
          
                Address address = new Address();
                address.Region = el.Element("address").Element("region").Value;
                address.Street = el.Element("address").Element("street").Value;
                address.HouseNumb = el.Element("address").Element("houseNo").Value;
                address.FlatNumb = (int)el.Element("address").Element("flatNo");

                flat.FlatAddress = address;
                list.Add(flat);
                
            }
            return list;
        
        }

        public List<String> getAllRegions() {
            List<Flat> flats = getAllFlatsFromXml();
            List<String> regions = new List<String>();
            foreach (Flat el in flats) {
                regions.Add(el.FlatAddress.Region);
            }
            return regions;
        }

        public void FillFlatIntoXml(Flat flat)
        {
            XmlDocument document = new XmlDocument();
            document.Load(pathToXml);
            XmlNode element = document.CreateElement("flat");
            document.DocumentElement.AppendChild(element); // указываем родителя
            XmlAttribute attribute = document.CreateAttribute("id"); // создаём атрибут
            attribute.Value = flat.Id.ToString(); // устанавливаем значение атрибута
            element.Attributes.Append(attribute); // добавляем атрибут

            XmlNode roomCount = document.CreateElement("roomCount"); // даём имя
            roomCount.InnerText = flat.RoomCount.ToString(); // и значение
            element.AppendChild(roomCount); // и указываем кому принадлежит

            XmlNode price = document.CreateElement("price"); // даём имя
            price.InnerText = flat.Price.ToString(); // и значение
            element.AppendChild(price); // и указываем кому принадлежит
            
            XmlNode address = document.CreateElement("address"); // даём имя
            element.AppendChild(address); // и указываем кому принадлежит

            XmlNode region = document.CreateElement("region"); // даём имя
            region.InnerText = flat.FlatAddress.Region;// и значение
            address.AppendChild(region); // и указываем кому принадлежит

            XmlNode street = document.CreateElement("street"); // даём имя
            street.InnerText = flat.FlatAddress.Street;// и значение
            address.AppendChild(street); // и указываем кому принадлежит

            XmlNode houseNumb = document.CreateElement("houseNo"); // даём имя
            houseNumb.InnerText = flat.FlatAddress.HouseNumb;// и значение
            address.AppendChild(houseNumb); // и указываем кому принадлежит

            XmlNode flatNumb = document.CreateElement("flatNo"); // даём имя
            flatNumb.InnerText = flat.FlatAddress.FlatNumb.ToString();// и значение
            address.AppendChild(flatNumb); // и указываем кому принадлежит

            document.Save(pathToXml);
        }

    }
}
