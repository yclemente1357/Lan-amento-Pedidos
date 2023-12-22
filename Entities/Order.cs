using System.Globalization;
using System.Text;
using Course2.Entities.Enums;

namespace Course2.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { 
        }
        
        public Order(DateTime date, OrderStatus status, Client client)
        {
            Moment = date;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        
        public double GetPrice()
        {
            double price = 0.00;
            foreach (OrderItem item in Items)
            {
                price += item.SubTotal();
            }

            return price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Resumo dos Pedido(s)");
            sb.AppendLine("Momento: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Status do pedido: " + Status);
            sb.AppendLine("Cliente" + Client);
            sb.AppendLine("itens do pedido:");

            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("Total price: " + GetPrice().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }


    }
}
