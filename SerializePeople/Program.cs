using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        public string Name;
        [NonSerialized]
        public byte age;
        public int BirthDate;
        public Genders Gender;

        public int currentYear = DateTime.Now.Year;
        private const string filename = "data.dat";

        public enum Genders
        {
            Male,
            Female
        }

        public Person(string[] args)
        {
            this.Name = args[0];
            int.TryParse(args[1], out BirthDate);
            this.age = (byte)(currentYear - BirthDate);
            Enum.TryParse(args[2], out Gender);
        }
        public Person()
        {
            this.Name = null;
            int.TryParse("0", out BirthDate);
            this.age = 0;
            Enum.TryParse("0", out Gender);
        }

        public override string ToString()
        {
            return "Name: " + Name + " Age: " + age + " BirthDate: " + BirthDate + " Gender: " + Gender;
        }

        public void Serialize(string[] args)
        {

            // Create file to save the data
            // Create and use a BinaryFormatter object to perform the serialization
            // Close the file
           
            // Create object Person
            var p = new Person(args);

            // Serialize object.
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Person.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, p);
            stream.Close();
        }
        public static Person Deserialize()
        {
             // notice that Person should have a default constructor
                                          // Open file to read the data from
                                          // Create a BinaryFormatter object to perform the deserialization
                                          // Use the BinaryFormatter object to deserialize the data from the file
                                          // Close the file and return with the brand-new Person object
                                          // Deserialize object.
            IFormatter formatter = new BinaryFormatter();
            Stream readStream = new FileStream("Person.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Person p2 = (Person)formatter.Deserialize(readStream);
            readStream.Close();
            return p2;
        }

        static void Main(string[] args)
        {
            var person = new Person(args);
            person.Serialize(args);
            Person person2 = Deserialize();
            Console.WriteLine(person2.ToString());
            System.Console.WriteLine("Done.");
            Console.ReadKey();
        }

        public void OnDeserialization(object sender)
        {
            this.age = 99;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           info.AddValue("Name", Name);
           info.AddValue("Birthdate", BirthDate);
           info.AddValue("Gender", Gender);
           info.AddValue("age", 99);
        }
    }
}
