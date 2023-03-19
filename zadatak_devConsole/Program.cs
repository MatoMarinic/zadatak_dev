// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
using zadatak_devConsole;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7014");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/users");
HttpResponseMessage response2 = await client.GetAsync("api/preferences");
response.EnsureSuccessStatusCode();
response2.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var users = await response.Content.ReadFromJsonAsync<IEnumerable<UsersDto>>();
    foreach (var user in users)
    {
        Console.WriteLine("***** KORISNICI *****");
        Console.WriteLine("\tIme: " +user.Ime);
        Console.WriteLine("\tPrezime: " +user.Prezime);
        Console.WriteLine("\tDob: " +user.Dob);
    }
}
else
{
    Console.WriteLine("No results");
}
if (response2.IsSuccessStatusCode)
{
    var preferences = await response2.Content.ReadFromJsonAsync<IEnumerable<PreferencesDto>>();
    foreach (var preference in preferences)
    {
        Console.WriteLine("***** PREFERENCE *****");
        Console.WriteLine("\tZanr knjige: " +preference.Zanr_Knjige);
        Console.WriteLine("\tNaziv knjige: " +preference.Naziv_Knjige);
        Console.WriteLine("\tAutor knjige: " +preference.Autor_Knjige);
    }
}
else
{
    Console.WriteLine("No results");
}
Console.ReadLine();