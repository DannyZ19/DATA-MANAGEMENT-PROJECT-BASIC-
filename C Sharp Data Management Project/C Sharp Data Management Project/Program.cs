using System;
using System.Collections.Generic;
using System.Text.Json;

// CS30 Data Mangement Project - By Daniel Zahiroddini


// DATA ARRAY


List<Song> songsList = new List<Song>();
songsList.Add(new Song("UPTOWN FUNK", "BRUNO MARS", "POP"));
songsList.Add(new Song("HEY YA!", "OUTKAST", "FUNK"));
songsList.Add(new Song("DESPACITO", "LUIS FONSI", "LATIN"));
songsList.Add(new Song("ALL TIME LOW", "JON BELLION", "POP"));
songsList.Add(new Song("SUMMER", "CALVIN HARRIS", "ELECTRONIC"));
songsList.Add(new Song("BAD ROMANCE", "LADY GAGA", "POP"));
songsList.Add(new Song("DA FUNK", "DAFT PUNK", "FUNK"));
songsList.Add(new Song("WAKE ME UP", "AVICII", "ELECTRONIC"));
songsList.Add(new Song("LA TORTURA", "SHAKIRA", "LATIN"));

// LOAD FAVOURITES FROM FILE
string favouritesStr = File.ReadAllText(@"C:\Users\d.zahiroddini\Desktop\favouritesList\daniel.txt");

List<Song> favouriteList;
if (favouritesStr != "")
{
    var options = new JsonSerializerOptions { IncludeFields = true };
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    favouriteList = JsonSerializer.Deserialize<List<Song>>(favouritesStr, options);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

} else
{
    favouriteList = new List<Song>();
}





List<string> accounts = new List<string>();

// MENU \\




do
{
    Console.WriteLine("\n\nMENU");

    Console.WriteLine("\n1.Display All Data");
    Console.WriteLine("\n2.Display Some Data");
    Console.WriteLine("\n3.Add Data to Favourites List");
    Console.WriteLine("\n4.Remove Data from Favourites List");
    Console.WriteLine("\n5.Display Favourites List");
    Console.WriteLine("\n6.Exit");


    Console.WriteLine("\nPlease make a selection.");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    string selection = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

    if (selection == "1")
    {
        OptionOne();
    }

    if (selection == "2")
    {
        OptionTwo();
    }

    if (selection == "3")
    {
        OptionThree();
    }
    if (selection == "4")
    {
        OptionFour();
    }

    if (selection == "5")
    {
        OptionFive();
    }

    if (selection == "6")
    {
        Save();
    }

} while (true);

void OptionOne()
{
    Console.WriteLine("Display All Data");
    foreach (var song in songsList)
    {
        Console.WriteLine($" \n Name: {song.name}\n Artist: {song.artist}\n Genre: {song.genre}  ");
    }
}

void OptionTwo()
{
    
    Console.WriteLine("Display Some Data");

    Console.WriteLine("Please type in a song that you'd like to find.");

    string response =  Console.ReadLine().ToUpper();

    foreach (var songs in songsList)
    {
        if (songs.genre == response)
        {
            Console.WriteLine($"Here is {songs.name} by {songs.artist} \nGenre: {songs.genre}");
        }
    }
    

    
    
    
    
        
}

void OptionThree()
{
    Console.WriteLine("Add Data to Favourites List");

    Console.WriteLine("Enter name of song to add to favourites list: ");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    string songName = Console.ReadLine().ToUpper();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    int index = LinearSearch(songsList, songName);
    if (index == -1)
    {
        Console.WriteLine("Song not found");
    } else
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        favouriteList.Add(songsList[index]);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
        

}

void OptionFour()
{
    Console.WriteLine("Remove Data from Favourites List");

    Console.WriteLine("Please remove a song from your favourites list");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    string removeSong = Console.ReadLine().ToUpper();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    int index = LinearSearch(songsList, removeSong);
    if (index == -1)
    {
        Console.WriteLine("Song not found in favourite list");
    } else
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        favouriteList.Remove(songsList[index]);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
  

}

void OptionFive()
{
    Console.WriteLine("Display Favourites List");



#pragma warning disable CS8602 // Dereference of a possibly null reference.
    foreach (var fave in favouriteList)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    {
        Console.WriteLine($" \n {fave.name}, {fave.artist}, {fave.genre}  ");
    }
}

void Save()
{
    Console.WriteLine("\nSaving before Exit.");

// SAVE LIST INTO FILE 
    var options = new JsonSerializerOptions { IncludeFields = true };
    string jsonString = JsonSerializer.Serialize(favouriteList, options);
    File.WriteAllText(@"C:\Users\d.zahiroddini\Desktop\favouritesList\daniel.txt", jsonString);

    Console.WriteLine("\nSaved.");

    Environment.Exit(0);
}


int LinearSearch(List<Song> list, string target)
{
    for (int i = 0; i < list.Count; i++)
    {
        if (target == list[i].name)
            return (i);
    }
    return -1;
}


class Song
{
    public string name;
    public string artist;
    public string genre;

    public Song(string name, string artist, string genre)
    {
        this.name = name;
        this.artist = artist;
        this.genre = genre;
    }
}