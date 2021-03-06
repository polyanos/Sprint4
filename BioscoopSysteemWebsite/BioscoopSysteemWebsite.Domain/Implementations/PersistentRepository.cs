﻿using BioscoopSysteemWebsite.Domain.Concrete;
using BioscoopSysteemWebsite.Domain.Entities;
using BioscoopSysteemWebsite.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Data.Entity.Infrastructure;

namespace BioscoopSysteemWebsite.Domain.Implementations
{
    [ExcludeFromCodeCoverage]
    public class PersistentRepository : IRepository
    {
        private ApplicationDbContext context = ApplicationDbContext.Create();

        [ExcludeFromCodeCoverage]
        public IEnumerable<Show> GetAllShows()
        {
            return context.Shows;
        }


        public Movie GetByID(int id)
        {
            //Gemaakt door: Frank Molengraaf
            return context.Movies.Where(x => x.MovieId == id).FirstOrDefault();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            //Gemaakt door: Frank Molengraaf
            return context.Movies;
        }

        public Show GetShowByID(int id)
        {
            return context.Shows.Where(x => x.ShowID == id).FirstOrDefault();
        }

        //Gemaakt door: Ricardo Jobse
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders;
            }
        }

        public IEnumerable<Ticket> Tickets
        {
            get
            {
                return context.Tickets;
            }
        }

        public IEnumerable<Room> GetRooms()
        {
            return context.Rooms;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return context.Tickets;
        }

        public TicketSoort GetTicketSoort(int ticketSoortID)
        {
            return context.TicketSoort.Where(r => r.TicketSoortID == ticketSoortID).First();
        }

        //Gemaakt door: Ricardo Jobse & Gregor Hoogstad
        public bool UpdateOrder(Order order)
        {
            Order changedOrder = order;
            bool result;

            if (changedOrder.Paid.Equals(false))
            {
                //Payment will be done.
                //Order will be picked up.
                Order dbEntry = context.Orders.Find(changedOrder.OrderId);
                if (dbEntry != null)
                {
                    dbEntry.Paid = true;
                    dbEntry.PickedUp = true;
                }
                result = true;
            }
            else
            {
                result = false;
            }

            context.SaveChanges();
            return result;
        }

        public void AddTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        //Gemaakt door: Ricardo Jobse
        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders;
        }

        //Gemaakt door: Ricardo Jobse
        public Order GetOrderByID(int orderid)
        {
            return context.Orders.Where(x => x.OrderId == orderid).FirstOrDefault();
        }

        public bool AddMailForNewsletter(Mail mail)
        {
            bool b = false;
            if (mail != null)
            {
                context.Emails.Add(mail);
                b = true;
            }
            context.SaveChanges();

            return b;
        }

        public IEnumerable<Mail> GetAllMails()
        {
            return context.Emails;
        }

        [ExcludeFromCodeCoverage]
        public IEnumerable<TicketSoort> GetTicketSoorten()
        {
            return context.TicketSoort;
        }

        public bool removeMovie(Movie movie)
        {
            bool success;
            context.Movies.Remove(movie);
            try
            {
                success = true;
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                success = false;
            }
            return success;
        }
    }
}
