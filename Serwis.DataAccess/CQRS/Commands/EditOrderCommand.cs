using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class EditOrderCommand : CommandBase<Order, Order>
    {
        public async override Task<Order> Exexute(ServiceStorageContext context)
        {
            var employee = context.Employees.Find(1);
            var order = await context.Orders.FindAsync(Parameter.Id);

            if(Parameter.Diagnosis != order.Diagnosis)
            {
                order.Diagnosis = Parameter.Diagnosis;
                await context.OrderHistories.AddAsync(CreateOrderHistory(order, employee, "Wystawiono diagnozę", Parameter.Diagnosis));
            }   
            
            if(Parameter.Price != order.Price)
            {
                order.Price = Parameter.Price;
                await context.OrderHistories.AddAsync(CreateOrderHistory(order, employee, "Określono kwotę naprawy", $"Kwota do zapłaty: {Parameter.Price} zł"));
            }

            if(Parameter.PayedPrice != order.PayedPrice)
            {
                order.PayedPrice = Parameter.PayedPrice;
                await context.OrderHistories.AddAsync(CreateOrderHistory(order, employee, "Przyjęcie gotówki", $"Przyjęto: {Parameter.PayedPrice} zł "));
            }

            if (Parameter.RepairStatus != order.RepairStatus)
            {
                order.RepairStatus = Parameter.RepairStatus;
                await context.OrderHistories.AddAsync(CreateOrderHistory(order, employee, "Zmiana statusu naprawy", $"Status zmieniony na: {Parameter.RepairStatus}"));
            }

            await context.SaveChangesAsync();
            return order;
        }

        OrderHistory CreateOrderHistory(Order order, Employee employee, string title, string text)
        {
            return new OrderHistory()
            {
                Title = title,
                Description = text,
                Date = DateTime.Now,
                Employee = employee,
                Order = order
            };
        }
    }
}
