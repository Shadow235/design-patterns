
using GenericJsonRepository;

var repository = new Repository<Printer>("printers.json");

repository.Add(new Printer { Name = "Printer 1" });
repository.SaveChanges();

Console.ReadKey();