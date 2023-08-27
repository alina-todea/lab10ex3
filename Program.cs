// See https://aka.ms/new-console-template for more information
using System.Net.NetworkInformation;
using Lab10ex3.Models;
using Microsoft.EntityFrameworkCore;


/*

Exercitiul – 3 – gestiune magazin
• Un produs este caracterizat de • Id (unic)
• Nume : string • Stoc: int
• Producator
• Eticheta
• NavigationProperty- ce lipseste?
• Eticheta este caracterizata de : • Id(unic)
• Cod de bare (sub forma unui Guid)
• Pret : double
• NavigationProperty / FK- ce lipseste?
• Producatorii vor fi caracterizati de • Id(unic)
• Nume
• Adresa : string • CUI : string

Exercitiul – 3 – gestiune magazin
1. Stabiliti relatiile dintre clase
2. Realizati diagrama uml
3. Stabiliti relatiile dintre entitati (1- 1,1-*)
4. Stabiliti Navigation Property-urile si FK-urile necesare
5. Creeati DB-ul, DBContext-ul, precum
si o functie statica seedDB
• Scrieti urmatoarele functii
• •
• •
•
Adaugaredeproducator Modificareapretuluiunuiprodus
• Va primi ca parametru id-ul produsului Obtinerea valorii totale a stocului
magazinului
Obtinearea valorii stocului de la un anumit producator oferit ca parametru
• Va primi ca parametru id-ul produsului
• Suplimentar: supraincarcati functia ca sa primeasca parametru numele producatorului
Adaugaredeprodus
• Va adauga automat si eticheta
• Va primi ca parametru producatorul corespunzator produsului si datele produsului

*/

using var ctx = new ShopDbcontext();

//Seed();

//Console.WriteLine ($"Producatorul {SeedProducer("The Ordinary", "address 6", "45632")} a fost adaugat cu succes");

//SeedProduct("crema AHA", 20, 63.20, "The Ordinary",  "45632");

Console.WriteLine($"Stoc Magazin: {GetStock()}");



Console.WriteLine($" Stoc producator: {ctx.GetStockProducer("Nivea", "123")}");

Console.WriteLine($" Stoc produs: {ctx.GetStockProducer(1)}");


ChangePrice(2, 100.50);



static void Seed()
{

    using var ctx = new ShopDbcontext();

    var nivea = new Producer
    {
        Name = "Nivea",
        Address = "address 1",
        Cui = "123"
    };
    var dove = new Producer
    {
        Name = "Dove",
        Address = "address 2",
        Cui = "456"
    };

    var samponNivea = new Product
    {
        Name = "sampon",
        Stock = 50,
        Price = 48.5,
        Producer = nivea
        

    };
    var balsamNivea = new Product
    {
        Name = "balsam",
        Stock = 25,
        Price = 24,
        Producer = nivea


    };

    var cremaDove = new Product
    {
        Name = "crema",
        Stock = 45,
        Price = 59.00,
        Producer = dove
    };

    ctx.Tags.Add(new Tag
    {
        Product = samponNivea
    }); 

    ctx.Tags.Add(new Tag
    {
        
        Product = cremaDove
    });
    ctx.Tags.Add(new Tag
    {

        Product = balsamNivea
    }); ;
    ctx.SaveChanges();

}

static string SeedProducer(string name, string address, string cui)

{
    using var ctx = new ShopDbcontext();

    ctx.Producers.Add(new Producer
    {
        Name = name,
        Address = address,
        Cui = cui
        
    });
    ctx.SaveChanges();

    return name;
    
}

/*
static string GetProducer(string name, string cui)
{
    using var ctx = new ShopDbcontext();

    var producer = ctx.Producers
     .Where(e => e.Name == name && e.Cui == cui)
     .Take(1).ToList();

    return producer;
}
 

static void SeedProduct(string name, int stock, double price, string producerName, string producerCui)

{
    using var ctx = new ShopDbcontext();

    var product = new Product
    {
        Name =name,
        Stock = stock,
        Price = price,
        Producer = GetProducer(producerName, producerCui)
    };

    ctx.Tags.Add(new Tag
    {
        
        Product = product
    });

    Console.WriteLine($"Produsul {name} a fost adaugat cu succes. Eticheta a fost creata.");

}
*/

static int GetStock()
{
    using var ctx = new ShopDbcontext();

    int stock = ctx.Products.Sum(e => e.Stock);

    return stock;


}

static void ChangePrice(int id, double newPrice)
{
    using var ctx = new ShopDbcontext();

    
    ctx.Products
       .Where(e => e.Id==id)
       .ToList()
       .ForEach(e => e.Price=newPrice);

    ctx.SaveChanges();
    

}
