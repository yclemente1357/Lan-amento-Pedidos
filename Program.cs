using System.Globalization;
using Course2.Entities;
using Course2.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Data de aniversário: ");
            DateTime birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Insira os dados do pedido: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birth);

            Console.Write("Quantos pedidos serão acrescentados? ");
            int order = int.Parse(Console.ReadLine());

            Order order1 = new Order(DateTime.Now, status, client);

            for (int i = 1; i <= order; i++)
            {
                Console.WriteLine($"Entre com os dados do #{i} pedido:");
                Console.Write("Nome produto: ");
                string nameprod = Console.ReadLine();
                Console.Write("Valor do produto: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantidade: ");
                int quant = int.Parse(Console.ReadLine());

                Product product = new Product(nameprod, price);
                OrderItem item = new OrderItem(quant, price, product);
                order1.AddItem(item);
            }
            Console.WriteLine(order1);
        }
    }
}
