//version incrementor: 0001


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace cleaner3._0
{
    public partial class Form1 : Form
    {
        
        static class Globals
        {
            //program defined files
            public static string programFileDirectory;
            public static string configFile;
            public static string acceptedCharsFile;
            public static string genericContentFile;

            //user defined files
            public static string dirtyFile;
        }

        private void triggerErrorForm(string errorMessage)
        {
            FatalErrorFound errorFound = new FatalErrorFound();
            errorFound.label1.Text = errorMessage;
            errorFound.Show();
        }

        private void initializeGlobals()
        {
            //set directory of program files
            string programFileDirectory = System.IO.Directory.GetCurrentDirectory() + @"\programFiles";
            if (Directory.Exists(programFileDirectory))
            {
                Globals.programFileDirectory = programFileDirectory;
            }
            else { triggerErrorForm("Could not find the programsFiles directory"); }

            //set path for configFile
            string configFile = Globals.programFileDirectory + @"\config.txt";
            if (File.Exists(configFile)) { Globals.configFile = configFile; }
            else { triggerErrorForm("Could not find the config.txt"); }

            //set path for accepted charecters file
            string acceptedCharsFile = Globals.programFileDirectory + @"\acceptedChars.txt";
            if (File.Exists(acceptedCharsFile)) { Globals.acceptedCharsFile = acceptedCharsFile; }
            else { triggerErrorForm("Could not find the acceptedChars.txt"); }

            Console.WriteLine("HERE" + Globals.acceptedCharsFile);

            if ((checkEncodingType(Globals.acceptedCharsFile)) != 3)
            { //File not in unicode
                triggerErrorForm("acceptedChars.txt not in unicode");
            }

            //set path for generic content file
            string genericContentFile = Globals.programFileDirectory + @"\genericContent.txt";
            if (File.Exists(genericContentFile)) { Globals.genericContentFile = genericContentFile; }
            else { triggerErrorForm("Could not find the genericContent.txt"); }

            Console.WriteLine("HERE" + Globals.genericContentFile);

            if ((checkEncodingType(Globals.genericContentFile)) != 3)
            { //File not in unicode
                triggerErrorForm("genericContent.txt not in unicode");
            }

            
        }


        

        /**********************************************************
        *           getDirectoryOf(string)
        * 
        * Input:
        *   - string origin: Location to create the file
        *   
        * Notes: Strip the filename from the abs path to obtain
        *        the folder where the file resides
        *********************************************************/
        private string getDirectoryOf(string origin)
        {
            string directory = origin.Substring(origin.LastIndexOf("\\") + 1);
            directory = origin.Remove(origin.IndexOf(directory));

            return directory;
        }

        /**********************************************************
        *        getFilePath(string)
        *   
        * Notes: Displays file exploerer for user to pick file path
        *********************************************************/
        private string getFilePath()
        {
            System.IO.StreamReader configReader = new System.IO.StreamReader(Globals.configFile, System.Text.Encoding.Unicode);
            string lastKnowndirtyFileLoc = getConfigInfoFor(configReader);
            configReader.Close();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = lastKnowndirtyFileLoc;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ShowDialog();


            setDirtyFileLoc(openFileDialog1.FileName);

            return openFileDialog1.FileName;
        }

        /**********************************************************
        *           writeListToFile(List<string>, string)
        * 
        * Input:
        *   - string thisList: Name of the list to write to file
        *   - string thisFile: File to write the list too
        *   
        * Notes: writes one element of the list to its own line.
        *        One element per line.
        *********************************************************/
        private void writeListToFile(List<string> thisList, string thisFile)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(thisFile, false, Encoding.Unicode))
            {
                foreach (string line in thisList)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private void writeDictValueToFile(SortedDictionary<int, string> thisDict, string thisFile)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(thisFile, false, Encoding.Unicode))
            {
                foreach (var pair in thisDict.OrderBy(p => p.Value))
                {
                    writer.WriteLine(pair.Value);
                }
            }
        }

        /**********************************************************
        *        deleteDuplicatesFrom(string)
        * 
        * Input:
        *   - string thisFile: file to check and remove duplicates
        *********************************************************/
        private List<string> deleteDuplicatesFrom(string thisFile)
        {
            string line = "";
            List<string> dupList = new List<string>();
            List<string> noDupList = new List<string>();

            System.IO.StreamReader reader = new System.IO.StreamReader(thisFile, System.Text.Encoding.UTF8);

            //primmer

            while ((line = reader.ReadLine()) != null)
            {
                dupList.Add(line);
            }
            reader.Close();

            noDupList = dupList.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();

            writeListToFile(noDupList, thisFile); //overwright file without duplicates

            //dupList = dupList.Intersect(noDupList).ToList();
            dupList = dupList.GroupBy(s => s.ToUpperInvariant()).SelectMany(grp => grp.Skip(1)).ToList();

            return dupList;
        }
        /**********************************************************
        *        checkEncodingType(string)
        * 
        * Input:
        *   - string thisFile: file to be checked for it's encoding
        *                      type
        *   
        * Notes: Returns a number associated with its encoding type
        *********************************************************/
        private int checkEncodingType(string thisFile)
        {
            var bom = new byte[4]; //byte order mask
            using (var checkFile = new FileStream(thisFile, FileMode.Open, FileAccess.Read)) { checkFile.Read(bom, 0, 4); }

            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return 1; // UTF-7
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return 2; // UTF-8
            if (bom[0] == 0xff && bom[1] == 0xfe) return 3; // Unicode (UTF-16LE)
            if (bom[0] == 0xfe && bom[1] == 0xff) return 4; // Big Endian Unicode (UTF-16BE)
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return 5; // UTF-32

            return -1;
        }

        /**********************************************************
        *        populateStringList(string)
        * 
        * Input:
        *   - string thisFile: the file to be stored into a list
        *   
        * Notes: Returns a list with each element containing
        *        one line of the file.
        *********************************************************/
        private List<string> populateStringListByLine(string thisFile)
        {
            List<string> thisList = new List<string>();
            string line = "";

            System.IO.StreamReader reader = new System.IO.StreamReader(thisFile, System.Text.Encoding.Unicode);

            while ((line = reader.ReadLine()) != null)
            {
                thisList.Add(line);
            }
            reader.Close();
            return thisList;
        }

        private List<int> populateStringListByCharecter(string thisFile)
        {
            List<int> thisList = new List<int>();
            string line = "";

            System.IO.StreamReader reader = new System.IO.StreamReader(thisFile, System.Text.Encoding.Unicode);

            while ((line = reader.ReadLine()) != null)
            {// get integer value of the accepted charecter file
                foreach (int x in line) thisList.Add(x);
            }
            reader.Close();
            return thisList;
        }

        /**********************************************************
        *           getConfigInfoFor(System.IO.StreamReader)
        * 
        * Input:
        *   - string reader: opened stream reader to access file
        *                    content
        *   
        * Notes: Returns next line not preceeding with a '#'
        *********************************************************/
        private string getConfigInfoFor(System.IO.StreamReader reader)
        {
            string line = "";
            string path = "";
            //obtain configuration information
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("#")) { continue; } //skip documentation
                path = line;
                break;
            }
            return path;
        }

        private void setDirtyFileLoc(string newLocation)
        {
            //string newLocation = getDirectoryOf(absPath);

            string[] oldLocation = File.ReadAllLines(Globals.configFile);
            oldLocation[1] = newLocation; //2rd line is the absolute path for dirtyFile
            File.WriteAllLines(Globals.configFile, oldLocation);
        }

        /*###########################################################
         *               Main Form Initializer
         *###########################################################*/
        public Form1()
        {
            InitializeComponent();
            initializeGlobals();


            configLabel.Text = "Config File: " + Globals.configFile;
            acceptedLabel.Text = "Accepted Charecters File: " + Globals.acceptedCharsFile;
            GenericContentLabel.Text = "Generic Content File: " + Globals.genericContentFile;
        }

        /*###########################################################
         *               ChooseFileButton_Click
         *###########################################################*/
        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            string results = getFilePath();

            if (results != "")
            {
                Globals.dirtyFile = results;

                if ((checkEncodingType(Globals.dirtyFile)) != 3)
                { //File not in unicode
                    triggerErrorForm("File chosen was not in unicode");
                }

                sourceLabel.Text = "Source: " + Globals.dirtyFile;
            }
            else
            {

                
            }
        }
        /*###########################################################
         *               CleanFileButton_Click
         *###########################################################*/
        private void cleanFileButton_Click(object sender, EventArgs e)
        {
            string data = "";

            List<int> acceptedCharList = new List<int>();
            //List<int> RowRemovedList = new List<int>();
            List<string> genericContentList = new List<string>();
           // List<string> contentRemovedList = new List<string>();

            SortedDictionary<int, string> badContentDict = new SortedDictionary<int, string>();


            acceptedCharList = populateStringListByCharecter(Globals.acceptedCharsFile); //put accepted chars file into a list
            genericContentList = populateStringListByLine(Globals.genericContentFile); //put generic content file into a list

            System.IO.StreamReader dirtyReader = new System.IO.StreamReader(Globals.dirtyFile, System.Text.Encoding.Unicode);



            int currentRow = 0;
            while ((data = dirtyReader.ReadLine()) != null)
            {// read through the dirty file
                bool foundGeneric = false;

                foreach (string s in genericContentList)
                {
                    if (s.ToUpperInvariant() == data.ToUpperInvariant())
                    {//check for generic
                        badContentDict.Add(currentRow, data);
                        foundGeneric = true;
                        break;
                    }
                }
                if (!foundGeneric)
                { //if a generic word was not found
                    foreach (int x in data)
                    {
                        if (!acceptedCharList.Contains(x) || data.Length <= 3)
                        { //if a charecter is found not in the accepted list
                            badContentDict.Add(currentRow, data);
                            break;
                        }
                    }
                }
                currentRow++;
                foundGeneric = false;
            }
            dirtyReader.Close();

            //////////////////////////////////////////////////////////

            //*********   Creating cleaned file

            string cleanedFile = getDirectoryOf(Globals.dirtyFile) + "cleanedFile.txt";

            // ########## Creating clean file

            string line = "";
            using (System.IO.StreamWriter cleanFileWriter = new System.IO.StreamWriter(cleanedFile, false, Encoding.UTF8))
            {
                dirtyReader = new System.IO.StreamReader(Globals.dirtyFile);

                int thisRow = 0;
                while ((line = dirtyReader.ReadLine()) != null)
                {
                    if (!badContentDict.ContainsKey(thisRow))
                    {// Only enter if the row is valid
                        cleanFileWriter.WriteLine(line);
                    }
                    thisRow++;
                }
                dirtyReader.Close();
            }


            List<string> duplicateList = new List<string>();
            duplicateList = deleteDuplicatesFrom(cleanedFile);

            string duplicatesRemovedFile = getDirectoryOf(Globals.dirtyFile) + "duplicatesRemoved.txt";
            writeListToFile(duplicateList, duplicatesRemovedFile);

            //check duplicate content


            //checked overalcontent

            string contentRemovedFile = getDirectoryOf(Globals.dirtyFile) + "contentRemoved.txt";

            writeDictValueToFile(badContentDict, contentRemovedFile);




            Console.WriteLine("Done...");

            cleaningCommplete successForm = new cleaningCommplete();
            successForm.successMessageLable.Text = "Cleaning Complete.\r\nCheck the following folder for the results:\r\n" + getDirectoryOf(Globals.dirtyFile);
            successForm.Show();
        }
    }
}
