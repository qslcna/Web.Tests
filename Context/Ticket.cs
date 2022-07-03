using System;
using System.Collections.Generic;

namespace Pocket.Domain
{
    public abstract class Ticket
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; }

    }
    public abstract class TicketItem
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }

    public class Produce : Ticket
    {
        public virtual List<ProduceItem> Items { get; set; }
    }

    public class ProduceItem : TicketItem { }

    public class Fix : Ticket
    {
        public virtual List<FixItem> Items { get; set; }
    }

    public class FixItem : TicketItem { }
}
