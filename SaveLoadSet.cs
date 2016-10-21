using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StoryPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void save(List<attributes> myAttributes) { //Saving the file
            string saveFile;
            string[] writeString;
            List<string> listFiles = new List<string>();
            foreach (attributes thisCharacter in myAttributes)
            {
                saveFile = thisCharacter.name + ".txt"; // Creating the file name from the character name
                writeString = attributeWriting(thisCharacter);
                File.WriteAllLines(saveFile, writeString); //Save the character attributes
                listFiles.Add(saveFile);
            }
            File.WriteAllLines("FileNames.txt", listFiles);
        }

        static List<attributes> load() { //Loading from the file
            string[] listFiles;
            string[] myAttributes;
            List<attributes> theAttributes = null;
            if (File.Exists("FileNames.txt") && File.ReadAllText("FileNames.txt") != "")
            {
                theAttributes = new List<attributes>();
                listFiles = File.ReadAllLines("FileNames.txt");  //Read all the filenames
                foreach (string file in listFiles)
                { //load each character
                    myAttributes = File.ReadAllLines(file);
                    attributes mycharacter = new attributes();
                    mycharacter.name = myAttributes[0];
                    mycharacter.birthday = myAttributes[1];
                    mycharacter.age = myAttributes[2];
                    mycharacter.gender = myAttributes[3];
                    mycharacter.race = myAttributes[4];
                    mycharacter.description = myAttributes[5];
                    mycharacter.backstory = myAttributes[6];
                    theAttributes.Add(mycharacter);
                }
            }
            return theAttributes;
        }

        struct attributes {  //The text about the character
            public string name;
            public string birthday;
            public string age;
            public string gender;
            public string race;
            public string description;
            public string backstory;
        }

        static string[] attributeWriting(attributes myAttributes) { //Converts an attribute struct to a string
            string[] attribute = new string[7];
            //Adding all the attributes to the array
            attribute[0] = myAttributes.name;
            attribute[1] = myAttributes.birthday;
            attribute[2] = myAttributes.age;
            attribute[3] = myAttributes.gender;
            attribute[4] = myAttributes.race;
            attribute[5] = myAttributes.description;
            attribute[6] = myAttributes.backstory;
            return attribute;
        }
    }
}
