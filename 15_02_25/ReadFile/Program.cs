using System;
using System.IO;
class StreamReaderExample {
    static void Main() {
       Console.WriteLine("enter the file Path");
       string filePath=Console.ReadLine();

        try {
            using (StreamReader sr = new StreamReader(filePath)) {
                string line;
                while ((line = sr.ReadLine()) != null) { // Read line by line
                    Console.WriteLine(line);
                }
            }
        } catch (IOException e) {
            Console.WriteLine(e.Message);
        }
    }
}
